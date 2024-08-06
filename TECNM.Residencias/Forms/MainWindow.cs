using System;
using System.Windows.Forms;
using TECNM.Residencias.Forms.CareerForms;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Forms
{
    public sealed partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Text = $"Panel de administración | {App.Name}";
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            App.Initialize();
        }

        private void ShowCareers_Click(object sender, EventArgs e)
        {
            FormManagerService.OpenForm<CareerListViewForm>();
        }

        private void ShowCompanies_Click(object sender, EventArgs e)
        {
        }
    }
}
