namespace TECNM.Residencias.Forms.StudentForms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

public sealed partial class StudentSkillsPickerDialogForm : EditForm
{
    private Dictionary<long, CheckBox> extrasControls = new Dictionary<long, CheckBox>();
    private HashSet<long> _selectedSkills = [];

    public StudentSkillsPickerDialogForm()
    {
        InitializeComponent();
        Text = $"Seleccionar habilidades | {App.Name}";
    }

    internal StudentSkillsPickerDialogForm(ISet<long> extras) : this()
    {
        if (extras is not null)
        {
            _selectedSkills.UnionWith(extras);
        }
    }

    public ISet<long> SelectedSkills => _selectedSkills;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        using var context = new AppDbContext();
        IEnumerable<Skill> extras = context.Skills.EnumerateAll();

        foreach (Skill extra in extras)
        {
            var control = new CheckBox();
            control.AutoSize = true;
            control.Tag = extra;
            control.Text = extra.Value;

            extrasControls[extra.Id] = control;
            switch (extra.Type)
            {
                case SkillType.Database:
                    flp_Databases.Controls.Add(control);
                    break;
                case SkillType.Editor:
                    flp_editors.Controls.Add(control);
                    break;
                case SkillType.Language:
                    flp_Languages.Controls.Add(control);
                    break;
                case SkillType.Methodology:
                    flp_methodologies.Controls.Add(control);
                    break;
            }
        }

        MarkCheckedSkills();
    }

    private void MarkCheckedSkills()
    {
        foreach (long rowid in _selectedSkills)
        {
            extrasControls[rowid].Checked = true;
        }
    }

    private void SaveEdit_Click(object sender, EventArgs e)
    {
        _selectedSkills.Clear();

        foreach (KeyValuePair<long, CheckBox> kvp in extrasControls)
        {
            if (kvp.Value.Checked)
            {
                _selectedSkills.Add(kvp.Key);
            }
        }

        Close();
    }
}
