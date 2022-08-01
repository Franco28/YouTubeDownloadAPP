namespace YouTubeDownload
{
    partial class EditAudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAudio));
            this.buttonCargarAudio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.waveViewer1 = new NAudio.Gui.WaveViewer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.labelEstado = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTiempoTranscurrido = new System.Windows.Forms.Label();
            this.labelTiempoTotal = new System.Windows.Forms.Label();
            this.labelRutaAudio = new System.Windows.Forms.Label();
            this.labelTipoArchivo = new System.Windows.Forms.Label();
            this.labelTamanoArchivo = new System.Windows.Forms.Label();
            this.labelAudioBitrate = new System.Windows.Forms.Label();
            this.labelAlbum = new System.Windows.Forms.Label();
            this.labelComentario = new System.Windows.Forms.Label();
            this.labelArtista = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCargarAudio
            // 
            this.buttonCargarAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCargarAudio.Location = new System.Drawing.Point(303, 67);
            this.buttonCargarAudio.Name = "buttonCargarAudio";
            this.buttonCargarAudio.Size = new System.Drawing.Size(227, 45);
            this.buttonCargarAudio.TabIndex = 0;
            this.buttonCargarAudio.Text = "Cargar Audio";
            this.buttonCargarAudio.UseVisualStyleBackColor = true;
            this.buttonCargarAudio.Click += new System.EventHandler(this.buttonCargarAudio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(807, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arrastre hasta aquí el archivo de audio para cargarlo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "o utilice el botón";
            // 
            // waveViewer1
            // 
            this.waveViewer1.Location = new System.Drawing.Point(12, 303);
            this.waveViewer1.Name = "waveViewer1";
            this.waveViewer1.SamplesPerPixel = 128;
            this.waveViewer1.Size = new System.Drawing.Size(1009, 89);
            this.waveViewer1.StartPosition = ((long)(0));
            this.waveViewer1.TabIndex = 3;
            this.waveViewer1.WaveStream = null;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelEstado
            // 
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.Red;
            this.labelEstado.Location = new System.Drawing.Point(10, 502);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(1013, 21);
            this.labelEstado.TabIndex = 9;
            this.labelEstado.Text = "Estado:";
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Location = new System.Drawing.Point(12, 526);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1011, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(19, 252);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(47, 45);
            this.buttonPlay.TabIndex = 10;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPause.Image = ((System.Drawing.Image)(resources.GetObject("buttonPause.Image")));
            this.buttonPause.Location = new System.Drawing.Point(72, 252);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(47, 45);
            this.buttonPause.TabIndex = 11;
            this.buttonPause.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(125, 252);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(47, 45);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // labelTiempoTranscurrido
            // 
            this.labelTiempoTranscurrido.AutoSize = true;
            this.labelTiempoTranscurrido.Location = new System.Drawing.Point(178, 264);
            this.labelTiempoTranscurrido.Name = "labelTiempoTranscurrido";
            this.labelTiempoTranscurrido.Size = new System.Drawing.Size(199, 21);
            this.labelTiempoTranscurrido.TabIndex = 13;
            this.labelTiempoTranscurrido.Text = "Tiempo Transcurrido: 00:00";
            // 
            // labelTiempoTotal
            // 
            this.labelTiempoTotal.AutoSize = true;
            this.labelTiempoTotal.Location = new System.Drawing.Point(769, 264);
            this.labelTiempoTotal.Name = "labelTiempoTotal";
            this.labelTiempoTotal.Size = new System.Drawing.Size(144, 21);
            this.labelTiempoTotal.TabIndex = 14;
            this.labelTiempoTotal.Text = "Tiempo Total: 00:00";
            // 
            // labelRutaAudio
            // 
            this.labelRutaAudio.AutoSize = true;
            this.labelRutaAudio.Location = new System.Drawing.Point(12, 207);
            this.labelRutaAudio.Name = "labelRutaAudio";
            this.labelRutaAudio.Size = new System.Drawing.Size(45, 21);
            this.labelRutaAudio.TabIndex = 15;
            this.labelRutaAudio.Text = "Ruta:";
            // 
            // labelTipoArchivo
            // 
            this.labelTipoArchivo.AutoSize = true;
            this.labelTipoArchivo.Location = new System.Drawing.Point(17, 125);
            this.labelTipoArchivo.Name = "labelTipoArchivo";
            this.labelTipoArchivo.Size = new System.Drawing.Size(100, 21);
            this.labelTipoArchivo.TabIndex = 16;
            this.labelTipoArchivo.Text = "Tipo Archivo:";
            // 
            // labelTamanoArchivo
            // 
            this.labelTamanoArchivo.AutoSize = true;
            this.labelTamanoArchivo.Location = new System.Drawing.Point(17, 167);
            this.labelTamanoArchivo.Name = "labelTamanoArchivo";
            this.labelTamanoArchivo.Size = new System.Drawing.Size(124, 21);
            this.labelTamanoArchivo.TabIndex = 17;
            this.labelTamanoArchivo.Text = "Tamaño Archivo:";
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(17, 146);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(100, 21);
            this.labelAudioBitrate.TabIndex = 18;
            this.labelAudioBitrate.Text = "Audio Bitrate";
            // 
            // labelAlbum
            // 
            this.labelAlbum.AutoSize = true;
            this.labelAlbum.Location = new System.Drawing.Point(420, 146);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.Size = new System.Drawing.Size(59, 21);
            this.labelAlbum.TabIndex = 21;
            this.labelAlbum.Text = "Álbum:";
            // 
            // labelComentario
            // 
            this.labelComentario.AutoSize = true;
            this.labelComentario.Location = new System.Drawing.Point(420, 167);
            this.labelComentario.Name = "labelComentario";
            this.labelComentario.Size = new System.Drawing.Size(95, 21);
            this.labelComentario.TabIndex = 20;
            this.labelComentario.Text = "Comentario:";
            // 
            // labelArtista
            // 
            this.labelArtista.AutoSize = true;
            this.labelArtista.Location = new System.Drawing.Point(420, 125);
            this.labelArtista.Name = "labelArtista";
            this.labelArtista.Size = new System.Drawing.Size(58, 21);
            this.labelArtista.TabIndex = 19;
            this.labelArtista.Text = "Artista:";
            // 
            // EditAudio
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1035, 561);
            this.Controls.Add(this.labelAlbum);
            this.Controls.Add(this.labelComentario);
            this.Controls.Add(this.labelArtista);
            this.Controls.Add(this.labelAudioBitrate);
            this.Controls.Add(this.labelTamanoArchivo);
            this.Controls.Add(this.labelTipoArchivo);
            this.Controls.Add(this.labelRutaAudio);
            this.Controls.Add(this.labelTiempoTotal);
            this.Controls.Add(this.labelTiempoTranscurrido);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.waveViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCargarAudio);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "EditAudio";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Audio";
            this.Load += new System.EventHandler(this.EditAudio_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.EditAudio_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EditAudio_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCargarAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private NAudio.Gui.WaveViewer waveViewer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelTiempoTranscurrido;
        private System.Windows.Forms.Label labelTiempoTotal;
        private System.Windows.Forms.Label labelRutaAudio;
        private System.Windows.Forms.Label labelTipoArchivo;
        private System.Windows.Forms.Label labelTamanoArchivo;
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.Label labelAlbum;
        private System.Windows.Forms.Label labelComentario;
        private System.Windows.Forms.Label labelArtista;
    }
}