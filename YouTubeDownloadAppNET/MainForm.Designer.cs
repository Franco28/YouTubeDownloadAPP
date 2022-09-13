namespace YouTubeDownload
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonComenzarDescarga = new System.Windows.Forms.Button();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelRuta = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelEstado = new System.Windows.Forms.Label();
            this.buttonGoToFolder = new System.Windows.Forms.Button();
            this.buttonConvertir = new System.Windows.Forms.Button();
            this.labelInfoDuracion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelInfoTipo = new System.Windows.Forms.Label();
            this.labelInfoFormatoAudio = new System.Windows.Forms.Label();
            this.labelAudioBitrate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxAudioFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonWAV = new System.Windows.Forms.RadioButton();
            this.radioButtonMP3 = new System.Windows.Forms.RadioButton();
            this.labelOpcionesTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxGuardarVideo = new System.Windows.Forms.GroupBox();
            this.radioButtonGuardarVideoNo = new System.Windows.Forms.RadioButton();
            this.radioButtonGuardarVideoSi = new System.Windows.Forms.RadioButton();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.labelMetadatos = new System.Windows.Forms.Label();
            this.textBoxTituloCancion = new System.Windows.Forms.TextBox();
            this.labelMDTitulo = new System.Windows.Forms.Label();
            this.labelMDComment = new System.Windows.Forms.Label();
            this.textBoxComentario = new System.Windows.Forms.TextBox();
            this.labelMDArtista = new System.Windows.Forms.Label();
            this.textBoxArtista = new System.Windows.Forms.TextBox();
            this.buttonEditAudio = new System.Windows.Forms.Button();
            this.labelTmanoArchivo = new System.Windows.Forms.Label();
            this.groupBoxAuBitrate = new System.Windows.Forms.GroupBox();
            this.radioButtonAB16 = new System.Windows.Forms.RadioButton();
            this.radioButtonAB32 = new System.Windows.Forms.RadioButton();
            this.radioButtonAB96 = new System.Windows.Forms.RadioButton();
            this.radioButtonAB128 = new System.Windows.Forms.RadioButton();
            this.radioButtonAB196 = new System.Windows.Forms.RadioButton();
            this.radioButtonAB320 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxAudioFormat.SuspendLayout();
            this.groupBoxGuardarVideo.SuspendLayout();
            this.groupBoxAuBitrate.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.textBoxURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxURL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxURL.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxURL.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxURL.Location = new System.Drawing.Point(9, 92);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(724, 29);
            this.textBoxURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese un LINK de YouTube";
            // 
            // buttonComenzarDescarga
            // 
            this.buttonComenzarDescarga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonComenzarDescarga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonComenzarDescarga.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.buttonComenzarDescarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonComenzarDescarga.Location = new System.Drawing.Point(5, 557);
            this.buttonComenzarDescarga.Name = "buttonComenzarDescarga";
            this.buttonComenzarDescarga.Size = new System.Drawing.Size(796, 38);
            this.buttonComenzarDescarga.TabIndex = 2;
            this.buttonComenzarDescarga.TabStop = false;
            this.buttonComenzarDescarga.Text = "Comenzar Descarga";
            this.buttonComenzarDescarga.UseVisualStyleBackColor = true;
            this.buttonComenzarDescarga.Click += new System.EventHandler(this.buttonComenzarDescarga_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxNombre.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxNombre.Location = new System.Drawing.Point(10, 189);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(723, 29);
            this.textBoxNombre.TabIndex = 1;
            // 
            // labelRuta
            // 
            this.labelRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRuta.AutoSize = true;
            this.labelRuta.ForeColor = System.Drawing.Color.Silver;
            this.labelRuta.Location = new System.Drawing.Point(5, 28);
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Size = new System.Drawing.Size(132, 21);
            this.labelRuta.TabIndex = 5;
            this.labelRuta.Text = "Ruta de descarga:";
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 628);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1019, 29);
            this.progressBar1.TabIndex = 6;
            // 
            // labelEstado
            // 
            this.labelEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEstado.ForeColor = System.Drawing.Color.Red;
            this.labelEstado.Location = new System.Drawing.Point(0, 607);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(1019, 21);
            this.labelEstado.TabIndex = 7;
            this.labelEstado.Text = "Estado:";
            // 
            // buttonGoToFolder
            // 
            this.buttonGoToFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGoToFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoToFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.buttonGoToFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoToFolder.Location = new System.Drawing.Point(739, 350);
            this.buttonGoToFolder.Name = "buttonGoToFolder";
            this.buttonGoToFolder.Size = new System.Drawing.Size(268, 36);
            this.buttonGoToFolder.TabIndex = 8;
            this.buttonGoToFolder.TabStop = false;
            this.buttonGoToFolder.Text = "Ir a la carpeta de descarga";
            this.buttonGoToFolder.UseVisualStyleBackColor = true;
            this.buttonGoToFolder.Click += new System.EventHandler(this.buttonGoToFolder_Click);
            // 
            // buttonConvertir
            // 
            this.buttonConvertir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvertir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConvertir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.buttonConvertir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConvertir.Location = new System.Drawing.Point(10, 231);
            this.buttonConvertir.Name = "buttonConvertir";
            this.buttonConvertir.Size = new System.Drawing.Size(723, 38);
            this.buttonConvertir.TabIndex = 2;
            this.buttonConvertir.Text = "Obtener Datos Del Link";
            this.buttonConvertir.UseVisualStyleBackColor = true;
            this.buttonConvertir.Click += new System.EventHandler(this.buttonConvertir_Click);
            // 
            // labelInfoDuracion
            // 
            this.labelInfoDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfoDuracion.AutoSize = true;
            this.labelInfoDuracion.Location = new System.Drawing.Point(735, 242);
            this.labelInfoDuracion.Name = "labelInfoDuracion";
            this.labelInfoDuracion.Size = new System.Drawing.Size(76, 21);
            this.labelInfoDuracion.TabIndex = 9;
            this.labelInfoDuracion.Text = "Duración:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(739, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // labelInfoTipo
            // 
            this.labelInfoTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfoTipo.AutoSize = true;
            this.labelInfoTipo.Location = new System.Drawing.Point(735, 263);
            this.labelInfoTipo.Name = "labelInfoTipo";
            this.labelInfoTipo.Size = new System.Drawing.Size(116, 21);
            this.labelInfoTipo.TabIndex = 11;
            this.labelInfoTipo.Text = "Formato Video:";
            // 
            // labelInfoFormatoAudio
            // 
            this.labelInfoFormatoAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfoFormatoAudio.AutoSize = true;
            this.labelInfoFormatoAudio.Location = new System.Drawing.Point(735, 284);
            this.labelInfoFormatoAudio.Name = "labelInfoFormatoAudio";
            this.labelInfoFormatoAudio.Size = new System.Drawing.Size(117, 21);
            this.labelInfoFormatoAudio.TabIndex = 12;
            this.labelInfoFormatoAudio.Text = "Formato Audio:";
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(735, 305);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(103, 21);
            this.labelAudioBitrate.TabIndex = 13;
            this.labelAudioBitrate.Text = "Audio Bitrate:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(7, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(471, 33);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ingrese un NOMBRE para asignar al audio a guardar";
            // 
            // labelRed
            // 
            this.labelRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(5, 4);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(40, 21);
            this.labelRed.TabIndex = 15;
            this.labelRed.Text = "Red:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "(opcional, al obtener los datos se asgina un nombre)";
            // 
            // groupBoxAudioFormat
            // 
            this.groupBoxAudioFormat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAudioFormat.Controls.Add(this.radioButtonWAV);
            this.groupBoxAudioFormat.Controls.Add(this.radioButtonMP3);
            this.groupBoxAudioFormat.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBoxAudioFormat.Location = new System.Drawing.Point(12, 317);
            this.groupBoxAudioFormat.Name = "groupBoxAudioFormat";
            this.groupBoxAudioFormat.Size = new System.Drawing.Size(143, 62);
            this.groupBoxAudioFormat.TabIndex = 17;
            this.groupBoxAudioFormat.TabStop = false;
            this.groupBoxAudioFormat.Text = "Formato Audio";
            // 
            // radioButtonWAV
            // 
            this.radioButtonWAV.AutoSize = true;
            this.radioButtonWAV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonWAV.Location = new System.Drawing.Point(76, 29);
            this.radioButtonWAV.Name = "radioButtonWAV";
            this.radioButtonWAV.Size = new System.Drawing.Size(59, 25);
            this.radioButtonWAV.TabIndex = 1;
            this.radioButtonWAV.Text = ".wav";
            this.radioButtonWAV.UseVisualStyleBackColor = true;
            this.radioButtonWAV.CheckedChanged += new System.EventHandler(this.radioButtonWAV_CheckedChanged);
            // 
            // radioButtonMP3
            // 
            this.radioButtonMP3.AutoSize = true;
            this.radioButtonMP3.Checked = true;
            this.radioButtonMP3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonMP3.Location = new System.Drawing.Point(7, 29);
            this.radioButtonMP3.Name = "radioButtonMP3";
            this.radioButtonMP3.Size = new System.Drawing.Size(63, 25);
            this.radioButtonMP3.TabIndex = 0;
            this.radioButtonMP3.TabStop = true;
            this.radioButtonMP3.Text = ".mp3";
            this.radioButtonMP3.UseVisualStyleBackColor = true;
            this.radioButtonMP3.CheckedChanged += new System.EventHandler(this.radioButtonMP3_CheckedChanged);
            // 
            // labelOpcionesTitle
            // 
            this.labelOpcionesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOpcionesTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelOpcionesTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOpcionesTitle.Location = new System.Drawing.Point(12, 278);
            this.labelOpcionesTitle.Name = "labelOpcionesTitle";
            this.labelOpcionesTitle.Size = new System.Drawing.Size(702, 33);
            this.labelOpcionesTitle.TabIndex = 19;
            this.labelOpcionesTitle.Text = "Opciones";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(739, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 33);
            this.label5.TabIndex = 20;
            this.label5.Text = "Información del video";
            // 
            // groupBoxGuardarVideo
            // 
            this.groupBoxGuardarVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGuardarVideo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxGuardarVideo.Controls.Add(this.radioButtonGuardarVideoNo);
            this.groupBoxGuardarVideo.Controls.Add(this.radioButtonGuardarVideoSi);
            this.groupBoxGuardarVideo.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBoxGuardarVideo.Location = new System.Drawing.Point(514, 317);
            this.groupBoxGuardarVideo.Name = "groupBoxGuardarVideo";
            this.groupBoxGuardarVideo.Size = new System.Drawing.Size(200, 62);
            this.groupBoxGuardarVideo.TabIndex = 18;
            this.groupBoxGuardarVideo.TabStop = false;
            this.groupBoxGuardarVideo.Text = "Guardar Video";
            // 
            // radioButtonGuardarVideoNo
            // 
            this.radioButtonGuardarVideoNo.AutoSize = true;
            this.radioButtonGuardarVideoNo.Checked = true;
            this.radioButtonGuardarVideoNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonGuardarVideoNo.Location = new System.Drawing.Point(76, 29);
            this.radioButtonGuardarVideoNo.Name = "radioButtonGuardarVideoNo";
            this.radioButtonGuardarVideoNo.Size = new System.Drawing.Size(49, 25);
            this.radioButtonGuardarVideoNo.TabIndex = 1;
            this.radioButtonGuardarVideoNo.TabStop = true;
            this.radioButtonGuardarVideoNo.Text = "No";
            this.radioButtonGuardarVideoNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonGuardarVideoSi
            // 
            this.radioButtonGuardarVideoSi.AutoSize = true;
            this.radioButtonGuardarVideoSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonGuardarVideoSi.Location = new System.Drawing.Point(7, 29);
            this.radioButtonGuardarVideoSi.Name = "radioButtonGuardarVideoSi";
            this.radioButtonGuardarVideoSi.Size = new System.Drawing.Size(41, 25);
            this.radioButtonGuardarVideoSi.TabIndex = 0;
            this.radioButtonGuardarVideoSi.Text = "Sí";
            this.radioButtonGuardarVideoSi.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.Image = ((System.Drawing.Image)(resources.GetObject("buttonHelp.Image")));
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(807, 585);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(200, 37);
            this.buttonHelp.TabIndex = 21;
            this.buttonHelp.Text = "App Info";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // labelMetadatos
            // 
            this.labelMetadatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMetadatos.BackColor = System.Drawing.Color.Transparent;
            this.labelMetadatos.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMetadatos.Location = new System.Drawing.Point(12, 390);
            this.labelMetadatos.Name = "labelMetadatos";
            this.labelMetadatos.Size = new System.Drawing.Size(702, 33);
            this.labelMetadatos.TabIndex = 22;
            this.labelMetadatos.Text = "Asignar MetaDatos";
            // 
            // textBoxTituloCancion
            // 
            this.textBoxTituloCancion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTituloCancion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.textBoxTituloCancion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTituloCancion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTituloCancion.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxTituloCancion.Location = new System.Drawing.Point(12, 454);
            this.textBoxTituloCancion.Name = "textBoxTituloCancion";
            this.textBoxTituloCancion.Size = new System.Drawing.Size(245, 29);
            this.textBoxTituloCancion.TabIndex = 23;
            this.textBoxTituloCancion.TabStop = false;
            // 
            // labelMDTitulo
            // 
            this.labelMDTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMDTitulo.AutoSize = true;
            this.labelMDTitulo.Location = new System.Drawing.Point(12, 430);
            this.labelMDTitulo.Name = "labelMDTitulo";
            this.labelMDTitulo.Size = new System.Drawing.Size(49, 21);
            this.labelMDTitulo.TabIndex = 24;
            this.labelMDTitulo.Text = "Título";
            // 
            // labelMDComment
            // 
            this.labelMDComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMDComment.AutoSize = true;
            this.labelMDComment.Location = new System.Drawing.Point(263, 430);
            this.labelMDComment.Name = "labelMDComment";
            this.labelMDComment.Size = new System.Drawing.Size(92, 21);
            this.labelMDComment.TabIndex = 26;
            this.labelMDComment.Text = "Comentario";
            // 
            // textBoxComentario
            // 
            this.textBoxComentario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.textBoxComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxComentario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxComentario.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxComentario.Location = new System.Drawing.Point(263, 454);
            this.textBoxComentario.Multiline = true;
            this.textBoxComentario.Name = "textBoxComentario";
            this.textBoxComentario.Size = new System.Drawing.Size(538, 84);
            this.textBoxComentario.TabIndex = 25;
            this.textBoxComentario.TabStop = false;
            // 
            // labelMDArtista
            // 
            this.labelMDArtista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMDArtista.AutoSize = true;
            this.labelMDArtista.Location = new System.Drawing.Point(12, 485);
            this.labelMDArtista.Name = "labelMDArtista";
            this.labelMDArtista.Size = new System.Drawing.Size(55, 21);
            this.labelMDArtista.TabIndex = 28;
            this.labelMDArtista.Text = "Artista";
            // 
            // textBoxArtista
            // 
            this.textBoxArtista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxArtista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.textBoxArtista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxArtista.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxArtista.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxArtista.Location = new System.Drawing.Point(12, 509);
            this.textBoxArtista.Name = "textBoxArtista";
            this.textBoxArtista.Size = new System.Drawing.Size(245, 29);
            this.textBoxArtista.TabIndex = 27;
            this.textBoxArtista.TabStop = false;
            // 
            // buttonEditAudio
            // 
            this.buttonEditAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditAudio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEditAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditAudio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.buttonEditAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditAudio.Location = new System.Drawing.Point(807, 542);
            this.buttonEditAudio.Name = "buttonEditAudio";
            this.buttonEditAudio.Size = new System.Drawing.Size(200, 37);
            this.buttonEditAudio.TabIndex = 30;
            this.buttonEditAudio.Text = "Editar Audio";
            this.buttonEditAudio.UseVisualStyleBackColor = true;
            this.buttonEditAudio.Click += new System.EventHandler(this.buttonEditAudio_Click);
            // 
            // labelTmanoArchivo
            // 
            this.labelTmanoArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTmanoArchivo.AutoSize = true;
            this.labelTmanoArchivo.Location = new System.Drawing.Point(735, 326);
            this.labelTmanoArchivo.Name = "labelTmanoArchivo";
            this.labelTmanoArchivo.Size = new System.Drawing.Size(168, 21);
            this.labelTmanoArchivo.TabIndex = 31;
            this.labelTmanoArchivo.Text = "Tamañano Del Archivo:";
            // 
            // groupBoxAuBitrate
            // 
            this.groupBoxAuBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAuBitrate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxAuBitrate.Controls.Add(this.radioButtonAB16);
            this.groupBoxAuBitrate.Controls.Add(this.radioButtonAB32);
            this.groupBoxAuBitrate.Controls.Add(this.radioButtonAB96);
            this.groupBoxAuBitrate.Controls.Add(this.radioButtonAB128);
            this.groupBoxAuBitrate.Controls.Add(this.radioButtonAB196);
            this.groupBoxAuBitrate.Controls.Add(this.radioButtonAB320);
            this.groupBoxAuBitrate.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBoxAuBitrate.Location = new System.Drawing.Point(161, 317);
            this.groupBoxAuBitrate.Name = "groupBoxAuBitrate";
            this.groupBoxAuBitrate.Size = new System.Drawing.Size(347, 62);
            this.groupBoxAuBitrate.TabIndex = 18;
            this.groupBoxAuBitrate.TabStop = false;
            this.groupBoxAuBitrate.Text = "Audio Bitrate / kbps";
            // 
            // radioButtonAB16
            // 
            this.radioButtonAB16.AutoSize = true;
            this.radioButtonAB16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonAB16.Location = new System.Drawing.Point(294, 29);
            this.radioButtonAB16.Name = "radioButtonAB16";
            this.radioButtonAB16.Size = new System.Drawing.Size(46, 25);
            this.radioButtonAB16.TabIndex = 5;
            this.radioButtonAB16.Text = "16";
            this.radioButtonAB16.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB32
            // 
            this.radioButtonAB32.AutoSize = true;
            this.radioButtonAB32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonAB32.Location = new System.Drawing.Point(242, 29);
            this.radioButtonAB32.Name = "radioButtonAB32";
            this.radioButtonAB32.Size = new System.Drawing.Size(46, 25);
            this.radioButtonAB32.TabIndex = 4;
            this.radioButtonAB32.Text = "32";
            this.radioButtonAB32.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB96
            // 
            this.radioButtonAB96.AutoSize = true;
            this.radioButtonAB96.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonAB96.Location = new System.Drawing.Point(190, 29);
            this.radioButtonAB96.Name = "radioButtonAB96";
            this.radioButtonAB96.Size = new System.Drawing.Size(46, 25);
            this.radioButtonAB96.TabIndex = 3;
            this.radioButtonAB96.Text = "96";
            this.radioButtonAB96.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB128
            // 
            this.radioButtonAB128.AutoSize = true;
            this.radioButtonAB128.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonAB128.Location = new System.Drawing.Point(129, 29);
            this.radioButtonAB128.Name = "radioButtonAB128";
            this.radioButtonAB128.Size = new System.Drawing.Size(55, 25);
            this.radioButtonAB128.TabIndex = 2;
            this.radioButtonAB128.Text = "128";
            this.radioButtonAB128.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB196
            // 
            this.radioButtonAB196.AutoSize = true;
            this.radioButtonAB196.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonAB196.Location = new System.Drawing.Point(68, 29);
            this.radioButtonAB196.Name = "radioButtonAB196";
            this.radioButtonAB196.Size = new System.Drawing.Size(55, 25);
            this.radioButtonAB196.TabIndex = 1;
            this.radioButtonAB196.Text = "192";
            this.radioButtonAB196.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB320
            // 
            this.radioButtonAB320.AutoSize = true;
            this.radioButtonAB320.Checked = true;
            this.radioButtonAB320.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonAB320.Location = new System.Drawing.Point(7, 29);
            this.radioButtonAB320.Name = "radioButtonAB320";
            this.radioButtonAB320.Size = new System.Drawing.Size(55, 25);
            this.radioButtonAB320.TabIndex = 0;
            this.radioButtonAB320.TabStop = true;
            this.radioButtonAB320.Text = "320";
            this.radioButtonAB320.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1019, 657);
            this.Controls.Add(this.groupBoxAuBitrate);
            this.Controls.Add(this.labelTmanoArchivo);
            this.Controls.Add(this.buttonEditAudio);
            this.Controls.Add(this.labelMDArtista);
            this.Controls.Add(this.textBoxArtista);
            this.Controls.Add(this.labelMDComment);
            this.Controls.Add(this.textBoxComentario);
            this.Controls.Add(this.labelMDTitulo);
            this.Controls.Add(this.textBoxTituloCancion);
            this.Controls.Add(this.labelMetadatos);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.groupBoxGuardarVideo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelOpcionesTitle);
            this.Controls.Add(this.groupBoxAudioFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAudioBitrate);
            this.Controls.Add(this.labelInfoFormatoAudio);
            this.Controls.Add(this.labelInfoTipo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelInfoDuracion);
            this.Controls.Add(this.buttonConvertir);
            this.Controls.Add(this.buttonGoToFolder);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelRuta);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.buttonComenzarDescarga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxURL);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descargar Música Y Videos De YouTube - Por @Franco28";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DescargarMusica_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DescargarMusica_FormClosed);
            this.Load += new System.EventHandler(this.DescargarMusica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxAudioFormat.ResumeLayout(false);
            this.groupBoxAudioFormat.PerformLayout();
            this.groupBoxGuardarVideo.ResumeLayout(false);
            this.groupBoxGuardarVideo.PerformLayout();
            this.groupBoxAuBitrate.ResumeLayout(false);
            this.groupBoxAuBitrate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonComenzarDescarga;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelRuta;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Button buttonGoToFolder;
        private System.Windows.Forms.Button buttonConvertir;
        private System.Windows.Forms.Label labelInfoDuracion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelInfoTipo;
        private System.Windows.Forms.Label labelInfoFormatoAudio;
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxAudioFormat;
        private System.Windows.Forms.RadioButton radioButtonWAV;
        private System.Windows.Forms.RadioButton radioButtonMP3;
        private System.Windows.Forms.Label labelOpcionesTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxGuardarVideo;
        private System.Windows.Forms.RadioButton radioButtonGuardarVideoNo;
        private System.Windows.Forms.RadioButton radioButtonGuardarVideoSi;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label labelMetadatos;
        private System.Windows.Forms.TextBox textBoxTituloCancion;
        private System.Windows.Forms.Label labelMDTitulo;
        private System.Windows.Forms.Label labelMDComment;
        private System.Windows.Forms.TextBox textBoxComentario;
        private System.Windows.Forms.Label labelMDArtista;
        private System.Windows.Forms.TextBox textBoxArtista;
        private System.Windows.Forms.Button buttonEditAudio;
        private System.Windows.Forms.Label labelTmanoArchivo;
        private System.Windows.Forms.GroupBox groupBoxAuBitrate;
        private System.Windows.Forms.RadioButton radioButtonAB16;
        private System.Windows.Forms.RadioButton radioButtonAB32;
        private System.Windows.Forms.RadioButton radioButtonAB96;
        private System.Windows.Forms.RadioButton radioButtonAB128;
        private System.Windows.Forms.RadioButton radioButtonAB196;
        private System.Windows.Forms.RadioButton radioButtonAB320;
    }
}