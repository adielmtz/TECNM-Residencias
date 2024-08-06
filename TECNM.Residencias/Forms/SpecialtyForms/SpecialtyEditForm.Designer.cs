namespace TECNM.Residencias.Forms.SpecialtyForms
{
    partial class SpecialtyEditForm
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
            cb_SpecialtyCareer = new System.Windows.Forms.ComboBox();
            btn_CancelEdit = new System.Windows.Forms.Button();
            btn_SaveEdit = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            tb_SpecialtyName = new System.Windows.Forms.TextBox();
            chk_SpecialtyEnabled = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Carrera";
            // 
            // cb_SpecialtyCareer
            // 
            cb_SpecialtyCareer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cb_SpecialtyCareer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cb_SpecialtyCareer.FormattingEnabled = true;
            cb_SpecialtyCareer.Location = new System.Drawing.Point(12, 27);
            cb_SpecialtyCareer.Name = "cb_SpecialtyCareer";
            cb_SpecialtyCareer.Size = new System.Drawing.Size(272, 23);
            cb_SpecialtyCareer.TabIndex = 0;
            cb_SpecialtyCareer.TabStop = false;
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Location = new System.Drawing.Point(156, 125);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(128, 23);
            btn_CancelEdit.TabIndex = 4;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // btn_SaveEdit
            // 
            btn_SaveEdit.Location = new System.Drawing.Point(12, 125);
            btn_SaveEdit.Name = "btn_SaveEdit";
            btn_SaveEdit.Size = new System.Drawing.Size(128, 23);
            btn_SaveEdit.TabIndex = 3;
            btn_SaveEdit.Text = "Guardar";
            btn_SaveEdit.UseVisualStyleBackColor = true;
            btn_SaveEdit.Click += SaveEdit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 53);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(147, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre de la especialidad";
            // 
            // tb_SpecialtyName
            // 
            tb_SpecialtyName.Location = new System.Drawing.Point(12, 71);
            tb_SpecialtyName.Name = "tb_SpecialtyName";
            tb_SpecialtyName.Size = new System.Drawing.Size(272, 23);
            tb_SpecialtyName.TabIndex = 1;
            tb_SpecialtyName.KeyPress += SpecialtyName_KeyPress;
            // 
            // chk_SpecialtyEnabled
            // 
            chk_SpecialtyEnabled.AutoSize = true;
            chk_SpecialtyEnabled.Checked = true;
            chk_SpecialtyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_SpecialtyEnabled.Location = new System.Drawing.Point(12, 100);
            chk_SpecialtyEnabled.Name = "chk_SpecialtyEnabled";
            chk_SpecialtyEnabled.Size = new System.Drawing.Size(71, 19);
            chk_SpecialtyEnabled.TabIndex = 2;
            chk_SpecialtyEnabled.Text = "Habilitar";
            chk_SpecialtyEnabled.UseVisualStyleBackColor = true;
            // 
            // SpecialtyEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(296, 157);
            ControlBox = false;
            Controls.Add(chk_SpecialtyEnabled);
            Controls.Add(tb_SpecialtyName);
            Controls.Add(label2);
            Controls.Add(btn_SaveEdit);
            Controls.Add(btn_CancelEdit);
            Controls.Add(cb_SpecialtyCareer);
            Controls.Add(label1);
            Name = "SpecialtyEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            Load += SpecialtyEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_SpecialtyCareer;
        private System.Windows.Forms.Button btn_CancelEdit;
        private System.Windows.Forms.Button btn_SaveEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_SpecialtyName;
        private System.Windows.Forms.CheckBox chk_SpecialtyEnabled;
    }
}
