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
            this.groupBoxResolucionVideo = new System.Windows.Forms.GroupBox();
            this.radioButton4K = new System.Windows.Forms.RadioButton();
            this.radioButtonFHD = new System.Windows.Forms.RadioButton();
            this.radioButtonHD = new System.Windows.Forms.RadioButton();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.labelMetadatos = new System.Windows.Forms.Label();
            this.textBoxTituloCancion = new System.Windows.Forms.TextBox();
            this.labelMDTitulo = new System.Windows.Forms.Label();
            this.labelMDComment = new System.Windows.Forms.Label();
            this.textBoxComentario = new System.Windows.Forms.TextBox();
            this.labelMDArtista = new System.Windows.Forms.Label();
            this.textBoxArtista = new System.Windows.Forms.TextBox();
            this.labelOTAS = new System.Windows.Forms.Label();
            this.buttonEditAudio = new System.Windows.Forms.Button();
            this.labelTmanoArchivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxAudioFormat.SuspendLayout();
            this.groupBoxGuardarVideo.SuspendLayout();
            this.groupBoxResolucionVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxURL.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxURL.Location = new System.Drawing.Point(9, 89);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(523, 29);
            this.textBoxURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese un LINK de YouTube";
            // 
            // buttonComenzarDescarga
            // 
            this.buttonComenzarDescarga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonComenzarDescarga.Location = new System.Drawing.Point(12, 532);
            this.buttonComenzarDescarga.Name = "buttonComenzarDescarga";
            this.buttonComenzarDescarga.Size = new System.Drawing.Size(167, 38);
            this.buttonComenzarDescarga.TabIndex = 2;
            this.buttonComenzarDescarga.TabStop = false;
            this.buttonComenzarDescarga.Text = "Comenzar Descarga";
            this.buttonComenzarDescarga.UseVisualStyleBackColor = true;
            this.buttonComenzarDescarga.Click += new System.EventHandler(this.buttonComenzarDescarga_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombre.Location = new System.Drawing.Point(10, 184);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(523, 29);
            this.textBoxNombre.TabIndex = 1;
            // 
            // labelRuta
            // 
            this.labelRuta.AutoSize = true;
            this.labelRuta.Location = new System.Drawing.Point(12, 268);
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Size = new System.Drawing.Size(132, 21);
            this.labelRuta.TabIndex = 5;
            this.labelRuta.Text = "Ruta de descarga:";
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Location = new System.Drawing.Point(12, 597);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(797, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // labelEstado
            // 
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.Red;
            this.labelEstado.Location = new System.Drawing.Point(10, 573);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(799, 21);
            this.labelEstado.TabIndex = 7;
            this.labelEstado.Text = "Estado:";
            // 
            // buttonGoToFolder
            // 
            this.buttonGoToFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoToFolder.Location = new System.Drawing.Point(12, 292);
            this.buttonGoToFolder.Name = "buttonGoToFolder";
            this.buttonGoToFolder.Size = new System.Drawing.Size(200, 36);
            this.buttonGoToFolder.TabIndex = 8;
            this.buttonGoToFolder.TabStop = false;
            this.buttonGoToFolder.Text = "Ir a la carpeta de descarga";
            this.buttonGoToFolder.UseVisualStyleBackColor = true;
            this.buttonGoToFolder.Click += new System.EventHandler(this.buttonGoToFolder_Click);
            // 
            // buttonConvertir
            // 
            this.buttonConvertir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConvertir.Location = new System.Drawing.Point(10, 219);
            this.buttonConvertir.Name = "buttonConvertir";
            this.buttonConvertir.Size = new System.Drawing.Size(523, 38);
            this.buttonConvertir.TabIndex = 2;
            this.buttonConvertir.Text = "Obtener Datos Del Link";
            this.buttonConvertir.UseVisualStyleBackColor = true;
            this.buttonConvertir.Click += new System.EventHandler(this.buttonConvertir_Click);
            // 
            // labelInfoDuracion
            // 
            this.labelInfoDuracion.AutoSize = true;
            this.labelInfoDuracion.Location = new System.Drawing.Point(537, 239);
            this.labelInfoDuracion.Name = "labelInfoDuracion";
            this.labelInfoDuracion.Size = new System.Drawing.Size(76, 21);
            this.labelInfoDuracion.TabIndex = 9;
            this.labelInfoDuracion.Text = "Duración:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(541, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // labelInfoTipo
            // 
            this.labelInfoTipo.AutoSize = true;
            this.labelInfoTipo.Location = new System.Drawing.Point(537, 260);
            this.labelInfoTipo.Name = "labelInfoTipo";
            this.labelInfoTipo.Size = new System.Drawing.Size(116, 21);
            this.labelInfoTipo.TabIndex = 11;
            this.labelInfoTipo.Text = "Formato Video:";
            // 
            // labelInfoFormatoAudio
            // 
            this.labelInfoFormatoAudio.AutoSize = true;
            this.labelInfoFormatoAudio.Location = new System.Drawing.Point(537, 281);
            this.labelInfoFormatoAudio.Name = "labelInfoFormatoAudio";
            this.labelInfoFormatoAudio.Size = new System.Drawing.Size(117, 21);
            this.labelInfoFormatoAudio.TabIndex = 12;
            this.labelInfoFormatoAudio.Text = "Formato Audio:";
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(537, 302);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(103, 21);
            this.labelAudioBitrate.TabIndex = 13;
            this.labelAudioBitrate.Text = "Audio Bitrate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(459, 37);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ingrese NOMBRE del audio a guardar";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(5, 4);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(40, 21);
            this.labelRed.TabIndex = 15;
            this.labelRed.Text = "Red:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "(opcional, al obtener los datos se asgina un nombre)";
            // 
            // groupBoxAudioFormat
            // 
            this.groupBoxAudioFormat.Controls.Add(this.radioButtonWAV);
            this.groupBoxAudioFormat.Controls.Add(this.radioButtonMP3);
            this.groupBoxAudioFormat.Location = new System.Drawing.Point(190, 354);
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
            // 
            // labelOpcionesTitle
            // 
            this.labelOpcionesTitle.AutoSize = true;
            this.labelOpcionesTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpcionesTitle.Location = new System.Drawing.Point(7, 338);
            this.labelOpcionesTitle.Name = "labelOpcionesTitle";
            this.labelOpcionesTitle.Size = new System.Drawing.Size(128, 37);
            this.labelOpcionesTitle.TabIndex = 19;
            this.labelOpcionesTitle.Text = "Opciones";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(525, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 37);
            this.label5.TabIndex = 20;
            this.label5.Text = "Información del video";
            // 
            // groupBoxGuardarVideo
            // 
            this.groupBoxGuardarVideo.Controls.Add(this.radioButtonGuardarVideoNo);
            this.groupBoxGuardarVideo.Controls.Add(this.radioButtonGuardarVideoSi);
            this.groupBoxGuardarVideo.Location = new System.Drawing.Point(339, 354);
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
            this.radioButtonGuardarVideoNo.CheckedChanged += new System.EventHandler(this.radioButtonGuardarVideoNo_CheckedChanged);
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
            this.radioButtonGuardarVideoSi.CheckedChanged += new System.EventHandler(this.radioButtonGuardarVideoSi_CheckedChanged);
            // 
            // groupBoxResolucionVideo
            // 
            this.groupBoxResolucionVideo.Controls.Add(this.radioButton4K);
            this.groupBoxResolucionVideo.Controls.Add(this.radioButtonFHD);
            this.groupBoxResolucionVideo.Controls.Add(this.radioButtonHD);
            this.groupBoxResolucionVideo.Location = new System.Drawing.Point(446, 422);
            this.groupBoxResolucionVideo.Name = "groupBoxResolucionVideo";
            this.groupBoxResolucionVideo.Size = new System.Drawing.Size(363, 65);
            this.groupBoxResolucionVideo.TabIndex = 19;
            this.groupBoxResolucionVideo.TabStop = false;
            this.groupBoxResolucionVideo.Text = "Resolución Video";
            // 
            // radioButton4K
            // 
            this.radioButton4K.AutoSize = true;
            this.radioButton4K.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton4K.Location = new System.Drawing.Point(257, 31);
            this.radioButton4K.Name = "radioButton4K";
            this.radioButton4K.Size = new System.Drawing.Size(104, 25);
            this.radioButton4K.TabIndex = 2;
            this.radioButton4K.Text = "4k (2160p)";
            this.radioButton4K.UseVisualStyleBackColor = true;
            // 
            // radioButtonFHD
            // 
            this.radioButtonFHD.AutoSize = true;
            this.radioButtonFHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonFHD.Location = new System.Drawing.Point(113, 31);
            this.radioButtonFHD.Name = "radioButtonFHD";
            this.radioButtonFHD.Size = new System.Drawing.Size(138, 25);
            this.radioButtonFHD.TabIndex = 1;
            this.radioButtonFHD.Text = "Full HD (1080p)";
            this.radioButtonFHD.UseVisualStyleBackColor = true;
            // 
            // radioButtonHD
            // 
            this.radioButtonHD.AutoSize = true;
            this.radioButtonHD.Checked = true;
            this.radioButtonHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonHD.Location = new System.Drawing.Point(7, 29);
            this.radioButtonHD.Name = "radioButtonHD";
            this.radioButtonHD.Size = new System.Drawing.Size(100, 25);
            this.radioButtonHD.TabIndex = 0;
            this.radioButtonHD.TabStop = true;
            this.radioButtonHD.Text = "HD (720p)";
            this.radioButtonHD.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonHelp.Image = ((System.Drawing.Image)(resources.GetObject("buttonHelp.Image")));
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(692, 554);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(117, 37);
            this.buttonHelp.TabIndex = 21;
            this.buttonHelp.Text = "App Info";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // labelMetadatos
            // 
            this.labelMetadatos.AutoSize = true;
            this.labelMetadatos.Location = new System.Drawing.Point(8, 380);
            this.labelMetadatos.Name = "labelMetadatos";
            this.labelMetadatos.Size = new System.Drawing.Size(142, 21);
            this.labelMetadatos.TabIndex = 22;
            this.labelMetadatos.Text = "Asignar MetaDatos";
            // 
            // textBoxTituloCancion
            // 
            this.textBoxTituloCancion.Location = new System.Drawing.Point(12, 430);
            this.textBoxTituloCancion.Name = "textBoxTituloCancion";
            this.textBoxTituloCancion.Size = new System.Drawing.Size(167, 29);
            this.textBoxTituloCancion.TabIndex = 23;
            this.textBoxTituloCancion.TabStop = false;
            // 
            // labelMDTitulo
            // 
            this.labelMDTitulo.AutoSize = true;
            this.labelMDTitulo.Location = new System.Drawing.Point(12, 406);
            this.labelMDTitulo.Name = "labelMDTitulo";
            this.labelMDTitulo.Size = new System.Drawing.Size(49, 21);
            this.labelMDTitulo.TabIndex = 24;
            this.labelMDTitulo.Text = "Título";
            // 
            // labelMDComment
            // 
            this.labelMDComment.AutoSize = true;
            this.labelMDComment.Location = new System.Drawing.Point(193, 422);
            this.labelMDComment.Name = "labelMDComment";
            this.labelMDComment.Size = new System.Drawing.Size(92, 21);
            this.labelMDComment.TabIndex = 26;
            this.labelMDComment.Text = "Comentario";
            // 
            // textBoxComentario
            // 
            this.textBoxComentario.Location = new System.Drawing.Point(193, 446);
            this.textBoxComentario.Multiline = true;
            this.textBoxComentario.Name = "textBoxComentario";
            this.textBoxComentario.Size = new System.Drawing.Size(247, 68);
            this.textBoxComentario.TabIndex = 25;
            this.textBoxComentario.TabStop = false;
            // 
            // labelMDArtista
            // 
            this.labelMDArtista.AutoSize = true;
            this.labelMDArtista.Location = new System.Drawing.Point(12, 461);
            this.labelMDArtista.Name = "labelMDArtista";
            this.labelMDArtista.Size = new System.Drawing.Size(55, 21);
            this.labelMDArtista.TabIndex = 28;
            this.labelMDArtista.Text = "Artista";
            // 
            // textBoxArtista
            // 
            this.textBoxArtista.Location = new System.Drawing.Point(12, 485);
            this.textBoxArtista.Name = "textBoxArtista";
            this.textBoxArtista.Size = new System.Drawing.Size(167, 29);
            this.textBoxArtista.TabIndex = 27;
            this.textBoxArtista.TabStop = false;
            // 
            // labelOTAS
            // 
            this.labelOTAS.AutoSize = true;
            this.labelOTAS.Location = new System.Drawing.Point(6, 28);
            this.labelOTAS.Name = "labelOTAS";
            this.labelOTAS.Size = new System.Drawing.Size(108, 21);
            this.labelOTAS.TabIndex = 29;
            this.labelOTAS.Text = "Actualización: ";
            // 
            // buttonEditAudio
            // 
            this.buttonEditAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditAudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditAudio.Location = new System.Drawing.Point(569, 554);
            this.buttonEditAudio.Name = "buttonEditAudio";
            this.buttonEditAudio.Size = new System.Drawing.Size(117, 37);
            this.buttonEditAudio.TabIndex = 30;
            this.buttonEditAudio.Text = "Editar Audio";
            this.buttonEditAudio.UseVisualStyleBackColor = true;
            this.buttonEditAudio.Click += new System.EventHandler(this.buttonEditAudio_Click);
            // 
            // labelTmanoArchivo
            // 
            this.labelTmanoArchivo.AutoSize = true;
            this.labelTmanoArchivo.Location = new System.Drawing.Point(537, 323);
            this.labelTmanoArchivo.Name = "labelTmanoArchivo";
            this.labelTmanoArchivo.Size = new System.Drawing.Size(168, 21);
            this.labelTmanoArchivo.TabIndex = 31;
            this.labelTmanoArchivo.Text = "Tamañano Del Archivo:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(818, 632);
            this.Controls.Add(this.labelTmanoArchivo);
            this.Controls.Add(this.buttonEditAudio);
            this.Controls.Add(this.labelOTAS);
            this.Controls.Add(this.labelMDArtista);
            this.Controls.Add(this.textBoxArtista);
            this.Controls.Add(this.labelMDComment);
            this.Controls.Add(this.textBoxComentario);
            this.Controls.Add(this.labelMDTitulo);
            this.Controls.Add(this.textBoxTituloCancion);
            this.Controls.Add(this.labelMetadatos);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.groupBoxResolucionVideo);
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
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descargar Música Y Videos De YouTube - Por Franco Mato";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DescargarMusica_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DescargarMusica_FormClosed);
            this.Load += new System.EventHandler(this.DescargarMusica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxAudioFormat.ResumeLayout(false);
            this.groupBoxAudioFormat.PerformLayout();
            this.groupBoxGuardarVideo.ResumeLayout(false);
            this.groupBoxGuardarVideo.PerformLayout();
            this.groupBoxResolucionVideo.ResumeLayout(false);
            this.groupBoxResolucionVideo.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxResolucionVideo;
        private System.Windows.Forms.RadioButton radioButtonFHD;
        private System.Windows.Forms.RadioButton radioButtonHD;
        private System.Windows.Forms.RadioButton radioButton4K;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label labelMetadatos;
        private System.Windows.Forms.TextBox textBoxTituloCancion;
        private System.Windows.Forms.Label labelMDTitulo;
        private System.Windows.Forms.Label labelMDComment;
        private System.Windows.Forms.TextBox textBoxComentario;
        private System.Windows.Forms.Label labelMDArtista;
        private System.Windows.Forms.TextBox textBoxArtista;
        private System.Windows.Forms.Label labelOTAS;
        private System.Windows.Forms.Button buttonEditAudio;
        private System.Windows.Forms.Label labelTmanoArchivo;
    }
}