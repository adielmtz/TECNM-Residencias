using FluentValidation;
using FluentValidation.Results;
using Microsoft.Data.Sqlite;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;

namespace TECNM.Residencias.Forms.CareerForms
{
    public sealed partial class CareerEditForm : Form
    {
        private readonly AbstractValidator<Career> _validator = new CareerValidator();
        private Career _career = new Career();

        public CareerEditForm()
        {
            InitializeComponent();
        }

        public CareerEditForm(Career? entity) : this()
        {
            if (entity != null)
            {
                _career = entity;
                tb_CareerName.Text = _career.Name;
                chk_CareerEnabled.Checked = _career.Enabled;
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
            _career.Name = tb_CareerName.Text;
            _career.Enabled = chk_CareerEnabled.Checked;

            ValidationResult result = _validator.Validate(_career);

            if (!result.IsValid)
            {
                Debug.Assert(result.Errors.Count == 1);
                MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var context = new AppDbContext();
            if (_career.Id > 0)
            {
                context.Careers.Update(_career);
            }
            else
            {
                try
                {
                    context.Careers.Insert(_career);
                }
                catch (SqliteException)
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
