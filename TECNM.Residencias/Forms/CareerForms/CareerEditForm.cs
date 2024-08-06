using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Forms.CareerForms
{
    public sealed partial class CareerEditForm : Form
    {
        private Career career = new Career();

        public CareerEditForm()
        {
            InitializeComponent();
        }

        public CareerEditForm(Career? entity) : this()
        {
            if (entity != null)
            {
                career = entity;
                tb_CareerName.Text = career.Name;
                chk_CareerEnabled.Checked = career.Enabled;
            }
        }

        private void CareerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                Save();
                e.Handled = true;
            }
        }

        private void SaveEdit_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            career.Name = tb_CareerName.Text;
            career.Enabled = chk_CareerEnabled.Checked;

            using var context = new AppDbContext();
            if (career.Id > 0)
            {
                context.Careers.Update(career);
            }
            else
            {
                try
                {
                    context.Careers.Insert(career);
                }
                catch (SqliteException e)
                {
                    MessageBox.Show(
                        "Ya existe un registro con el mismo nombre.",
                        "Error al guardar la información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    context.Rollback();
                    return;
                }
            }

            context.Commit();
            Close();
        }
    }
}
