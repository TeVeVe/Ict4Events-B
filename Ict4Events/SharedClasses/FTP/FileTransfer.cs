using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using SharedClasses.Extensions;
using SharedClasses.Properties;
using MessageBox = System.Windows.MessageBox;

namespace SharedClasses.FTP
{
    public class FileTransfer
    {
        private static readonly NetworkCredential credentials = new NetworkCredential(Settings.Default.FTP_UserID,
            Settings.Default.FTP_Password);

        /// <summary>
        ///     This method is used to upload files to our FTP server
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="categories"></param>
        /// <returns></returns>
        public static bool UploadFile(string filePath, IEnumerable<string> categories)
        {
            string categoriesPath = "";
            string fileName = Path.GetFileName(filePath);

            //Creating a path from the categories
            foreach (string c in categories)
                categoriesPath += c + '/';

            if (CreateFolder(categoriesPath))
            {
                var uploadRequest =
                    (FtpWebRequest)
                        WebRequest.Create(String.Format("ftp://{0}/{1}{2}", Settings.Default.FTP_Server, categoriesPath,
                            fileName));
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                uploadRequest.Credentials = credentials;

                using (FileStream fs = File.OpenRead(filePath))
                {
                    var buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = uploadRequest.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                    requestStream.Flush();
                }

                var response = (FtpWebResponse)uploadRequest.GetResponse();
                MessageBox.Show(String.Format("File upload complete, status: {0}", response.StatusDescription));
                response.Close();
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Creating the directory on the FTP server
        /// </summary>
        /// <param name="categoriesPath"></param>
        /// <returns></returns>
        private static bool CreateFolder(string categoriesPath)
        {
            try
            {
                var directoryRequest =
                    (FtpWebRequest)
                        WebRequest.Create(String.Format("ftp://{0}/{1}", Settings.Default.FTP_Server, categoriesPath));
                directoryRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                directoryRequest.Credentials = credentials;

                using (var resp = (FtpWebResponse)directoryRequest.GetResponse())
                    Console.WriteLine(resp.StatusCode);

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
                response.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool DownloadFile(string fileName)
        {
            var request =
                (FtpWebRequest)WebRequest.Create(String.Format("ftp://{0}/{1}", Settings.Default.FTP_Server, fileName));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(Settings.Default.FTP_UserID, Settings.Default.FTP_Password);

            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                MessageBox.Show("Kon het bestand niet ophalen van de server. Mogelijk bestaat het bestand niet.",
                    "Bestand bestaat niet", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            Stream responseStream = response.GetResponseStream();

            Task<bool> openFileTask = TaskExt.StartSTATask(() =>
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        File.WriteAllBytes(String.Format("{0}\\{1}", fbd.SelectedPath, Path.GetFileName(fileName)),
                            responseStream.ReadAllBytes());
                        Debug.WriteLine("Download Complete, status {0}", response.StatusDescription);
                        response.Close();
                        return true;
                    }
                }
                return false;
            });
            openFileTask.Wait();

            response.Close();
            return openFileTask.Result;
        }

        public static string DownloadFileTemp(string fileName, out bool success)
        {
            success = false;
            var request =
                (FtpWebRequest)WebRequest.Create(String.Format("ftp://{0}/{1}", Settings.Default.FTP_Server, fileName));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(Settings.Default.FTP_UserID, Settings.Default.FTP_Password);

            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                MessageBox.Show("Kon het bestand niet ophalen van de server. Mogelijk bestaat het bestand niet.",
                    "Bestand bestaat niet", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + Path.GetExtension(fileName));
            Stream responseStream = response.GetResponseStream();

            File.WriteAllBytes(tempPath, responseStream.ReadAllBytes());
            Debug.WriteLine("Download Complete, status {0}", response.StatusDescription);
            response.Close();
            success = true;
            return tempPath;
        }

        public static IEnumerable<string> GetDirectoryNames(TreeNode node)
        {
            var categoryList = new List<String>();
            TreeNode parent = node.Parent;

            categoryList.Add(node.Text);
            while (parent != null)
            {
                categoryList.Add(parent.Text);
                parent = parent.Parent;
            }

            categoryList.Reverse();
            return categoryList;
        }
    }
}