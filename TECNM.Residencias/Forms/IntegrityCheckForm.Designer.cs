namespace TECNM.Residencias.Forms
{
    partial class IntegrityCheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntegrityCheckForm));
            btn_Cancel = new System.Windows.Forms.Button();
            chk_VerifyDb = new System.Windows.Forms.CheckBox();
            chk_VerifyFileExist = new System.Windows.Forms.CheckBox();
            chk_VerifyFileIntegrity = new System.Windows.Forms.CheckBox();
            lb_OutputLog = new System.Windows.Forms.ListBox();
            gb_Options = new System.Windows.Forms.GroupBox();
            chk_VerifyFKs = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            gb_Output = new System.Windows.Forms.GroupBox();
            pb_Progress = new System.Windows.Forms.ProgressBar();
            lbl_FileCount = new System.Windows.Forms.Label();
            gb_Options.SuspendLayout();
            gb_Output.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Cancel.Location = new System.Drawing.Point(713, 415);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(75, 23);
            btn_Cancel.TabIndex = 0;
            btn_Cancel.Text = "Cancelar";
            btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // chk_VerifyDb
            // 
            chk_VerifyDb.AutoSize = true;
            chk_VerifyDb.Checked = true;
            chk_VerifyDb.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_VerifyDb.Location = new System.Drawing.Point(12, 22);
            chk_VerifyDb.Name = "chk_VerifyDb";
            chk_VerifyDb.Size = new System.Drawing.Size(177, 19);
            chk_VerifyDb.TabIndex = 1;
            chk_VerifyDb.Text = "Comprobar la base de datos.";
            chk_VerifyDb.UseVisualStyleBackColor = true;
            chk_VerifyDb.CheckedChanged += VerifyDb_CheckedChanged;
            // 
            // chk_VerifyFileExist
            // 
            chk_VerifyFileExist.AutoSize = true;
            chk_VerifyFileExist.Checked = true;
            chk_VerifyFileExist.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_VerifyFileExist.Location = new System.Drawing.Point(12, 47);
            chk_VerifyFileExist.Name = "chk_VerifyFileExist";
            chk_VerifyFileExist.Size = new System.Drawing.Size(155, 19);
            chk_VerifyFileExist.TabIndex = 2;
            chk_VerifyFileExist.Text = "Comprobar los archivos.";
            chk_VerifyFileExist.UseVisualStyleBackColor = true;
            chk_VerifyFileExist.CheckedChanged += VerifyFileExists_CheckedChanged;
            // 
            // chk_VerifyFileIntegrity
            // 
            chk_VerifyFileIntegrity.AutoSize = true;
            chk_VerifyFileIntegrity.Location = new System.Drawing.Point(236, 47);
            chk_VerifyFileIntegrity.Name = "chk_VerifyFileIntegrity";
            chk_VerifyFileIntegrity.Size = new System.Drawing.Size(272, 19);
            chk_VerifyFileIntegrity.TabIndex = 3;
            chk_VerifyFileIntegrity.Text = "Verificar integridad de los archivos (más lento).";
            chk_VerifyFileIntegrity.UseVisualStyleBackColor = true;
            // 
            // lb_OutputLog
            // 
            lb_OutputLog.CausesValidation = false;
            lb_OutputLog.ItemHeight = 15;
            lb_OutputLog.Location = new System.Drawing.Point(6, 22);
            lb_OutputLog.Name = "lb_OutputLog";
            lb_OutputLog.Size = new System.Drawing.Size(764, 259);
            lb_OutputLog.TabIndex = 4;
            // 
            // gb_Options
            // 
            gb_Options.Controls.Add(chk_VerifyFKs);
            gb_Options.Controls.Add(button1);
            gb_Options.Controls.Add(chk_VerifyDb);
            gb_Options.Controls.Add(chk_VerifyFileExist);
            gb_Options.Controls.Add(chk_VerifyFileIntegrity);
            gb_Options.Location = new System.Drawing.Point(12, 12);
            gb_Options.Name = "gb_Options";
            gb_Options.Size = new System.Drawing.Size(776, 85);
            gb_Options.TabIndex = 5;
            gb_Options.TabStop = false;
            gb_Options.Text = "Opciones";
            // 
            // chk_VerifyFKs
            // 
            chk_VerifyFKs.AutoSize = true;
            chk_VerifyFKs.Checked = true;
            chk_VerifyFKs.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_VerifyFKs.Location = new System.Drawing.Point(236, 22);
            chk_VerifyFKs.Name = "chk_VerifyFKs";
            chk_VerifyFKs.Size = new System.Drawing.Size(182, 19);
            chk_VerifyFKs.TabIndex = 9;
            chk_VerifyFKs.Text = "Verificar integridad relacional.";
            chk_VerifyFKs.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(609, 22);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(161, 44);
            button1.TabIndex = 8;
            button1.Text = "Iniciar comprobación";
            button1.UseVisualStyleBackColor = true;
            button1.Click += StartCheck_Click;
            // 
            // gb_Output
            // 
            gb_Output.Controls.Add(lb_OutputLog);
            gb_Output.Location = new System.Drawing.Point(12, 108);
            gb_Output.Name = "gb_Output";
            gb_Output.Size = new System.Drawing.Size(776, 301);
            gb_Output.TabIndex = 7;
            gb_Output.TabStop = false;
            gb_Output.Text = "Salida";
            // 
            // pb_Progress
            // 
            pb_Progress.Location = new System.Drawing.Point(12, 415);
            pb_Progress.Name = "pb_Progress";
            pb_Progress.Size = new System.Drawing.Size(545, 23);
            pb_Progress.Step = 1;
            pb_Progress.TabIndex = 8;
            // 
            // lbl_FileCount
            // 
            lbl_FileCount.AutoSize = true;
            lbl_FileCount.Location = new System.Drawing.Point(563, 419);
            lbl_FileCount.Name = "lbl_FileCount";
            lbl_FileCount.Size = new System.Drawing.Size(79, 15);
            lbl_FileCount.TabIndex = 9;
            lbl_FileCount.Text = "[FILE COUNT]";
            // 
            // IntegrityCheckForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            CancelPromptMessage = "¿Cancelar comprobación de integridad?";
            ClientSize = new System.Drawing.Size(800, 450);
            ControlBox = false;
            Controls.Add(lbl_FileCount);
            Controls.Add(pb_Progress);
            Controls.Add(gb_Output);
            Controls.Add(gb_Options);
            Controls.Add(btn_Cancel);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "IntegrityCheckForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "IntegrityCheckForm";
            gb_Options.ResumeLayout(false);
            gb_Options.PerformLayout();
            gb_Output.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox chk_VerifyDb;
        private System.Windows.Forms.CheckBox chk_VerifyFileExist;
        private System.Windows.Forms.CheckBox chk_VerifyFileIntegrity;
        private System.Windows.Forms.ListBox lb_OutputLog;
        private System.Windows.Forms.GroupBox gb_Options;
        private System.Windows.Forms.GroupBox gb_Output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar pb_Progress;
        private System.Windows.Forms.Label lbl_FileCount;
        private System.Windows.Forms.CheckBox chk_VerifyFKs;
    }
}
