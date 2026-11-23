namespace FitCR
{
    partial class FormMenuUsuario
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
            lblEntrenadorAsignado = new Label();
            tabControl1 = new TabControl();
            Clases = new TabPage();
            lstHistorialClases = new ListBox();
            btnVerHistorialClases = new Button();
            btnRegistrarParticipacion = new Button();
            lstClases = new ListBox();
            btnVerClases = new Button();
            Rutinas = new TabPage();
            lstHistorialCargas = new ListBox();
            label1 = new Label();
            lstDetalleEjercicios = new ListBox();
            lblVigenciaRutina = new Label();
            lstRutinas = new ListBox();
            btnVerRutinas = new Button();
            Mediciones = new TabPage();
            lstHistorialMediciones = new ListBox();
            btnVerMediciones = new Button();
            btnRegistrarMedicion = new Button();
            nudMusculo = new NumericUpDown();
            chkIncluirMusculo = new CheckBox();
            nudGrasa = new NumericUpDown();
            chkIncluirGrasa = new CheckBox();
            nudPesoMedicion = new NumericUpDown();
            label2 = new Label();
            Objetivos = new TabPage();
            lstObjetivos = new ListBox();
            btnVerObjetivos = new Button();
            btnRegistrarObjetivo = new Button();
            dtpFechaLimiteObjetivo = new DateTimePicker();
            nudValorObjetivo = new NumericUpDown();
            cboDireccionObjetivo = new ComboBox();
            cboTipoObjetivo = new ComboBox();
            Visitas = new TabPage();
            lstHistorialVisitas = new ListBox();
            btnVerVisitas = new Button();
            btnRegistrarVisita = new Button();
            Insignias = new TabPage();
            lstInsignias = new ListBox();
            btnVerInsignias = new Button();
            Notificaciones = new TabPage();
            lstNotificaciones = new ListBox();
            btnVerNotificaciones = new Button();
            Estadisticas = new TabPage();
            lstMenosVisitantes = new ListBox();
            label6 = new Label();
            lstMasVisitantes = new ListBox();
            label5 = new Label();
            btnVerTopVisitas = new Button();
            lstProgresoObjetivos = new ListBox();
            btnVerProgresoObjetivos = new Button();
            lstAumentosCarga = new ListBox();
            btnVerAumentosCarga = new Button();
            dtpEstadisticasHasta = new DateTimePicker();
            label4 = new Label();
            dtpEstadisticasDesde = new DateTimePicker();
            label3 = new Label();
            tabControl1.SuspendLayout();
            Clases.SuspendLayout();
            Rutinas.SuspendLayout();
            Mediciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMusculo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGrasa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPesoMedicion).BeginInit();
            Objetivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudValorObjetivo).BeginInit();
            Visitas.SuspendLayout();
            Insignias.SuspendLayout();
            Notificaciones.SuspendLayout();
            Estadisticas.SuspendLayout();
            SuspendLayout();
            // 
            // lblEntrenadorAsignado
            // 
            lblEntrenadorAsignado.AutoSize = true;
            lblEntrenadorAsignado.Location = new Point(12, 26);
            lblEntrenadorAsignado.Name = "lblEntrenadorAsignado";
            lblEntrenadorAsignado.Size = new Size(118, 15);
            lblEntrenadorAsignado.TabIndex = 0;
            lblEntrenadorAsignado.Text = "Entrenador Asignado";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Clases);
            tabControl1.Controls.Add(Rutinas);
            tabControl1.Controls.Add(Mediciones);
            tabControl1.Controls.Add(Objetivos);
            tabControl1.Controls.Add(Visitas);
            tabControl1.Controls.Add(Insignias);
            tabControl1.Controls.Add(Notificaciones);
            tabControl1.Controls.Add(Estadisticas);
            tabControl1.Location = new Point(22, 55);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(766, 508);
            tabControl1.TabIndex = 31;
            // 
            // Clases
            // 
            Clases.Controls.Add(lstHistorialClases);
            Clases.Controls.Add(btnVerHistorialClases);
            Clases.Controls.Add(btnRegistrarParticipacion);
            Clases.Controls.Add(lstClases);
            Clases.Controls.Add(btnVerClases);
            Clases.Location = new Point(4, 24);
            Clases.Name = "Clases";
            Clases.Padding = new Padding(3);
            Clases.Size = new Size(758, 480);
            Clases.TabIndex = 0;
            Clases.Text = "Clases";
            Clases.UseVisualStyleBackColor = true;
            // 
            // lstHistorialClases
            // 
            lstHistorialClases.FormattingEnabled = true;
            lstHistorialClases.Location = new Point(198, 56);
            lstHistorialClases.Name = "lstHistorialClases";
            lstHistorialClases.Size = new Size(191, 94);
            lstHistorialClases.TabIndex = 6;
            // 
            // btnVerHistorialClases
            // 
            btnVerHistorialClases.Location = new Point(198, 22);
            btnVerHistorialClases.Name = "btnVerHistorialClases";
            btnVerHistorialClases.Size = new Size(128, 23);
            btnVerHistorialClases.TabIndex = 5;
            btnVerHistorialClases.Text = "Ver historial de clases";
            btnVerHistorialClases.UseVisualStyleBackColor = true;
            btnVerHistorialClases.Click += btnVerHistorialClases_Click;
            // 
            // btnRegistrarParticipacion
            // 
            btnRegistrarParticipacion.Location = new Point(11, 167);
            btnRegistrarParticipacion.Name = "btnRegistrarParticipacion";
            btnRegistrarParticipacion.Size = new Size(133, 23);
            btnRegistrarParticipacion.TabIndex = 4;
            btnRegistrarParticipacion.Text = "Registrar Participación";
            btnRegistrarParticipacion.UseVisualStyleBackColor = true;
            btnRegistrarParticipacion.Click += btnRegistrarParticipacion_Click;
            // 
            // lstClases
            // 
            lstClases.FormattingEnabled = true;
            lstClases.Location = new Point(11, 56);
            lstClases.Name = "lstClases";
            lstClases.Size = new Size(120, 94);
            lstClases.TabIndex = 3;
            // 
            // btnVerClases
            // 
            btnVerClases.Location = new Point(11, 22);
            btnVerClases.Name = "btnVerClases";
            btnVerClases.Size = new Size(75, 23);
            btnVerClases.TabIndex = 2;
            btnVerClases.Text = "Ver clases";
            btnVerClases.UseVisualStyleBackColor = true;
            btnVerClases.Click += btnVerClases_Click;
            // 
            // Rutinas
            // 
            Rutinas.Controls.Add(lstHistorialCargas);
            Rutinas.Controls.Add(label1);
            Rutinas.Controls.Add(lstDetalleEjercicios);
            Rutinas.Controls.Add(lblVigenciaRutina);
            Rutinas.Controls.Add(lstRutinas);
            Rutinas.Controls.Add(btnVerRutinas);
            Rutinas.Location = new Point(4, 24);
            Rutinas.Name = "Rutinas";
            Rutinas.Padding = new Padding(3);
            Rutinas.Size = new Size(758, 480);
            Rutinas.TabIndex = 1;
            Rutinas.Text = "Rutinas";
            Rutinas.UseVisualStyleBackColor = true;
            // 
            // lstHistorialCargas
            // 
            lstHistorialCargas.FormattingEnabled = true;
            lstHistorialCargas.Location = new Point(193, 206);
            lstHistorialCargas.Name = "lstHistorialCargas";
            lstHistorialCargas.Size = new Size(264, 94);
            lstHistorialCargas.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 174);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 11;
            label1.Text = "Historial de cargas";
            // 
            // lstDetalleEjercicios
            // 
            lstDetalleEjercicios.FormattingEnabled = true;
            lstDetalleEjercicios.Location = new Point(193, 64);
            lstDetalleEjercicios.Name = "lstDetalleEjercicios";
            lstDetalleEjercicios.Size = new Size(341, 94);
            lstDetalleEjercicios.TabIndex = 10;
            // 
            // lblVigenciaRutina
            // 
            lblVigenciaRutina.AutoSize = true;
            lblVigenciaRutina.Location = new Point(193, 30);
            lblVigenciaRutina.Name = "lblVigenciaRutina";
            lblVigenciaRutina.Size = new Size(120, 15);
            lblVigenciaRutina.TabIndex = 9;
            lblVigenciaRutina.Text = "Selecciona una rutina";
            // 
            // lstRutinas
            // 
            lstRutinas.FormattingEnabled = true;
            lstRutinas.Location = new Point(16, 64);
            lstRutinas.Name = "lstRutinas";
            lstRutinas.Size = new Size(142, 94);
            lstRutinas.TabIndex = 8;
            lstRutinas.SelectedIndexChanged += lstRutinas_SelectedIndexChanged;
            // 
            // btnVerRutinas
            // 
            btnVerRutinas.Location = new Point(16, 26);
            btnVerRutinas.Name = "btnVerRutinas";
            btnVerRutinas.Size = new Size(133, 23);
            btnVerRutinas.TabIndex = 7;
            btnVerRutinas.Text = "Ver mis rutinas";
            btnVerRutinas.UseVisualStyleBackColor = true;
            btnVerRutinas.Click += btnVerRutinas_Click;
            // 
            // Mediciones
            // 
            Mediciones.Controls.Add(lstHistorialMediciones);
            Mediciones.Controls.Add(btnVerMediciones);
            Mediciones.Controls.Add(btnRegistrarMedicion);
            Mediciones.Controls.Add(nudMusculo);
            Mediciones.Controls.Add(chkIncluirMusculo);
            Mediciones.Controls.Add(nudGrasa);
            Mediciones.Controls.Add(chkIncluirGrasa);
            Mediciones.Controls.Add(nudPesoMedicion);
            Mediciones.Controls.Add(label2);
            Mediciones.Location = new Point(4, 24);
            Mediciones.Name = "Mediciones";
            Mediciones.Size = new Size(758, 480);
            Mediciones.TabIndex = 2;
            Mediciones.Text = "Mediciones";
            Mediciones.UseVisualStyleBackColor = true;
            // 
            // lstHistorialMediciones
            // 
            lstHistorialMediciones.FormattingEnabled = true;
            lstHistorialMediciones.Location = new Point(14, 166);
            lstHistorialMediciones.Name = "lstHistorialMediciones";
            lstHistorialMediciones.Size = new Size(435, 94);
            lstHistorialMediciones.TabIndex = 21;
            // 
            // btnVerMediciones
            // 
            btnVerMediciones.Location = new Point(191, 114);
            btnVerMediciones.Name = "btnVerMediciones";
            btnVerMediciones.Size = new Size(98, 23);
            btnVerMediciones.TabIndex = 20;
            btnVerMediciones.Text = "Ver mediciones";
            btnVerMediciones.UseVisualStyleBackColor = true;
            btnVerMediciones.Click += btnVerMediciones_Click;
            // 
            // btnRegistrarMedicion
            // 
            btnRegistrarMedicion.Location = new Point(14, 114);
            btnRegistrarMedicion.Name = "btnRegistrarMedicion";
            btnRegistrarMedicion.Size = new Size(114, 23);
            btnRegistrarMedicion.TabIndex = 19;
            btnRegistrarMedicion.Text = "Registrar medición";
            btnRegistrarMedicion.UseVisualStyleBackColor = true;
            btnRegistrarMedicion.Click += btnRegistrarMedicion_Click;
            // 
            // nudMusculo
            // 
            nudMusculo.DecimalPlaces = 2;
            nudMusculo.Location = new Point(375, 70);
            nudMusculo.Name = "nudMusculo";
            nudMusculo.RightToLeft = RightToLeft.No;
            nudMusculo.Size = new Size(74, 23);
            nudMusculo.TabIndex = 18;
            // 
            // chkIncluirMusculo
            // 
            chkIncluirMusculo.AutoSize = true;
            chkIncluirMusculo.Location = new Point(191, 25);
            chkIncluirMusculo.Name = "chkIncluirMusculo";
            chkIncluirMusculo.Size = new Size(129, 19);
            chkIncluirMusculo.TabIndex = 17;
            chkIncluirMusculo.Text = "Incluir músculo (%)";
            chkIncluirMusculo.UseVisualStyleBackColor = true;
            // 
            // nudGrasa
            // 
            nudGrasa.DecimalPlaces = 2;
            nudGrasa.Location = new Point(375, 24);
            nudGrasa.Name = "nudGrasa";
            nudGrasa.Size = new Size(74, 23);
            nudGrasa.TabIndex = 16;
            // 
            // chkIncluirGrasa
            // 
            chkIncluirGrasa.AutoSize = true;
            chkIncluirGrasa.Location = new Point(191, 69);
            chkIncluirGrasa.Name = "chkIncluirGrasa";
            chkIncluirGrasa.Size = new Size(111, 19);
            chkIncluirGrasa.TabIndex = 15;
            chkIncluirGrasa.Text = "Incluir grasa (%)";
            chkIncluirGrasa.UseVisualStyleBackColor = true;
            // 
            // nudPesoMedicion
            // 
            nudPesoMedicion.DecimalPlaces = 2;
            nudPesoMedicion.Location = new Point(14, 69);
            nudPesoMedicion.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudPesoMedicion.Name = "nudPesoMedicion";
            nudPesoMedicion.Size = new Size(120, 23);
            nudPesoMedicion.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 26);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 13;
            label2.Text = "Peso (kg)";
            // 
            // Objetivos
            // 
            Objetivos.Controls.Add(lstObjetivos);
            Objetivos.Controls.Add(btnVerObjetivos);
            Objetivos.Controls.Add(btnRegistrarObjetivo);
            Objetivos.Controls.Add(dtpFechaLimiteObjetivo);
            Objetivos.Controls.Add(nudValorObjetivo);
            Objetivos.Controls.Add(cboDireccionObjetivo);
            Objetivos.Controls.Add(cboTipoObjetivo);
            Objetivos.Location = new Point(4, 24);
            Objetivos.Name = "Objetivos";
            Objetivos.Size = new Size(758, 480);
            Objetivos.TabIndex = 3;
            Objetivos.Text = "Objetivos";
            Objetivos.UseVisualStyleBackColor = true;
            // 
            // lstObjetivos
            // 
            lstObjetivos.FormattingEnabled = true;
            lstObjetivos.Location = new Point(49, 145);
            lstObjetivos.Name = "lstObjetivos";
            lstObjetivos.Size = new Size(321, 94);
            lstObjetivos.TabIndex = 34;
            // 
            // btnVerObjetivos
            // 
            btnVerObjetivos.Location = new Point(171, 116);
            btnVerObjetivos.Name = "btnVerObjetivos";
            btnVerObjetivos.Size = new Size(90, 23);
            btnVerObjetivos.TabIndex = 33;
            btnVerObjetivos.Text = "Ver objetivos";
            btnVerObjetivos.UseVisualStyleBackColor = true;
            btnVerObjetivos.Click += btnVerObjetivos_Click;
            // 
            // btnRegistrarObjetivo
            // 
            btnRegistrarObjetivo.Location = new Point(49, 116);
            btnRegistrarObjetivo.Name = "btnRegistrarObjetivo";
            btnRegistrarObjetivo.Size = new Size(107, 23);
            btnRegistrarObjetivo.TabIndex = 32;
            btnRegistrarObjetivo.Text = "Registrar objetivo";
            btnRegistrarObjetivo.UseVisualStyleBackColor = true;
            btnRegistrarObjetivo.Click += btnRegistrarObjetivo_Click;
            // 
            // dtpFechaLimiteObjetivo
            // 
            dtpFechaLimiteObjetivo.Format = DateTimePickerFormat.Short;
            dtpFechaLimiteObjetivo.Location = new Point(243, 76);
            dtpFechaLimiteObjetivo.Name = "dtpFechaLimiteObjetivo";
            dtpFechaLimiteObjetivo.Size = new Size(121, 23);
            dtpFechaLimiteObjetivo.TabIndex = 31;
            // 
            // nudValorObjetivo
            // 
            nudValorObjetivo.DecimalPlaces = 2;
            nudValorObjetivo.Location = new Point(49, 76);
            nudValorObjetivo.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudValorObjetivo.Name = "nudValorObjetivo";
            nudValorObjetivo.Size = new Size(121, 23);
            nudValorObjetivo.TabIndex = 30;
            // 
            // cboDireccionObjetivo
            // 
            cboDireccionObjetivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDireccionObjetivo.FormattingEnabled = true;
            cboDireccionObjetivo.Location = new Point(243, 35);
            cboDireccionObjetivo.Name = "cboDireccionObjetivo";
            cboDireccionObjetivo.Size = new Size(121, 23);
            cboDireccionObjetivo.TabIndex = 29;
            // 
            // cboTipoObjetivo
            // 
            cboTipoObjetivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoObjetivo.FormattingEnabled = true;
            cboTipoObjetivo.Location = new Point(49, 35);
            cboTipoObjetivo.Name = "cboTipoObjetivo";
            cboTipoObjetivo.Size = new Size(121, 23);
            cboTipoObjetivo.TabIndex = 28;
            // 
            // Visitas
            // 
            Visitas.Controls.Add(lstHistorialVisitas);
            Visitas.Controls.Add(btnVerVisitas);
            Visitas.Controls.Add(btnRegistrarVisita);
            Visitas.Location = new Point(4, 24);
            Visitas.Name = "Visitas";
            Visitas.Size = new Size(758, 480);
            Visitas.TabIndex = 4;
            Visitas.Text = "Visitas";
            Visitas.UseVisualStyleBackColor = true;
            // 
            // lstHistorialVisitas
            // 
            lstHistorialVisitas.FormattingEnabled = true;
            lstHistorialVisitas.Location = new Point(15, 66);
            lstHistorialVisitas.Name = "lstHistorialVisitas";
            lstHistorialVisitas.Size = new Size(343, 94);
            lstHistorialVisitas.TabIndex = 31;
            // 
            // btnVerVisitas
            // 
            btnVerVisitas.Location = new Point(125, 19);
            btnVerVisitas.Name = "btnVerVisitas";
            btnVerVisitas.Size = new Size(86, 23);
            btnVerVisitas.TabIndex = 30;
            btnVerVisitas.Text = "Ver historial";
            btnVerVisitas.UseVisualStyleBackColor = true;
            btnVerVisitas.Click += btnVerVisitas_Click;
            // 
            // btnRegistrarVisita
            // 
            btnRegistrarVisita.Location = new Point(15, 19);
            btnRegistrarVisita.Name = "btnRegistrarVisita";
            btnRegistrarVisita.Size = new Size(94, 23);
            btnRegistrarVisita.TabIndex = 29;
            btnRegistrarVisita.Text = "Registrar visita";
            btnRegistrarVisita.UseVisualStyleBackColor = true;
            btnRegistrarVisita.Click += btnRegistrarVisita_Click;
            // 
            // Insignias
            // 
            Insignias.Controls.Add(lstInsignias);
            Insignias.Controls.Add(btnVerInsignias);
            Insignias.Location = new Point(4, 24);
            Insignias.Name = "Insignias";
            Insignias.Padding = new Padding(3);
            Insignias.Size = new Size(758, 480);
            Insignias.TabIndex = 5;
            Insignias.Text = "Insignias";
            Insignias.UseVisualStyleBackColor = true;
            // 
            // lstInsignias
            // 
            lstInsignias.FormattingEnabled = true;
            lstInsignias.Location = new Point(6, 64);
            lstInsignias.Name = "lstInsignias";
            lstInsignias.Size = new Size(393, 94);
            lstInsignias.TabIndex = 1;
            // 
            // btnVerInsignias
            // 
            btnVerInsignias.Location = new Point(6, 24);
            btnVerInsignias.Name = "btnVerInsignias";
            btnVerInsignias.Size = new Size(87, 23);
            btnVerInsignias.TabIndex = 0;
            btnVerInsignias.Text = "Ver insignias";
            btnVerInsignias.UseVisualStyleBackColor = true;
            btnVerInsignias.Click += btnVerInsignias_Click;
            // 
            // Notificaciones
            // 
            Notificaciones.Controls.Add(lstNotificaciones);
            Notificaciones.Controls.Add(btnVerNotificaciones);
            Notificaciones.Location = new Point(4, 24);
            Notificaciones.Name = "Notificaciones";
            Notificaciones.Padding = new Padding(3);
            Notificaciones.Size = new Size(758, 480);
            Notificaciones.TabIndex = 6;
            Notificaciones.Text = "Notificaciones";
            Notificaciones.UseVisualStyleBackColor = true;
            // 
            // lstNotificaciones
            // 
            lstNotificaciones.FormattingEnabled = true;
            lstNotificaciones.Location = new Point(6, 65);
            lstNotificaciones.Name = "lstNotificaciones";
            lstNotificaciones.Size = new Size(527, 94);
            lstNotificaciones.TabIndex = 1;
            // 
            // btnVerNotificaciones
            // 
            btnVerNotificaciones.Location = new Point(6, 23);
            btnVerNotificaciones.Name = "btnVerNotificaciones";
            btnVerNotificaciones.Size = new Size(108, 23);
            btnVerNotificaciones.TabIndex = 0;
            btnVerNotificaciones.Text = "Ver notificaciones";
            btnVerNotificaciones.UseVisualStyleBackColor = true;
            btnVerNotificaciones.Click += btnVerNotificaciones_Click;
            // 
            // Estadisticas
            // 
            Estadisticas.Controls.Add(lstMenosVisitantes);
            Estadisticas.Controls.Add(label6);
            Estadisticas.Controls.Add(lstMasVisitantes);
            Estadisticas.Controls.Add(label5);
            Estadisticas.Controls.Add(btnVerTopVisitas);
            Estadisticas.Controls.Add(lstProgresoObjetivos);
            Estadisticas.Controls.Add(btnVerProgresoObjetivos);
            Estadisticas.Controls.Add(lstAumentosCarga);
            Estadisticas.Controls.Add(btnVerAumentosCarga);
            Estadisticas.Controls.Add(dtpEstadisticasHasta);
            Estadisticas.Controls.Add(label4);
            Estadisticas.Controls.Add(dtpEstadisticasDesde);
            Estadisticas.Controls.Add(label3);
            Estadisticas.Location = new Point(4, 24);
            Estadisticas.Name = "Estadisticas";
            Estadisticas.Padding = new Padding(3);
            Estadisticas.Size = new Size(758, 480);
            Estadisticas.TabIndex = 7;
            Estadisticas.Text = "Estadisticas";
            Estadisticas.UseVisualStyleBackColor = true;
            // 
            // lstMenosVisitantes
            // 
            lstMenosVisitantes.FormattingEnabled = true;
            lstMenosVisitantes.Location = new Point(601, 104);
            lstMenosVisitantes.Name = "lstMenosVisitantes";
            lstMenosVisitantes.Size = new Size(127, 289);
            lstMenosVisitantes.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(601, 69);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 11;
            label6.Text = "Menos visitas";
            // 
            // lstMasVisitantes
            // 
            lstMasVisitantes.FormattingEnabled = true;
            lstMasVisitantes.Location = new Point(449, 104);
            lstMasVisitantes.Name = "lstMasVisitantes";
            lstMasVisitantes.Size = new Size(128, 289);
            lstMasVisitantes.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(450, 69);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 9;
            label5.Text = "Más visitas";
            // 
            // btnVerTopVisitas
            // 
            btnVerTopVisitas.Location = new Point(444, 24);
            btnVerTopVisitas.Name = "btnVerTopVisitas";
            btnVerTopVisitas.Size = new Size(122, 23);
            btnVerTopVisitas.TabIndex = 8;
            btnVerTopVisitas.Text = "Ver top 10 de visitas";
            btnVerTopVisitas.UseVisualStyleBackColor = true;
            btnVerTopVisitas.Click += btnVerTopVisitas_Click;
            // 
            // lstProgresoObjetivos
            // 
            lstProgresoObjetivos.FormattingEnabled = true;
            lstProgresoObjetivos.Location = new Point(7, 300);
            lstProgresoObjetivos.Name = "lstProgresoObjetivos";
            lstProgresoObjetivos.Size = new Size(427, 94);
            lstProgresoObjetivos.TabIndex = 7;
            // 
            // btnVerProgresoObjetivos
            // 
            btnVerProgresoObjetivos.Location = new Point(7, 255);
            btnVerProgresoObjetivos.Name = "btnVerProgresoObjetivos";
            btnVerProgresoObjetivos.Size = new Size(148, 23);
            btnVerProgresoObjetivos.TabIndex = 6;
            btnVerProgresoObjetivos.Text = "Ver progreso de objetivos";
            btnVerProgresoObjetivos.UseVisualStyleBackColor = true;
            btnVerProgresoObjetivos.Click += btnVerProgresoObjetivos_Click;
            // 
            // lstAumentosCarga
            // 
            lstAumentosCarga.FormattingEnabled = true;
            lstAumentosCarga.Location = new Point(7, 144);
            lstAumentosCarga.Name = "lstAumentosCarga";
            lstAumentosCarga.Size = new Size(427, 94);
            lstAumentosCarga.TabIndex = 5;
            // 
            // btnVerAumentosCarga
            // 
            btnVerAumentosCarga.Location = new Point(7, 105);
            btnVerAumentosCarga.Name = "btnVerAumentosCarga";
            btnVerAumentosCarga.Size = new Size(142, 23);
            btnVerAumentosCarga.TabIndex = 4;
            btnVerAumentosCarga.Text = "Ver aumentos de carga";
            btnVerAumentosCarga.UseVisualStyleBackColor = true;
            btnVerAumentosCarga.Click += btnVerAumentosCarga_Click;
            // 
            // dtpEstadisticasHasta
            // 
            dtpEstadisticasHasta.Format = DateTimePickerFormat.Short;
            dtpEstadisticasHasta.Location = new Point(51, 58);
            dtpEstadisticasHasta.Name = "dtpEstadisticasHasta";
            dtpEstadisticasHasta.Size = new Size(98, 23);
            dtpEstadisticasHasta.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 64);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 2;
            label4.Text = "Hasta";
            // 
            // dtpEstadisticasDesde
            // 
            dtpEstadisticasDesde.Format = DateTimePickerFormat.Short;
            dtpEstadisticasDesde.Location = new Point(51, 18);
            dtpEstadisticasDesde.Name = "dtpEstadisticasDesde";
            dtpEstadisticasDesde.Size = new Size(98, 23);
            dtpEstadisticasDesde.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 24);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 0;
            label3.Text = "Desde";
            // 
            // FormMenuUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 585);
            Controls.Add(tabControl1);
            Controls.Add(lblEntrenadorAsignado);
            Name = "FormMenuUsuario";
            Text = "FitCR - Menú de Usuario";
            tabControl1.ResumeLayout(false);
            Clases.ResumeLayout(false);
            Rutinas.ResumeLayout(false);
            Rutinas.PerformLayout();
            Mediciones.ResumeLayout(false);
            Mediciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMusculo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGrasa).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPesoMedicion).EndInit();
            Objetivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudValorObjetivo).EndInit();
            Visitas.ResumeLayout(false);
            Insignias.ResumeLayout(false);
            Notificaciones.ResumeLayout(false);
            Estadisticas.ResumeLayout(false);
            Estadisticas.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label lblEntrenadorAsignado;
        private TabControl tabControl1;
        private TabPage Clases;
        private TabPage Rutinas;
        private TabPage Mediciones;
        private TabPage Objetivos;
        private TabPage Visitas;
        private ListBox lstHistorialVisitas;
        private Button btnVerVisitas;
        private Button btnRegistrarVisita;
        private ListBox lstHistorialClases;
        private Button btnVerHistorialClases;
        private Button btnRegistrarParticipacion;
        private ListBox lstClases;
        private Button btnVerClases;
        private ListBox lstHistorialCargas;
        private Label label1;
        private ListBox lstDetalleEjercicios;
        private Label lblVigenciaRutina;
        private ListBox lstRutinas;
        private Button btnVerRutinas;
        private Label label2;
        private ListBox lstHistorialMediciones;
        private Button btnVerMediciones;
        private Button btnRegistrarMedicion;
        private NumericUpDown nudMusculo;
        private CheckBox chkIncluirMusculo;
        private NumericUpDown nudGrasa;
        private CheckBox chkIncluirGrasa;
        private NumericUpDown nudPesoMedicion;
        private ListBox lstObjetivos;
        private Button btnVerObjetivos;
        private Button btnRegistrarObjetivo;
        private DateTimePicker dtpFechaLimiteObjetivo;
        private NumericUpDown nudValorObjetivo;
        private ComboBox cboDireccionObjetivo;
        private ComboBox cboTipoObjetivo;
        private TabPage Insignias;
        private ListBox lstInsignias;
        private Button btnVerInsignias;
        private TabPage Notificaciones;
        private Button btnVerNotificaciones;
        private ListBox lstNotificaciones;
        private TabPage Estadisticas;
        private DateTimePicker dtpEstadisticasDesde;
        private Label label3;
        private ListBox lstAumentosCarga;
        private Button btnVerAumentosCarga;
        private DateTimePicker dtpEstadisticasHasta;
        private Label label4;
        private Button btnVerProgresoObjetivos;
        private ListBox lstProgresoObjetivos;
        private Label label6;
        private ListBox lstMasVisitantes;
        private Label label5;
        private Button btnVerTopVisitas;
        private ListBox lstMenosVisitantes;
    }
}