namespace TECNM.Residencias.Forms.CompanyForms
{
    partial class CompanyEditForm
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
            cb_CompanyCountry = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cb_CompanyState = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cb_CompanyCity = new System.Windows.Forms.ComboBox();
            btn_CancelEdit = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            cb_CompanyType = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            tb_CompanyRfc = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            tb_CompanyName = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            tb_CompanyAddress = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            tb_CompanyLocality = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            tb_CompanyPostalCode = new System.Windows.Forms.TextBox();
            chk_CompanyEnabled = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            label10 = new System.Windows.Forms.Label();
            tb_CompanyEmail = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            tb_CompanyPhone = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 273);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(28, 15);
            label1.TabIndex = 0;
            label1.Text = "País";
            // 
            // cb_CompanyCountry
            // 
            cb_CompanyCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cb_CompanyCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cb_CompanyCountry.Enabled = false;
            cb_CompanyCountry.FormattingEnabled = true;
            cb_CompanyCountry.Location = new System.Drawing.Point(12, 291);
            cb_CompanyCountry.Name = "cb_CompanyCountry";
            cb_CompanyCountry.Size = new System.Drawing.Size(121, 23);
            cb_CompanyCountry.TabIndex = 1;
            cb_CompanyCountry.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(139, 273);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Estado";
            // 
            // cb_CompanyState
            // 
            cb_CompanyState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cb_CompanyState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cb_CompanyState.Enabled = false;
            cb_CompanyState.FormattingEnabled = true;
            cb_CompanyState.Location = new System.Drawing.Point(139, 291);
            cb_CompanyState.Name = "cb_CompanyState";
            cb_CompanyState.Size = new System.Drawing.Size(121, 23);
            cb_CompanyState.TabIndex = 3;
            cb_CompanyState.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(266, 273);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "Ciudad";
            // 
            // cb_CompanyCity
            // 
            cb_CompanyCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cb_CompanyCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cb_CompanyCity.Enabled = false;
            cb_CompanyCity.FormattingEnabled = true;
            cb_CompanyCity.Location = new System.Drawing.Point(266, 291);
            cb_CompanyCity.Name = "cb_CompanyCity";
            cb_CompanyCity.Size = new System.Drawing.Size(121, 23);
            cb_CompanyCity.TabIndex = 5;
            cb_CompanyCity.TabStop = false;
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Location = new System.Drawing.Point(259, 345);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(128, 23);
            btn_CancelEdit.TabIndex = 6;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 9);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(29, 15);
            label4.TabIndex = 7;
            label4.Text = "Giro";
            // 
            // cb_CompanyType
            // 
            cb_CompanyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_CompanyType.FormattingEnabled = true;
            cb_CompanyType.Items.AddRange(new object[] { "Pública", "Privada", "Industrial" });
            cb_CompanyType.Location = new System.Drawing.Point(12, 27);
            cb_CompanyType.Name = "cb_CompanyType";
            cb_CompanyType.Size = new System.Drawing.Size(121, 23);
            cb_CompanyType.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(139, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(28, 15);
            label5.TabIndex = 9;
            label5.Text = "RFC";
            // 
            // tb_CompanyRfc
            // 
            tb_CompanyRfc.Location = new System.Drawing.Point(139, 27);
            tb_CompanyRfc.Name = "tb_CompanyRfc";
            tb_CompanyRfc.Size = new System.Drawing.Size(248, 23);
            tb_CompanyRfc.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 53);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 15);
            label6.TabIndex = 11;
            label6.Text = "Nombre";
            // 
            // tb_CompanyName
            // 
            tb_CompanyName.Location = new System.Drawing.Point(12, 71);
            tb_CompanyName.Name = "tb_CompanyName";
            tb_CompanyName.Size = new System.Drawing.Size(375, 23);
            tb_CompanyName.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 185);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 15);
            label7.TabIndex = 13;
            label7.Text = "Dirección";
            // 
            // tb_CompanyAddress
            // 
            tb_CompanyAddress.Location = new System.Drawing.Point(12, 203);
            tb_CompanyAddress.Name = "tb_CompanyAddress";
            tb_CompanyAddress.Size = new System.Drawing.Size(375, 23);
            tb_CompanyAddress.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(12, 229);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(48, 15);
            label8.TabIndex = 15;
            label8.Text = "Colonia";
            // 
            // tb_CompanyLocality
            // 
            tb_CompanyLocality.Location = new System.Drawing.Point(12, 247);
            tb_CompanyLocality.Name = "tb_CompanyLocality";
            tb_CompanyLocality.Size = new System.Drawing.Size(248, 23);
            tb_CompanyLocality.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(266, 229);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(81, 15);
            label9.TabIndex = 17;
            label9.Text = "Código postal";
            // 
            // tb_CompanyPostalCode
            // 
            tb_CompanyPostalCode.Location = new System.Drawing.Point(266, 247);
            tb_CompanyPostalCode.Name = "tb_CompanyPostalCode";
            tb_CompanyPostalCode.Size = new System.Drawing.Size(121, 23);
            tb_CompanyPostalCode.TabIndex = 7;
            // 
            // chk_CompanyEnabled
            // 
            chk_CompanyEnabled.AutoSize = true;
            chk_CompanyEnabled.Checked = true;
            chk_CompanyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_CompanyEnabled.Location = new System.Drawing.Point(12, 320);
            chk_CompanyEnabled.Name = "chk_CompanyEnabled";
            chk_CompanyEnabled.Size = new System.Drawing.Size(71, 19);
            chk_CompanyEnabled.TabIndex = 8;
            chk_CompanyEnabled.Text = "Habilitar";
            chk_CompanyEnabled.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 345);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(128, 23);
            button1.TabIndex = 20;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveEdit_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(12, 97);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(43, 15);
            label10.TabIndex = 21;
            label10.Text = "Correo";
            // 
            // tb_CompanyEmail
            // 
            tb_CompanyEmail.Location = new System.Drawing.Point(12, 115);
            tb_CompanyEmail.Name = "tb_CompanyEmail";
            tb_CompanyEmail.Size = new System.Drawing.Size(373, 23);
            tb_CompanyEmail.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(12, 141);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(52, 15);
            label11.TabIndex = 23;
            label11.Text = "Teléfono";
            // 
            // tb_CompanyPhone
            // 
            tb_CompanyPhone.Location = new System.Drawing.Point(12, 159);
            tb_CompanyPhone.Name = "tb_CompanyPhone";
            tb_CompanyPhone.Size = new System.Drawing.Size(373, 23);
            tb_CompanyPhone.TabIndex = 4;
            // 
            // CompanyEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(397, 378);
            ControlBox = false;
            Controls.Add(tb_CompanyPhone);
            Controls.Add(label11);
            Controls.Add(tb_CompanyEmail);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(chk_CompanyEnabled);
            Controls.Add(tb_CompanyPostalCode);
            Controls.Add(label9);
            Controls.Add(tb_CompanyLocality);
            Controls.Add(label8);
            Controls.Add(tb_CompanyAddress);
            Controls.Add(label7);
            Controls.Add(tb_CompanyName);
            Controls.Add(label6);
            Controls.Add(tb_CompanyRfc);
            Controls.Add(label5);
            Controls.Add(cb_CompanyType);
            Controls.Add(label4);
            Controls.Add(btn_CancelEdit);
            Controls.Add(cb_CompanyCity);
            Controls.Add(label3);
            Controls.Add(cb_CompanyState);
            Controls.Add(label2);
            Controls.Add(cb_CompanyCountry);
            Controls.Add(label1);
            Name = "CompanyEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            Load += CompanyEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_CompanyCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_CompanyState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_CompanyCity;
        private System.Windows.Forms.Button btn_CancelEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_CompanyType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_CompanyRfc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_CompanyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_CompanyAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_CompanyLocality;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_CompanyPostalCode;
        private System.Windows.Forms.CheckBox chk_CompanyEnabled;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_CompanyEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_CompanyPhone;
    }
}
