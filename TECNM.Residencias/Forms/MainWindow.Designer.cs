namespace TECNM.Residencias.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            button4 = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button5 = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            button6 = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            button1.Location = new System.Drawing.Point(6, 31);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(192, 52);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "Ver carreras";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ShowCareers_Click;
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            button2.Location = new System.Drawing.Point(6, 31);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(192, 52);
            button2.TabIndex = 1;
            button2.TabStop = false;
            button2.Text = "Ver empresas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ShowCompanies_Click;
            // 
            // button3
            // 
            button3.Font = new System.Drawing.Font("Segoe UI", 10F);
            button3.Location = new System.Drawing.Point(6, 31);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(192, 52);
            button3.TabIndex = 0;
            button3.TabStop = false;
            button3.Text = "Ver expedientes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ShowStudents_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Corbel", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(502, 59);
            label1.TabIndex = 3;
            label1.Text = "Panel de administración";
            // 
            // button4
            // 
            button4.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button4.Location = new System.Drawing.Point(1131, 635);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(121, 34);
            button4.TabIndex = 4;
            button4.TabStop = false;
            button4.Text = "Configuración";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ShowSettings_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button3);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            groupBox1.Location = new System.Drawing.Point(12, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(403, 501);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Expedientes de residencias";
            // 
            // button5
            // 
            button5.Font = new System.Drawing.Font("Segoe UI", 10F);
            button5.Location = new System.Drawing.Point(204, 31);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(192, 52);
            button5.TabIndex = 0;
            button5.TabStop = false;
            button5.Text = "Crear nuevo expediente";
            button5.UseVisualStyleBackColor = true;
            button5.Click += AddNewStudent_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button2);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F);
            groupBox2.Location = new System.Drawing.Point(12, 578);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(403, 91);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Catálogo de empresas";
            // 
            // button6
            // 
            button6.Font = new System.Drawing.Font("Segoe UI", 10F);
            button6.Location = new System.Drawing.Point(204, 31);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(192, 52);
            button6.TabIndex = 0;
            button6.TabStop = false;
            button6.Text = "Agregar empresa";
            button6.UseVisualStyleBackColor = true;
            button6.Click += AddNewCompany_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button1);
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 14F);
            groupBox3.Location = new System.Drawing.Point(421, 578);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(204, 91);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Carreras";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button4);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "MainWindow";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += MainWindow_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
