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
            textBoxURL = new TextBox();
            label1 = new Label();
            buttonComenzarDescarga = new Button();
            labelRuta = new Label();
            progressBar1 = new ProgressBar();
            labelEstado = new Label();
            buttonGoToFolder = new Button();
            buttonConvertir = new Button();
            labelInfoDuracion = new Label();
            pictureBox1 = new PictureBox();
            labelInfoTipo = new Label();
            labelAudioBitrate = new Label();
            labelRed = new Label();
            groupBoxAudioFormat = new GroupBox();
            radioButtonWAV = new RadioButton();
            radioButtonMP3 = new RadioButton();
            labelOpcionesTitle = new Label();
            label5 = new Label();
            groupBoxGuardarVideo = new GroupBox();
            radioButtonGuardarVideoNo = new RadioButton();
            radioButtonGuardarVideoSi = new RadioButton();
            buttonHelp = new Button();
            labelMetadatos = new Label();
            textBoxTituloCancion = new TextBox();
            labelMDTitulo = new Label();
            labelMDComment = new Label();
            textBoxComentario = new TextBox();
            labelMDArtista = new Label();
            textBoxArtista = new TextBox();
            buttonEditAudio = new Button();
            labelTmanoArchivo = new Label();
            groupBoxAuBitrate = new GroupBox();
            radioButtonAB16 = new RadioButton();
            radioButtonAB32 = new RadioButton();
            radioButtonAB96 = new RadioButton();
            radioButtonAB128 = new RadioButton();
            radioButtonAB196 = new RadioButton();
            radioButtonAB320 = new RadioButton();
            textBoxNombre = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxAudioFormat.SuspendLayout();
            groupBoxGuardarVideo.SuspendLayout();
            groupBoxAuBitrate.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxURL
            // 
            textBoxURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxURL.BackColor = Color.FromArgb(34, 34, 34);
            textBoxURL.BorderStyle = BorderStyle.FixedSingle;
            textBoxURL.Cursor = Cursors.IBeam;
            textBoxURL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxURL.ForeColor = Color.Gainsboro;
            textBoxURL.Location = new Point(9, 92);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new Size(724, 29);
            textBoxURL.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold Condensed", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(3, 52);
            label1.Name = "label1";
            label1.Size = new Size(254, 33);
            label1.TabIndex = 0;
            label1.Text = "Ingrese un LINK de YouTube";
            // 
            // buttonComenzarDescarga
            // 
            buttonComenzarDescarga.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonComenzarDescarga.Cursor = Cursors.Hand;
            buttonComenzarDescarga.FlatAppearance.BorderColor = Color.Green;
            buttonComenzarDescarga.FlatStyle = FlatStyle.Flat;
            buttonComenzarDescarga.Location = new Point(12, 557);
            buttonComenzarDescarga.Name = "buttonComenzarDescarga";
            buttonComenzarDescarga.Size = new Size(995, 38);
            buttonComenzarDescarga.TabIndex = 2;
            buttonComenzarDescarga.TabStop = false;
            buttonComenzarDescarga.Text = "Comenzar Descarga";
            buttonComenzarDescarga.UseVisualStyleBackColor = true;
            buttonComenzarDescarga.Click += buttonComenzarDescarga_Click;
            // 
            // labelRuta
            // 
            labelRuta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelRuta.AutoSize = true;
            labelRuta.ForeColor = Color.Silver;
            labelRuta.Location = new Point(5, 28);
            labelRuta.Name = "labelRuta";
            labelRuta.Size = new Size(132, 21);
            labelRuta.TabIndex = 5;
            labelRuta.Text = "Ruta de descarga:";
            // 
            // progressBar1
            // 
            progressBar1.Cursor = Cursors.WaitCursor;
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 628);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1019, 29);
            progressBar1.TabIndex = 6;
            // 
            // labelEstado
            // 
            labelEstado.Dock = DockStyle.Bottom;
            labelEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelEstado.ForeColor = Color.Red;
            labelEstado.Location = new Point(0, 607);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(1019, 21);
            labelEstado.TabIndex = 7;
            labelEstado.Text = "Estado:";
            // 
            // buttonGoToFolder
            // 
            buttonGoToFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonGoToFolder.Cursor = Cursors.Hand;
            buttonGoToFolder.FlatAppearance.BorderColor = Color.FromArgb(217, 173, 173);
            buttonGoToFolder.FlatStyle = FlatStyle.Flat;
            buttonGoToFolder.Location = new Point(739, 335);
            buttonGoToFolder.Name = "buttonGoToFolder";
            buttonGoToFolder.Size = new Size(268, 36);
            buttonGoToFolder.TabIndex = 8;
            buttonGoToFolder.TabStop = false;
            buttonGoToFolder.Text = "Ir a la carpeta de descarga";
            buttonGoToFolder.UseVisualStyleBackColor = true;
            buttonGoToFolder.Click += buttonGoToFolder_Click;
            // 
            // buttonConvertir
            // 
            buttonConvertir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonConvertir.Cursor = Cursors.Hand;
            buttonConvertir.FlatAppearance.BorderColor = Color.FromArgb(217, 173, 173);
            buttonConvertir.FlatStyle = FlatStyle.Flat;
            buttonConvertir.Location = new Point(10, 127);
            buttonConvertir.Name = "buttonConvertir";
            buttonConvertir.Size = new Size(723, 38);
            buttonConvertir.TabIndex = 2;
            buttonConvertir.Text = "Obtener Datos Del Link";
            buttonConvertir.UseVisualStyleBackColor = true;
            buttonConvertir.Click += buttonConvertir_Click;
            // 
            // labelInfoDuracion
            // 
            labelInfoDuracion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelInfoDuracion.AutoSize = true;
            labelInfoDuracion.Location = new Point(735, 242);
            labelInfoDuracion.Name = "labelInfoDuracion";
            labelInfoDuracion.Size = new Size(76, 21);
            labelInfoDuracion.TabIndex = 9;
            labelInfoDuracion.Text = "Duración:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = YouTubeDownloadAppNET.Properties.Resources.favicon_144x144;
            pictureBox1.Location = new Point(739, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // labelInfoTipo
            // 
            labelInfoTipo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelInfoTipo.AutoSize = true;
            labelInfoTipo.Location = new Point(735, 263);
            labelInfoTipo.Name = "labelInfoTipo";
            labelInfoTipo.Size = new Size(72, 21);
            labelInfoTipo.TabIndex = 11;
            labelInfoTipo.Text = "Formato:";
            // 
            // labelAudioBitrate
            // 
            labelAudioBitrate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAudioBitrate.AutoSize = true;
            labelAudioBitrate.Location = new Point(735, 284);
            labelAudioBitrate.Name = "labelAudioBitrate";
            labelAudioBitrate.Size = new Size(103, 21);
            labelAudioBitrate.TabIndex = 13;
            labelAudioBitrate.Text = "Audio Bitrate:";
            // 
            // labelRed
            // 
            labelRed.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelRed.AutoSize = true;
            labelRed.Location = new Point(5, 4);
            labelRed.Name = "labelRed";
            labelRed.Size = new Size(40, 21);
            labelRed.TabIndex = 15;
            labelRed.Text = "Red:";
            // 
            // groupBoxAudioFormat
            // 
            groupBoxAudioFormat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxAudioFormat.Controls.Add(radioButtonWAV);
            groupBoxAudioFormat.Controls.Add(radioButtonMP3);
            groupBoxAudioFormat.ForeColor = Color.Gainsboro;
            groupBoxAudioFormat.Location = new Point(12, 299);
            groupBoxAudioFormat.Name = "groupBoxAudioFormat";
            groupBoxAudioFormat.Size = new Size(143, 62);
            groupBoxAudioFormat.TabIndex = 17;
            groupBoxAudioFormat.TabStop = false;
            groupBoxAudioFormat.Text = "Formato Audio";
            // 
            // radioButtonWAV
            // 
            radioButtonWAV.AutoSize = true;
            radioButtonWAV.Cursor = Cursors.Hand;
            radioButtonWAV.Location = new Point(76, 29);
            radioButtonWAV.Name = "radioButtonWAV";
            radioButtonWAV.Size = new Size(59, 25);
            radioButtonWAV.TabIndex = 1;
            radioButtonWAV.Text = ".wav";
            radioButtonWAV.UseVisualStyleBackColor = true;
            radioButtonWAV.CheckedChanged += radioButtonWAV_CheckedChanged;
            // 
            // radioButtonMP3
            // 
            radioButtonMP3.AutoSize = true;
            radioButtonMP3.Checked = true;
            radioButtonMP3.Cursor = Cursors.Hand;
            radioButtonMP3.Location = new Point(7, 29);
            radioButtonMP3.Name = "radioButtonMP3";
            radioButtonMP3.Size = new Size(63, 25);
            radioButtonMP3.TabIndex = 0;
            radioButtonMP3.TabStop = true;
            radioButtonMP3.Text = ".mp3";
            radioButtonMP3.UseVisualStyleBackColor = true;
            radioButtonMP3.CheckedChanged += radioButtonMP3_CheckedChanged;
            // 
            // labelOpcionesTitle
            // 
            labelOpcionesTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelOpcionesTitle.BackColor = Color.Transparent;
            labelOpcionesTitle.Font = new Font("Bahnschrift SemiBold Condensed", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelOpcionesTitle.Location = new Point(12, 260);
            labelOpcionesTitle.Name = "labelOpcionesTitle";
            labelOpcionesTitle.Size = new Size(245, 33);
            labelOpcionesTitle.TabIndex = 19;
            labelOpcionesTitle.Text = "Opciones";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift SemiBold Condensed", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(739, 9);
            label5.Name = "label5";
            label5.Size = new Size(205, 33);
            label5.TabIndex = 20;
            label5.Text = "Información del video";
            // 
            // groupBoxGuardarVideo
            // 
            groupBoxGuardarVideo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxGuardarVideo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxGuardarVideo.Controls.Add(radioButtonGuardarVideoNo);
            groupBoxGuardarVideo.Controls.Add(radioButtonGuardarVideoSi);
            groupBoxGuardarVideo.ForeColor = Color.Gainsboro;
            groupBoxGuardarVideo.Location = new Point(514, 299);
            groupBoxGuardarVideo.Name = "groupBoxGuardarVideo";
            groupBoxGuardarVideo.Size = new Size(200, 62);
            groupBoxGuardarVideo.TabIndex = 18;
            groupBoxGuardarVideo.TabStop = false;
            groupBoxGuardarVideo.Text = "Guardar Video";
            // 
            // radioButtonGuardarVideoNo
            // 
            radioButtonGuardarVideoNo.AutoSize = true;
            radioButtonGuardarVideoNo.Checked = true;
            radioButtonGuardarVideoNo.Cursor = Cursors.Hand;
            radioButtonGuardarVideoNo.Location = new Point(76, 29);
            radioButtonGuardarVideoNo.Name = "radioButtonGuardarVideoNo";
            radioButtonGuardarVideoNo.Size = new Size(49, 25);
            radioButtonGuardarVideoNo.TabIndex = 1;
            radioButtonGuardarVideoNo.TabStop = true;
            radioButtonGuardarVideoNo.Text = "No";
            radioButtonGuardarVideoNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonGuardarVideoSi
            // 
            radioButtonGuardarVideoSi.AutoSize = true;
            radioButtonGuardarVideoSi.Cursor = Cursors.Hand;
            radioButtonGuardarVideoSi.Location = new Point(7, 29);
            radioButtonGuardarVideoSi.Name = "radioButtonGuardarVideoSi";
            radioButtonGuardarVideoSi.Size = new Size(41, 25);
            radioButtonGuardarVideoSi.TabIndex = 0;
            radioButtonGuardarVideoSi.Text = "Sí";
            radioButtonGuardarVideoSi.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonHelp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonHelp.Cursor = Cursors.Help;
            buttonHelp.FlatAppearance.BorderColor = Color.FromArgb(217, 173, 173);
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.Image = (Image)resources.GetObject("buttonHelp.Image");
            buttonHelp.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHelp.Location = new Point(739, 387);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(268, 37);
            buttonHelp.TabIndex = 21;
            buttonHelp.Text = "App Info";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // labelMetadatos
            // 
            labelMetadatos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelMetadatos.BackColor = Color.Transparent;
            labelMetadatos.Font = new Font("Bahnschrift SemiBold Condensed", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelMetadatos.Location = new Point(12, 385);
            labelMetadatos.Name = "labelMetadatos";
            labelMetadatos.Size = new Size(245, 33);
            labelMetadatos.TabIndex = 22;
            labelMetadatos.Text = "Asignar MetaDatos";
            // 
            // textBoxTituloCancion
            // 
            textBoxTituloCancion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxTituloCancion.BackColor = Color.FromArgb(34, 34, 34);
            textBoxTituloCancion.BorderStyle = BorderStyle.FixedSingle;
            textBoxTituloCancion.Cursor = Cursors.IBeam;
            textBoxTituloCancion.ForeColor = Color.Gainsboro;
            textBoxTituloCancion.Location = new Point(12, 449);
            textBoxTituloCancion.Name = "textBoxTituloCancion";
            textBoxTituloCancion.Size = new Size(245, 29);
            textBoxTituloCancion.TabIndex = 23;
            textBoxTituloCancion.TabStop = false;
            // 
            // labelMDTitulo
            // 
            labelMDTitulo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelMDTitulo.AutoSize = true;
            labelMDTitulo.Location = new Point(12, 425);
            labelMDTitulo.Name = "labelMDTitulo";
            labelMDTitulo.Size = new Size(49, 21);
            labelMDTitulo.TabIndex = 24;
            labelMDTitulo.Text = "Título";
            // 
            // labelMDComment
            // 
            labelMDComment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelMDComment.AutoSize = true;
            labelMDComment.Location = new Point(263, 425);
            labelMDComment.Name = "labelMDComment";
            labelMDComment.Size = new Size(92, 21);
            labelMDComment.TabIndex = 26;
            labelMDComment.Text = "Comentario";
            // 
            // textBoxComentario
            // 
            textBoxComentario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxComentario.BackColor = Color.FromArgb(34, 34, 34);
            textBoxComentario.BorderStyle = BorderStyle.FixedSingle;
            textBoxComentario.Cursor = Cursors.IBeam;
            textBoxComentario.ForeColor = Color.Gainsboro;
            textBoxComentario.Location = new Point(263, 449);
            textBoxComentario.Multiline = true;
            textBoxComentario.Name = "textBoxComentario";
            textBoxComentario.Size = new Size(744, 84);
            textBoxComentario.TabIndex = 25;
            textBoxComentario.TabStop = false;
            // 
            // labelMDArtista
            // 
            labelMDArtista.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelMDArtista.AutoSize = true;
            labelMDArtista.Location = new Point(12, 480);
            labelMDArtista.Name = "labelMDArtista";
            labelMDArtista.Size = new Size(55, 21);
            labelMDArtista.TabIndex = 28;
            labelMDArtista.Text = "Artista";
            // 
            // textBoxArtista
            // 
            textBoxArtista.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxArtista.BackColor = Color.FromArgb(34, 34, 34);
            textBoxArtista.BorderStyle = BorderStyle.FixedSingle;
            textBoxArtista.Cursor = Cursors.IBeam;
            textBoxArtista.ForeColor = Color.Gainsboro;
            textBoxArtista.Location = new Point(12, 504);
            textBoxArtista.Name = "textBoxArtista";
            textBoxArtista.Size = new Size(245, 29);
            textBoxArtista.TabIndex = 27;
            textBoxArtista.TabStop = false;
            // 
            // buttonEditAudio
            // 
            buttonEditAudio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonEditAudio.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEditAudio.Cursor = Cursors.Hand;
            buttonEditAudio.FlatAppearance.BorderColor = Color.FromArgb(217, 173, 173);
            buttonEditAudio.FlatStyle = FlatStyle.Flat;
            buttonEditAudio.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEditAudio.Location = new Point(533, 387);
            buttonEditAudio.Name = "buttonEditAudio";
            buttonEditAudio.Size = new Size(200, 37);
            buttonEditAudio.TabIndex = 30;
            buttonEditAudio.Text = "Editar Audio";
            buttonEditAudio.UseVisualStyleBackColor = true;
            buttonEditAudio.Visible = false;
            buttonEditAudio.Click += buttonEditAudio_Click;
            // 
            // labelTmanoArchivo
            // 
            labelTmanoArchivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTmanoArchivo.AutoSize = true;
            labelTmanoArchivo.Location = new Point(735, 305);
            labelTmanoArchivo.Name = "labelTmanoArchivo";
            labelTmanoArchivo.Size = new Size(168, 21);
            labelTmanoArchivo.TabIndex = 31;
            labelTmanoArchivo.Text = "Tamañano Del Archivo:";
            // 
            // groupBoxAuBitrate
            // 
            groupBoxAuBitrate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAuBitrate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxAuBitrate.Controls.Add(radioButtonAB16);
            groupBoxAuBitrate.Controls.Add(radioButtonAB32);
            groupBoxAuBitrate.Controls.Add(radioButtonAB96);
            groupBoxAuBitrate.Controls.Add(radioButtonAB128);
            groupBoxAuBitrate.Controls.Add(radioButtonAB196);
            groupBoxAuBitrate.Controls.Add(radioButtonAB320);
            groupBoxAuBitrate.ForeColor = Color.Gainsboro;
            groupBoxAuBitrate.Location = new Point(161, 299);
            groupBoxAuBitrate.Name = "groupBoxAuBitrate";
            groupBoxAuBitrate.Size = new Size(347, 62);
            groupBoxAuBitrate.TabIndex = 18;
            groupBoxAuBitrate.TabStop = false;
            groupBoxAuBitrate.Text = "Audio Bitrate / kbps";
            // 
            // radioButtonAB16
            // 
            radioButtonAB16.AutoSize = true;
            radioButtonAB16.Cursor = Cursors.Hand;
            radioButtonAB16.Location = new Point(294, 29);
            radioButtonAB16.Name = "radioButtonAB16";
            radioButtonAB16.Size = new Size(46, 25);
            radioButtonAB16.TabIndex = 5;
            radioButtonAB16.Text = "16";
            radioButtonAB16.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB32
            // 
            radioButtonAB32.AutoSize = true;
            radioButtonAB32.Cursor = Cursors.Hand;
            radioButtonAB32.Location = new Point(242, 29);
            radioButtonAB32.Name = "radioButtonAB32";
            radioButtonAB32.Size = new Size(46, 25);
            radioButtonAB32.TabIndex = 4;
            radioButtonAB32.Text = "32";
            radioButtonAB32.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB96
            // 
            radioButtonAB96.AutoSize = true;
            radioButtonAB96.Cursor = Cursors.Hand;
            radioButtonAB96.Location = new Point(190, 29);
            radioButtonAB96.Name = "radioButtonAB96";
            radioButtonAB96.Size = new Size(46, 25);
            radioButtonAB96.TabIndex = 3;
            radioButtonAB96.Text = "96";
            radioButtonAB96.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB128
            // 
            radioButtonAB128.AutoSize = true;
            radioButtonAB128.Cursor = Cursors.Hand;
            radioButtonAB128.Location = new Point(129, 29);
            radioButtonAB128.Name = "radioButtonAB128";
            radioButtonAB128.Size = new Size(55, 25);
            radioButtonAB128.TabIndex = 2;
            radioButtonAB128.Text = "128";
            radioButtonAB128.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB196
            // 
            radioButtonAB196.AutoSize = true;
            radioButtonAB196.Cursor = Cursors.Hand;
            radioButtonAB196.Location = new Point(68, 29);
            radioButtonAB196.Name = "radioButtonAB196";
            radioButtonAB196.Size = new Size(55, 25);
            radioButtonAB196.TabIndex = 1;
            radioButtonAB196.Text = "192";
            radioButtonAB196.UseVisualStyleBackColor = true;
            // 
            // radioButtonAB320
            // 
            radioButtonAB320.AutoSize = true;
            radioButtonAB320.Checked = true;
            radioButtonAB320.Cursor = Cursors.Hand;
            radioButtonAB320.Location = new Point(7, 29);
            radioButtonAB320.Name = "radioButtonAB320";
            radioButtonAB320.Size = new Size(55, 25);
            radioButtonAB320.TabIndex = 0;
            radioButtonAB320.TabStop = true;
            radioButtonAB320.Text = "320";
            radioButtonAB320.UseVisualStyleBackColor = true;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNombre.Font = new Font("Bahnschrift SemiBold Condensed", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxNombre.Location = new Point(10, 179);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(723, 67);
            textBoxNombre.TabIndex = 32;
            textBoxNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(1019, 657);
            Controls.Add(textBoxNombre);
            Controls.Add(groupBoxAuBitrate);
            Controls.Add(labelTmanoArchivo);
            Controls.Add(buttonEditAudio);
            Controls.Add(labelMDArtista);
            Controls.Add(textBoxArtista);
            Controls.Add(labelMDComment);
            Controls.Add(textBoxComentario);
            Controls.Add(labelMDTitulo);
            Controls.Add(textBoxTituloCancion);
            Controls.Add(labelMetadatos);
            Controls.Add(buttonHelp);
            Controls.Add(groupBoxGuardarVideo);
            Controls.Add(label5);
            Controls.Add(labelOpcionesTitle);
            Controls.Add(groupBoxAudioFormat);
            Controls.Add(labelRed);
            Controls.Add(labelAudioBitrate);
            Controls.Add(labelInfoTipo);
            Controls.Add(pictureBox1);
            Controls.Add(labelInfoDuracion);
            Controls.Add(buttonConvertir);
            Controls.Add(buttonGoToFolder);
            Controls.Add(labelEstado);
            Controls.Add(progressBar1);
            Controls.Add(labelRuta);
            Controls.Add(buttonComenzarDescarga);
            Controls.Add(label1);
            Controls.Add(textBoxURL);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Descargar Música Y Videos De YouTube - Por @Franco28";
            FormClosing += DescargarMusica_FormClosing;
            FormClosed += DescargarMusica_FormClosed;
            Load += DescargarMusica_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxAudioFormat.ResumeLayout(false);
            groupBoxAudioFormat.PerformLayout();
            groupBoxGuardarVideo.ResumeLayout(false);
            groupBoxGuardarVideo.PerformLayout();
            groupBoxAuBitrate.ResumeLayout(false);
            groupBoxAuBitrate.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxURL;
        private Label label1;
        private Button buttonComenzarDescarga;
        private Label labelRuta;
        private ProgressBar progressBar1;
        private Label labelEstado;
        private Button buttonGoToFolder;
        private Button buttonConvertir;
        private Label labelInfoDuracion;
        private PictureBox pictureBox1;
        private Label labelInfoTipo;
        private Label labelAudioBitrate;
        private Label labelRed;
        private GroupBox groupBoxAudioFormat;
        private RadioButton radioButtonWAV;
        private RadioButton radioButtonMP3;
        private Label labelOpcionesTitle;
        private Label label5;
        private GroupBox groupBoxGuardarVideo;
        private RadioButton radioButtonGuardarVideoNo;
        private RadioButton radioButtonGuardarVideoSi;
        private Button buttonHelp;
        private Label labelMetadatos;
        private TextBox textBoxTituloCancion;
        private Label labelMDTitulo;
        private Label labelMDComment;
        private TextBox textBoxComentario;
        private Label labelMDArtista;
        private TextBox textBoxArtista;
        private Button buttonEditAudio;
        private Label labelTmanoArchivo;
        private GroupBox groupBoxAuBitrate;
        private RadioButton radioButtonAB16;
        private RadioButton radioButtonAB32;
        private RadioButton radioButtonAB96;
        private RadioButton radioButtonAB128;
        private RadioButton radioButtonAB196;
        private RadioButton radioButtonAB320;
        private Label textBoxNombre;
    }
}