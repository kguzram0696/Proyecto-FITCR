namespace FitCR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtNombreUsuario = new TextBox();
            label3 = new Label();
            nudEdad = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            nudPeso = new NumericUpDown();
            nudEstatura = new NumericUpDown();
            btnRegistrar = new Button();
            label6 = new Label();
            txtContrasena = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPeso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEstatura).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(166, 53);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre de Usuario";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(166, 96);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 141);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 4;
            label3.Text = "Edad";
            // 
            // nudEdad
            // 
            nudEdad.Location = new Point(166, 139);
            nudEdad.Name = "nudEdad";
            nudEdad.Size = new Size(100, 23);
            nudEdad.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 189);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 6;
            label4.Text = "Peso (kg)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 238);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 7;
            label5.Text = "Estatura (m)";
            // 
            // nudPeso
            // 
            nudPeso.DecimalPlaces = 2;
            nudPeso.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudPeso.Location = new Point(166, 187);
            nudPeso.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudPeso.Name = "nudPeso";
            nudPeso.Size = new Size(100, 23);
            nudPeso.TabIndex = 8;
            // 
            // nudEstatura
            // 
            nudEstatura.DecimalPlaces = 2;
            nudEstatura.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudEstatura.Location = new Point(166, 236);
            nudEstatura.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            nudEstatura.Name = "nudEstatura";
            nudEstatura.Size = new Size(100, 23);
            nudEstatura.TabIndex = 9;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(12, 348);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 286);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 11;
            label6.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(166, 283);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(100, 23);
            txtContrasena.TabIndex = 12;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtContrasena);
            Controls.Add(label6);
            Controls.Add(btnRegistrar);
            Controls.Add(nudEstatura);
            Controls.Add(nudPeso);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(nudEdad);
            Controls.Add(label3);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPeso).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEstatura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtNombreUsuario;
        private Label label3;
        private NumericUpDown nudEdad;
        private Label label4;
        private Label label5;
        private NumericUpDown nudPeso;
        private NumericUpDown nudEstatura;
        private Button btnRegistrar;
        private Label label6;
        private TextBox txtContrasena;
    }
}
