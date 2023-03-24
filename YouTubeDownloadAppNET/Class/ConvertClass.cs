using System.Web;

namespace YouTubeDownloadAppNET.Class
{
    public class ConvertClass
    {
        private static string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "YouTubeDownload");

        // convert byte[] to image bitmap
        protected static readonly ImageConverter _imageConverter = new ImageConverter();
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
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
        public static string getID(string url)
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
        public static void SetAlbumArt(TagLib.File file)
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
    }
}
