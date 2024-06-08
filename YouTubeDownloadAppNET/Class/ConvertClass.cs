using System.Web;

namespace YouTubeDownloadAppNET.Class
{
    public class ConvertClass
    {     
        protected static readonly ImageConverter _imageConverter = new();

        /// <summary>
        /// Convert byte[] to image bitmap
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get YouTube ID
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Set cover art
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        public static void SetAlbumArt(TagLib.File file, string filePath)
        {
            byte[] imageBytes;
            imageBytes = File.ReadAllBytes(filePath + @"\cover.jpeg");

            TagLib.Id3v2.AttachmentFrame cover = new()
            {
                Type = TagLib.PictureType.FrontCover,
                Description = "Cover",
                MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
                Data = imageBytes,
                TextEncoding = TagLib.StringType.UTF16
            };

            file.Tag.Pictures = [cover];
            file.Save();
        }
    }
}
