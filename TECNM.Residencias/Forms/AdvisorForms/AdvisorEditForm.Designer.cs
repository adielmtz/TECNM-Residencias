namespace TECNM.Residencias.Forms.AdvisorForms
{
    partial class AdvisorEditForm
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
            btn_CancelEdit = new System.Windows.Forms.Button();
            cb_AdvisorType = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tb_AdvisorName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tb_AdvisorSection = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tb_AdvisorRole = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tb_AdvisorEmail = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            tb_AdvisorPhone = new System.Windows.Forms.TextBox();
            chk_AdvisorEnabled = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            cb_AdvisorCompany = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_CancelEdit.Location = new System.Drawing.Point(298, 302);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(100, 23);
            btn_CancelEdit.TabIndex = 0;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // cb_AdvisorType
            // 
            cb_AdvisorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_AdvisorType.FormattingEnabled = true;
            cb_AdvisorType.Items.AddRange(new object[] { "Interno", "Externo" });
            cb_AdvisorType.Location = new System.Drawing.Point(12, 27);
            cb_AdvisorType.Name = "cb_AdvisorType";
            cb_AdvisorType.Size = new System.Drawing.Size(100, 23);
            cb_AdvisorType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(30, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(118, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // tb_AdvisorName
            // 
            tb_AdvisorName.Location = new System.Drawing.Point(118, 27);
            tb_AdvisorName.Name = "tb_AdvisorName";
            tb_AdvisorName.Size = new System.Drawing.Size(280, 23);
            tb_AdvisorName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 97);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 15);
            label3.TabIndex = 5;
            label3.Text = "Departamento";
            // 
            // tb_AdvisorSection
            // 
            tb_AdvisorSection.Location = new System.Drawing.Point(12, 115);
            tb_AdvisorSection.Name = "tb_AdvisorSection";
            tb_AdvisorSection.Size = new System.Drawing.Size(386, 23);
            tb_AdvisorSection.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 141);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 7;
            label4.Text = "Puesto";
            // 
            // tb_AdvisorRole
            // 
            tb_AdvisorRole.Location = new System.Drawing.Point(12, 159);
            tb_AdvisorRole.Name = "tb_AdvisorRole";
            tb_AdvisorRole.Size = new System.Drawing.Size(386, 23);
            tb_AdvisorRole.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 185);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 15);
            label5.TabIndex = 9;
            label5.Text = "Correo";
            // 
            // tb_AdvisorEmail
            // 
            tb_AdvisorEmail.Location = new System.Drawing.Point(12, 203);
            tb_AdvisorEmail.Name = "tb_AdvisorEmail";
            tb_AdvisorEmail.Size = new System.Drawing.Size(386, 23);
            tb_AdvisorEmail.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 229);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 15);
            label6.TabIndex = 11;
            label6.Text = "Teléfono";
            // 
            // tb_AdvisorPhone
            // 
            tb_AdvisorPhone.Location = new System.Drawing.Point(12, 247);
            tb_AdvisorPhone.Name = "tb_AdvisorPhone";
            tb_AdvisorPhone.Size = new System.Drawing.Size(386, 23);
            tb_AdvisorPhone.TabIndex = 12;
            // 
            // chk_AdvisorEnabled
            // 
            chk_AdvisorEnabled.AutoSize = true;
            chk_AdvisorEnabled.Checked = true;
            chk_AdvisorEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_AdvisorEnabled.Location = new System.Drawing.Point(12, 276);
            chk_AdvisorEnabled.Name = "chk_AdvisorEnabled";
            chk_AdvisorEnabled.Size = new System.Drawing.Size(71, 19);
            chk_AdvisorEnabled.TabIndex = 13;
            chk_AdvisorEnabled.Text = "Habilitar";
            chk_AdvisorEnabled.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(12, 302);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(100, 23);
            button1.TabIndex = 14;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveEdit_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 53);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(52, 15);
            label7.TabIndex = 15;
            label7.Text = "Empresa";
            // 
            // cb_AdvisorCompany
            // 
            cb_AdvisorCompany.FormattingEnabled = true;
            cb_AdvisorCompany.Location = new System.Drawing.Point(12, 71);
            cb_AdvisorCompany.Name = "cb_AdvisorCompany";
            cb_AdvisorCompany.Size = new System.Drawing.Size(386, 23);
            cb_AdvisorCompany.TabIndex = 16;
            // 
            // AdvisorEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(410, 337);
            ControlBox = false;
            Controls.Add(cb_AdvisorCompany);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(chk_AdvisorEnabled);
            Controls.Add(tb_AdvisorPhone);
            Controls.Add(label6);
            Controls.Add(tb_AdvisorEmail);
            Controls.Add(label5);
            Controls.Add(tb_AdvisorRole);
            Controls.Add(label4);
            Controls.Add(tb_AdvisorSection);
            Controls.Add(label3);
            Controls.Add(tb_AdvisorName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cb_AdvisorType);
            Controls.Add(btn_CancelEdit);
            Name = "AdvisorEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            Load += AdvisorEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_CancelEdit;
        private System.Windows.Forms.ComboBox cb_AdvisorType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_AdvisorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AdvisorSection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_AdvisorRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_AdvisorEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_AdvisorPhone;
        private System.Windows.Forms.CheckBox chk_AdvisorEnabled;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_AdvisorCompany;
    }
}