namespace FitCR
{
    partial class FormMenuEntrenador
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
            lblTipoEntrenador = new Label();
            label1 = new Label();
            btnAsignarUsuario = new Button();
            txtUsuarioAsignar = new TextBox();
            btnAbrirAsignarRutina = new Button();
            btnVerRutinasAsignadas = new Button();
            lstRutinasEntrenador = new ListBox();
            btnEditarRutina = new Button();
            btnRetirarRutina = new Button();
            btnVerAvisosEntrenador = new Button();
            lstAvisosEntrenador = new ListBox();
            label2 = new Label();
            label3 = new Label();
            dtpProximaMedicion = new DateTimePicker();
            btnProgramarMedicion = new Button();
            txtClienteMedicion = new TextBox();
            SuspendLayout();
            // 
            // lblTipoEntrenador
            // 
            lblTipoEntrenador.AutoSize = true;
            lblTipoEntrenador.Location = new Point(12, 38);
            lblTipoEntrenador.Name = "lblTipoEntrenador";
            lblTipoEntrenador.Size = new Size(108, 15);
            lblTipoEntrenador.TabIndex = 0;
            lblTipoEntrenador.Text = "Tipo de Entrenador";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 71);
            label1.Name = "label1";
            label1.Size = new Size(159, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre de usuario a asignar";
            // 
            // btnAsignarUsuario
            // 
            btnAsignarUsuario.Location = new Point(12, 138);
            btnAsignarUsuario.Name = "btnAsignarUsuario";
            btnAsignarUsuario.Size = new Size(98, 23);
            btnAsignarUsuario.TabIndex = 2;
            btnAsignarUsuario.Text = "Asignar usuario";
            btnAsignarUsuario.UseVisualStyleBackColor = true;
            btnAsignarUsuario.Click += btnAsignarUsuario_Click;
            // 
            // txtUsuarioAsignar
            // 
            txtUsuarioAsignar.Location = new Point(12, 99);
            txtUsuarioAsignar.Name = "txtUsuarioAsignar";
            txtUsuarioAsignar.Size = new Size(100, 23);
            txtUsuarioAsignar.TabIndex = 3;
            // 
            // btnAbrirAsignarRutina
            // 
            btnAbrirAsignarRutina.Location = new Point(303, 70);
            btnAbrirAsignarRutina.Name = "btnAbrirAsignarRutina";
            btnAbrirAsignarRutina.Size = new Size(98, 23);
            btnAbrirAsignarRutina.TabIndex = 4;
            btnAbrirAsignarRutina.Text = "Crear Rutina";
            btnAbrirAsignarRutina.UseVisualStyleBackColor = true;
            btnAbrirAsignarRutina.Click += btnAbrirAsignarRutina_Click;
            // 
            // btnVerRutinasAsignadas
            // 
            btnVerRutinasAsignadas.Location = new Point(407, 70);
            btnVerRutinasAsignadas.Name = "btnVerRutinasAsignadas";
            btnVerRutinasAsignadas.Size = new Size(130, 23);
            btnVerRutinasAsignadas.TabIndex = 5;
            btnVerRutinasAsignadas.Text = "Ver Rutinas Asignadas";
            btnVerRutinasAsignadas.UseVisualStyleBackColor = true;
            btnVerRutinasAsignadas.Click += btnVerRutinasAsignadas_Click;
            // 
            // lstRutinasEntrenador
            // 
            lstRutinasEntrenador.FormattingEnabled = true;
            lstRutinasEntrenador.Location = new Point(348, 102);
            lstRutinasEntrenador.Name = "lstRutinasEntrenador";
            lstRutinasEntrenador.Size = new Size(326, 94);
            lstRutinasEntrenador.TabIndex = 6;
            lstRutinasEntrenador.Format += lstRutinasEntrenador_Format;
            // 
            // btnEditarRutina
            // 
            btnEditarRutina.Location = new Point(543, 70);
            btnEditarRutina.Name = "btnEditarRutina";
            btnEditarRutina.Size = new Size(87, 23);
            btnEditarRutina.TabIndex = 7;
            btnEditarRutina.Text = "Editar Rutina";
            btnEditarRutina.UseVisualStyleBackColor = true;
            btnEditarRutina.Click += btnEditarRutina_Click;
            // 
            // btnRetirarRutina
            // 
            btnRetirarRutina.Location = new Point(636, 70);
            btnRetirarRutina.Name = "btnRetirarRutina";
            btnRetirarRutina.Size = new Size(95, 23);
            btnRetirarRutina.TabIndex = 8;
            btnRetirarRutina.Text = "Retirar Rutina";
            btnRetirarRutina.UseVisualStyleBackColor = true;
            btnRetirarRutina.Click += btnRetirarRutina_Click;
            // 
            // btnVerAvisosEntrenador
            // 
            btnVerAvisosEntrenador.Location = new Point(303, 202);
            btnVerAvisosEntrenador.Name = "btnVerAvisosEntrenador";
            btnVerAvisosEntrenador.Size = new Size(75, 23);
            btnVerAvisosEntrenador.TabIndex = 9;
            btnVerAvisosEntrenador.Text = "Ver avisos";
            btnVerAvisosEntrenador.UseVisualStyleBackColor = true;
            btnVerAvisosEntrenador.Click += btnVerAvisosEntrenador_Click;
            // 
            // lstAvisosEntrenador
            // 
            lstAvisosEntrenador.FormattingEnabled = true;
            lstAvisosEntrenador.Location = new Point(303, 231);
            lstAvisosEntrenador.Name = "lstAvisosEntrenador";
            lstAvisosEntrenador.Size = new Size(428, 94);
            lstAvisosEntrenador.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 206);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 11;
            label2.Text = "Usuario del cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 247);
            label3.Name = "label3";
            label3.Size = new Size(165, 15);
            label3.TabIndex = 13;
            label3.Text = "Fecha de la próxima medición";
            // 
            // dtpProximaMedicion
            // 
            dtpProximaMedicion.Format = DateTimePickerFormat.Short;
            dtpProximaMedicion.Location = new Point(187, 241);
            dtpProximaMedicion.Name = "dtpProximaMedicion";
            dtpProximaMedicion.Size = new Size(100, 23);
            dtpProximaMedicion.TabIndex = 14;
            // 
            // btnProgramarMedicion
            // 
            btnProgramarMedicion.Location = new Point(6, 280);
            btnProgramarMedicion.Name = "btnProgramarMedicion";
            btnProgramarMedicion.Size = new Size(129, 23);
            btnProgramarMedicion.TabIndex = 15;
            btnProgramarMedicion.Text = "Programar medición";
            btnProgramarMedicion.UseVisualStyleBackColor = true;
            btnProgramarMedicion.Click += btnProgramarMedicion_Click;
            // 
            // txtClienteMedicion
            // 
            txtClienteMedicion.Location = new Point(187, 203);
            txtClienteMedicion.Name = "txtClienteMedicion";
            txtClienteMedicion.Size = new Size(100, 23);
            txtClienteMedicion.TabIndex = 16;
            // 
            // FormMenuEntrenador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtClienteMedicion);
            Controls.Add(btnProgramarMedicion);
            Controls.Add(dtpProximaMedicion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lstAvisosEntrenador);
            Controls.Add(btnVerAvisosEntrenador);
            Controls.Add(btnRetirarRutina);
            Controls.Add(btnEditarRutina);
            Controls.Add(lstRutinasEntrenador);
            Controls.Add(btnVerRutinasAsignadas);
            Controls.Add(btnAbrirAsignarRutina);
            Controls.Add(txtUsuarioAsignar);
            Controls.Add(btnAsignarUsuario);
            Controls.Add(label1);
            Controls.Add(lblTipoEntrenador);
            Name = "FormMenuEntrenador";
            Text = "FormMenuEntrenador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipoEntrenador;
        private Label label1;
        private Button btnAsignarUsuario;
        private TextBox txtUsuarioAsignar;
        private Button btnAbrirAsignarRutina;
        private Button btnVerRutinasAsignadas;
        private ListBox lstRutinasEntrenador;
        private Button btnEditarRutina;
        private Button btnRetirarRutina;
        private Button btnVerAvisosEntrenador;
        private ListBox lstAvisosEntrenador;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpProximaMedicion;
        private Button btnProgramarMedicion;
        private TextBox txtClienteMedicion;
    }
}