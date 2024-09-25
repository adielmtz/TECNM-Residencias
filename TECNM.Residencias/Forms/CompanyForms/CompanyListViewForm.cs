namespace TECNM.Residencias.Forms.CompanyForms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Extensions;
using TECNM.Residencias.Forms.AdvisorForms;

public sealed partial class CompanyListViewForm : Form
{
    private readonly int _rowsPerPage = App.DefaultRowsPerPage;
    private int _currentPage = App.DefaultInitialPage;
    private bool _refreshFromSearch = false;

    public CompanyListViewForm()
    {
        InitializeComponent();
        Text = $"Listado de empresas | {App.Name}";
        dgv_ListView.DoubleBuffered(true);
    }

    private void CompanyListViewForm_Load(object sender, EventArgs e)
    {
        RefreshList();
    }

    private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var grid = (DataGridView) sender;
        if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
        {
            var company = (Company) grid.Rows[e.RowIndex].Tag!;

            if (e.ColumnIndex == 12)
            {
                ShowCompanyEditDialog(company);
            }
            else if (e.ColumnIndex == 13)
            {
                using var dialog = new AdvisorListViewForm(company);
                dialog.ShowDialog();
            }
        }
    }

    private void AddNewCompany_Click(object sender, EventArgs e)
    {
        ShowCompanyEditDialog();
    }

    private void SearchQuery_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char) Keys.Enter)
        {
            SearchCompanies();
            e.Handled = true;
        }
    }

    private void RunQuerySearch_Click(object sender, EventArgs e)
    {
        SearchCompanies();
    }

    private void ResetSearch_Click(object sender, EventArgs e)
    {
        _currentPage = App.DefaultInitialPage;
        _refreshFromSearch = false;
        RefreshList();
    }

    private void PagePrev_Click(object sender, EventArgs e)
    {
        _currentPage = Math.Max(0, _currentPage - 1);
        RefreshList();
    }

    private void PageNext_Click(object sender, EventArgs e)
    {
        _currentPage++;
        RefreshList();
    }

    private void ShowCompanyEditDialog(Company? company = null)
    {
        using var dialog = new CompanyEditForm(company);
        dialog.ShowDialog();
        RefreshList();
    }

    private void RefreshList()
    {
        if (_refreshFromSearch)
        {
            SearchCompanies();
            return;
        }

        using var context = new AppDbContext();
        IEnumerable<Company> companies = context.Companies.EnumerateCompanies(_rowsPerPage, _currentPage);
        PopulateTable(context, companies);
    }

    private void SearchCompanies()
    {
        string query = tb_SearchQuery.Text.Trim();
        if (query.Length == 0)
        {
            return;
        }

        _refreshFromSearch = true;
        using var context = new AppDbContext();
        IEnumerable<Company> companies = context.Companies.Search(query, _rowsPerPage, _currentPage);
        PopulateTable(context, companies);
    }

    private void PopulateTable(AppDbContext context, IEnumerable<Company> companies)
    {
        dgv_ListView.Rows.Clear();
        int count = 0;

        foreach (Company company in companies)
        {
            int index = dgv_ListView.Rows.Add();
            DataGridViewRow row = dgv_ListView.Rows[index];

            City city = context.Cities.GetCityById(company.CityId);
            State state = context.States.GetStateById(city.StateId);
            Country country = context.Countries.GetCountryById(state.CountryId);

            row.Tag = company;
            row.Cells[0].Value = company.Name;
            row.Cells[1].Value = company.Rfc;
            row.Cells[2].Value = TranslateCompanyType(company.Type);
            row.Cells[3].Value = company.Email;
            row.Cells[4].Value = company.Phone;
            row.Cells[5].Value = company.Address;
            row.Cells[6].Value = company.Locality;
            row.Cells[7].Value = company.PostalCode;
            row.Cells[8].Value = $"{city}, {state}, {country}";
            row.Cells[9].Value = company.Enabled;
            row.Cells[10].Value = company.UpdatedOn;
            row.Cells[11].Value = company.CreatedOn;
            count++;
        }

        dgv_ListView.ClearSelection();
        btn_PagePrev.Enabled = _currentPage > 1;
        btn_PageNext.Enabled = count == _rowsPerPage;
        UpdateStatusLabel();
    }

    private string TranslateCompanyType(CompanyType type)
    {
        switch (type)
        {
            case CompanyType.Public:
                return "Pública";
            case CompanyType.Private:
                return "Privada";
            case CompanyType.Industrial:
                return "Industrial";
            default:
                throw new UnreachableException();
        }
    }

    private void UpdateStatusLabel()
    {
        lbl_StatusLabel.Text = $"Página {_currentPage}    Número de registros: {dgv_ListView.RowCount}";
    }
}
