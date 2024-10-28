namespace TECNM.Residencias.Forms.CompanyForms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities.DTO;

public sealed partial class CompanyQuickSearchForm : Form
{
    public CompanySearchResultDto? SelectedCompany { get; private set; }

    public CompanyQuickSearchForm()
    {
        InitializeComponent();
    }

    private void RunSearch_Click(object sender, EventArgs e)
    {
        SearchCompanies();
    }

    private void SearchQuery_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char) Keys.Enter)
        {
            SearchCompanies();
            e.Handled = true;
        }
    }

    private void SearchCompanies()
    {
        string query = tb_SearchQuery.Text.Trim();
        dgv_ListView.Rows.Clear();

        if (query.Length == 0)
        {
            return;
        }

        using var context = new AppDbContext();
        IEnumerable<CompanySearchResultDto> companies = context.Companies.Search(query, 50, 1);

        foreach (CompanySearchResultDto company in companies)
        {
            int index = dgv_ListView.Rows.Add();
            DataGridViewRow row = dgv_ListView.Rows[index];

            row.Tag = company;
            row.Cells[0].Value = company.Rfc;
            row.Cells[1].Value = company.Name;
        }

        dgv_ListView.ClearSelection();
    }

    private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var grid = (DataGridView) sender;
        if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
        {
            SelectedCompany = (CompanySearchResultDto) grid.Rows[e.RowIndex].Tag!;
            Close();
        }
    }

    private void QuickAddCompany_Click(object sender, EventArgs e)
    {
        using var dialog = new CompanyEditForm();
        dialog.ShowDialog();
        tb_SearchQuery.Text = dialog.Company.Name;
        SearchCompanies();
    }
}
