using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Diagnostics;
using System.Web;
using VideoLibrary;

namespace YouTubeDownload
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "YouTubeDownload");

        // thread UI
        protected Thread _thread;
        protected Thread _threadDownload;
        private void UpdateProgress(int percent)
        {
            RunOnUiThread(() => progressBar1.Value = percent);
        }

        private void RunOnUiThread(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        // convert byte[] to image bitmap
        protected static readonly ImageConverter _imageConverter = new ImageConverter();
        protected Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }

        // get youtube ID
        protected string getID(string url)
        {
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var videoId = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                videoId = query["v"];
            }
            else
            {
                videoId = uri.Segments.Last();
            }

            return videoId;
        }   

        // Set cover art
        private void SetAlbumArt(TagLib.File file)
        {
            byte[] imageBytes;
            imageBytes = File.ReadAllBytes(downloadPath + @"\cover.jpeg");

            TagLib.Id3v2.AttachmentFrame cover = new TagLib.Id3v2.AttachmentFrame
            {
                Type = TagLib.PictureType.FrontCover,
                Description = "Cover",
                MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
                Data = imageBytes,
                TextEncoding = TagLib.StringType.UTF16
            };
            file.Tag.Pictures = new TagLib.IPicture[] { cover };
            file.Save();
        }

        // convert and download audio
        private void SaveMP3()
        {
            try
            {
                labelEstado.Text = "Estado: Comenzando...";
                UpdateProgress(10);
                Thread.Sleep(500);

                labelEstado.Text = "Estado: Aplicando ajustes previos...";

                // Audio format
                var audioformat = "";
                if (radioButtonMP3.Checked == true)
                {
                    audioformat = ".mp3";
                }

                if (radioButtonWAV.Checked == true)
                {
                    audioformat = ".wav";
                }

                var VideoURL = textBoxURL.Text;
                var MP3Name = textBoxNombre.Text.Replace(" ", "_");
                UpdateProgress(15);
                Thread.Sleep(500);

                labelEstado.Text = "Estado: Leyendo datos...";
                var youtube = YouTube.Default;
                var vid = youtube.GetVideo(VideoURL);

                string videopath = Path.Combine(downloadPath, vid.FullName);
                UpdateProgress(20);
                Thread.Sleep(500);

                labelEstado.Text = "Estado: Creando el archivo...";
                UpdateProgress(30);
                Thread.Sleep(500);

                // Create video from YouTube
                byte[] videoBytes = vid.GetBytes();
                File.WriteAllBytes(videopath, videoBytes);

                labelEstado.Text = "Estado: Obteniendo rutas de los archivos...";
                UpdateProgress(40);
                Thread.Sleep(500);

                // Media file paths
                var inputFile = new MediaFile { Filename = Path.Combine(downloadPath, vid.FullName) };
                var outputFile = new MediaFile { Filename = Path.Combine(downloadPath, $"{MP3Name}{audioformat}") };

                // File paths
                var outputFile_Path = Path.Combine(downloadPath, $"{MP3Name}{audioformat}");
                var outputFileNew_Path = Path.Combine(downloadPath, $"{MP3Name + "_new"}{audioformat}");

                Thread.Sleep(500);
                UpdateProgress(50);

                // Video conversions
                var conversionOptionsVideo = new ConversionOptions();
                conversionOptionsVideo.AudioBitRate = 320;
                conversionOptionsVideo.VideoFps = 60;
                conversionOptionsVideo.VideoSize = VideoSize.Custom;
                conversionOptionsVideo.CustomWidth = 1920;
                conversionOptionsVideo.CustomHeight = 1080;

                // Bitrate options
                var conversionOptionsAudio = new ConversionOptions();
                if (radioButtonAB320.Checked == true)
                {
                    conversionOptionsAudio.AudioBitRate = 320;
                }

                if (radioButtonAB196.Checked == true)
                {
                    conversionOptionsAudio.AudioBitRate = 196;
                }

                if (radioButtonAB128.Checked == true)
                {
                    conversionOptionsAudio.AudioBitRate = 128;
                }

                if (radioButtonAB96.Checked == true)
                {
                    conversionOptionsAudio.AudioBitRate = 96;
                }

                if (radioButtonAB32.Checked == true)
                {
                    conversionOptionsAudio.AudioBitRate = 32;
                }

                if (radioButtonAB16.Checked == true)
                {
                    conversionOptionsAudio.AudioBitRate = 16;
                }

                using (var engine = new Engine())
                {
                    // Get metadata video
                    labelEstado.Text = "Estado: Obteniendo metadatos del video...";
                    UpdateProgress(60);
                    engine.GetMetadata(inputFile);
                    Thread.Sleep(500);

                    // Convert file
                    labelEstado.Text = $"Estado: Convirtiendo el video a {audioformat}...";
                    UpdateProgress(70);
                    engine.Convert(inputFile, outputFile, conversionOptionsVideo);
                    Thread.Sleep(500);

                    // Convert audio bitrate
                    labelEstado.Text = $"Estado: Convirtiendo bitrate {conversionOptionsAudio.AudioBitRate}...";
                    UpdateProgress(75);
                    engine.Convert(inputFile, outputFile, conversionOptionsAudio);
                    Thread.Sleep(500);

                    // Metadata
                    labelEstado.Text = "Estado: Agregando metadatos al audio...";
                    UpdateProgress(80);

                    // Metadata artist
                    string artist = "";
                    if (textBoxArtista.Text == string.Empty)
                    {
                        artist = vid.Title;
                    }
                    else
                    {
                        artist = textBoxArtista.Text;
                    }

                    // Metada title
                    string title = "";
                    if (textBoxTituloCancion.Text == string.Empty)
                    {
                        title = vid.Title;
                    }
                    else
                    {
                        title = textBoxTituloCancion.Text;
                    }

                    // Set metadata audio
                    var tfile = TagLib.File.Create(outputFile_Path);
                    tfile.Tag.Title = title;
                    tfile.Tag.Comment = "Música descargada con YouTube Download App por @Franco28 / " + textBoxComentario.Text;
                    tfile.Tag.Publisher = "Música descargada con YouTube Download App por @Franco28 / " + textBoxComentario.Text;

                    string patchNameAudio = vid.FullName;
                    if (patchNameAudio.EndsWith(".mp4") || patchNameAudio.EndsWith(".webm"))
                    {
                        patchNameAudio = patchNameAudio.Replace(".mp4", "");
                        patchNameAudio = patchNameAudio.Replace(".webm", "");
                    }

                    tfile.Tag.Album = patchNameAudio;
                    tfile.Save();
                    Thread.Sleep(500);

                    labelEstado.Text = "Estado: Agregando portada al audio...";
                    UpdateProgress(85);
                    SetAlbumArt(tfile);
                    Thread.Sleep(500);

                    // Delete video
                    if (radioButtonGuardarVideoNo.Checked == true)
                    {
                        UpdateProgress(90);
                        labelEstado.Text = "Estado: Eliminando video...";
                        File.Delete(videopath);
                        Thread.Sleep(500);
                    } 
                    else if (radioButtonGuardarVideoNo.Checked == false)
                    {
                        UpdateProgress(90);
                        labelEstado.Text = "Estado: Convirtiendo a FULL HD el video...";
                        engine.CustomCommand($" -i {videopath} -vf scale=-1920:1080 -map 0 -c:a copy -c:s copy {Path.GetFullPath(videopath) + Path.GetFileNameWithoutExtension(videopath) + "_FHD.mp4"}");
                    }

                    // Delete coverart
                    labelEstado.Text = "Estado: Eliminando archivos basura...";
                    UpdateProgress(95);
                    File.Delete(downloadPath + @"\cover.jpeg");
                    Thread.Sleep(500);

                    // Hide components
                    labelEstado.Text = "Estado: Terminando...";
                    UpdateProgress(98);
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
                    Thread.Sleep(500);
                }

                labelEstado.Text = "Estado: Listo!";
                UpdateProgress(100);

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
                Thread.Sleep(500);

                labelEstado.Text = "";
                UpdateProgress(0);
                labelEstado.Hide();
                progressBar1.Hide();

                MessageBox.Show("Listo! Se convirtió y se descargó el audio " + MP3Name + " y se guardó en " + downloadPath, "Audio procesado correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo { FileName = @downloadPath, UseShellExecute = true });

                _threadDownload = null;

            } 
            catch (Exception er)
            {
                MessageBox.Show("Error al convertir canción! \nDetalle: " +er.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonComenzarDescarga_Click(object sender, EventArgs e)
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

            if (Interface.CheckConnectivity() == false)
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
                if (_threadDownload == null)
                {
                    progressBar1.Value = 5;
                    labelEstado.Text = "Estado: Preparando...";
                    Thread.Sleep(500);

                    _threadDownload = new Thread(new ThreadStart(SaveMP3));
                    _threadDownload.IsBackground = true;
                    _threadDownload.Start();
                }
            }
            catch (Exception er)
            {
                labelEstado.Text = "Estado: Error...";
                MessageBox.Show(er.ToString(), "Error al descargar la canción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void AvoidFlick()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void DescargarMusica_Load(object sender, EventArgs e)
        {
            AvoidFlick();

            // Extraigo libreria de audio
            try
            {
                var en = new Engine();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error con la librería de audio! \nDetalle: " + er.Message, "ERROR AUDIO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Threading.Timer timerRed = new System.Threading.Timer(_ => timerRed_Tick(), null, 0, 1 * 500);

            Directory.CreateDirectory(downloadPath);

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

        private void buttonGoToFolder_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @downloadPath, UseShellExecute = true });
        }

        private void getMetaData()
        {
            UpdateProgress(10);
            Thread.Sleep(500);

            // Setting vars
            labelEstado.Text = "Estado: Leyendo metadatos...";
            UpdateProgress(15);
            // variables de libreria 
            var youtube = YouTube.Default;
            var video = youtube.GetVideo(textBoxURL.Text);

            // duracion del video
            var totalSeconds = video.Info.LengthSeconds;
            var seconds = totalSeconds % 60;
            var minutes = totalSeconds / 60;
            string totalVideoTime = minutes + ":" + seconds;
            Thread.Sleep(500);

            // Get cover art from youtube
            labelEstado.Text = "Estado: Obteniendo miniatura del video...";
            UpdateProgress(25);

            string url = "https://img.youtube.com/vi/" + getID(textBoxURL.Text) + "/hqdefault.jpg";

            // best practice to create one HttpClient per Application and inject it
            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                using (HttpContent content = response.Content)
                {
                    var imgBytes = content.ReadAsByteArrayAsync().Result;

                    Thread.Sleep(500);

                    labelEstado.Text = "Estado: Guardando miniatura del video...";
                    UpdateProgress(50);
                    File.WriteAllBytes(downloadPath + @"\cover.jpeg", imgBytes);
                    Thread.Sleep(500);

                    // Print picture
                    labelEstado.Text = "Estado: Imprimiendo miniatura...";
                    pictureBox1.Image = GetImageFromByteArray(imgBytes);
                    UpdateProgress(60);
                    Thread.Sleep(500);
                }
            }

            labelEstado.Text = "Estado: Obteniendo información del video...";
            UpdateProgress(75);
            Thread.Sleep(500);

            // Show info
            labelInfoDuracion.Text = "Duración: " + totalVideoTime + " minutos";
            labelInfoTipo.Text = "Formato Video: " + video.Format.ToString();
            labelInfoFormatoAudio.Text = "Formato Audio: " + video.AudioFormat;
            labelAudioBitrate.Text = "Audio Bitrate: " + video.AudioBitrate.ToString() + "kbps";
            labelTmanoArchivo.Text = "Tamañano Del Archivo: " + Interface.SizeSuffix((long)video.ContentLength);
            UpdateProgress(85);
            Thread.Sleep(500);

            // verifico que el casillero nombre este vacio para asignar el titulo del video
            if (textBoxNombre.Text == string.Empty)
            {
                String patchName = video.FullName;
                if (patchName.EndsWith(".mp4") || patchName.EndsWith(".webm"))
                {
                    patchName = patchName.Replace(".mp4", "");
                    patchName = patchName.Replace(".webm", "");
                }

                textBoxNombre.Text = patchName;
            }

            labelEstado.Text = "Estado: Realizando últimos arreglos...";
            UpdateProgress(95);
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
            Thread.Sleep(500);

            UpdateProgress(100);
            _thread = null;
            Thread.Sleep(500);

            UpdateProgress(0);
            progressBar1.Hide();
            labelEstado.Hide();
        }

        private void buttonConvertir_Click(object sender, EventArgs e)
        {
            if (Interface.CheckConnectivity() == false)
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
                if (_thread == null)
                {
                    _thread = new Thread(new ThreadStart(getMetaData));
                    _thread.IsBackground = true;
                    _thread.Start();
                }
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

            if (Interface.CheckConnectivity() == false)
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
            Interface.PanicKill();
        }

        private void DescargarMusica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Interface.PanicKill();
        }
    }
}
