using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Forms.CompanyForms
{
    public sealed partial class CompanyListViewForm : Form
    {
        public CompanyListViewForm()
        {
            InitializeComponent();
            Text = $"Listado de empresas | {App.Name}";
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

                if (e.ColumnIndex == 10)
                {
                    ShowEditCompanyDialog(company);
                }
            }
        }

        private void AddNewCompany_Click(object sender, EventArgs e)
        {
            ShowEditCompanyDialog();
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
            IList<Company> companies = context.Companies.GetCompanies();

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
                row.Cells[3].Value = company.Address;
                row.Cells[4].Value = company.Locality;
                row.Cells[5].Value = company.PostalCode;
                row.Cells[6].Value = $"{city}, {state}, {country}";
                row.Cells[7].Value = company.Enabled;
                row.Cells[8].Value = company.UpdatedOn;
                row.Cells[9].Value = company.CreatedOn;
            }
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
