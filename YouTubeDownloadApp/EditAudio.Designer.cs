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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCFDA = new System.Windows.Forms.Label();
            this.buttonCutAudio = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxAudioSegundo = new System.Windows.Forms.TextBox();
            this.textBoxAudioMinuto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAudioHora = new System.Windows.Forms.TextBox();
            this.labelCPDA = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAudioSegundosP = new System.Windows.Forms.TextBox();
            this.textBoxAudioMinutosP = new System.Windows.Forms.TextBox();
            this.textBoxAudioHoraP = new System.Windows.Forms.TextBox();
            this.buttonCortarPrincipio = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelEstado
            // 
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.Red;
            this.labelEstado.Location = new System.Drawing.Point(12, 445);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(1013, 21);
            this.labelEstado.TabIndex = 9;
            this.labelEstado.Text = "Estado:";
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Location = new System.Drawing.Point(12, 469);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1011, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(17, 292);
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
            this.buttonPause.Location = new System.Drawing.Point(70, 292);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(47, 45);
            this.buttonPause.TabIndex = 11;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(123, 292);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(47, 45);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTiempoTranscurrido
            // 
            this.labelTiempoTranscurrido.AutoSize = true;
            this.labelTiempoTranscurrido.Location = new System.Drawing.Point(176, 292);
            this.labelTiempoTranscurrido.Name = "labelTiempoTranscurrido";
            this.labelTiempoTranscurrido.Size = new System.Drawing.Size(199, 21);
            this.labelTiempoTranscurrido.TabIndex = 13;
            this.labelTiempoTranscurrido.Text = "Tiempo Transcurrido: 00:00";
            // 
            // labelTiempoTotal
            // 
            this.labelTiempoTotal.AutoSize = true;
            this.labelTiempoTotal.Location = new System.Drawing.Point(176, 316);
            this.labelTiempoTotal.Name = "labelTiempoTotal";
            this.labelTiempoTotal.Size = new System.Drawing.Size(144, 21);
            this.labelTiempoTotal.TabIndex = 14;
            this.labelTiempoTotal.Text = "Tiempo Total: 00:00";
            // 
            // labelRutaAudio
            // 
            this.labelRutaAudio.AutoSize = true;
            this.labelRutaAudio.Location = new System.Drawing.Point(17, 257);
            this.labelRutaAudio.Name = "labelRutaAudio";
            this.labelRutaAudio.Size = new System.Drawing.Size(45, 21);
            this.labelRutaAudio.TabIndex = 15;
            this.labelRutaAudio.Text = "Ruta:";
            // 
            // labelTipoArchivo
            // 
            this.labelTipoArchivo.AutoSize = true;
            this.labelTipoArchivo.Location = new System.Drawing.Point(17, 124);
            this.labelTipoArchivo.Name = "labelTipoArchivo";
            this.labelTipoArchivo.Size = new System.Drawing.Size(100, 21);
            this.labelTipoArchivo.TabIndex = 16;
            this.labelTipoArchivo.Text = "Tipo Archivo:";
            // 
            // labelTamanoArchivo
            // 
            this.labelTamanoArchivo.AutoSize = true;
            this.labelTamanoArchivo.Location = new System.Drawing.Point(17, 166);
            this.labelTamanoArchivo.Name = "labelTamanoArchivo";
            this.labelTamanoArchivo.Size = new System.Drawing.Size(124, 21);
            this.labelTamanoArchivo.TabIndex = 17;
            this.labelTamanoArchivo.Text = "Tamaño Archivo:";
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(17, 145);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(100, 21);
            this.labelAudioBitrate.TabIndex = 18;
            this.labelAudioBitrate.Text = "Audio Bitrate";
            // 
            // labelAlbum
            // 
            this.labelAlbum.AutoSize = true;
            this.labelAlbum.Location = new System.Drawing.Point(17, 193);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.Size = new System.Drawing.Size(59, 21);
            this.labelAlbum.TabIndex = 21;
            this.labelAlbum.Text = "Álbum:";
            // 
            // labelComentario
            // 
            this.labelComentario.AutoSize = true;
            this.labelComentario.Location = new System.Drawing.Point(17, 214);
            this.labelComentario.Name = "labelComentario";
            this.labelComentario.Size = new System.Drawing.Size(95, 21);
            this.labelComentario.TabIndex = 20;
            this.labelComentario.Text = "Comentario:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(777, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // labelCFDA
            // 
            this.labelCFDA.AutoSize = true;
            this.labelCFDA.Location = new System.Drawing.Point(13, 372);
            this.labelCFDA.Name = "labelCFDA";
            this.labelCFDA.Size = new System.Drawing.Size(163, 21);
            this.labelCFDA.TabIndex = 23;
            this.labelCFDA.Text = "Cortar Final Del Audio";
            // 
            // buttonCutAudio
            // 
            this.buttonCutAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCutAudio.Location = new System.Drawing.Point(230, 399);
            this.buttonCutAudio.Name = "buttonCutAudio";
            this.buttonCutAudio.Size = new System.Drawing.Size(157, 29);
            this.buttonCutAudio.TabIndex = 26;
            this.buttonCutAudio.Text = "Cortar Final";
            this.buttonCutAudio.UseVisualStyleBackColor = true;
            this.buttonCutAudio.Click += new System.EventHandler(this.buttonCutAudio_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 21);
            this.label8.TabIndex = 40;
            this.label8.Text = ":";
            // 
            // textBoxAudioSegundo
            // 
            this.textBoxAudioSegundo.Location = new System.Drawing.Point(170, 399);
            this.textBoxAudioSegundo.Name = "textBoxAudioSegundo";
            this.textBoxAudioSegundo.Size = new System.Drawing.Size(54, 29);
            this.textBoxAudioSegundo.TabIndex = 38;
            this.textBoxAudioSegundo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAudioSegundo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAudioHora_KeyPress);
            // 
            // textBoxAudioMinuto
            // 
            this.textBoxAudioMinuto.Location = new System.Drawing.Point(91, 399);
            this.textBoxAudioMinuto.Name = "textBoxAudioMinuto";
            this.textBoxAudioMinuto.Size = new System.Drawing.Size(54, 29);
            this.textBoxAudioMinuto.TabIndex = 37;
            this.textBoxAudioMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAudioMinuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAudioHora_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 21);
            this.label9.TabIndex = 39;
            this.label9.Text = ":";
            // 
            // textBoxAudioHora
            // 
            this.textBoxAudioHora.Location = new System.Drawing.Point(13, 399);
            this.textBoxAudioHora.Name = "textBoxAudioHora";
            this.textBoxAudioHora.Size = new System.Drawing.Size(54, 29);
            this.textBoxAudioHora.TabIndex = 36;
            this.textBoxAudioHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAudioHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAudioHora_KeyPress);
            // 
            // labelCPDA
            // 
            this.labelCPDA.AutoSize = true;
            this.labelCPDA.Enabled = false;
            this.labelCPDA.Location = new System.Drawing.Point(497, 370);
            this.labelCPDA.Name = "labelCPDA";
            this.labelCPDA.Size = new System.Drawing.Size(191, 21);
            this.labelCPDA.TabIndex = 46;
            this.labelCPDA.Text = "Cortar Principio Del Audio";
            this.labelCPDA.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(639, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 21);
            this.label4.TabIndex = 51;
            this.label4.Text = ":";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(561, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 21);
            this.label5.TabIndex = 50;
            this.label5.Text = ":";
            this.label5.Visible = false;
            // 
            // textBoxAudioSegundosP
            // 
            this.textBoxAudioSegundosP.Enabled = false;
            this.textBoxAudioSegundosP.Location = new System.Drawing.Point(658, 400);
            this.textBoxAudioSegundosP.Name = "textBoxAudioSegundosP";
            this.textBoxAudioSegundosP.Size = new System.Drawing.Size(54, 29);
            this.textBoxAudioSegundosP.TabIndex = 49;
            this.textBoxAudioSegundosP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAudioSegundosP.Visible = false;
            this.textBoxAudioSegundosP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAudioHora_KeyPress);
            // 
            // textBoxAudioMinutosP
            // 
            this.textBoxAudioMinutosP.Enabled = false;
            this.textBoxAudioMinutosP.Location = new System.Drawing.Point(579, 400);
            this.textBoxAudioMinutosP.Name = "textBoxAudioMinutosP";
            this.textBoxAudioMinutosP.Size = new System.Drawing.Size(54, 29);
            this.textBoxAudioMinutosP.TabIndex = 48;
            this.textBoxAudioMinutosP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAudioMinutosP.Visible = false;
            this.textBoxAudioMinutosP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAudioHora_KeyPress);
            // 
            // textBoxAudioHoraP
            // 
            this.textBoxAudioHoraP.Enabled = false;
            this.textBoxAudioHoraP.Location = new System.Drawing.Point(501, 400);
            this.textBoxAudioHoraP.Name = "textBoxAudioHoraP";
            this.textBoxAudioHoraP.Size = new System.Drawing.Size(54, 29);
            this.textBoxAudioHoraP.TabIndex = 47;
            this.textBoxAudioHoraP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAudioHoraP.Visible = false;
            this.textBoxAudioHoraP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAudioHora_KeyPress);
            // 
            // buttonCortarPrincipio
            // 
            this.buttonCortarPrincipio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCortarPrincipio.Enabled = false;
            this.buttonCortarPrincipio.Location = new System.Drawing.Point(718, 400);
            this.buttonCortarPrincipio.Name = "buttonCortarPrincipio";
            this.buttonCortarPrincipio.Size = new System.Drawing.Size(157, 29);
            this.buttonCortarPrincipio.TabIndex = 52;
            this.buttonCortarPrincipio.Text = "Cortar Principio";
            this.buttonCortarPrincipio.UseVisualStyleBackColor = true;
            this.buttonCortarPrincipio.Visible = false;
            this.buttonCortarPrincipio.Click += new System.EventHandler(this.buttonCortarPrincipio_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(425, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 45);
            this.label7.TabIndex = 53;
            this.label7.Text = "|";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(425, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 45);
            this.label10.TabIndex = 54;
            this.label10.Text = "|";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(425, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 45);
            this.label11.TabIndex = 55;
            this.label11.Text = "|";
            // 
            // EditAudio
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1035, 504);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonCortarPrincipio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAudioSegundosP);
            this.Controls.Add(this.textBoxAudioMinutosP);
            this.Controls.Add(this.textBoxAudioHoraP);
            this.Controls.Add(this.labelCPDA);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxAudioSegundo);
            this.Controls.Add(this.textBoxAudioMinuto);
            this.Controls.Add(this.textBoxAudioHora);
            this.Controls.Add(this.buttonCutAudio);
            this.Controls.Add(this.labelCFDA);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelAlbum);
            this.Controls.Add(this.labelComentario);
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
            this.Text = "Editar Audio - MP3 - Por @Franco28";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditAudio_FormClosing);
            this.Load += new System.EventHandler(this.EditAudio_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.EditAudio_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EditAudio_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCargarAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCFDA;
        private System.Windows.Forms.Button buttonCutAudio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAudioSegundo;
        private System.Windows.Forms.TextBox textBoxAudioMinuto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAudioHora;
        private System.Windows.Forms.Label labelCPDA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAudioSegundosP;
        private System.Windows.Forms.TextBox textBoxAudioMinutosP;
        private System.Windows.Forms.TextBox textBoxAudioHoraP;
        private System.Windows.Forms.Button buttonCortarPrincipio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}