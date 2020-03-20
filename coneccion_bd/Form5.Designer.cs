namespace coneccion_bd
{
    partial class Form5
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
            this.txtNOTA2 = new System.Windows.Forms.TextBox();
            this.txtNOTA1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnBorradoLogico = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtidcurso = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdetalle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpromedio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNOTA2
            // 
            this.txtNOTA2.Location = new System.Drawing.Point(118, 70);
            this.txtNOTA2.Name = "txtNOTA2";
            this.txtNOTA2.Size = new System.Drawing.Size(118, 20);
            this.txtNOTA2.TabIndex = 26;
            // 
            // txtNOTA1
            // 
            this.txtNOTA1.Location = new System.Drawing.Point(118, 25);
            this.txtNOTA1.MaxLength = 10;
            this.txtNOTA1.Name = "txtNOTA1";
            this.txtNOTA1.Size = new System.Drawing.Size(116, 20);
            this.txtNOTA1.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "NOTA 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "NOTA 1";
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(253, 111);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 23);
            this.btnReporte.TabIndex = 30;
            this.btnReporte.Text = "Reporte Notas";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(21, 111);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(75, 23);
            this.btnguardar.TabIndex = 29;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btnBorradoLogico
            // 
            this.btnBorradoLogico.Location = new System.Drawing.Point(140, 111);
            this.btnBorradoLogico.Name = "btnBorradoLogico";
            this.btnBorradoLogico.Size = new System.Drawing.Size(75, 23);
            this.btnBorradoLogico.TabIndex = 28;
            this.btnBorradoLogico.Text = "Eliminar";
            this.btnBorradoLogico.UseVisualStyleBackColor = true;
            this.btnBorradoLogico.Click += new System.EventHandler(this.btnBorradoLogico_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(551, 114);
            this.dataGridView1.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Id";
            // 
            // txtidcurso
            // 
            this.txtidcurso.Location = new System.Drawing.Point(300, 22);
            this.txtidcurso.Name = "txtidcurso";
            this.txtidcurso.Size = new System.Drawing.Size(42, 20);
            this.txtidcurso.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Detalle";
            // 
            // txtdetalle
            // 
            this.txtdetalle.Location = new System.Drawing.Point(396, 19);
            this.txtdetalle.Name = "txtdetalle";
            this.txtdetalle.Size = new System.Drawing.Size(204, 20);
            this.txtdetalle.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Promedio";
            // 
            // txtpromedio
            // 
            this.txtpromedio.Location = new System.Drawing.Point(569, 104);
            this.txtpromedio.Name = "txtpromedio";
            this.txtpromedio.Size = new System.Drawing.Size(111, 20);
            this.txtpromedio.TabIndex = 55;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 316);
            this.Controls.Add(this.txtpromedio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtdetalle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtidcurso);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnBorradoLogico);
            this.Controls.Add(this.txtNOTA2);
            this.Controls.Add(this.txtNOTA1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNOTA2;
        private System.Windows.Forms.TextBox txtNOTA1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnBorradoLogico;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtidcurso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpromedio;
    }
}