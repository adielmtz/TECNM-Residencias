namespace TECNM.Residencias.Forms.StudentForms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

public sealed partial class StudentExtrasPickerDialogForm : EditForm
{
    private Dictionary<long, CheckBox> extrasControls = new Dictionary<long, CheckBox>();
    private HashSet<Extra> selectedExtras = [];
    private Student? _student;

    public StudentExtrasPickerDialogForm()
    {
        InitializeComponent();
        Text = $"Seleccionar extras | {App.Name}";
    }

    internal StudentExtrasPickerDialogForm(Student student, ISet<Extra>? extras) : this()
    {
        _student = student;

        if (extras is not null)
        {
            selectedExtras.UnionWith(extras);
        }
    }

    public ISet<Extra> SelectedExtras => selectedExtras;

    private void StudentExtrasPickerDialogForm_Load(object sender, EventArgs e)
    {
        using var context = new AppDbContext();
        IEnumerable<Extra> extras = context.Extras.EnumerateAll();

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
        IEnumerable<Extra> extras = context.Extras.EnumerateAll(_student!);
        selectedExtras.Clear();

        foreach (Extra extra in extras)
        {
            extrasControls[extra.Id].Checked = true;
            selectedExtras.Add(extra);
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
