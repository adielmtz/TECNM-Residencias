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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvisorEditForm));
            btn_CancelEdit = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            tb_AdvisorFirstName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tb_AdvisorSection = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tb_AdvisorRole = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tb_AdvisorEmail = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            chk_AdvisorEnabled = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            tb_AdvisorLastName = new System.Windows.Forms.TextBox();
            mtb_AdvisorPhone = new System.Windows.Forms.MaskedTextBox();
            label9 = new System.Windows.Forms.Label();
            tb_AdvisorExtension = new System.Windows.Forms.TextBox();
            btn_ChooseCompany = new System.Windows.Forms.Button();
            tb_AdvisorCompany = new System.Windows.Forms.TextBox();
            chk_AdvisorInternal = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_CancelEdit.Location = new System.Drawing.Point(298, 302);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(100, 23);
            btn_CancelEdit.TabIndex = 10;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre*";
            // 
            // tb_AdvisorFirstName
            // 
            tb_AdvisorFirstName.Location = new System.Drawing.Point(12, 27);
            tb_AdvisorFirstName.Name = "tb_AdvisorFirstName";
            tb_AdvisorFirstName.Size = new System.Drawing.Size(190, 23);
            tb_AdvisorFirstName.TabIndex = 1;
            tb_AdvisorFirstName.KeyPress += QuickSave_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 97);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 15);
            label3.TabIndex = 0;
            label3.Text = "Departamento";
            // 
            // tb_AdvisorSection
            // 
            tb_AdvisorSection.Location = new System.Drawing.Point(12, 115);
            tb_AdvisorSection.Name = "tb_AdvisorSection";
            tb_AdvisorSection.Size = new System.Drawing.Size(386, 23);
            tb_AdvisorSection.TabIndex = 3;
            tb_AdvisorSection.KeyPress += QuickSave_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 141);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 0;
            label4.Text = "Puesto";
            // 
            // tb_AdvisorRole
            // 
            tb_AdvisorRole.Location = new System.Drawing.Point(12, 159);
            tb_AdvisorRole.Name = "tb_AdvisorRole";
            tb_AdvisorRole.Size = new System.Drawing.Size(386, 23);
            tb_AdvisorRole.TabIndex = 4;
            tb_AdvisorRole.KeyPress += QuickSave_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 185);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 15);
            label5.TabIndex = 0;
            label5.Text = "Correo";
            // 
            // tb_AdvisorEmail
            // 
            tb_AdvisorEmail.Location = new System.Drawing.Point(12, 203);
            tb_AdvisorEmail.Name = "tb_AdvisorEmail";
            tb_AdvisorEmail.Size = new System.Drawing.Size(386, 23);
            tb_AdvisorEmail.TabIndex = 5;
            tb_AdvisorEmail.KeyPress += QuickSave_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 229);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 15);
            label6.TabIndex = 0;
            label6.Text = "Teléfono";
            // 
            // chk_AdvisorEnabled
            // 
            chk_AdvisorEnabled.AutoSize = true;
            chk_AdvisorEnabled.Checked = true;
            chk_AdvisorEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_AdvisorEnabled.Location = new System.Drawing.Point(98, 276);
            chk_AdvisorEnabled.Name = "chk_AdvisorEnabled";
            chk_AdvisorEnabled.Size = new System.Drawing.Size(71, 19);
            chk_AdvisorEnabled.TabIndex = 8;
            chk_AdvisorEnabled.Text = "Habilitar";
            chk_AdvisorEnabled.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(12, 302);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(100, 23);
            button1.TabIndex = 9;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveEdit_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 53);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 15);
            label7.TabIndex = 0;
            label7.Text = "Empresa*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(208, 9);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(61, 15);
            label8.TabIndex = 0;
            label8.Text = "Apellidos*";
            // 
            // tb_AdvisorLastName
            // 
            tb_AdvisorLastName.Location = new System.Drawing.Point(208, 27);
            tb_AdvisorLastName.Name = "tb_AdvisorLastName";
            tb_AdvisorLastName.Size = new System.Drawing.Size(190, 23);
            tb_AdvisorLastName.TabIndex = 2;
            tb_AdvisorLastName.KeyPress += QuickSave_KeyPress;
            // 
            // mtb_AdvisorPhone
            // 
            mtb_AdvisorPhone.Location = new System.Drawing.Point(12, 247);
            mtb_AdvisorPhone.Mask = "000-000-0000";
            mtb_AdvisorPhone.Name = "mtb_AdvisorPhone";
            mtb_AdvisorPhone.Size = new System.Drawing.Size(80, 23);
            mtb_AdvisorPhone.TabIndex = 6;
            mtb_AdvisorPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            mtb_AdvisorPhone.KeyPress += QuickSave_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(98, 229);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(58, 15);
            label9.TabIndex = 0;
            label9.Text = "Extensión";
            // 
            // tb_AdvisorExtension
            // 
            tb_AdvisorExtension.Location = new System.Drawing.Point(98, 247);
            tb_AdvisorExtension.Name = "tb_AdvisorExtension";
            tb_AdvisorExtension.Size = new System.Drawing.Size(80, 23);
            tb_AdvisorExtension.TabIndex = 0;
            tb_AdvisorExtension.TabStop = false;
            tb_AdvisorExtension.KeyPress += QuickSave_KeyPress;
            // 
            // btn_ChooseCompany
            // 
            btn_ChooseCompany.Location = new System.Drawing.Point(12, 71);
            btn_ChooseCompany.Name = "btn_ChooseCompany";
            btn_ChooseCompany.Size = new System.Drawing.Size(83, 23);
            btn_ChooseCompany.TabIndex = 0;
            btn_ChooseCompany.TabStop = false;
            btn_ChooseCompany.Text = "Seleccionar";
            btn_ChooseCompany.UseVisualStyleBackColor = true;
            btn_ChooseCompany.Click += ChooseCompany_Click;
            // 
            // tb_AdvisorCompany
            // 
            tb_AdvisorCompany.Enabled = false;
            tb_AdvisorCompany.Location = new System.Drawing.Point(100, 71);
            tb_AdvisorCompany.Name = "tb_AdvisorCompany";
            tb_AdvisorCompany.Size = new System.Drawing.Size(298, 23);
            tb_AdvisorCompany.TabIndex = 0;
            tb_AdvisorCompany.TabStop = false;
            // 
            // chk_AdvisorInternal
            // 
            chk_AdvisorInternal.AutoSize = true;
            chk_AdvisorInternal.Location = new System.Drawing.Point(12, 276);
            chk_AdvisorInternal.Name = "chk_AdvisorInternal";
            chk_AdvisorInternal.Size = new System.Drawing.Size(64, 19);
            chk_AdvisorInternal.TabIndex = 7;
            chk_AdvisorInternal.Text = "Interno";
            chk_AdvisorInternal.UseVisualStyleBackColor = true;
            // 
            // AdvisorEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(410, 337);
            ControlBox = false;
            Controls.Add(chk_AdvisorInternal);
            Controls.Add(tb_AdvisorCompany);
            Controls.Add(btn_ChooseCompany);
            Controls.Add(tb_AdvisorExtension);
            Controls.Add(label9);
            Controls.Add(mtb_AdvisorPhone);
            Controls.Add(tb_AdvisorLastName);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(chk_AdvisorEnabled);
            Controls.Add(label6);
            Controls.Add(tb_AdvisorEmail);
            Controls.Add(label5);
            Controls.Add(tb_AdvisorRole);
            Controls.Add(label4);
            Controls.Add(tb_AdvisorSection);
            Controls.Add(label3);
            Controls.Add(tb_AdvisorFirstName);
            Controls.Add(label2);
            Controls.Add(btn_CancelEdit);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "AdvisorEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_CancelEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_AdvisorFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AdvisorSection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_AdvisorRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_AdvisorEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_AdvisorEnabled;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_AdvisorLastName;
        private System.Windows.Forms.MaskedTextBox mtb_AdvisorPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_AdvisorExtension;
        private System.Windows.Forms.Button btn_ChooseCompany;
        private System.Windows.Forms.TextBox tb_AdvisorCompany;
        private System.Windows.Forms.CheckBox chk_AdvisorInternal;
    }
}
