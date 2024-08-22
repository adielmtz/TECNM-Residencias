using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Forms.StudentForms
{
    public sealed partial class StudentEditForm : Form
    {
        public StudentEditForm()
        {
            InitializeComponent();
        }

        public StudentEditForm(Student? entity) : this()
        {
        }

        private void StudentEditForm_Load(object sender, EventArgs e)
        {
            using var context = new AppDbContext();
            IEnumerable<Career> careers = context.Careers.EnumerateCareers(enabled: true);

            foreach (Career career in careers)
            {
                cb_StudentCareer.Items.Add(career);
            }

            cb_StudentSpecialty.Enabled = false;
        }

        private void StudentCareer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Career? career = (Career?) cb_StudentCareer.SelectedItem;
            if (career == null)
            {
                return;
            }

            cb_StudentSpecialty.Enabled = false;
            cb_StudentSpecialty.Items.Clear();
            cb_StudentSpecialty.SelectedIndex = -1;

            using var context = new AppDbContext();
            IEnumerable<Specialty> specialties = context.Specialties.EnumerateSpecialtiesByCareer(career.Id, enabled: true);

            foreach (Specialty specialty in specialties)
            {
                cb_StudentSpecialty.Items.Add(specialty);
            }

            cb_StudentSpecialty.Enabled = cb_StudentSpecialty.Items.Count > 0;
        }
    }
}
