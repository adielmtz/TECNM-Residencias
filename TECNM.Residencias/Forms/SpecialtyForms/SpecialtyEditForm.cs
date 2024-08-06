using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Forms.SpecialtyForms
{
    public sealed partial class SpecialtyEditForm : Form
    {
        private Specialty _specialty = new Specialty();

        public SpecialtyEditForm()
        {
            InitializeComponent();
        }

        public SpecialtyEditForm(Specialty? entity) : this()
        {
            if (entity != null)
            {
                _specialty = entity;
                tb_SpecialtyName.Text = entity.Name;
                chk_SpecialtyEnabled.Checked = entity.Enabled;
            }
        }

        private void SpecialtyEditForm_Load(object sender, EventArgs e)
        {
            using var context = new AppDbContext();
            IList<Career> careers = context.Careers.GetCareers(enabled: true);

            foreach (Career career in careers)
            {
                int index = cb_SpecialtyCareer.Items.Add(career);
                if (career.Id == _specialty.CareerId)
                {
                    cb_SpecialtyCareer.SelectedIndex = index;
                }
            }
        }

        private void SpecialtyName_KeyPress(object sender, KeyPressEventArgs e)
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
            Career career = (Career) cb_SpecialtyCareer.SelectedItem!;
            _specialty.CareerId = career.Id;
            _specialty.Name = tb_SpecialtyName.Text;
            _specialty.Enabled = chk_SpecialtyEnabled.Checked;

            using var context = new AppDbContext();
            if (_specialty.Id > 0)
            {
                context.Specialties.Update(_specialty);
            }
            else
            {
                try
                {
                    context.Specialties.Insert(_specialty);
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
