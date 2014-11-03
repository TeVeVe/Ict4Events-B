using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;

namespace SharedClasses.Data.Models.Types
{
    public class DbImage
    {
        public DbImage(Image image, Uri uri)
        {
            Image = image;
            Uri = uri;
        }

        public Image Image { get; set; }
        public Uri Uri { get; set; }

        public bool DownloadImage()
        {
            if (string.IsNullOrWhiteSpace(Uri.OriginalString)) return false;

            using (var client = new WebClient())
                client.DownloadString(Uri);
            return true;
        }

        public static implicit operator DbImage(Bitmap bitmap)
        {
            return new DbImage(bitmap, null);
        }

        public static explicit operator Bitmap(DbImage image)
        {
            return (Bitmap)image.Image;
        }
    }
}