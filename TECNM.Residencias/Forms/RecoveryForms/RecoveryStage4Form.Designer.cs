namespace TECNM.Residencias.Forms.RecoveryForms;

partial class RecoveryStage4Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoveryStage4Form));
        gb_Status = new System.Windows.Forms.GroupBox();
        lbl_FileCount = new System.Windows.Forms.Label();
        pb_Progress = new System.Windows.Forms.ProgressBar();
        lbl_ProgressStatus = new System.Windows.Forms.Label();
        gb_Status.SuspendLayout();
        SuspendLayout();
        // 
        // gb_Status
        // 
        gb_Status.Controls.Add(lbl_FileCount);
        gb_Status.Controls.Add(pb_Progress);
        gb_Status.Controls.Add(lbl_ProgressStatus);
        gb_Status.Location = new System.Drawing.Point(12, 12);
        gb_Status.Name = "gb_Status";
        gb_Status.Size = new System.Drawing.Size(461, 85);
        gb_Status.TabIndex = 3;
        gb_Status.TabStop = false;
        gb_Status.Text = "Progreso";
        // 
        // lbl_FileCount
        // 
        lbl_FileCount.AutoSize = true;
        lbl_FileCount.Location = new System.Drawing.Point(6, 63);
        lbl_FileCount.Name = "lbl_FileCount";
        lbl_FileCount.Size = new System.Drawing.Size(79, 15);
        lbl_FileCount.TabIndex = 2;
        lbl_FileCount.Text = "[FILE COUNT]";
        // 
        // pb_Progress
        // 
        pb_Progress.Location = new System.Drawing.Point(6, 37);
        pb_Progress.MarqueeAnimationSpeed = 50;
        pb_Progress.Maximum = 0;
        pb_Progress.Name = "pb_Progress";
        pb_Progress.Size = new System.Drawing.Size(449, 23);
        pb_Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        pb_Progress.TabIndex = 1;
        // 
        // lbl_ProgressStatus
        // 
        lbl_ProgressStatus.Location = new System.Drawing.Point(6, 19);
        lbl_ProgressStatus.Name = "lbl_ProgressStatus";
        lbl_ProgressStatus.Size = new System.Drawing.Size(449, 15);
        lbl_ProgressStatus.TabIndex = 0;
        lbl_ProgressStatus.Text = "Sin iniciar";
        // 
        // RecoveryStage4Form
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(484, 108);
        Controls.Add(gb_Status);
        DoubleBuffered = true;
        Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
        Name = "RecoveryStage4Form";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Restaurando sistema | Entorno de recuperación";
        gb_Status.ResumeLayout(false);
        gb_Status.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox gb_Status;
    private System.Windows.Forms.Label lbl_FileCount;
    private System.Windows.Forms.ProgressBar pb_Progress;
    private System.Windows.Forms.Label lbl_ProgressStatus;
}