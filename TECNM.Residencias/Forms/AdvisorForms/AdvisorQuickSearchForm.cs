namespace TECNM.Residencias.Forms.AdvisorForms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DTO;

public sealed partial class AdvisorQuickSearchForm : Form
{
    private readonly long _filterCompany;

    public AdvisorQuickSearchForm()
    {
        InitializeComponent();
    }

    public AdvisorQuickSearchForm(long filterCompany) : this()
    {
        _filterCompany = filterCompany;
    }

    public AdvisorSearchResultDto? SelectedAdvisor { get; private set; }

    public long FilterCompany => _filterCompany;

    private void RunSearch_Click(object sender, EventArgs e)
    {
        SearchAdvisors();
    }

    private void SearchQuery_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char) Keys.Enter)
        {
            SearchAdvisors();
            e.Handled = true;
        }
    }

    private void SearchAdvisors()
    {
        string query = tb_SearchQuery.Text.Trim();
        dgv_ListView.Rows.Clear();

        if (query.Length == 0)
        {
            return;
        }

        using var context = new AppDbContext();
        IEnumerable<AdvisorSearchResultDto> searchResults = context.Advisors.Search(query, 50, 1, FilterCompany);

        foreach (AdvisorSearchResultDto advisor in searchResults)
        {
            int index = dgv_ListView.Rows.Add();
            DataGridViewRow row = dgv_ListView.Rows[index];

            row.Tag = advisor;
            row.Cells[0].Value = advisor.ToString();
        }

        dgv_ListView.ClearSelection();
    }

    private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var grid = (DataGridView) sender;
        if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
        {
            SelectedAdvisor = (AdvisorSearchResultDto) grid.Rows[e.RowIndex].Tag!;
            Close();
        }
    }

    private void QuickAddAdvisor_Click(object sender, EventArgs e)
    {
        using var context = new AppDbContext();
        Company company = context.Companies.GetCompany(FilterCompany)!;
        Trace.Assert(company is not null);

        using var dialog = new AdvisorEditForm(company, null);
        dialog.ShowDialog();

        string name = dialog.Advisor.ToString();
        if (!string.IsNullOrEmpty(name))
        {
            tb_SearchQuery.Text = name;
            SearchAdvisors();
        }
    }
}
