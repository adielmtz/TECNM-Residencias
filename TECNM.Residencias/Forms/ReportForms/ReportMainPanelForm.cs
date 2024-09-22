using System;
using System.Windows.Forms;

namespace TECNM.Residencias.Forms.ReportForms
{
    public sealed partial class ReportMainPanelForm : Form
    {
        public ReportMainPanelForm()
        {
            InitializeComponent();
            Text = $"Generación de reportes | {App.Name}";

            DateTime now = DateTime.Now;
            cb_Semester.SelectedIndex = now.Month >= 1 && now.Month < 7 ? 0 : 1;
        }

        private void ReportMainPanelForm_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Today.Year; i >= App.MinimumReportYear; i--)
            {
                cb_Year.Items.Add(i);
            }

            cb_Year.SelectedIndex = 0;
        }
    }
}
