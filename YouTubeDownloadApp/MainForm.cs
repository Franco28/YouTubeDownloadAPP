using AutoUpdaterDotNET;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
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
            //using (WebClient client = new WebClient())
            //{
            //    imageBytes = client.DownloadData("https://img.youtube.com/vi/" + getID(textBoxURL.Text) + "/hqdefault.jpg");
            //}
            
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

            try
            {
                labelEstado.Text = "Estado: Creando el archivo...";
                UpdateProgress(30);
                Thread.Sleep(500);

                // Create file
                File.WriteAllBytes(videopath, vid.GetBytes());

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
                var conversionOptionsVideo = new ConversionOptions
                {
                    AudioBitRate = 320,
                    VideoFps = 60,
                    VideoSize = VideoSize.Hd720
                };

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

                    // Convert audio bitrate
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
                    tfile.Tag.Comment = "Música descargada con YouTubeDownload por Franco Mato / " + textBoxComentario.Text;
                    tfile.Tag.Publisher = "Música descargada con YouTubeDownload por Franco Mato / " + textBoxComentario.Text;
                    tfile.Tag.Album = vid.FullName;
                    UpdateProgress(85);
                    tfile.Save();

                    labelEstado.Text = "Estado: Agregando metadatos al audio...";
                    UpdateProgress(90);
                    SetAlbumArt(tfile);
                    Thread.Sleep(500);

                    // Delete video
                    if (radioButtonGuardarVideoNo.Checked == true)
                    {
                        UpdateProgress(93);
                        labelEstado.Text = "Estado: Eliminando video...";
                        File.Delete(videopath);
                        Thread.Sleep(500);
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
            } 
            catch (Exception er)
            {
                MessageBox.Show("Error al convertir canción! \nDetalle: " +er.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            labelEstado.Text = "Estado: Listo!";
            UpdateProgress(100);
            Thread.Sleep(1000);

            MessageBox.Show("Listo! Se convirtió y se descargó el audio " + MP3Name + " y se guardó en " + downloadPath, "Audio procesado correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            buttonComenzarDescarga.Cursor = Cursors.Hand;
            buttonComenzarDescarga.Hide();
            labelEstado.Hide();
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
            progressBar1.Hide();

            UpdateProgress(100);

            Process.Start(downloadPath);

            _threadDownload = null;

            UpdateProgress(0);
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

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        labelOTAS.ForeColor = Color.YellowGreen;
                        labelOTAS.Text = "Actualización: Nueva versión disponible! v" + args.CurrentVersion;

                        dialogResult =
                            MessageBox.Show(
                                $@"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}. This is required update. Press Ok to begin updating the application.", @"Update Available",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        labelOTAS.ForeColor = Color.YellowGreen;
                        labelOTAS.Text = "Actualización: Nueva versión disponible! v" + args.CurrentVersion;

                        dialogResult =
                         MessageBox.Show(
                             $@"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}. This is required update. Press Ok to begin updating the application.", @"Update Available",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                    }

                    AutoUpdater.Mandatory = true;
                    AutoUpdater.UpdateMode = Mode.Forced;
                    AutoUpdater.ShowRemindLaterButton = false;
                    AutoUpdater.ShowSkipButton = false;
                    AutoUpdater.ShowUpdateForm(args);

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    labelOTAS.ForeColor = Color.Green;
                    labelOTAS.Text = "Actualización: Estás en la última versión!";
                }
            }
            else
            {
                if (args.Error is WebException)
                {
                    labelOTAS.ForeColor = Color.Red;
                    labelOTAS.Text = "Actualización: Error al obtener información del servidor...";
                }
                else
                {
                    MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void DescargarMusica_Load(object sender, EventArgs e)
        {
            AvoidFlick();

            labelOTAS.Text = "Actualización: Obteniendo información...";

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

            progressBar1.Hide();
            labelEstado.Hide();
            buttonComenzarDescarga.Hide();
            labelRuta.Text = "Ruta de descarga: " + downloadPath;

            // Verifico OTA
            AutoUpdater.Start("https://raw.githubusercontent.com/Franco28/YouTubeDownloadAPP/main/SETUP/data/ota.xml");
        }

        private void buttonGoToFolder_Click(object sender, EventArgs e)
        {
            Process.Start(downloadPath);
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
            WebClient cli = new WebClient();
            var imgBytes = cli.DownloadData("https://img.youtube.com/vi/" + getID(textBoxURL.Text) + "/hqdefault.jpg");
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
                AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
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
            //var app = new EditAudio();
            //app.ShowDialog();
            return;
        }

        private void radioButtonWAV_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxAuBitrate.Hide();
        }

        private void radioButtonMP3_CheckedChanged(object sender, EventArgs e)
        {
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
