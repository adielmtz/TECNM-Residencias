namespace TECNM.Residencias.Forms.RecoveryForms;

partial class RecoveryStage2Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoveryStage2Form));
        btn_Next = new System.Windows.Forms.Button();
        btn_Cancel = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        lb_BackupVersion = new System.Windows.Forms.ListBox();
        groupBox1 = new System.Windows.Forms.GroupBox();
        label1 = new System.Windows.Forms.Label();
        pb_UnpackProgress = new System.Windows.Forms.ProgressBar();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // btn_Next
        // 
        btn_Next.Enabled = false;
        btn_Next.Location = new System.Drawing.Point(251, 368);
        btn_Next.Name = "btn_Next";
        btn_Next.Size = new System.Drawing.Size(75, 23);
        btn_Next.TabIndex = 4;
        btn_Next.Text = "Siguiente";
        btn_Next.UseVisualStyleBackColor = true;
        btn_Next.Click += GoNext_Click;
        // 
        // btn_Cancel
        // 
        btn_Cancel.Location = new System.Drawing.Point(332, 368);
        btn_Cancel.Name = "btn_Cancel";
        btn_Cancel.Size = new System.Drawing.Size(75, 23);
        btn_Cancel.TabIndex = 3;
        btn_Cancel.Text = "Cancelar";
        btn_Cancel.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(170, 368);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(75, 23);
        button1.TabIndex = 5;
        button1.Text = "Atrás";
        button1.UseVisualStyleBackColor = true;
        button1.Click += GoBack_Click;
        // 
        // lb_BackupVersion
        // 
        lb_BackupVersion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
        lb_BackupVersion.FormattingEnabled = true;
        lb_BackupVersion.ItemHeight = 20;
        lb_BackupVersion.Location = new System.Drawing.Point(6, 73);
        lb_BackupVersion.Name = "lb_BackupVersion";
        lb_BackupVersion.Size = new System.Drawing.Size(383, 264);
        lb_BackupVersion.TabIndex = 6;
        lb_BackupVersion.SelectedIndexChanged += BackupVersion_SelectedIndexChanged;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(lb_BackupVersion);
        groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
        groupBox1.Location = new System.Drawing.Point(12, 7);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(395, 355);
        groupBox1.TabIndex = 7;
        groupBox1.TabStop = false;
        groupBox1.Text = "Seleccionar versión para restaurar";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
        label1.Location = new System.Drawing.Point(6, 25);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(383, 45);
        label1.TabIndex = 7;
        label1.Text = resources.GetString("label1.Text");
        // 
        // pb_UnpackProgress
        // 
        pb_UnpackProgress.Location = new System.Drawing.Point(12, 368);
        pb_UnpackProgress.Name = "pb_UnpackProgress";
        pb_UnpackProgress.Size = new System.Drawing.Size(152, 23);
        pb_UnpackProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        pb_UnpackProgress.TabIndex = 8;
        // 
        // RecoveryStage2Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(420, 397);
        Controls.Add(pb_UnpackProgress);
        Controls.Add(groupBox1);
        Controls.Add(button1);
        Controls.Add(btn_Next);
        Controls.Add(btn_Cancel);
        Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
        Name = "RecoveryStage2Form";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Entorno de recuperación";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button btn_Next;
    private System.Windows.Forms.Button btn_Cancel;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ListBox lb_BackupVersion;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ProgressBar pb_UnpackProgress;
}