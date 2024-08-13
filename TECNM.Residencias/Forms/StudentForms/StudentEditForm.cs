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
    }
}
