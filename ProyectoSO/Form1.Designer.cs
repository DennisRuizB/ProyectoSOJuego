
namespace ProyectoSO
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.anoGanado = new System.Windows.Forms.RadioButton();
            this.Edad = new System.Windows.Forms.RadioButton();
            this.nombreConsulta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edadRegister = new System.Windows.Forms.TextBox();
            this.nombreRegister = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contrasenaRegister = new System.Windows.Forms.TextBox();
            this.Contrasena = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.Contrasena);
            this.groupBox1.Controls.Add(this.anoGanado);
            this.groupBox1.Controls.Add(this.Edad);
            this.groupBox1.Controls.Add(this.nombreConsulta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(33, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "consultas";
            // 
            // anoGanado
            // 
            this.anoGanado.AutoSize = true;
            this.anoGanado.Location = new System.Drawing.Point(125, 136);
            this.anoGanado.Name = "anoGanado";
            this.anoGanado.Size = new System.Drawing.Size(166, 17);
            this.anoGanado.TabIndex = 10;
            this.anoGanado.TabStop = true;
            this.anoGanado.Text = "Dime los años que ha ganado";
            this.anoGanado.UseVisualStyleBackColor = true;
            // 
            // Edad
            // 
            this.Edad.AutoSize = true;
            this.Edad.Location = new System.Drawing.Point(125, 99);
            this.Edad.Name = "Edad";
            this.Edad.Size = new System.Drawing.Size(142, 17);
            this.Edad.TabIndex = 9;
            this.Edad.TabStop = true;
            this.Edad.Text = "Dime la edad del jugador";
            this.Edad.UseVisualStyleBackColor = true;
            // 
            // nombreConsulta
            // 
            this.nombreConsulta.Location = new System.Drawing.Point(127, 35);
            this.nombreConsulta.Name = "nombreConsulta";
            this.nombreConsulta.Size = new System.Drawing.Size(164, 20);
            this.nombreConsulta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.contrasenaRegister);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.edadRegister);
            this.groupBox2.Controls.Add(this.nombreRegister);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(485, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 198);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "register";
            // 
            // edadRegister
            // 
            this.edadRegister.Location = new System.Drawing.Point(109, 56);
            this.edadRegister.Name = "edadRegister";
            this.edadRegister.Size = new System.Drawing.Size(164, 20);
            this.edadRegister.TabIndex = 5;
            // 
            // nombreRegister
            // 
            this.nombreRegister.Location = new System.Drawing.Point(109, 27);
            this.nombreRegister.Name = "nombreRegister";
            this.nombreRegister.Size = new System.Drawing.Size(164, 20);
            this.nombreRegister.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Edad";
            // 
            // contrasenaRegister
            // 
            this.contrasenaRegister.Location = new System.Drawing.Point(109, 91);
            this.contrasenaRegister.Name = "contrasenaRegister";
            this.contrasenaRegister.Size = new System.Drawing.Size(164, 20);
            this.contrasenaRegister.TabIndex = 12;
            // 
            // Contrasena
            // 
            this.Contrasena.AutoSize = true;
            this.Contrasena.Location = new System.Drawing.Point(125, 168);
            this.Contrasena.Name = "Contrasena";
            this.Contrasena.Size = new System.Drawing.Size(116, 17);
            this.Contrasena.TabIndex = 11;
            this.Contrasena.TabStop = true;
            this.Contrasena.Text = "Dime la contraseña";
            this.Contrasena.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(91, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 47);
            this.button3.TabIndex = 13;
            this.button3.Text = "register";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(60, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 53);
            this.button1.TabIndex = 12;
            this.button1.Text = "conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(276, 335);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(147, 53);
            this.button4.TabIndex = 15;
            this.button4.Text = "desconectar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton anoGanado;
        private System.Windows.Forms.RadioButton Edad;
        private System.Windows.Forms.TextBox nombreConsulta;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox edadRegister;
        private System.Windows.Forms.TextBox nombreRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox contrasenaRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton Contrasena;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}

