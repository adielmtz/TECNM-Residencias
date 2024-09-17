using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Forms.StudentForms
{
    public sealed partial class StudentExtrasPickerDialogForm : Form
    {
        private readonly FormConfirmClosingService closeConfirmService;
        private Dictionary<long, CheckBox> extrasControls = new Dictionary<long, CheckBox>();
        private IList<Extra> selectedExtras = new List<Extra>();
        private Student? _student;

        public StudentExtrasPickerDialogForm()
        {
            InitializeComponent();
            closeConfirmService = new FormConfirmClosingService(this);
            Text = $"Seleccionar extras | {App.Name}";
        }

        internal StudentExtrasPickerDialogForm(Student student) : this()
        {
            _student = student;
        }

        public IList<Extra> SelectedExtras => selectedExtras;

        private void StudentExtrasPickerDialogForm_Load(object sender, EventArgs e)
        {
            using var context = new AppDbContext();
            IEnumerable<Extra> extras = context.Extras.EnumerateExtras();

            foreach (Extra extra in extras)
            {
                var control = new CheckBox();
                control.AutoSize = true;
                control.Tag = extra;
                control.Text = extra.Value;

                extrasControls[extra.Id] = control;

                switch (extra.Type)
                {
                    case ExtraType.Database:
                        flp_Databases.Controls.Add(control);
                        break;
                    case ExtraType.Editor:
                        flp_editors.Controls.Add(control);
                        break;
                    case ExtraType.Language:
                        flp_Languages.Controls.Add(control);
                        break;
                    case ExtraType.Methodology:
                        flp_methodologies.Controls.Add(control);
                        break;
                }
            }

            if (_student != null)
            {
                MarkCheckedExtras(context);
            }
        }

        private void MarkCheckedExtras(AppDbContext context)
        {
            IEnumerable<long> extrasRowIds = context.Extras.EnumerateExtras(_student!);

            foreach (long rowid in extrasRowIds)
            {
                extrasControls[rowid].Checked = true;
            }
        }

        private void SaveEdit_Click(object sender, EventArgs e)
        {
            selectedExtras.Clear();
            foreach (CheckBox control in extrasControls.Values)
            {
                if (control.Checked)
                {
                    Extra extra = (Extra) control.Tag!;
                    selectedExtras.Add(extra);
                }
            }

            Close();
        }
    }
}
