namespace TECNM.Residencias.Forms.CareerForms
{
    partial class CareerEditForm
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
            label1 = new System.Windows.Forms.Label();
            tb_CareerName = new System.Windows.Forms.TextBox();
            chk_CareerEnabled = new System.Windows.Forms.CheckBox();
            btn_SaveEdit = new System.Windows.Forms.Button();
            btn_CancelEdit = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la carrera";
            // 
            // tb_CareerName
            // 
            tb_CareerName.Location = new System.Drawing.Point(12, 27);
            tb_CareerName.Name = "tb_CareerName";
            tb_CareerName.Size = new System.Drawing.Size(272, 23);
            tb_CareerName.TabIndex = 1;
            tb_CareerName.KeyPress += CareerName_KeyPress;
            // 
            // chk_CareerEnabled
            // 
            chk_CareerEnabled.AutoSize = true;
            chk_CareerEnabled.Checked = true;
            chk_CareerEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_CareerEnabled.Location = new System.Drawing.Point(12, 56);
            chk_CareerEnabled.Name = "chk_CareerEnabled";
            chk_CareerEnabled.Size = new System.Drawing.Size(71, 19);
            chk_CareerEnabled.TabIndex = 2;
            chk_CareerEnabled.Text = "Habilitar";
            chk_CareerEnabled.UseVisualStyleBackColor = true;
            // 
            // btn_SaveEdit
            // 
            btn_SaveEdit.Location = new System.Drawing.Point(12, 81);
            btn_SaveEdit.Name = "btn_SaveEdit";
            btn_SaveEdit.Size = new System.Drawing.Size(128, 23);
            btn_SaveEdit.TabIndex = 3;
            btn_SaveEdit.Text = "Guardar";
            btn_SaveEdit.UseVisualStyleBackColor = true;
            btn_SaveEdit.Click += SaveEdit_Click;
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Location = new System.Drawing.Point(156, 81);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(128, 23);
            btn_CancelEdit.TabIndex = 4;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // CareerEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(296, 113);
            ControlBox = false;
            Controls.Add(btn_CancelEdit);
            Controls.Add(btn_SaveEdit);
            Controls.Add(chk_CareerEnabled);
            Controls.Add(tb_CareerName);
            Controls.Add(label1);
            Name = "CareerEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_CareerName;
        private System.Windows.Forms.CheckBox chk_CareerEnabled;
        private System.Windows.Forms.Button btn_SaveEdit;
        private System.Windows.Forms.Button btn_CancelEdit;
    }
}
