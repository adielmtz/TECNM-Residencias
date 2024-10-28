namespace TECNM.Residencias.Controls;

using System;
using System.Drawing;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Forms.StudentForms;

public sealed partial class StudentListItemViewControl : UserControl
{
    private readonly Label lbl_StudentName;
    private long _studentId;

    public StudentListItemViewControl()
    {
        InitializeComponent();

        lbl_StudentName = new CustomLabel();
        lbl_StudentName.AutoSize = true;
        lbl_StudentName.Enabled = false;
        lbl_StudentName.Font = new Font("Segoe UI", 10F);
        lbl_StudentName.ForeColor = Color.Black;
        lbl_StudentName.Location = new Point(13, 10);
        lbl_StudentName.Name = "lbl_StudentName";
        lbl_StudentName.Size = new Size(45, 19);
        lbl_StudentName.TabIndex = 0;
        Controls.Add(lbl_StudentName);
    }

    public StudentListItemViewControl(long id, string label) : this()
    {
        _studentId = id;
        lbl_StudentName.Text = label;
    }

    private void StudentListItemViewControl_DoubleClick(object sender, EventArgs e)
    {
        Student? student;
        using (var context = new AppDbContext())
        {
            student = context.Students.GetStudent(_studentId);
        }

        if (student == null)
        {
            MessageBox.Show("Este registro no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new StudentEditForm(student);
        dialog.ShowDialog();
    }

    private void StudentListItemViewControl_MouseEnter(object sender, EventArgs e)
    {
        BackColor = SystemColors.ControlDark;
    }

    private void StudentListItemViewControl_MouseLeave(object sender, EventArgs e)
    {
        BackColor = SystemColors.Control;
    }

    private class CustomLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Enabled)
            {
                base.OnPaint(e);
                return;
            }

            using var brush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(Text, Font, brush, new PointF(0, 0));
        }
    }
}
