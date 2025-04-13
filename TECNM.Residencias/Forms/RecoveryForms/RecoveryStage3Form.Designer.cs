namespace TECNM.Residencias.Forms.RecoveryForms;

partial class RecoveryStage3Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoveryStage3Form));
        button1 = new System.Windows.Forms.Button();
        btn_Next = new System.Windows.Forms.Button();
        btn_Cancel = new System.Windows.Forms.Button();
        groupBox1 = new System.Windows.Forms.GroupBox();
        label1 = new System.Windows.Forms.Label();
        lbl_DbVersion = new System.Windows.Forms.Label();
        lbl_FileCount = new System.Windows.Forms.Label();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(215, 145);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(75, 23);
        button1.TabIndex = 8;
        button1.Text = "Atrás";
        button1.UseVisualStyleBackColor = true;
        button1.Click += GoBack_Click;
        // 
        // btn_Next
        // 
        btn_Next.Location = new System.Drawing.Point(296, 145);
        btn_Next.Name = "btn_Next";
        btn_Next.Size = new System.Drawing.Size(75, 23);
        btn_Next.TabIndex = 7;
        btn_Next.Text = "Siguiente";
        btn_Next.UseVisualStyleBackColor = true;
        btn_Next.Click += GoNext_Click;
        // 
        // btn_Cancel
        // 
        btn_Cancel.Location = new System.Drawing.Point(377, 145);
        btn_Cancel.Name = "btn_Cancel";
        btn_Cancel.Size = new System.Drawing.Size(75, 23);
        btn_Cancel.TabIndex = 6;
        btn_Cancel.Text = "Cancelar";
        btn_Cancel.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(lbl_DbVersion);
        groupBox1.Controls.Add(lbl_FileCount);
        groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
        groupBox1.Location = new System.Drawing.Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(440, 127);
        groupBox1.TabIndex = 9;
        groupBox1.TabStop = false;
        groupBox1.Text = "Resumen";
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
        label1.Location = new System.Drawing.Point(7, 55);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(376, 67);
        label1.TabIndex = 2;
        label1.Text = resources.GetString("label1.Text");
        // 
        // lbl_DbVersion
        // 
        lbl_DbVersion.AutoSize = true;
        lbl_DbVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
        lbl_DbVersion.Location = new System.Drawing.Point(6, 25);
        lbl_DbVersion.Name = "lbl_DbVersion";
        lbl_DbVersion.Size = new System.Drawing.Size(80, 15);
        lbl_DbVersion.TabIndex = 1;
        lbl_DbVersion.Text = "[DB VERSION]";
        // 
        // lbl_FileCount
        // 
        lbl_FileCount.AutoSize = true;
        lbl_FileCount.Font = new System.Drawing.Font("Segoe UI", 9F);
        lbl_FileCount.Location = new System.Drawing.Point(7, 40);
        lbl_FileCount.Name = "lbl_FileCount";
        lbl_FileCount.Size = new System.Drawing.Size(79, 15);
        lbl_FileCount.TabIndex = 0;
        lbl_FileCount.Text = "[FILE COUNT]";
        // 
        // RecoveryStage3Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(464, 175);
        Controls.Add(groupBox1);
        Controls.Add(button1);
        Controls.Add(btn_Next);
        Controls.Add(btn_Cancel);
        Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
        Name = "RecoveryStage3Form";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Entorno de recuperación";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btn_Next;
    private System.Windows.Forms.Button btn_Cancel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lbl_DbVersion;
    private System.Windows.Forms.Label lbl_FileCount;
    private System.Windows.Forms.Label label1;
}