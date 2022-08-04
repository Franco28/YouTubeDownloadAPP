using MediaToolkit;
using MediaToolkit.Model;
using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace YouTubeDownload
{
    public partial class EditAudio : Form
    {
        public EditAudio()
        {
            InitializeComponent();
        }

        private string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "YouTubeDownload");
        
        private byte[] mp3FileDialog;
        private string filePath;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private void EditAudio_Load(object sender, EventArgs e)
        {
            labelEstado.Hide();
            progressBar1.Hide();
            buttonCutAudio.Hide();
        }

        private void loadFile(string file)
        {
            progressBar1.Show();
            labelEstado.Show();
            labelEstado.Text = "Estado: Cargando archivo...";
            progressBar1.Value = 50;

            // Ruta general
            filePath = Path.Combine(downloadPath, $"{Path.GetFileName(file)}");
            
            // Medifile para obtenr metadatos
            var inputFile = new MediaFile { Filename = filePath };

            // mp3 transformado a wav
            var outputFileWAV = Path.Combine(downloadPath, $"{Path.GetFileNameWithoutExtension(file)}" + ".wav");
            using (var engine = new Engine())
            {
                if (Path.GetExtension(file) == ".mp3")
                {
                    labelEstado.Text = "Estado: Obteniendo información del audio...";
                    progressBar1.Value = 55;
                    TagLib.File tfile = TagLib.File.Create(file);
                    var bin = tfile.Tag.Pictures[0].Data.Data;
                    pictureBox1.Image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(720, 1080, null, IntPtr.Zero);

                    labelAlbum.Text = "Álbum: " + tfile.Tag.Album.ToString();
                    labelComentario.Text = "Comentario: " + tfile.Tag.Publisher.ToString();

                    progressBar1.Value = 60;
                    mp3FileDialog = File.ReadAllBytes(filePath);
                }
                else if (Path.GetExtension(file) == ".wav")
                {
                    mp3FileDialog = File.ReadAllBytes(file);
                }

                progressBar1.Value = 70;
                labelEstado.Text = "Estado: Obteniendo metadatos del audio...";
                engine.GetMetadata(inputFile);
            }

            if (Path.GetExtension(file) == ".wav")
            {
                progressBar1.Value = 75;
                this.waveViewer1.WaveStream = new WaveFileReader(filePath);
            }

            labelEstado.Text = "Estado: Obteniendo metadata...";
            progressBar1.Value = 85;
            long size = mp3FileDialog.Length;
            labelAudioBitrate.Text = "Audio Bitrate: " + inputFile.Metadata.AudioData.BitRateKbs.ToString() + "Kbs";
            labelTipoArchivo.Text = "Tipo Archivo: " + Path.GetExtension(file);
            labelTamanoArchivo.Text = "Tamaño Del Archivo: " + Interface.SizeSuffix(size);
            labelTiempoTotal.Text = "Tiempo Total: " + inputFile.Metadata.Duration.Minutes + ":" + inputFile.Metadata.Duration.Seconds + " minutos";
            labelRutaAudio.Text = "Ruta: " + filePath;

            textBoxAudioHora.Text = inputFile.Metadata.Duration.Hours.ToString();
            textBoxAudioMinuto.Text = inputFile.Metadata.Duration.Minutes.ToString();
            textBoxAudioSegundo.Text = inputFile.Metadata.Duration.Seconds.ToString();

            textBoxCH.Text = textBoxAudioHora.Text;
            textBoxCM.Text = textBoxAudioMinuto.Text;
            textBoxCS.Text = textBoxAudioSegundo.Text;

            labelEstado.Text = "Estado: Listo!";
            progressBar1.Value = 100;

            Thread.Sleep(1000);
            progressBar1.Hide();
            labelEstado.Hide();
            buttonCutAudio.Show();
            progressBar1.Value = 0;
        }

        private void buttonCargarAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "YouTubeDownload"),
                Title = "Buscar Archivos De Audio",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "Audio",
                Filter = "Archivos De Audio (*.wav;*.mp3)|*.mp3;*.wav",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadFile(openFileDialog1.FileName);
            }
        }

        private void EditAudio_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if ((files.Count() == 1) && ((Path.GetExtension(files[0]) == ".mp3") ||
                                         (Path.GetExtension(files[0]) == ".wav")))
            {
                loadFile(files[0]);
            }
        }

        private void EditAudio_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if ((files.Count() == 1) && ((Path.GetExtension(files[0]) == ".mp3") ||
                                        (Path.GetExtension(files[0]) == ".wav")))
                e.Effect = DragDropEffects.Copy;
        }

        private void TrimMp3(string inputPath, string outputPath, TimeSpan? begin, TimeSpan? end)
        {
            if (begin.HasValue && end.HasValue && begin == end)
            {
                progressBar1.Value = 100;
                labelEstado.Text = "Estado: Error...";
                MessageBox.Show("El final y el comienzo no pueden ser iguales", "No se puede cortar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelEstado.Hide();
                progressBar1.Hide();
                return;
            }

            if (begin.HasValue && end.HasValue && begin > end)
            {
                progressBar1.Value = 100;
                labelEstado.Text = "Estado: Error...";
                MessageBox.Show("El final debe ser mayor que el comienzo", "No se puede cortar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelEstado.Hide();
                progressBar1.Hide();
                return;
            }

            var inputFile = new MediaFile { Filename = inputPath };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

            using (var reader = new Mp3FileReader(inputPath))
            using (var writer = File.Create(outputPath))
            {
                progressBar1.Value = 80;
                labelEstado.Text = $"Estado: Cortando audio [{begin} / {end}]...";

                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (reader.CurrentTime >= begin || !begin.HasValue)
                    {
                        if (reader.CurrentTime <= end || !end.HasValue)
                        {
                            writer.Write(frame.RawData, 0, frame.RawData.Length);
                        }
                        else 
                        {
                            break;
                        }
                    }
                }
            }

            // Create again metadata
            TagLib.File tfile = TagLib.File.Create(inputPath);
            var bin = tfile.Tag.Pictures[0].Data.Data;
            pictureBox1.Image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(720, 1080, null, IntPtr.Zero);

            File.ReadAllBytes(downloadPath + @"\cover.jpeg");

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

            var inputFileTag = TagLib.File.Create(outputPath);
            inputFileTag.Tag.Title = title;
            inputFileTag.Tag.Comment = "Música descargada con YouTubeDownload por Franco Mato / " + textBoxComentario.Text;
            inputFileTag.Tag.Publisher = "Música descargada con YouTubeDownload por Franco Mato / " + textBoxComentario.Text;
            inputFileTag.Tag.Album = vid.FullName;
            inputFileTag.Save();

        }

        private void buttonCutAudio_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            labelEstado.Show();

            progressBar1.Value = 10;
            labelEstado.Text = "Estado: Preparando archivo...";

            string sourceFile = Path.Combine(downloadPath, $"{Path.GetFileName(filePath)}");
            string outputFile = Path.GetDirectoryName(filePath) + @"/" + Path.GetFileNameWithoutExtension(filePath) + "_audio_cortado.mp3";

            string hoursC = textBoxCH.Text;
            string minutesC = textBoxCM.Text;
            string secondsC = textBoxCS.Text;

            string hours = textBoxAudioHora.Text;
            string minutes = textBoxAudioMinuto.Text;
            string seconds = textBoxAudioSegundo.Text;

            double hoursSegundos;
            double minutesSegundos;
            double segundosSegundos;

            if (hours == "0")
            {
                hoursSegundos = 0;
            } 
            else
            {
                hoursSegundos = Convert.ToDouble(hours);
                hoursSegundos *= 3600;
            }

            if (minutes == "0")
            {
                minutesSegundos = 0;
            }
            else
            {
                minutesSegundos = Convert.ToDouble(minutes);
                minutesSegundos *= 60;
            }

            if (seconds == "0")
            {
                segundosSegundos = 0;
            } 
            else
            {
                segundosSegundos = Convert.ToDouble(seconds);
            }

            double hoursSegundosC;
            double minutesSegundosC;
            double segundosSegundosC;

            if (hoursC == "0")
            {
                hoursSegundosC = 0;
            } 
            else
            {
                hoursSegundosC = Convert.ToDouble(hoursC);
                hoursSegundosC *= 3600;
            }

            if (minutesC == "0")
            {
                minutesSegundosC = 0;
            }
            else
            {
                minutesSegundosC = Convert.ToDouble(minutesC);
                minutesSegundosC *= 60;
            }

            if (secondsC == "0")
            {
                segundosSegundosC = 0;
            } 
            else
            {
                segundosSegundosC = Convert.ToDouble(secondsC);
            }

            double timeCutGet = hoursSegundos + minutesSegundos + segundosSegundos;
            double timeCutGetC = hoursSegundosC + minutesSegundosC + segundosSegundosC;

            double endCut = timeCutGetC - timeCutGet;
            
            progressBar1.Value = 30;
            labelEstado.Text = "Estado: Leyendo archivo...";
            TrimMp3(sourceFile, outputFile, TimeSpan.FromSeconds(endCut), TimeSpan.FromSeconds(timeCutGetC));

            progressBar1.Value = 100;
            labelEstado.Text = "Estado: Listo!";

            Thread.Sleep(1000);
            progressBar1.Hide();
            labelEstado.Hide();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (filePath == null || filePath == string.Empty)
            {
                return;
            }

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(filePath);
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();

            if (outputDevice != null)
            {
                int currentTime = (int)(outputDevice.GetPosition() * 1d / outputDevice.OutputWaveFormat.AverageBytesPerSecond);
                labelTiempoTranscurrido.Text = "Tiempo Transcurrido: " + currentTime.ToString();
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            outputDevice?.Stop();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            outputDevice?.Dispose();
        }

        private void EditAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
        }

        private void textBoxAudioHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
