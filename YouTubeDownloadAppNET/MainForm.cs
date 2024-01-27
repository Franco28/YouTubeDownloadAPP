using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Diagnostics;
using YouTubeDownloadAppNET.Class;
using YouTubeDownloadAppNET.Enum;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using File = System.IO.File;
using Timer = System.Threading.Timer;

namespace YouTubeDownload
{
    public partial class MainForm : Form
    {
        #region var
        private string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "YouTubeDownload");
        YoutubeClient youtube = new YoutubeClient();
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
            var audioformat = string.Empty;
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
        /// Convert and save video to Audio
        /// </summary>
        /// <returns></returns>
        private async Task ConvertAndSaveFile()
        {
            IProgress<int> progress = new Progress<int>(percent => UpdateProgressBar(percent));

            buttonComenzarDescarga.Hide();

            try
            {
                IStreamInfo streamInfo = null;
                IStreamInfo streamInfoVideo = null;

                labelEstado.Text = "Estado: Comenzando...";
                progress.Report(5);

                labelEstado.Text = "Estado: Leyendo datos...";
                var VideoURL = textBoxURL.Text;
                var videoData = await youtube.Videos.GetAsync(VideoURL);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(VideoURL);

                string cleanedTitle = new string(videoData.Title
                    .Where(c => !Path.GetInvalidFileNameChars().Contains(c))
                    .ToArray());

                progress.Report(15);

                try
                {
                    if (!radioButtonGuardarVideoNo.Checked)
                    {
                        labelEstado.Text = "Estado: Descargando video... Esto puede demorar varios minutos...";

                        streamInfoVideo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
                        await youtube.Videos.Streams.DownloadAsync(streamInfoVideo, Path.Combine(downloadPath, $"Video.{cleanedTitle}.{streamInfoVideo.Container}"));
                    }

                    labelEstado.Text = "Estado: Descargando audio... Esto puede demorar varios minutos...";

                    streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                    await youtube.Videos.Streams.DownloadAsync(streamInfo, Path.Combine(downloadPath, $"{cleanedTitle}.{streamInfo.Container}"));
                }
                catch (Exception ex)
                {
                    labelEstado.Text = $"Error al descargar audio/video...";
                    progress.Report(100);
                    MessageBox.Show($"Error al descargar audio/video: {ex.Message}", "Error al descargar audio/video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                labelEstado.Text = "Estado: Obteniendo rutas de los archivos...";

                // Audio path
                string audioName = $"{cleanedTitle}.{streamInfo.Container}";
                string audioPath = Path.Combine(downloadPath, audioName);

                // Video path
                string videoName = string.Empty;
                string videoPath = string.Empty;
                MediaFile inputVideoFile = null;
                MediaFile outputVideoFile = null;
                if (!radioButtonGuardarVideoNo.Checked)
                {
                    videoName = $"Video.{cleanedTitle}.{streamInfoVideo.Container}";
                    videoPath = Path.Combine(downloadPath, videoName);

                    // Video MediaFile path
                    inputVideoFile = new MediaFile { Filename = videoPath };
                    outputVideoFile = new MediaFile { Filename = Path.Combine(downloadPath, videoPath) };
                }

                progress.Report(35);

                // Audio MediaFile path
                var inputAudioFile = new MediaFile { Filename = audioPath };
                var outputAudioFile = new MediaFile { Filename = Path.Combine(downloadPath, $"{cleanedTitle}{SetAudioFormat()}") };
                var outputAudioFile_Path = Path.Combine(downloadPath, $"{cleanedTitle}{SetAudioFormat()}");

                progress.Report(45);

                using (var engine = new Engine())
                {
                    labelEstado.Text = "Estado: Aplicando ajustes al audio...";

                    // Convert Audio Options
                    var conversionOptionsVideo = new ConversionOptions()
                    {
                        AudioBitRate = 320,
                        VideoFps = 60,
                        VideoSize = VideoSize.Hd1080,
                        CustomWidth = 1920,
                        CustomHeight = 1080,
                        AudioSampleRate = AudioSampleRate.Hz44100
                    };

                    if (!radioButtonGuardarVideoNo.Checked)
                    {
                        // Convertir el video a Full HD
                        labelEstado.Text = $"Estado: Obteniendo metadatos del video...";
                        engine.GetMetadata(inputVideoFile);

                        labelEstado.Text = $"Estado: Convirtiendo video a Full HD...";
                        engine.Convert(inputVideoFile, outputVideoFile, conversionOptionsVideo);
                    }

                    // Audio Bitrate options
                    var conversionOptionsAudio = GetConversionOptionsAudio();

                    // Get audio metadata
                    labelEstado.Text = $"Estado: Obteniendo metadatos del audio...";
                    progress.Report(55);
                    engine.GetMetadata(inputAudioFile);

                    // Convert to .mp3 or .wav
                    try
                    {
                        labelEstado.Text = $"Estado: Convirtiendo el audio .{streamInfo.Container} a {SetAudioFormat()}...";
                        progress.Report(65);
                        engine.Convert(inputAudioFile, outputAudioFile, conversionOptionsVideo);
                    }
                    catch (Exception ex)
                    {
                        labelEstado.Text = $"Error al convertir el audio...";
                        progress.Report(100);
                        MessageBox.Show($"Error al convertir el audio: {ex.Message}", "Error al convertir el audio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Convert audio bitrate
                    try
                    {
                        labelEstado.Text = $"Estado: Convirtiendo bitrate {conversionOptionsAudio.AudioBitRate}...";
                        progress.Report(75);
                        engine.Convert(inputAudioFile, outputAudioFile, conversionOptionsAudio);
                    }
                    catch (Exception ex)
                    {
                        labelEstado.Text = $"Error al convertir bitrate...";
                        progress.Report(100);
                        MessageBox.Show($"Error al convertir bitrate: {ex.Message}", "Error al convertir el BitRate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Set Metadata to the file
                    try
                    {
                        labelEstado.Text = $"Estado: Agregando metadatos al audio...";
                        progress.Report(80);

                        // Metadata artist
                        string artist = string.Empty;
                        if (textBoxArtista.Text == string.Empty)
                        {
                            artist = videoData.Title;
                        }
                        else
                        {
                            artist = textBoxArtista.Text;
                        }

                        // Metada title
                        string title = string.Empty;
                        if (textBoxTituloCancion.Text == string.Empty)
                        {
                            title = videoData.Title;
                        }
                        else
                        {
                            title = textBoxTituloCancion.Text;
                        }

                        // Create TagLib file
                        var tfile = TagLib.File.Create(outputAudioFile_Path);
                        tfile.Tag.Title = title;
                        tfile.Tag.Comment = $"Música/Video descargado con YouTube Download App por @Franco28 / " + textBoxComentario.Text;
                        tfile.Tag.Publisher = $"Música/Video descargado con YouTube Download App por @Franco28 / " + textBoxComentario.Text;
                        tfile.Tag.Album = cleanedTitle;
                        tfile.Save();

                        // Add coverart
                        labelEstado.Text = "Estado: Agregando portada al audio...";
                        progress.Report(85);
                        ConvertClass.SetAlbumArt(tfile, downloadPath);
                    }
                    catch (FileNotFoundException ex)
                    {
                        labelEstado.Text = $"Error no se pudo encontrar el archivo...";
                        progress.Report(100);
                        MessageBox.Show($"Error: No se pudo encontrar el archivo {outputAudioFile_Path}.\nDetalles: {ex.Message}", "Error al actualizar los metadatos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        labelEstado.Text = $"Error no se pudo actualizar los metadatos...";
                        progress.Report(100);
                        MessageBox.Show($"Error al actualizar los metadatos.\nDetalles: {ex.Message}", "Error al actualizar los metadatos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Delete coverart
                    labelEstado.Text = $"Estado: Eliminando archivos basura...";
                    progress.Report(95);
                    File.Delete(downloadPath + @"\cover.jpeg");
                    File.Delete(inputAudioFile.Filename);

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
                    pictureBox1.Image = YouTubeDownloadAppNET.Properties.Resources.favicon_144x144;

                    labelEstado.Text = "Estado: Listo!";
                    progress.Report(100);

                    buttonComenzarDescarga.Cursor = Cursors.Hand;
                    buttonComenzarDescarga.Hide();
                    labelInfoDuracion.Text = "Duración: ...";
                    labelInfoTipo.Text = "Tipo: ...";
                    textBoxNombre.Text = string.Empty;
                    textBoxURL.Text = string.Empty;
                    labelAudioBitrate.Text = "Audio Bitrate: ...";
                    labelTmanoArchivo.Text = "Tamañano Del Archivo ...";
                    textBoxArtista.Text = string.Empty;
                    textBoxComentario.Text = string.Empty;
                    textBoxTituloCancion.Text = string.Empty;

                    labelEstado.Text = string.Empty;
                    progress.Report(0);
                    labelEstado.Hide();
                    progressBar1.Hide();

                    MessageBox.Show("Listo! Se convirtió y se descargó el audio " + cleanedTitle + " y se guardó en " + downloadPath, "Audio procesado correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = downloadPath,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception er)
            {
                labelEstado.Text = string.Empty;
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
                textBoxURL.Text = string.Empty;
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

            labelEstado.Text = "Estado: Leyendo metadatos...";
            progress.Report(15);

            // Obtener informacion del video
            var video = await youtube.Videos.GetAsync(textBoxURL.Text);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(textBoxURL.Text);
            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            // Get coverart from YouTube
            labelEstado.Text = "Estado: Obteniendo miniatura del video...";
            progress.Report(25);

            using (HttpClient client = new HttpClient())
            {
                string url = "https://img.youtube.com/vi/" + video.Id + "/hqdefault.jpg";

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        var imgBytes = await content.ReadAsByteArrayAsync();

                        // Guardar coverart
                        labelEstado.Text = "Estado: Guardando miniatura del video...";
                        progress.Report(50);
                        await File.WriteAllBytesAsync(downloadPath + @"\cover.jpeg", imgBytes);

                        // Mostrar coverart
                        labelEstado.Text = "Estado: Imprimiendo miniatura...";
                        pictureBox1.Image = ConvertClass.GetImageFromByteArray(imgBytes);
                        progress.Report(60);
                    }
                }
            }

            // Obtener informacion del video
            labelEstado.Text = "Estado: Obteniendo información del video...";
            progress.Report(75);

            // Mostrar informacion
            labelInfoDuracion.Text = $"Duración: {video.Duration.Value}";
            labelInfoTipo.Text = $"Formato: .{streamInfo.Container.Name}";
            labelAudioBitrate.Text = $"Audio Bitrate: {Math.Round(streamInfo.Bitrate.KiloBitsPerSecond, 1)} kbps";

            // Calcular tamanio del video
            labelEstado.Text = "Estado: Calculando tamaño del video...";
            progress.Report(80);

            //Validar tamanio del archivo
            double? contentLength = streamInfo.Size.MegaBytes;
            if (contentLength.HasValue)
            {
                double roundedContentLength = Math.Round(contentLength.Value, 1);
                labelTmanoArchivo.Text = $"Tamaño Del Archivo: {roundedContentLength} MB";
            }
            else
            {
                labelTmanoArchivo.Text = "Tamaño del archivo desconocido...";
            }

            progress.Report(85);

            string patchName = video.Title;
            if (patchName.EndsWith(".mp4") || patchName.EndsWith(".webm"))
            {
                patchName = patchName.Replace(".mp4", "");
                patchName = patchName.Replace(".webm", "");
            }

            labelEstado.Text = "Estado: Realizando últimos arreglos...";
            progress.Report(95);
            textBoxNombre.Text = patchName;
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
                textBoxURL.Text = string.Empty;
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
                textBoxURL.Enabled = false;
                buttonConvertir.Enabled = false;
                buttonConvertir.Cursor = Cursors.WaitCursor;
                labelRed.ForeColor = Color.Red;
                labelRed.Text = "Conexión a internet: Desconectado...";
            }
            else
            {
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
