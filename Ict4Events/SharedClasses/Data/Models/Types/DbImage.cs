using System;
using System.Drawing;
using System.Net;

namespace SharedClasses.Data.Models.Types
{
    public class DbImage : IConvertible
    {
        /// <summary>
        ///     Creates a new <see cref="DbImage" /> that is compatible for storage in a database.
        /// </summary>
        /// <param name="image"><see cref="Image" /> to store.</param>
        /// <param name="uri"><see cref="Uri" /> of <see cref="Image" /> to store.</param>
        public DbImage(Image image, Uri uri)
        {
            Image = image;
            Uri = uri;
        }

        /// <summary>
        ///     <see cref="Image" /> behind the <see cref="Uri" />.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        ///     Location of the <see cref="Image" />. Can be local or remote.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        ///     Downloads the <see cref="Image" /> using the <see cref="Uri" /> as location.
        /// </summary>
        /// <returns></returns>
        public bool DownloadImage()
        {
            if (string.IsNullOrWhiteSpace(Uri.OriginalString)) return false;

            using (var client = new WebClient())
                client.DownloadString(Uri);
            return true;
        }

        /// <summary>
        ///     Returns the <see cref="Uri" /> location.
        /// </summary>
        /// <param name="image">Image to cast from.</param>
        /// <returns>Locations details of the <see cref="Uri" />.</returns>
        public static explicit operator string(DbImage image)
        {
            return image.Uri.AbsoluteUri;
        }

        /// <summary>
        ///     Returns the <see cref="Uri" />'s location.
        /// </summary>
        /// <returns>Location of the <see cref="Uri" />.</returns>
        public override string ToString()
        {
            return Uri.AbsoluteUri;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.String;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Uri != null;
        }

        public char ToChar(IFormatProvider provider)
        {
            if (Uri == null) return '\0';
            return Uri.AbsoluteUri[0];
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return 0;
        }

        public byte ToByte(IFormatProvider provider)
        {
            return 0;
        }

        public short ToInt16(IFormatProvider provider)
        {
            return 0;
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return 0;
        }

        public int ToInt32(IFormatProvider provider)
        {
            return 0;
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return 0;
        }

        public long ToInt64(IFormatProvider provider)
        {
            return 0;
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return 0;
        }

        public float ToSingle(IFormatProvider provider)
        {
            return 0;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return 0;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return 0;
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return new DateTime();
        }

        public string ToString(IFormatProvider provider)
        {
            if (Uri == null) return "";
            return Uri.AbsoluteUri;
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(Uri.AbsoluteUri, conversionType);
        }
    }
}