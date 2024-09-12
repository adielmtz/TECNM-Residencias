using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Forms.AdvisorForms
{
    public sealed partial class AdvisorQuickSearchForm : Form
    {
        public Advisor? SelectedAdvisor { get; private set; }
        public Company? FilterCompany { get; set; }
        public AdvisorType? FilterType { get; set; }

        public AdvisorQuickSearchForm()
        {
            InitializeComponent();
        }

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
            if (query.Length == 0)
            {
                return;
            }

            using var context = new AppDbContext();
            IEnumerable<Advisor> advisors = context.Advisors.Search(query, 50, 1);

            dgv_ListView.Rows.Clear();

            foreach (Advisor advisor in advisors)
            {
                if (FilterCompany != null && advisor.CompanyId != FilterCompany.Id)
                {
                    continue;
                }

                if (FilterType != null && advisor.Type != FilterType)
                {
                    continue;
                }

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
                SelectedAdvisor = (Advisor) grid.Rows[e.RowIndex].Tag!;
                Close();
            }
        }
    }
}
