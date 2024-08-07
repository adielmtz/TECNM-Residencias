using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DataObjects;
using TECNM.Residencias.Extensions;

namespace TECNM.Residencias.Forms.CompanyForms
{
    public sealed partial class CompanyListViewForm : Form
    {
        private readonly int _rowsPerPage = 100;
        private int _currentPage = 1;

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
                ShowEditCompanyDialog(company);
            }
        }

        private void AddNewCompany_Click(object sender, EventArgs e)
        {
            ShowEditCompanyDialog();
        }

        private void SearchQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                Search();
                e.Handled = true;
            }
        }

        private void RunQuerySearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ShowAllRows_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
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

        private void ShowEditCompanyDialog(Company? company = null)
        {
            using var dialog = new CompanyEditForm(company);
            dialog.ShowDialog();
            RefreshList();
        }

        private void RefreshList()
        {
            using var context = new AppDbContext();
            IList<Company> companies = context.Companies.GetCompanies(_rowsPerPage, _currentPage);
            PopulateTable(companies, context);
        }

        private void Search()
        {
            string query = tb_SearchQuery.Text.Trim();
            if (query.Length == 0)
            {
                return;
            }

            using var context = new AppDbContext();
            IList<CompanySearchDto> searchResult = context.Companies.SearchCompany(query);

            var companies = new List<Company>(searchResult.Count);
            foreach (CompanySearchDto result in searchResult)
            {
                Company company = context.Companies.GetCompanyById(result.Id)!;
                companies.Add(company);
            }

            PopulateTable(companies, context);
        }

        private void PopulateTable(IList<Company> companies, AppDbContext context)
        {
            dgv_ListView.Rows.Clear();

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
            }

            dgv_ListView.ClearSelection();
            btn_PagePrev.Enabled = _currentPage > 1;
            btn_PageNext.Enabled = companies.Count == _rowsPerPage;
        }

        private string TranslateCompanyType(CompanyType type)
        {
            switch (type)
            {
                case Data.Entities.CompanyType.Public:
                    return "Pública";
                case Data.Entities.CompanyType.Private:
                    return "Privada";
                case Data.Entities.CompanyType.Industrial:
                    return "Industrial";
                default:
                    throw new UnreachableException();
            }
        }
    }
}
