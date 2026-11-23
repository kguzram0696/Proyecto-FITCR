namespace FitCR
{
    partial class FormAsignarRutina
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
            txtNombreRutina = new TextBox();
            txtUsuarioCliente = new TextBox();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            txtEjercicio = new TextBox();
            nudSeries = new NumericUpDown();
            nudRepeticiones = new NumericUpDown();
            nudCarga = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lstEjercicios = new ListBox();
            btnAgregarEjercicio = new Button();
            btnAsignarRutina = new Button();
            btnCambiarCarga = new Button();
            ((System.ComponentModel.ISupportInitialize)nudSeries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCarga).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 71);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la Rutina";
            // 
            // txtNombreRutina
            // 
            txtNombreRutina.Location = new Point(33, 89);
            txtNombreRutina.Name = "txtNombreRutina";
            txtNombreRutina.Size = new Size(100, 23);
            txtNombreRutina.TabIndex = 1;
            // 
            // txtUsuarioCliente
            // 
            txtUsuarioCliente.Location = new Point(237, 86);
            txtUsuarioCliente.Name = "txtUsuarioCliente";
            txtUsuarioCliente.Size = new Size(100, 23);
            txtUsuarioCliente.TabIndex = 2;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(628, 86);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(100, 23);
            dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(427, 86);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(100, 23);
            dtpFechaInicio.TabIndex = 4;
            // 
            // txtEjercicio
            // 
            txtEjercicio.Location = new Point(33, 163);
            txtEjercicio.Name = "txtEjercicio";
            txtEjercicio.Size = new Size(100, 23);
            txtEjercicio.TabIndex = 5;
            // 
            // nudSeries
            // 
            nudSeries.Location = new Point(237, 163);
            nudSeries.Name = "nudSeries";
            nudSeries.Size = new Size(100, 23);
            nudSeries.TabIndex = 6;
            // 
            // nudRepeticiones
            // 
            nudRepeticiones.Location = new Point(427, 164);
            nudRepeticiones.Name = "nudRepeticiones";
            nudRepeticiones.Size = new Size(100, 23);
            nudRepeticiones.TabIndex = 7;
            // 
            // nudCarga
            // 
            nudCarga.DecimalPlaces = 2;
            nudCarga.Location = new Point(628, 164);
            nudCarga.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudCarga.Name = "nudCarga";
            nudCarga.Size = new Size(100, 23);
            nudCarga.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 68);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 9;
            label2.Text = "Usuario del Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(427, 68);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 10;
            label3.Text = "Fecha de Inicio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(628, 68);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 11;
            label4.Text = "Fecha de Fin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 145);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 12;
            label5.Text = "Ejercicio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(237, 145);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 13;
            label6.Text = "Series";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(427, 145);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 14;
            label7.Text = "Repeticiones";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(628, 145);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 15;
            label8.Text = "Carga (kg)";
            // 
            // lstEjercicios
            // 
            lstEjercicios.FormattingEnabled = true;
            lstEjercicios.Location = new Point(132, 303);
            lstEjercicios.Name = "lstEjercicios";
            lstEjercicios.Size = new Size(301, 124);
            lstEjercicios.TabIndex = 16;
            // 
            // btnAgregarEjercicio
            // 
            btnAgregarEjercicio.Location = new Point(33, 254);
            btnAgregarEjercicio.Name = "btnAgregarEjercicio";
            btnAgregarEjercicio.Size = new Size(104, 23);
            btnAgregarEjercicio.TabIndex = 17;
            btnAgregarEjercicio.Text = "Agregar ejercicio";
            btnAgregarEjercicio.UseVisualStyleBackColor = true;
            btnAgregarEjercicio.Click += btnAgregarEjercicio_Click;
            // 
            // btnAsignarRutina
            // 
            btnAsignarRutina.Location = new Point(237, 255);
            btnAsignarRutina.Name = "btnAsignarRutina";
            btnAsignarRutina.Size = new Size(96, 23);
            btnAsignarRutina.TabIndex = 18;
            btnAsignarRutina.Text = "Asignar rutina";
            btnAsignarRutina.UseVisualStyleBackColor = true;
            btnAsignarRutina.Click += btnAsignarRutina_Click;
            // 
            // btnCambiarCarga
            // 
            btnCambiarCarga.Location = new Point(427, 255);
            btnCambiarCarga.Name = "btnCambiarCarga";
            btnCambiarCarga.Size = new Size(96, 23);
            btnCambiarCarga.TabIndex = 19;
            btnCambiarCarga.Text = "Cambiar Carga";
            btnCambiarCarga.UseVisualStyleBackColor = true;
            btnCambiarCarga.Visible = false;
            btnCambiarCarga.Click += btnCambiarCarga_Click;
            // 
            // FormAsignarRutina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCambiarCarga);
            Controls.Add(btnAsignarRutina);
            Controls.Add(btnAgregarEjercicio);
            Controls.Add(lstEjercicios);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudCarga);
            Controls.Add(nudRepeticiones);
            Controls.Add(nudSeries);
            Controls.Add(txtEjercicio);
            Controls.Add(dtpFechaInicio);
            Controls.Add(dtpFechaFin);
            Controls.Add(txtUsuarioCliente);
            Controls.Add(txtNombreRutina);
            Controls.Add(label1);
            Name = "FormAsignarRutina";
            Text = "FitCR - Asignar Rutina";
            ((System.ComponentModel.ISupportInitialize)nudSeries).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCarga).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreRutina;
        private TextBox txtUsuarioCliente;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private TextBox txtEjercicio;
        private NumericUpDown nudSeries;
        private NumericUpDown nudRepeticiones;
        private NumericUpDown nudCarga;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ListBox lstEjercicios;
        private Button btnAgregarEjercicio;
        private Button btnAsignarRutina;
        private Button btnCambiarCarga;
    }
}