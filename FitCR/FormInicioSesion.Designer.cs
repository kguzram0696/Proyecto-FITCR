namespace FitCR
{
    partial class FormInicioSesion
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
            label1 = new Label();
            txtNombreUsuario = new TextBox();
            label2 = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            btnCrearCuenta = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre de usuario";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(200, 44);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 91);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(200, 88);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(100, 23);
            txtContrasena.TabIndex = 3;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(12, 171);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.Location = new Point(106, 171);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(87, 23);
            btnCrearCuenta.TabIndex = 5;
            btnCrearCuenta.Text = "Crear Cuenta";
            btnCrearCuenta.UseVisualStyleBackColor = true;
            btnCrearCuenta.Click += btnCrearCuenta_Click;
            // 
            // FormInicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCrearCuenta);
            Controls.Add(btnIngresar);
            Controls.Add(txtContrasena);
            Controls.Add(label2);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label1);
            Name = "FormInicioSesion";
            Text = "FormInicioSesion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreUsuario;
        private Label label2;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Button btnCrearCuenta;
    }
}