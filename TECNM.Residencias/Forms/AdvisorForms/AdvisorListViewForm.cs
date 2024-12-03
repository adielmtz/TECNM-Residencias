namespace TECNM.Residencias.Forms.AdvisorForms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Extensions;
using TECNM.Residencias.Forms.StudentForms;

public sealed partial class AdvisorListViewForm : Form
{
    private Company _company = new Company();

    public AdvisorListViewForm()
    {
        InitializeComponent();
        dgv_ListView.DoubleBuffered(true);
    }

    public AdvisorListViewForm(Company company) : this()
    {
        Text = $"Listado de asesores | {company.Name} | {App.Name}";
        _company = company;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        RefreshList();
    }

    private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var grid = (DataGridView) sender;
        if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
        {
            var column = grid.Columns[e.ColumnIndex];
            var advisor = (Advisor) grid.Rows[e.RowIndex].Tag!;

            if (column == ListAdvisorActions)
            {
                ShowAdvisorEditDialog(advisor);
            }
            else if (column == ListAdvisorResidents)
            {
                ShowResidentsDialog(advisor);
            }
        }
    }

    private void AddNewAdvisor_Click(object sender, EventArgs e)
    {
        ShowAdvisorEditDialog();
    }

    private void ShowAdvisorEditDialog(Advisor? advisor = null)
    {
        using var dialog = new AdvisorEditForm(_company, advisor);
        dialog.ShowDialog();
        RefreshList();
    }

    private void ShowResidentsDialog(Advisor advisor)
    {
        using var dialog = new StudentListViewByAdvisorForm(advisor);
        dialog.ShowDialog();
        RefreshList();
    }

    private void RefreshList()
    {
        using var context = new AppDbContext();
        IEnumerable<Advisor> advisors = context.Advisors.EnumerateAll(_company);
        PopulateTable(context, advisors);
    }

    private void PopulateTable(AppDbContext context, IEnumerable<Advisor> advisors)
    {
        dgv_ListView.Rows.Clear();
        int count = 0;

        foreach (Advisor advisor in advisors)
        {
            int index = dgv_ListView.Rows.Add();
            DataGridViewRow row = dgv_ListView.Rows[index];

            row.Tag = advisor;
            row.Cells[0].Value = advisor.ToString();
            row.Cells[1].Value = advisor.Section;
            row.Cells[2].Value = advisor.Role;
            row.Cells[3].Value = advisor.Email;
            row.Cells[4].Value = advisor.Phone;
            row.Cells[5].Value = advisor.Extension;
            row.Cells[6].Value = advisor.Enabled;
            row.Cells[7].Value = advisor.UpdatedOn.ToString("g");
            row.Cells[8].Value = advisor.CreatedOn.ToString("g");
            count++;
        }

        dgv_ListView.ClearSelection();
        UpdateStatusLabel();
    }

    private void UpdateStatusLabel()
    {
        lbl_StatusLabel.Text = $"Número de registros: {dgv_ListView.RowCount}";
    }
}
