namespace TECNM.Residencias.Forms.StudentForms
{
    partial class StudentEditForm
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            cb_StudentSpecialty = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            cb_StudentCareer = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            textBox5 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            tb_StudentId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            textBox3 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_CancelEdit.Location = new System.Drawing.Point(1124, 646);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(128, 23);
            btn_CancelEdit.TabIndex = 5;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(cb_StudentSpecialty);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cb_StudentCareer);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(tb_StudentId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(716, 254);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información general";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 68);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(32, 15);
            label8.TabIndex = 15;
            label8.Text = "Sexo";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            comboBox1.Location = new System.Drawing.Point(6, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(97, 23);
            comboBox1.TabIndex = 14;
            // 
            // cb_StudentSpecialty
            // 
            cb_StudentSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentSpecialty.FormattingEnabled = true;
            cb_StudentSpecialty.Location = new System.Drawing.Point(310, 130);
            cb_StudentSpecialty.Name = "cb_StudentSpecialty";
            cb_StudentSpecialty.Size = new System.Drawing.Size(272, 23);
            cb_StudentSpecialty.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(310, 112);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(72, 15);
            label7.TabIndex = 12;
            label7.Text = "Especialidad";
            // 
            // cb_StudentCareer
            // 
            cb_StudentCareer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentCareer.FormattingEnabled = true;
            cb_StudentCareer.Location = new System.Drawing.Point(6, 130);
            cb_StudentCareer.Name = "cb_StudentCareer";
            cb_StudentCareer.Size = new System.Drawing.Size(272, 23);
            cb_StudentCareer.TabIndex = 11;
            cb_StudentCareer.SelectedIndexChanged += StudentCareer_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 112);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 15);
            label6.TabIndex = 10;
            label6.Text = "Carrera";
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(365, 86);
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(217, 23);
            textBox5.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(365, 68);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 15);
            label5.TabIndex = 8;
            label5.Text = "Teléfono";
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(109, 86);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(250, 23);
            textBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(109, 68);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "Correo";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(332, 42);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(250, 23);
            textBox2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(332, 24);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 15);
            label3.TabIndex = 4;
            label3.Text = "Apellidos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(76, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(76, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(250, 23);
            textBox1.TabIndex = 2;
            // 
            // tb_StudentId
            // 
            tb_StudentId.Location = new System.Drawing.Point(6, 42);
            tb_StudentId.Name = "tb_StudentId";
            tb_StudentId.Size = new System.Drawing.Size(64, 23);
            tb_StudentId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "N° Control";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox3);
            groupBox2.Location = new System.Drawing.Point(892, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(360, 628);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Observaciones";
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(6, 22);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            textBox3.Size = new System.Drawing.Size(348, 600);
            textBox3.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(18, 646);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            // 
            // StudentEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(1264, 681);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btn_CancelEdit);
            Name = "StudentEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            Load += StudentEditForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_CancelEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_StudentId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_StudentCareer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_StudentSpecialty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}