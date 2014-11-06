﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
                        WebRequest.Create(String.Format("ftp://{0}/{1}{2}", Settings.Default.FTP_Server, categoriesPath,
                            fileName));
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                uploadRequest.Credentials = credentials;

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

            return false;
        }

        /* Creating the directory on the FTP server */

        private static bool CreateFolder(string categoriesPath)
        {
            try
            {
                var directoryRequest =
                    (FtpWebRequest)
                        WebRequest.Create(String.Format("ftp://{0}/{1}", Settings.Default.FTP_Server, categoriesPath));
                directoryRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                directoryRequest.Credentials = credentials;

                using (var resp = (FtpWebResponse) directoryRequest.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }

                return true;
            }

            catch (WebException ex)
            {
                var response = (FtpWebResponse) ex.Response;
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

        public static bool DownloadFile(string path)
        {
            var request = (FtpWebRequest) WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(Settings.Default.FTP_UserID, Settings.Default.FTP_Password);

            string fileName = path.Split('/').Last();

            var response = (FtpWebResponse) request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File.WriteAllBytes(String.Format("{0}\\{1}", fbd.SelectedPath, fileName), responseStream.ReadAllBytes());
                    Debug.WriteLine("Download Complete, status {0}", response.StatusDescription);
                    response.Close();
                    return true;
                }
            }

            response.Close();
            return false;
        }
    }
}