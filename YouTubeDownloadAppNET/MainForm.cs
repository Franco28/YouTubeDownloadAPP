using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Diagnostics;
using VideoLibrary;
using YouTubeDownloadAppNET.Class;
using YouTubeDownloadAppNET.Enum;
using Timer = System.Threading.Timer;
using Video = VideoLibrary.Video;

namespace YouTubeDownload
{
    public partial class MainForm : Form
    {
        #region var
        private string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "YouTubeDownload");
        #endregion

        #region UI Start
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            MainClass.ExtractLibFiles();

            AvoidFlick();

            Timer timerRed = new Timer(_ => timerRed_Tick(), null, 0, 1 * 500);

            Directory.CreateDirectory(downloadPath);
        }

        private void AvoidFlick()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void DescargarMusica_Load(object sender, EventArgs e)
        {
            // Others
            groupBoxAudioFormat.Hide();
            groupBoxGuardarVideo.Hide();
            labelOpcionesTitle.Hide();
            labelMetadatos.Hide();
            labelMDTitulo.Hide();
            textBoxTituloCancion.Hide();
            textBoxArtista.Hide();
            textBoxComentario.Hide();
            labelMDComment.Hide();
            labelMDArtista.Hide();
            groupBoxAuBitrate.Hide();

            // Metadata
            labelMetadatos.Hide();
            labelMDTitulo.Hide();
            labelMDArtista.Hide();
            labelMDComment.Hide();
            textBoxTituloCancion.Hide();
            textBoxArtista.Hide();
            textBoxComentario.Hide();
            groupBoxAuBitrate.Hide();

            progressBar1.Hide();
            labelEstado.Hide();
            buttonComenzarDescarga.Hide();
            labelRuta.Text = "Ruta de descarga: " + downloadPath;
        }

        private async Task UpdateProgressAsync(int percent)
        {
            await Task.Run(() =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdateProgressBar(percent)));
                }
                else
                {
                    UpdateProgressBar(percent);
                }
            });
        }

        private void UpdateProgressBar(int percent)
        {
            progressBar1.Value = percent;
        }
        #endregion

        /// <summary>
        /// Set Audio Format 
        /// Options: wav / mp3
        /// </summary>
        /// <returns></returns>
        private string SetAudioFormat()
        {
            var audioformat = "";
            if (radioButtonMP3.Checked == true)
            {
                audioformat = ".mp3";
            }

            if (radioButtonWAV.Checked == true)
            {
                audioformat = ".wav";
            }

            return audioformat;
        }

        /// <summary>
        /// Set Audio BitRate Option
        /// </summary>
        /// <returns></returns>
        private ConversionOptions GetConversionOptionsAudio()
        {
            var conversionOptionsAudio = new ConversionOptions();

            if (radioButtonAB320.Checked == true)
            {
                conversionOptionsAudio.AudioBitRate = (int?)AudioBitRate.AudioBitRate320;
            }

            if (radioButtonAB196.Checked == true)
            {
                conversionOptionsAudio.AudioBitRate = (int?)AudioBitRate.AudioBitRate196;
            }

            if (radioButtonAB128.Checked == true)
            {
                conversionOptionsAudio.AudioBitRate = (int?)AudioBitRate.AudioBitRate128;
            }

            if (radioButtonAB96.Checked == true)
            {
                conversionOptionsAudio.AudioBitRate = (int?)AudioBitRate.AudioBitRate96;
            }

            if (radioButtonAB32.Checked == true)
            {
                conversionOptionsAudio.AudioBitRate = (int?)AudioBitRate.AudioBitRate32;
            }

            if (radioButtonAB16.Checked == true)
            {
                conversionOptionsAudio.AudioBitRate = (int?)AudioBitRate.AudioBitRate16;
            }

            return conversionOptionsAudio;
        }

        /// <summary>
        /// Get Video Bytes from youtube
        /// </summary>
        /// <param name="video"></param>
        /// <param name="videopath"></param>
        /// <returns></returns>
        private void DownloadVideo(Video video, string videopath)
        {
            byte[] videoBytes = video.GetBytes();
            File.WriteAllBytes(videopath, videoBytes);
        }

        /// <summary>
        /// Convert and save video to Audio
        /// </summary>
        /// <returns></returns>
        private async Task ConvertAndSaveFile()
        {
            IProgress<int> progress = new Progress<int>(percent => UpdateProgressBar(percent));

            try
            {
                labelEstado.Text = "Estado: Comenzando...";
                progress.Report(10);

                var VideoURL = textBoxURL.Text;
                var MP3Name = textBoxNombre.Text.Replace(" ", "_");
                progress.Report(15);

                labelEstado.Text = "Estado: Leyendo datos...";
                YouTube youtube = YouTube.Default;
                Video videoData = await youtube.GetVideoAsync(VideoURL);

                // Video path
                string videoName = videoData.FullName;
                string videopath = Path.Combine(downloadPath, videoName);
                progress.Report(20);

                // Create video from YouTube => I don't know why, takes 5 minutes to convert.
                try
                {
                    labelEstado.Text = "Estado: Creando el archivo... Esto puede demorar varios minutos...";

                    DownloadVideo(videoData, videopath);
                }
                catch (Exception ex)
                {
                    labelEstado.Text = $"Error al extraer el video";
                    progress.Report(100);
                    MessageBox.Show($"Error al extraer el video: {ex.Message}", "Error al extraer el video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                labelEstado.Text = "Estado: Obteniendo rutas de los archivos...";
                progress.Report(40);

                // MediaFile paths
                var inputFile = new MediaFile { Filename = Path.Combine(downloadPath, videoData.FullName) };
                var outputFile = new MediaFile { Filename = Path.Combine(downloadPath, $"{MP3Name}{SetAudioFormat()}") };

                var outputFile_Path = Path.Combine(downloadPath, $"{MP3Name}{SetAudioFormat()}");

                progress.Report(50);

                using (var engine = new Engine())
                {
                    labelEstado.Text = "Estado: Aplicando ajustes previos...";

                    // Convert Video Options
                    var conversionOptionsVideo = new ConversionOptions()
                    {
                        AudioBitRate = 320,
                        VideoFps = 60,
                        VideoSize = VideoSize.Custom,
                        CustomWidth = 1920,
                        CustomHeight = 1080
                    };

                    // Audio Bitrate options
                    var conversionOptionsAudio = GetConversionOptionsAudio();

                    // Get metadata video
                    labelEstado.Text = $"Estado: Obteniendo metadatos del video...";
                    progress.Report(60);
                    engine.GetMetadata(inputFile);

                    // Convert vide to mp3 File
                    try
                    {
                        labelEstado.Text = $"Estado: Convirtiendo el video a {SetAudioFormat()}...";
                        progress.Report(70);
                        engine.Convert(inputFile, outputFile, conversionOptionsVideo);
                    }
                    catch (Exception ex)
                    {
                        labelEstado.Text = $"Error al convertir el video";
                        progress.Report(100);
                        MessageBox.Show($"Error al convertir el video: {ex.Message}", "Error al convertir el video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Convert audio bitrate
                    try
                    {
                        labelEstado.Text = $"Estado: Convirtiendo bitrate {conversionOptionsAudio.AudioBitRate}...";
                        progress.Report(75);
                        engine.Convert(inputFile, outputFile, conversionOptionsAudio);
                    }
                    catch (Exception ex)
                    {
                        labelEstado.Text = $"Error al convertir bitrate";
                        progress.Report(100);
                        MessageBox.Show($"Error al convertir bitrate: {ex.Message}", "Error al convertir el BitRate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Set Metadata to the file
                    try
                    {
                        labelEstado.Text = $"Estado: Agregando metadatos al audio...";
                        progress.Report(80);

                        // Metadata artist
                        string artist = "";
                        if (textBoxArtista.Text == string.Empty)
                        {
                            artist = videoData.Title;
                        }
                        else
                        {
                            artist = textBoxArtista.Text;
                        }

                        // Metada title
                        string title = "";
                        if (textBoxTituloCancion.Text == string.Empty)
                        {
                            title = videoData.Title;
                        }
                        else
                        {
                            title = textBoxTituloCancion.Text;
                        }

                        var tfile = TagLib.File.Create(outputFile_Path);
                        tfile.Tag.Title = title;
                        tfile.Tag.Comment = $"Música/Video descargada con YouTube Download App por @Franco28 / " + textBoxComentario.Text;
                        tfile.Tag.Publisher = $"Música/Video descargada con YouTube Download App por @Franco28 / " + textBoxComentario.Text;

                        if (videoName.EndsWith(".mp4") || videoName.EndsWith(".webm"))
                        {
                            videoName = videoName.Replace(".mp4", "");
                            videoName = videoName.Replace(".webm", "");
                        }

                        tfile.Tag.Album = videoName;
                        tfile.Save();

                        labelEstado.Text = "Estado: Agregando portada al audio...";
                        progress.Report(85);
                        ConvertClass.SetAlbumArt(tfile);
                        Thread.Sleep(500);
                    }
                    catch (FileNotFoundException ex)
                    {
                        labelEstado.Text = $"Estado: Error, no se pudo encontrar el archivo...";
                        progress.Report(100);
                        MessageBox.Show($"Error: No se pudo encontrar el archivo {outputFile_Path}.\nDetalles: {ex.Message}", "Error al actualizar los metadatos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        labelEstado.Text = $"Estado: Error, no se pudo actualizar los metadatos...";
                        progress.Report(100);
                        MessageBox.Show($"Error al actualizar los metadatos.\nDetalles: {ex.Message}", "Error al actualizar los metadatos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Delete video
                    if (radioButtonGuardarVideoNo.Checked == true)
                    {
                        progress.Report(90);
                        labelEstado.Text = $"Estado: Eliminando video...";
                        File.Delete(videopath);
                    }
                    else if (radioButtonGuardarVideoNo.Checked == false)
                    {
                        progress.Report(92);
                        labelEstado.Text = $"Estado: Convirtiendo a FULL HD el video...";
                        engine.CustomCommand($" -i {videopath} -vf scale=-1920:1080 -map 0 -c:a copy -c:s copy {Path.GetFullPath(videopath) + Path.GetFileNameWithoutExtension(videopath) + "_FHD.mp4"}");
                    }

                    // Delete coverart
                    labelEstado.Text = $"Estado: Eliminando archivos basura...";
                    progress.Report(95);
                    File.Delete(downloadPath + @"\cover.jpeg");

                    // Hide components
                    labelEstado.Text = $"Estado: Terminando...";
                    progress.Report(98);
                    groupBoxAuBitrate.Hide();
                    groupBoxAudioFormat.Hide();
                    groupBoxGuardarVideo.Hide();
                    labelOpcionesTitle.Hide();
                    labelMetadatos.Hide();
                    labelMDTitulo.Hide();
                    textBoxTituloCancion.Hide();
                    textBoxArtista.Hide();
                    textBoxComentario.Hide();
                    labelMDComment.Hide();
                    labelMDArtista.Hide();

                    labelEstado.Text = "Estado: Listo!";
                    progress.Report(100);

                    buttonComenzarDescarga.Cursor = Cursors.Hand;
                    buttonComenzarDescarga.Hide();
                    labelInfoDuracion.Text = "Duración: ...";
                    labelInfoTipo.Text = "Tipo: ...";
                    textBoxNombre.Text = "";
                    textBoxURL.Text = "";
                    labelInfoFormatoAudio.Text = "Formato Audio: ...";
                    labelAudioBitrate.Text = "Audio Bitrate: ...";
                    labelTmanoArchivo.Text = "Tamañano Del Archivo ...";
                    textBoxArtista.Text = "";
                    textBoxComentario.Text = "";
                    textBoxTituloCancion.Text = "";
                    pictureBox1.Image = Properties.Resources.favicon_144x144;

                    labelEstado.Text = "";
                    progress.Report(0);
                    labelEstado.Hide();
                    progressBar1.Hide();

                    MessageBox.Show("Listo! Se convirtió y se descargó el audio " + MP3Name + " y se guardó en " + downloadPath, "Audio procesado correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Process.Start(new ProcessStartInfo { FileName = @downloadPath, UseShellExecute = true });
                }
            }
            catch (Exception er)
            {
                labelEstado.Text = "";
                progress.Report(0);
                MessageBox.Show("Error al convertir, descargar, o iniciar la carpeta de descarga. \n\nDetalle: " + er.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonComenzarDescarga_Click(object sender, EventArgs e)
        {
            if (textBoxURL.Text == string.Empty && textBoxNombre.Text == string.Empty)
            {
                MessageBox.Show("Los casilleros no pueden estar vacíos!", "Casilleros vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!textBoxURL.Text.Contains("https://www.youtube.com/watch?v="))
            {
                MessageBox.Show("La URL (LINK) que ingresó no parece ser de YouTube, por favor ingrese una URL (LINK) válido!", "URL inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxURL.Text = "";
                return;
            }

            if (MainClass.CheckConnectivity() == false)
            {
                MessageBox.Show("No tiene conexión a internet!", "Se perdió la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            buttonComenzarDescarga.Cursor = Cursors.WaitCursor;
            progressBar1.Show();
            labelEstado.Show();

            progressBar1.Value = 2;
            labelEstado.Text = "Estado: Comenzando...";

            try
            {
                await ConvertAndSaveFile();
            }
            catch (Exception er)
            {
                labelEstado.Text = "Estado: Error...";
                MessageBox.Show(er.ToString(), "Error al descargar la canción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonGoToFolder_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @downloadPath, UseShellExecute = true });
        }

        private async Task GetMetaDataAsync()
        {
            IProgress<int> progress = new Progress<int>(percent => UpdateProgressBar(percent));

            progress.Report(10);

            // Setting vars
            labelEstado.Text = "Estado: Leyendo metadatos...";
            progress.Report(15);

            // variables de libreria 
            YouTube youtube = YouTube.Default;
            YouTubeVideo video = await youtube.GetVideoAsync(textBoxURL.Text);

            // duracion del video
            var totalSeconds = video.Info.LengthSeconds;
            var seconds = totalSeconds % 60;
            var minutes = totalSeconds / 60;

            // Get cover art from youtube
            labelEstado.Text = "Estado: Obteniendo miniatura del video...";
            progress.Report(25);

            string url = "https://img.youtube.com/vi/" + ConvertClass.getID(textBoxURL.Text) + "/hqdefault.jpg";

            // best practice to create one HttpClient per Application and inject it
            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                using (HttpContent content = response.Content)
                {
                    var imgBytes = await content.ReadAsByteArrayAsync();

                    labelEstado.Text = "Estado: Guardando miniatura del video...";
                    progress.Report(50);
                    await File.WriteAllBytesAsync(downloadPath + @"\cover.jpeg", imgBytes);

                    // Print picture
                    labelEstado.Text = "Estado: Imprimiendo miniatura...";
                    pictureBox1.Image = ConvertClass.GetImageFromByteArray(imgBytes);
                    progress.Report(60);
                }
            }

            labelEstado.Text = "Estado: Obteniendo información del video...";
            progress.Report(75);

            string totalVideoTime = minutes + ":" + seconds;

            // Show info
            labelInfoDuracion.Text = "Duración: " + totalVideoTime + " minutos";
            labelInfoTipo.Text = "Formato Video: " + video.Format.ToString();
            labelInfoFormatoAudio.Text = "Formato Audio: " + video.AudioFormat;
            labelAudioBitrate.Text = "Audio Bitrate: " + video.AudioBitrate.ToString() + "kbps";

            labelEstado.Text = "Estado: Calculando tamaño del video...";
            progress.Report(80);

            // Valido el tamaño del archivo
            long? contentLength = await Task.Run(() => video.ContentLength);
            if (contentLength.HasValue)
            {
                long fileSize = (long)contentLength;
                labelTmanoArchivo.Text = "Tamañano Del Archivo: " + MainClass.SizeSuffix(fileSize);
            }
            else
            {
                labelTmanoArchivo.Text = "Tamaño del archivo desconocido";
            }

            progress.Report(85);

            // verifico que el casillero nombre este vacio para asignar el titulo del video
            if (textBoxNombre.Text == string.Empty)
            {
                string patchName = video.FullName;
                if (patchName.EndsWith(".mp4") || patchName.EndsWith(".webm"))
                {
                    patchName = patchName.Replace(".mp4", "");
                    patchName = patchName.Replace(".webm", "");
                }

                textBoxNombre.Text = patchName;
            }

            labelEstado.Text = "Estado: Realizando últimos arreglos...";
            progress.Report(95);
            textBoxNombre.Text = textBoxNombre.Text.Replace(" ", "_");
            buttonComenzarDescarga.Show();
            groupBoxAuBitrate.Show();
            groupBoxAudioFormat.Show();
            groupBoxGuardarVideo.Show();
            labelOpcionesTitle.Show();
            labelMetadatos.Show();
            labelMDTitulo.Show();
            textBoxTituloCancion.Show();
            textBoxArtista.Show();
            textBoxComentario.Show();
            labelMDComment.Show();
            labelMDArtista.Show();

            progress.Report(100);

            progress.Report(0);
            progressBar1.Hide();
            labelEstado.Hide();
        }

        private async void buttonConvertir_Click(object sender, EventArgs e)
        {
            if (MainClass.CheckConnectivity() == false)
            {
                MessageBox.Show("No tiene conexión a internet!", "Se perdió la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxURL.Text == string.Empty)
            {
                MessageBox.Show("El casillero URL (LINK) no puede estar vacío!", "Casillero URL (LINK) vacío!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!textBoxURL.Text.Contains("https://www.youtube.com/watch?v="))
            {
                MessageBox.Show("La URL (LINK) que ingresó no parece ser de YouTube, por favor ingrese una URL (LINK) válido!", "URL inválida! {DESCONOCIDO}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxURL.Text = "";
                return;
            }

            labelEstado.Show();
            progressBar1.Show();
            labelEstado.ForeColor = Color.Red;
            labelEstado.Text = "Estado: Comenzando...";

            try
            {
                await GetMetaDataAsync();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString(), "Error al obtener los metadatos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void timerRed_Tick()
        {
            Directory.CreateDirectory(downloadPath);

            if (MainClass.CheckConnectivity() == false)
            {
                textBoxNombre.Enabled = false;
                textBoxURL.Enabled = false;
                buttonConvertir.Enabled = false;
                buttonConvertir.Cursor = Cursors.WaitCursor;
                labelRed.ForeColor = Color.Red;
                labelRed.Text = "Conexión a internet: Desconectado...";
            }
            else
            {
                textBoxNombre.Enabled = true;
                textBoxURL.Enabled = true;
                buttonConvertir.Enabled = true;
                buttonConvertir.Cursor = Cursors.Hand;
                labelRed.ForeColor = Color.Green;
                labelRed.Text = "Conexión a internet: Conectado!";
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            var app = new About();
            app.ShowDialog();
            return;
        }

        private void buttonEditAudio_Click(object sender, EventArgs e)
        {
            // NOT WORKING
            var app = new EditAudio();
            app.ShowDialog();
            return;
        }

        private void radioButtonWAV_CheckedChanged(object sender, EventArgs e)
        {
            labelMetadatos.Hide();
            labelMDTitulo.Hide();
            labelMDArtista.Hide();
            labelMDComment.Hide();
            textBoxTituloCancion.Hide();
            textBoxArtista.Hide();
            textBoxComentario.Hide();

            groupBoxAuBitrate.Hide();
        }

        private void radioButtonMP3_CheckedChanged(object sender, EventArgs e)
        {
            // Metadata
            labelMetadatos.Show();
            labelMDTitulo.Show();
            labelMDArtista.Show();
            labelMDComment.Show();
            textBoxTituloCancion.Show();
            textBoxArtista.Show();
            textBoxComentario.Show();
            groupBoxAuBitrate.Show();

            groupBoxAuBitrate.Show();
        }

        private void DescargarMusica_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainClass.PanicKill();
        }

        private void DescargarMusica_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainClass.PanicKill();
        }
    }
}
