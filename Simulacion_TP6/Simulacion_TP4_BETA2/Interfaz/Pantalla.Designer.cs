
namespace Simulacion_TP1
{
    partial class Pantalla
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtHoraDesde = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidadHoras = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUniformeB = new System.Windows.Forms.MaskedTextBox();
            this.txtUniformeA = new System.Windows.Forms.MaskedTextBox();
            this.txtDesviacion = new System.Windows.Forms.MaskedTextBox();
            this.txtMedia = new System.Windows.Forms.MaskedTextBox();
            this.txtLambdaMatricula = new System.Windows.Forms.MaskedTextBox();
            this.txtLambdaRenovacion = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1438, 358);
            this.dataGridView1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHoraDesde
            // 
            this.txtHoraDesde.Location = new System.Drawing.Point(184, 27);
            this.txtHoraDesde.Name = "txtHoraDesde";
            this.txtHoraDesde.Size = new System.Drawing.Size(82, 20);
            this.txtHoraDesde.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Minuto Desde para mostrar:";
            // 
            // txtCantidadHoras
            // 
            this.txtCantidadHoras.Location = new System.Drawing.Point(184, 60);
            this.txtCantidadHoras.Mask = "99999999";
            this.txtCantidadHoras.Name = "txtCantidadHoras";
            this.txtCantidadHoras.Size = new System.Drawing.Size(82, 20);
            this.txtCantidadHoras.TabIndex = 26;
            this.txtCantidadHoras.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Minuto Hasta para mostrar:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 536);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(465, 308);
            this.dataGridView2.TabIndex = 30;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(503, 536);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(456, 308);
            this.dataGridView3.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(803, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Uniforme A:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(803, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Uniforme B:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1001, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Desviacion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1001, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Media";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1033, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Renovaciones";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(803, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Matriculas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1185, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Lambda llegada Matricula";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1185, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Lambda llegada Renovacion";
            // 
            // txtUniformeB
            // 
            this.txtUniformeB.Location = new System.Drawing.Point(870, 78);
            this.txtUniformeB.Name = "txtUniformeB";
            this.txtUniformeB.Size = new System.Drawing.Size(82, 20);
            this.txtUniformeB.TabIndex = 48;
            // 
            // txtUniformeA
            // 
            this.txtUniformeA.Location = new System.Drawing.Point(870, 43);
            this.txtUniformeA.Name = "txtUniformeA";
            this.txtUniformeA.Size = new System.Drawing.Size(82, 20);
            this.txtUniformeA.TabIndex = 49;
            // 
            // txtDesviacion
            // 
            this.txtDesviacion.Location = new System.Drawing.Point(1058, 76);
            this.txtDesviacion.Name = "txtDesviacion";
            this.txtDesviacion.Size = new System.Drawing.Size(82, 20);
            this.txtDesviacion.TabIndex = 52;
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(1058, 39);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(82, 20);
            this.txtMedia.TabIndex = 53;
            // 
            // txtLambdaMatricula
            // 
            this.txtLambdaMatricula.Location = new System.Drawing.Point(1350, 36);
            this.txtLambdaMatricula.Name = "txtLambdaMatricula";
            this.txtLambdaMatricula.Size = new System.Drawing.Size(82, 20);
            this.txtLambdaMatricula.TabIndex = 55;
            // 
            // txtLambdaRenovacion
            // 
            this.txtLambdaRenovacion.Location = new System.Drawing.Point(1350, 73);
            this.txtLambdaRenovacion.Name = "txtLambdaRenovacion";
            this.txtLambdaRenovacion.Size = new System.Drawing.Size(82, 20);
            this.txtLambdaRenovacion.TabIndex = 54;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(992, 536);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(449, 308);
            this.dataGridView4.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "PROXIMA LLEGADA ATENTADO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(582, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 20);
            this.label4.TabIndex = 58;
            this.label4.Text = "DURACION BLOQUEO LLEGADA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1062, 513);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(293, 20);
            this.label13.TabIndex = 59;
            this.label13.Text = "DURACION BLOQUEO SERVIDOR";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(604, 484);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(237, 20);
            this.label14.TabIndex = 60;
            this.label14.Text = "TABLAS DE RUNGE KUTTA";
            // 
            // Pantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 912);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.txtLambdaMatricula);
            this.Controls.Add(this.txtLambdaRenovacion);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.txtDesviacion);
            this.Controls.Add(this.txtUniformeA);
            this.Controls.Add(this.txtUniformeB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.txtHoraDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidadHoras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Pantalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador Números Pseudoaleatorios";
            this.Load += new System.EventHandler(this.Pantalla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox txtHoraDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtCantidadHoras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtUniformeB;
        private System.Windows.Forms.MaskedTextBox txtUniformeA;
        private System.Windows.Forms.MaskedTextBox txtDesviacion;
        private System.Windows.Forms.MaskedTextBox txtMedia;
        private System.Windows.Forms.MaskedTextBox txtLambdaMatricula;
        private System.Windows.Forms.MaskedTextBox txtLambdaRenovacion;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}

