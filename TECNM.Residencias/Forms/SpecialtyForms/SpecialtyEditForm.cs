namespace TECNM.Residencias.Forms.SpecialtyForms;

using System;
using System.Diagnostics;
using System.Windows.Forms;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;

public sealed partial class SpecialtyEditForm : EditForm
{
    private readonly AbstractValidator<Specialty> _validator = new SpecialtyValidator();
    private Career _career = new Career();
    private Specialty _specialty = new Specialty();

    public SpecialtyEditForm()
    {
        InitializeComponent();
    }

    public SpecialtyEditForm(Career career, Specialty? entity) : this()
    {
        _career = career;

        if (entity != null)
        {
            _specialty = entity;
            tb_SpecialtyName.Text = entity.Name;
            chk_SpecialtyEnabled.Checked = entity.Enabled;
        }
    }

    private void SpecialtyEditForm_Load(object sender, EventArgs e)
    {
        cb_SpecialtyCareer.Items.Add(_career);
        cb_SpecialtyCareer.SelectedIndex = 0;
        cb_SpecialtyCareer.Enabled = false;
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
        _specialty.CareerId = _career.Id;
        _specialty.Name = tb_SpecialtyName.Text.Trim();
        _specialty.Enabled = chk_SpecialtyEnabled.Checked;

        ValidationResult result = _validator.Validate(_specialty);

        if (!result.IsValid)
        {
            Debug.Assert(result.Errors.Count > 0);
            MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var context = new AppDbContext();
        if (_specialty.Id > 0)
        {
            context.Specialties.Update(_specialty);
        }
        else
        {
            try
            {
                context.Specialties.Add(_specialty);
            }
            catch (SqliteException)
            {
                MessageBox.Show(
                    "Ya existe un registro con el mismo nombre.",
                    "Error al guardar la información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                context.RejectChanges();
                return;
            }
        }

        context.SaveChanges();
        Close();
    }
}
