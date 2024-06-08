using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Diagnostics;
using System.Text.RegularExpressions;
using YouTubeDownloadAppNET.Class;
using YouTubeDownloadAppNET.Enum;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using File = System.IO.File;
using Timer = System.Threading.Timer;

namespace YouTubeDownload
{
    public partial class MainForm : Form
    {
        #region var
        private readonly string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "YouTubeDownload");
        private readonly YoutubeClient youtube = new();
        private IProgress<int> progress;
        #endregion

        #region UI Start
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            MainClass.ExtractLibFiles();

            AvoidFlick();

            Timer timerRed = new(_ => timerRed_Tick(), null, 0, 1 * 500);

            Directory.CreateDirectory(downloadPath);
        }

        /// <summary>
        /// Avoid UI flick
        /// </summary>
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

        /// <summary>
        /// Update progressbar
        /// </summary>
        /// <param name="percent"></param>
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
            string audioformat = string.Empty;
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
            ConversionOptions conversionOptionsAudio = new();

            Dictionary<RadioButton, AudioBitRate> audioBitRateMap = new()
            {
                { radioButtonAB320, AudioBitRate.AudioBitRate320 },
                { radioButtonAB196, AudioBitRate.AudioBitRate196 },
                { radioButtonAB128, AudioBitRate.AudioBitRate128 },
                { radioButtonAB96, AudioBitRate.AudioBitRate96 },
                { radioButtonAB32, AudioBitRate.AudioBitRate32 },
                { radioButtonAB16, AudioBitRate.AudioBitRate16 }
            };

            foreach (var entry in audioBitRateMap)
            {
                if (entry.Key.Checked)
                {
                    conversionOptionsAudio.AudioBitRate = (int?)entry.Value;
                    break;
                }
            }

            return conversionOptionsAudio;
        }

        /// <summary>
        /// Convert and save video to Audio
        /// </summary>
        /// <returns></returns>
        private async Task ConvertAndSaveFile()
        {
            buttonComenzarDescarga.Hide();

            try
            {
                labelEstado.Text = "Estado: Comenzando...";
                progress.Report(5);

                var videoURL = textBoxURL.Text;
                var videoData = await youtube.Videos.GetAsync(videoURL);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoURL);

                string cleanedTitle = new(videoData.Title.Where(c => !Path.GetInvalidFileNameChars().Contains(c)).ToArray());
                progress.Report(15);

                var videoDownloadTask = DownloadVideoIfRequired(streamManifest, cleanedTitle);
                var audioDownloadTask = DownloadAudio(streamManifest, cleanedTitle);

                await Task.WhenAll(videoDownloadTask, audioDownloadTask);

                var audioPath = Path.Combine(downloadPath, $"{cleanedTitle}.{audioDownloadTask.Result.Container}");
                var videoPath = videoDownloadTask.Result != null ? Path.Combine(downloadPath, $"Video.{cleanedTitle}.{videoDownloadTask.Result.Container}") : null;

                labelEstado.Text = "Estado: Obteniendo rutas de los archivos...";
                progress.Report(35);

                ConvertFiles(cleanedTitle, audioPath, videoPath);

                SetMetaDataToFILE(progress, videoData, cleanedTitle, Path.Combine(downloadPath, $"{cleanedTitle}{SetAudioFormat()}"));

                labelEstado.Text = "Estado: Eliminando archivos basura...";
                progress.Report(95);
                CleanUpFiles(audioPath);

                HideElements(progress);

                MessageBox.Show($"Listo. Se convirtió y se descargó el audio {cleanedTitle} y se guardó en {downloadPath}", "Audio procesado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo
                {
                    FileName = downloadPath,
                    UseShellExecute = true
                });
            }
            catch (Exception er)
            {
                HandleError(er);
            }
        }

        /// <summary>
        /// Download video if required
        /// </summary>
        /// <param name="streamManifest"></param>
        /// <param name="cleanedTitle"></param>
        /// <returns></returns>
        private async Task<IStreamInfo> DownloadVideoIfRequired(StreamManifest streamManifest, string cleanedTitle)
        {
            if (radioButtonGuardarVideoNo.Checked) return null;

            try
            {
                labelEstado.Text = "Estado: Descargando video... Esto puede demorar varios minutos...";
                var streamInfoVideo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
                await youtube.Videos.Streams.DownloadAsync(streamInfoVideo, Path.Combine(downloadPath, $"Video.{cleanedTitle}.{streamInfoVideo.Container}"));
                return streamInfoVideo;
            }
            catch (Exception ex)
            {
                HandleSpecificError("Error al descargar video", ex);
                return null;
            }
        }

        /// <summary>
        /// Download video/audio
        /// </summary>
        /// <param name="streamManifest"></param>
        /// <param name="cleanedTitle"></param>
        /// <returns></returns>
        private async Task<IStreamInfo> DownloadAudio(StreamManifest streamManifest, string cleanedTitle)
        {
            try
            {
                labelEstado.Text = "Estado: Descargando audio. Esto puede demorar varios minutos...";
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                await youtube.Videos.Streams.DownloadAsync(streamInfo, Path.Combine(downloadPath, $"{cleanedTitle}.{streamInfo.Container}"));
                return streamInfo;
            }
            catch (Exception ex)
            {
                HandleSpecificError("Error al descargar audio", ex);
                return null;
            }
        }

        /// <summary>
        /// Convert files
        /// </summary>
        /// <param name="cleanedTitle"></param>
        /// <param name="audioPath"></param>
        /// <param name="videoPath"></param>
        private void ConvertFiles(string cleanedTitle, string audioPath, string videoPath)
        {
            using var engine = new Engine();

            var inputAudioFile = new MediaFile { Filename = audioPath };
            var outputAudioFile = new MediaFile { Filename = Path.Combine(downloadPath, $"{cleanedTitle}{SetAudioFormat()}") };

            var conversionOptionsVideo = GetVideoConversionOptions();
            var conversionOptionsAudio = GetConversionOptionsAudio();

            if (videoPath != null)
            {
                var inputVideoFile = new MediaFile { Filename = videoPath };
                var outputVideoFile = new MediaFile { Filename = Path.Combine(downloadPath, videoPath) };

                labelEstado.Text = "Estado: Convirtiendo video a Full HD...";
                engine.Convert(inputVideoFile, outputVideoFile, conversionOptionsVideo);
            }

            try
            {
                labelEstado.Text = $"Estado: Convirtiendo el audio {Path.GetExtension(audioPath)} a {SetAudioFormat()}...";
                progress.Report(65);
                engine.Convert(inputAudioFile, outputAudioFile, conversionOptionsAudio);
            }
            catch (Exception ex)
            {
                HandleSpecificError("Error al convertir el audio", ex);
            }
        }

        /// <summary>
        /// Get video conversion options
        /// </summary>
        /// <returns></returns>
        private ConversionOptions GetVideoConversionOptions()
        {
            return new ConversionOptions
            {
                AudioBitRate = 320,
                VideoFps = 60,
                VideoSize = VideoSize.Hd1080,
                CustomWidth = 1920,
                CustomHeight = 1080,
                AudioSampleRate = AudioSampleRate.Hz44100
            };
        }

        /// <summary>
        /// Clean files
        /// </summary>
        /// <param name="audioPath"></param>
        private void CleanUpFiles(string audioPath)
        {
            File.Delete(Path.Combine(downloadPath, "cover.jpeg"));
            File.Delete(audioPath);
        }

        /// <summary>
        /// Handle specific error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        private void HandleSpecificError(string message, Exception ex)
        {
            labelEstado.Text = message;
            progress.Report(100);
            MessageBox.Show($"{message}: {ex.Message}", message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handle error
        /// </summary>
        /// <param name="er"></param>
        private void HandleError(Exception er)
        {
            labelEstado.Text = string.Empty;
            progress.Report(0);
            MessageBox.Show($"Error al convertir/descargar/iniciar la carpeta de descarga. \n\nDetalle: {er}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Hide elements
        /// </summary>
        /// <param name="progress"></param>
        private void HideElements(IProgress<int> progress)
        {
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
        }

        /// <summary>
        /// Set Metadata to the file
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="videoData"></param>
        /// <param name="cleanedTitle"></param>
        /// <param name="outputAudioFile_Path"></param>
        private void SetMetaDataToFILE(IProgress<int> progress, Video videoData, string cleanedTitle, string outputAudioFile_Path)
        {
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
                tfile.Tag.Comment = $"Música/Video descargado con YouTubeDownloadApp por @Franco28 / " + textBoxComentario.Text;
                tfile.Tag.Publisher = $"Música/Video descargado con YouTubeDownloadApp por @Franco28 / " + textBoxComentario.Text;
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
                labelEstado.Text = $"Error no se pudieron actualizar los metadatos...";
                progress.Report(100);
                MessageBox.Show($"Error al actualizar los metadatos.\nDetalles: {ex.Message}", "Error al actualizar los metadatos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validate YouTube URL
        /// </summary>
        private void ValidateYouTubeUrl()
        {
            string youtubeUrlPattern = @"^(https?://)?(www\.)?(youtube\.com|youtu\.?be)/.+$";
            Regex regex = new(youtubeUrlPattern);

            if (!regex.IsMatch(textBoxURL.Text))
            {
                MessageBox.Show("La URL (LINK) que ingresó no parece ser de YouTube, por favor ingrese una URL (LINK) válido!", "URL inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxURL.Text = string.Empty;
                return;
            }
        } 

        /// <summary>
        /// Get audio/video metadata
        /// </summary>
        /// <returns></returns>
        private async Task GetMetaDataAsync()
        {
            progress = new Progress<int>(x => UpdateProgressBar(x));

            progress.Report(10);

            labelEstado.Text = "Estado: Leyendo metadatos...";
            progress.Report(15);

            // Obtener informacion del video
            var video = await youtube.Videos.GetAsync(textBoxURL.Text);
            StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync(textBoxURL.Text);
            IStreamInfo streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            // Get coverart from YouTube
            labelEstado.Text = "Estado: Obteniendo miniatura del video...";
            progress.Report(25);

            using (HttpClient client = new HttpClient())
            {
                string url = "https://img.youtube.com/vi/" + video.Id + "/hqdefault.jpg";

                using HttpResponseMessage response = await client.GetAsync(url);
                using HttpContent content = response.Content;
                byte[] imgBytes = await content.ReadAsByteArrayAsync();

                // Guardar coverart
                labelEstado.Text = "Estado: Guardando miniatura del video...";
                progress.Report(50);
                await File.WriteAllBytesAsync(downloadPath + @"\cover.jpeg", imgBytes);

                // Mostrar coverart
                labelEstado.Text = "Estado: Imprimiendo miniatura...";
                pictureBox1.Image = ConvertClass.GetImageFromByteArray(imgBytes);
                progress.Report(60);
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

        /// <summary>
        /// Btn action start download video/audio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonComenzarDescarga_Click(object sender, EventArgs e)
        {
            if (textBoxURL.Text == string.Empty && textBoxNombre.Text == string.Empty)
            {
                MessageBox.Show("Los casilleros no pueden estar vacíos!", "Casilleros vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ValidateYouTubeUrl();

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
                MessageBox.Show(er.ToString(), "Error al descargar el audio/video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

            ValidateYouTubeUrl();

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
                labelRed.Text = "Conexión a internet: Conectado.";
            }
        }

        private void buttonGoToFolder_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @downloadPath, UseShellExecute = true });
        }   

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            var app = new About();
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
