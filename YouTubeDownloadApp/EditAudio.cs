using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using NAudio.Wave;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
        private bool wavFile = false;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private void EditAudio_Load(object sender, EventArgs e)
        {
            labelEstado.Hide();
            progressBar1.Hide();
            buttonCutAudio.Hide();
            buttonCortarPrincipio.Hide();

            textBoxAudioHora.Enabled = false;
            textBoxAudioMinuto.Enabled = false;
            textBoxAudioSegundo.Enabled = false;
            
            textBoxAudioHoraP.Enabled = false;
            textBoxAudioMinutosP.Enabled = false;
            textBoxAudioSegundosP.Enabled = false;

            textBoxAudioHora.Text = "---";
            textBoxAudioMinuto.Text = "---";
            textBoxAudioSegundo.Text = "---";

            textBoxAudioHoraP.Text = "---";
            textBoxAudioMinutosP.Text = "---";
            textBoxAudioSegundosP.Text = "---";
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

                    if (tfile.Tag.Pictures[0].Data.Data != null)
                    {
                        var bin = tfile.Tag.Pictures[0].Data.Data;
                        pictureBox1.Image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(1280, 720, null, IntPtr.Zero);
                    }

                    if (tfile.Tag.Album != null)
                    {
                        labelAlbum.Text = "Álbum: " + tfile.Tag.Album.ToString();
                    }

                    if (tfile.Tag.Publisher != null)
                    {
                        labelComentario.Text = "Comentario: " + tfile.Tag.Publisher.ToString();
                    }

                    progressBar1.Value = 60;
                    mp3FileDialog = File.ReadAllBytes(filePath);

                    wavFile = false;
                }
                
                if (Path.GetExtension(file) == ".wav")
                {
                    progressBar1.Value = 70;
                    labelEstado.Text = "Estado: Convirtiendo .wav a .mp3...";
                    engine.CustomCommand($" -i {file} -acodec libmp3lame -b:a 320k {Path.GetFullPath(file) + Path.GetFileNameWithoutExtension(file) + ".mp3"}");

                    File.Delete(Path.GetFullPath(file) + Path.GetFileNameWithoutExtension(file) + ".wav");

                    filePath = Path.Combine(downloadPath, $"{Path.GetFileName(file)}");

                    mp3FileDialog = File.ReadAllBytes(file);

                    wavFile = true;
                }

                progressBar1.Value = 75;
                labelEstado.Text = "Estado: Obteniendo metadatos del audio...";
                engine.GetMetadata(inputFile);
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

            textBoxAudioHoraP.Text = inputFile.Metadata.Duration.Hours.ToString();
            textBoxAudioMinutosP.Text = inputFile.Metadata.Duration.Minutes.ToString();
            textBoxAudioSegundosP.Text = inputFile.Metadata.Duration.Seconds.ToString();

            labelEstado.Text = "Estado: Listo!";
            progressBar1.Value = 100;

            Thread.Sleep(1000);
            progressBar1.Hide();
            labelEstado.Hide();
            buttonCutAudio.Show();
            buttonCortarPrincipio.Show();

            textBoxAudioHora.Enabled = true;
            textBoxAudioMinuto.Enabled = true;
            textBoxAudioSegundo.Enabled = true;

            textBoxAudioHoraP.Enabled = true;
            textBoxAudioMinutosP.Enabled = true;
            textBoxAudioSegundosP.Enabled = true;

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

        private void buttonCortarPrincipio_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            labelEstado.Show();
            Thread.Sleep(500);

            progressBar1.Value = 10;
            labelEstado.Text = "Estado: Preparando archivo...";

            string sourceFile = Path.Combine(downloadPath, $"{Path.GetFileName(filePath)}");
            string outputFile = Path.GetDirectoryName(filePath) + @"/" + Path.GetFileNameWithoutExtension(filePath) + "_audio_cortado.mp3";

            Thread.Sleep(500);

            progressBar1.Value = 20;
            labelEstado.Text = "Estado: Preparando tiempo a cortar del audio...";

            double hoursSegundos;
            double minutesSegundos;
            double segundosSegundos;

            if (textBoxAudioHoraP.Text == "0")
            {
                hoursSegundos = 0;
            }
            else
            {
                hoursSegundos = Convert.ToDouble(textBoxAudioHoraP.Text);
                hoursSegundos *= 3600;
            }

            if (textBoxAudioMinutosP.Text == "0")
            {
                minutesSegundos = 0;
            }
            else
            {
                minutesSegundos = Convert.ToDouble(textBoxAudioMinutosP.Text);
                minutesSegundos *= 60;
            }

            if (textBoxAudioSegundosP.Text == "0")
            {
                segundosSegundos = 0;
            }
            else
            {
                segundosSegundos = Convert.ToDouble(textBoxAudioSegundosP.Text);
            }

            double timeCutGetCortar = hoursSegundos + minutesSegundos + segundosSegundos;
            double timeCutGetOriginal = 0;

            progressBar1.Value = 50;
            labelEstado.Text = "Estado: Preparando...";
            Thread.Sleep(500);

            var inputFileC = new MediaFile { Filename = Path.Combine(downloadPath, Path.GetFileName(sourceFile)) };
            var outputFileC = new MediaFile { Filename = Path.Combine(downloadPath, Path.GetFileNameWithoutExtension(sourceFile) + $"_audio_cortado.mp3") };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFileC);

                timeCutGetOriginal = inputFileC.Metadata.Duration.Hours + inputFileC.Metadata.Duration.Minutes + inputFileC.Metadata.Duration.Seconds;

                progressBar1.Value = 70;
                labelEstado.Text = $"Estado: Cortando audio {timeCutGetOriginal} / {timeCutGetCortar}...";
                Thread.Sleep(500);
                engine.GetMetadata(inputFileC);

                var options = new ConversionOptions();
                options.CutMedia(TimeSpan.FromSeconds(timeCutGetOriginal), TimeSpan.FromSeconds(timeCutGetCortar));

                progressBar1.Value = 90;
                labelEstado.Text = $"Estado: Convirtiendo audio {timeCutGetOriginal} / {timeCutGetCortar}...";
                Thread.Sleep(500);
                engine.Convert(inputFileC, outputFileC, options);
            }

            progressBar1.Value = 100;
            labelEstado.Text = "Estado: Listo!";
            Thread.Sleep(500);

            MessageBox.Show($"Listo! Se corto el audio {Path.GetFileName(outputFile)} de {timeCutGetOriginal} / {timeCutGetCortar} y se guardó en " + downloadPath, "Audio cortado correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(downloadPath);

            progressBar1.Hide();
            labelEstado.Hide();
        }

        private void buttonCutAudio_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            labelEstado.Show();
            Thread.Sleep(500);

            progressBar1.Value = 10;
            labelEstado.Text = "Estado: Preparando archivo...";

            string sourceFile = Path.Combine(downloadPath, $"{Path.GetFileName(filePath)}");
            string outputFile = Path.GetDirectoryName(filePath) + @"/" + Path.GetFileNameWithoutExtension(filePath) + "_audio_cortado.mp3";

            Thread.Sleep(500);

            progressBar1.Value = 20;
            labelEstado.Text = "Estado: Preparando tiempo a cortar del audio...";

            double hoursSegundos;
            double minutesSegundos;
            double segundosSegundos;

            if (textBoxAudioHora.Text == "0")
            {
                hoursSegundos = 0;
            } 
            else
            {
                hoursSegundos = Convert.ToDouble(textBoxAudioHora.Text);
                hoursSegundos *= 3600;
            }

            if (textBoxAudioMinuto.Text == "0")
            {
                minutesSegundos = 0;
            }
            else
            {
                minutesSegundos = Convert.ToDouble(textBoxAudioMinuto.Text);
                minutesSegundos *= 60;
            }

            if (textBoxAudioSegundo.Text == "0")
            {
                segundosSegundos = 0;
            } 
            else
            {
                segundosSegundos = Convert.ToDouble(textBoxAudioSegundo.Text);
            }

            double timeCutGetCortar = hoursSegundos + minutesSegundos + segundosSegundos;
            double timeCutGetOriginal = 0;

            progressBar1.Value = 30;
            labelEstado.Text = "Estado: Preparando...";
            Thread.Sleep(500);
      
            var inputFileC = new MediaFile { Filename = Path.Combine(downloadPath, Path.GetFileName(sourceFile)) };
            var outputFileC = new MediaFile { Filename = Path.Combine(downloadPath, Path.GetFileNameWithoutExtension(sourceFile) + $"_audio_cortado.mp3") };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFileC);

                timeCutGetOriginal = inputFileC.Metadata.Duration.Hours + inputFileC.Metadata.Duration.Minutes + inputFileC.Metadata.Duration.Seconds;

                progressBar1.Value = 50;
                labelEstado.Text = $"Estado: Cortando audio {timeCutGetOriginal} / {timeCutGetCortar}...";
                Thread.Sleep(500);
                engine.GetMetadata(inputFileC);

                var options = new ConversionOptions();
                options.CutMedia(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(timeCutGetCortar));

                progressBar1.Value = 80;
                labelEstado.Text = $"Estado: Convirtiendo audio {timeCutGetOriginal} / {timeCutGetCortar}...";
                Thread.Sleep(500);
                engine.Convert(inputFileC, outputFileC, options);
            }

            // Create again metadata
            TagLib.File oldFile = TagLib.File.Create(sourceFile);
            pictureBox1.Image.Save(downloadPath + @"\cover.jpeg", ImageFormat.Jpeg);

            progressBar1.Value = 85;
            labelEstado.Text = $"Estado: Agregando los metadatos al audio cortado...";

            var inputFileTag = TagLib.File.Create(outputFile);
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
            inputFileTag.Tag.Pictures = new TagLib.IPicture[] { cover };

            inputFileTag.Tag.Title = oldFile.Tag.Title;
            inputFileTag.Tag.Comment = oldFile.Tag.Comment;
            inputFileTag.Tag.Publisher = oldFile.Tag.Publisher;
            inputFileTag.Tag.Album = oldFile.Tag.Album;
            inputFileTag.Save();
            Thread.Sleep(1000);

            progressBar1.Value = 90;
            labelEstado.Text = $"Estado: Terminando...";
            oldFile.Dispose();
            Thread.Sleep(500);

            progressBar1.Value = 100;
            labelEstado.Text = "Estado: Listo!";
            Thread.Sleep(500);

            MessageBox.Show($"Listo! Se corto el audio {Path.GetFileName(outputFile)} de {timeCutGetOriginal} / {timeCutGetCortar} y se guardó en " + downloadPath, "Audio cortado correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(downloadPath);

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
