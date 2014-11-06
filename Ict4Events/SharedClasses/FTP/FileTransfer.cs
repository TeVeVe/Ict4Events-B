using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharedClasses
{
    public class FileTransfer
    {
        public static bool UploadFile(string filePath, List<string> categories)
        {
            string fileName = "";
            string categoriesPath = "";

            /* Getting the filename from the path */
            string[] paths = filePath.Split('\\');
            fileName = paths.Last();

            /* Creating a path from the categories */
            foreach (string c in categories)
            {
                categoriesPath += c + "/";
            }

            if (CreateFolder(categoriesPath))
            {
                var uploadRequest =
                    (FtpWebRequest)
                        WebRequest.Create(String.Format("ftp://{0}/{1}{2}", Properties.Settings.Default.FTP_Server, categoriesPath, fileName));
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;

                uploadRequest.Credentials = new NetworkCredential(Properties.Settings.Default.FTP_UserID, Properties.Settings.Default.FTP_Password);

                var reader = new StreamReader(filePath);
                Byte[] fileContents = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                reader.Close();
                uploadRequest.ContentLength = fileContents.Length;

                Stream requestStream = uploadRequest.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                var response = (FtpWebResponse) uploadRequest.GetResponse();

                MessageBox.Show(String.Format("File upload complete, status: {0}", response.StatusDescription));

                response.Close();
                return true;
            }

            else
            {
                return false;
            }
        }


        /* Creating the directory on the FTP server */
        private static bool CreateFolder(string categoriesPath)
        {
            try
            {
                var directoryRequest =
                    (FtpWebRequest)WebRequest.Create(String.Format("ftp://{0}/{1}", Properties.Settings.Default.FTP_Server, categoriesPath));
                directoryRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                directoryRequest.Credentials = new NetworkCredential(Properties.Settings.Default.DB_UserID, Properties.Settings.Default.FTP_Password);

                using (var resp = (FtpWebResponse)directoryRequest.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }

                return true;
            }

            catch (WebException ex)
            {
                var response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return true;
                }
                else
                {
                    response.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }
}
