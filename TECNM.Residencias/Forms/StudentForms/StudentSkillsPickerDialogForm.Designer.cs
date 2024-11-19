namespace TECNM.Residencias.Forms.StudentForms
{
    partial class StudentSkillsPickerDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentSkillsPickerDialogForm));
            groupBox1 = new System.Windows.Forms.GroupBox();
            flp_Languages = new System.Windows.Forms.FlowLayoutPanel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            flp_Databases = new System.Windows.Forms.FlowLayoutPanel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            flp_editors = new System.Windows.Forms.FlowLayoutPanel();
            groupBox4 = new System.Windows.Forms.GroupBox();
            flp_methodologies = new System.Windows.Forms.FlowLayoutPanel();
            button1 = new System.Windows.Forms.Button();
            btn_Cancel = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            //
            // groupBox1
            //
            groupBox1.Controls.Add(flp_Languages);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(200, 417);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lenguajes de programación";
            //
            // flp_Languages
            //
            flp_Languages.AutoScroll = true;
            flp_Languages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp_Languages.Location = new System.Drawing.Point(6, 22);
            flp_Languages.Name = "flp_Languages";
            flp_Languages.Size = new System.Drawing.Size(188, 389);
            flp_Languages.TabIndex = 1;
            flp_Languages.WrapContents = false;
            //
            // groupBox2
            //
            groupBox2.Controls.Add(flp_Databases);
            groupBox2.Location = new System.Drawing.Point(218, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(200, 417);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bases de datos";
            //
            // flp_Databases
            //
            flp_Databases.AutoScroll = true;
            flp_Databases.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp_Databases.Location = new System.Drawing.Point(6, 22);
            flp_Databases.Name = "flp_Databases";
            flp_Databases.Size = new System.Drawing.Size(188, 389);
            flp_Databases.TabIndex = 1;
            flp_Databases.WrapContents = false;
            //
            // groupBox3
            //
            groupBox3.Controls.Add(flp_editors);
            groupBox3.Location = new System.Drawing.Point(424, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(200, 417);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Editores e IDEs";
            //
            // flp_editors
            //
            flp_editors.AutoScroll = true;
            flp_editors.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp_editors.Location = new System.Drawing.Point(6, 22);
            flp_editors.Name = "flp_editors";
            flp_editors.Size = new System.Drawing.Size(188, 389);
            flp_editors.TabIndex = 1;
            flp_editors.WrapContents = false;
            //
            // groupBox4
            //
            groupBox4.Controls.Add(flp_methodologies);
            groupBox4.Location = new System.Drawing.Point(630, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(292, 417);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Metodologías";
            //
            // flp_methodologies
            //
            flp_methodologies.AutoScroll = true;
            flp_methodologies.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp_methodologies.Location = new System.Drawing.Point(6, 22);
            flp_methodologies.Name = "flp_methodologies";
            flp_methodologies.Size = new System.Drawing.Size(280, 389);
            flp_methodologies.TabIndex = 1;
            flp_methodologies.WrapContents = false;
            //
            // button1
            //
            button1.Location = new System.Drawing.Point(12, 437);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveEdit_Click;
            //
            // btn_Cancel
            //
            btn_Cancel.Location = new System.Drawing.Point(847, 437);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(75, 23);
            btn_Cancel.TabIndex = 6;
            btn_Cancel.Text = "Cancelar";
            btn_Cancel.UseVisualStyleBackColor = true;
            //
            // StudentExtrasPickerDialogForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new System.Drawing.Size(934, 472);
            ControlBox = false;
            Controls.Add(btn_Cancel);
            Controls.Add(button1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "StudentExtrasPickerDialogForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "StudentExtrasPickerDialogForm";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flp_Languages;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flp_Databases;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flp_editors;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flp_methodologies;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
