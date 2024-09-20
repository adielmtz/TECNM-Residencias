namespace TECNM.Residencias.Forms
{
    partial class DialogBackupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBackupForm));
            gb_Config = new System.Windows.Forms.GroupBox();
            btn_StartBackup = new System.Windows.Forms.Button();
            chk_EnableCompression = new System.Windows.Forms.CheckBox();
            tb_BackupLocation = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            btn_Cancel = new System.Windows.Forms.Button();
            gb_Status = new System.Windows.Forms.GroupBox();
            lbl_FileCount = new System.Windows.Forms.Label();
            pb_Progress = new System.Windows.Forms.ProgressBar();
            lbl_ProgressStatus = new System.Windows.Forms.Label();
            chk_OpenBackupFolder = new System.Windows.Forms.CheckBox();
            gb_Config.SuspendLayout();
            gb_Status.SuspendLayout();
            SuspendLayout();
            // 
            // gb_Config
            // 
            gb_Config.Controls.Add(chk_OpenBackupFolder);
            gb_Config.Controls.Add(btn_StartBackup);
            gb_Config.Controls.Add(chk_EnableCompression);
            gb_Config.Controls.Add(tb_BackupLocation);
            gb_Config.Controls.Add(label1);
            gb_Config.Controls.Add(button1);
            gb_Config.Location = new System.Drawing.Point(12, 12);
            gb_Config.Name = "gb_Config";
            gb_Config.Size = new System.Drawing.Size(461, 147);
            gb_Config.TabIndex = 0;
            gb_Config.TabStop = false;
            gb_Config.Text = "Configuración";
            // 
            // btn_StartBackup
            // 
            btn_StartBackup.Enabled = false;
            btn_StartBackup.Location = new System.Drawing.Point(6, 116);
            btn_StartBackup.Name = "btn_StartBackup";
            btn_StartBackup.Size = new System.Drawing.Size(449, 23);
            btn_StartBackup.TabIndex = 4;
            btn_StartBackup.Text = "Iniciar copia de seguridad";
            btn_StartBackup.UseVisualStyleBackColor = true;
            btn_StartBackup.Click += StartBackup_Click;
            // 
            // chk_EnableCompression
            // 
            chk_EnableCompression.AutoSize = true;
            chk_EnableCompression.Checked = true;
            chk_EnableCompression.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_EnableCompression.Location = new System.Drawing.Point(6, 66);
            chk_EnableCompression.Name = "chk_EnableCompression";
            chk_EnableCompression.Size = new System.Drawing.Size(241, 19);
            chk_EnableCompression.TabIndex = 3;
            chk_EnableCompression.Text = "Comprimir archivos para ahorrar espacio";
            chk_EnableCompression.UseVisualStyleBackColor = true;
            // 
            // tb_BackupLocation
            // 
            tb_BackupLocation.Enabled = false;
            tb_BackupLocation.Location = new System.Drawing.Point(87, 37);
            tb_BackupLocation.Name = "tb_BackupLocation";
            tb_BackupLocation.Size = new System.Drawing.Size(368, 23);
            tb_BackupLocation.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(191, 15);
            label1.TabIndex = 1;
            label1.Text = "Ubicación de la copia de seguridad";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(6, 37);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Seleccionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ChoseBackupDestination_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Cancel.Location = new System.Drawing.Point(398, 262);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(75, 23);
            btn_Cancel.TabIndex = 1;
            btn_Cancel.Text = "Cancelar";
            btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // gb_Status
            // 
            gb_Status.Controls.Add(lbl_FileCount);
            gb_Status.Controls.Add(pb_Progress);
            gb_Status.Controls.Add(lbl_ProgressStatus);
            gb_Status.Enabled = false;
            gb_Status.Location = new System.Drawing.Point(12, 165);
            gb_Status.Name = "gb_Status";
            gb_Status.Size = new System.Drawing.Size(461, 85);
            gb_Status.TabIndex = 2;
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
            lbl_ProgressStatus.AutoSize = true;
            lbl_ProgressStatus.Location = new System.Drawing.Point(6, 19);
            lbl_ProgressStatus.Name = "lbl_ProgressStatus";
            lbl_ProgressStatus.Size = new System.Drawing.Size(58, 15);
            lbl_ProgressStatus.TabIndex = 0;
            lbl_ProgressStatus.Text = "Sin iniciar";
            // 
            // chk_OpenBackupFolder
            // 
            chk_OpenBackupFolder.AutoSize = true;
            chk_OpenBackupFolder.Location = new System.Drawing.Point(6, 91);
            chk_OpenBackupFolder.Name = "chk_OpenBackupFolder";
            chk_OpenBackupFolder.Size = new System.Drawing.Size(269, 19);
            chk_OpenBackupFolder.TabIndex = 5;
            chk_OpenBackupFolder.Text = "Abrir carpeta al terminar la copia de seguridad";
            chk_OpenBackupFolder.UseVisualStyleBackColor = true;
            // 
            // DialogBackupForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new System.Drawing.Size(484, 297);
            ControlBox = false;
            Controls.Add(gb_Status);
            Controls.Add(btn_Cancel);
            Controls.Add(gb_Config);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "DialogBackupForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Copia de seguridad";
            gb_Config.ResumeLayout(false);
            gb_Config.PerformLayout();
            gb_Status.ResumeLayout(false);
            gb_Status.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Config;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox tb_BackupLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chk_EnableCompression;
        private System.Windows.Forms.Button btn_StartBackup;
        private System.Windows.Forms.GroupBox gb_Status;
        private System.Windows.Forms.ProgressBar pb_Progress;
        private System.Windows.Forms.Label lbl_ProgressStatus;
        private System.Windows.Forms.Label lbl_FileCount;
        private System.Windows.Forms.CheckBox chk_OpenBackupFolder;
    }
}