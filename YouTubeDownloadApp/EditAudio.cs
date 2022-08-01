using MediaToolkit;
using MediaToolkit.Model;
using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
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

        private void EditAudio_Load(object sender, EventArgs e)
        {
            labelEstado.Hide();
            progressBar1.Hide();
        }

        byte[] mp3FileDialog;
        string filePath;

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
                    labelEstado.Text = "Estado: Transformando archivo .mp3 a .wav...";
                    progressBar1.Value = 60;
                    engine.CustomCommand($" -i {filePath} -acodec pcm_u8 -ar 22050 {outputFileWAV}");
                    mp3FileDialog = File.ReadAllBytes(filePath);
                }
                else if (Path.GetExtension(file) == ".wav")
                {
                    mp3FileDialog = File.ReadAllBytes(file);
                }

                progressBar1.Value = 80;
                labelEstado.Text = "Estado: Obteniendo metadatos del audio...";

                engine.GetMetadata(inputFile);
            }

            labelEstado.Text = "Estado: Obteniendo metadata...";


            var outputFile_Path = Path.Combine(downloadPath, $"{filePath}");

            var tfile = TagLib.File.Create(outputFile_Path);
            string album = tfile.Tag.Album;
            string comment = tfile.Tag.Publisher;
            string artist = tfile.Tag.FirstPerformer;

            labelArtista.Text = "Artista: " + artist.ToString();
            labelAlbum.Text = "Álbum: " + album.ToString();
            labelComentario.Text = "Comentario: " + comment.ToString();

            if (Path.GetExtension(file) == ".wav")
            {
                this.waveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(filePath);
            }

            long size = mp3FileDialog.Length;

            labelAudioBitrate.Text = "Audio Bitrate: " + inputFile.Metadata.AudioData.BitRateKbs.ToString() + "Kbs";
            labelTipoArchivo.Text = "Tipo Archivo: " + Path.GetExtension(file);
            labelTamanoArchivo.Text = "Tamaño Del Archivo: " + Interface.SizeSuffix(size);
            labelTiempoTotal.Text = "Tiempo Total: " + inputFile.Metadata.Duration.Minutes.ToString() + " minutos";
            labelRutaAudio.Text = "Ruta: " + filePath;

            progressBar1.Value = 100;
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

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (Path.GetExtension(filePath) == ".wav")
            {      
                WaveStream mainOutputStream = new WaveFileReader(filePath);
                WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);

                WaveOutEvent player = new WaveOutEvent();
        
                player.Init(volumeStream);
                player.Play();

                labelTiempoTranscurrido.Text = "Tiempo Transcurrido: " + player.OutputWaveFormat.AverageBytesPerSecond;         
            }
        }
    }
}
