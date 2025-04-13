namespace TECNM.Residencias.Forms.RecoveryForms;

partial class RecoveryStage1Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoveryStage1Form));
        label1 = new System.Windows.Forms.Label();
        btn_Cancel = new System.Windows.Forms.Button();
        btn_Next = new System.Windows.Forms.Button();
        tb_SelectedFile = new System.Windows.Forms.TextBox();
        button3 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(173, 15);
        label1.TabIndex = 0;
        label1.Text = "Seleccionar archivo de respaldo";
        // 
        // btn_Cancel
        // 
        btn_Cancel.Location = new System.Drawing.Point(268, 56);
        btn_Cancel.Name = "btn_Cancel";
        btn_Cancel.Size = new System.Drawing.Size(75, 23);
        btn_Cancel.TabIndex = 1;
        btn_Cancel.Text = "Cancelar";
        btn_Cancel.UseVisualStyleBackColor = true;
        // 
        // btn_Next
        // 
        btn_Next.Enabled = false;
        btn_Next.Location = new System.Drawing.Point(187, 56);
        btn_Next.Name = "btn_Next";
        btn_Next.Size = new System.Drawing.Size(75, 23);
        btn_Next.TabIndex = 2;
        btn_Next.Text = "Siguiente";
        btn_Next.UseVisualStyleBackColor = true;
        btn_Next.Click += GoNext_Click;
        // 
        // tb_SelectedFile
        // 
        tb_SelectedFile.Enabled = false;
        tb_SelectedFile.Location = new System.Drawing.Point(12, 27);
        tb_SelectedFile.Name = "tb_SelectedFile";
        tb_SelectedFile.Size = new System.Drawing.Size(250, 23);
        tb_SelectedFile.TabIndex = 3;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(268, 27);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(75, 23);
        button3.TabIndex = 4;
        button3.Text = "Seleccionar";
        button3.UseVisualStyleBackColor = true;
        button3.Click += OpenFileDialog_Click;
        // 
        // RecoveryStage1Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(353, 87);
        Controls.Add(button3);
        Controls.Add(tb_SelectedFile);
        Controls.Add(btn_Next);
        Controls.Add(btn_Cancel);
        Controls.Add(label1);
        Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
        Name = "RecoveryStage1Form";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Entorno de recuperación";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btn_Cancel;
    private System.Windows.Forms.Button btn_Next;
    private System.Windows.Forms.TextBox tb_SelectedFile;
    private System.Windows.Forms.Button button3;
}
