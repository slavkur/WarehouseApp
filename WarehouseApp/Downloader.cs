using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Security.AccessControl;

namespace WarehouseApp
{
    public class Downloader
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(Downloader));

        public delegate void DownloadProgressDelegate(int percProgress);
        //public delegate void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e);

        public static void DownloadFile(string source, string destination, DownloadProgressChangedEventHandler client_DownloadProgressChanged)
        {
            try
            {
                using (WebClient _WebClient = new WebClient())
                {
                    // Downloads the resource with the specified URI 
                    // to a local file.
                    _WebClient.DownloadProgressChanged += client_DownloadProgressChanged;

                    Uri remoteUri = new Uri(source);
                    destination = Path.GetFileName(remoteUri.LocalPath);
                    _WebClient.DownloadFileAsync(remoteUri, destination);
                }
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                    _Exception.ToString());
            }
        }

        public static void Download(string uri, string localPath, DownloadProgressDelegate progressDelegate)
        {
            long remoteSize;
            string fullLocalPath; // Full local path including file name if only directory was provided.

            //log.InfoFormat("Attempting to download file (Uri={0}, LocalPath={1})", uri, localPath);

            //try
            //{
                /// Get the name of the remote file.
                Uri remoteUri = new Uri(uri);
                string fileName = Path.GetFileName(remoteUri.LocalPath);
                Console.WriteLine(fileName);

                //if (Path.GetFileName(localPath).Length == 0)
                fullLocalPath = Path.Combine(localPath, fileName);
                //else
                //    fullLocalPath = localPath;

                //Create a new subfolder under the current active folder 
                //fullLocalPath = System.IO.Path.Combine(fullLocalPath, "test");
                // Create the subfolder
                
                //DirectoryInfo directory = System.IO.Directory.CreateDirectory(fullLocalPath);
                //directory.Attributes = FileAttributes.Normal;
                //DirectorySecurity security = directory.GetAccessControl();
                //security.SetAccessRule(new FileSystemAccessRule(Environment.UserDomainName.ToString() + "\\" + Environment.UserName.ToString(), FileSystemRights.Write, AccessControlType.Allow));
                //directory.SetAccessControl(security);

                /// Have to get size of remote object through the webrequest as not available on remote files,
                /// although it does work on local files.
                using (WebResponse response = WebRequest.Create(uri).GetResponse())
                using (Stream stream = response.GetResponseStream())
                    remoteSize = response.ContentLength;

                //log.InfoFormat("Downloading file (Uri={0}, Size={1}, FullLocalPath={2}).",
                //    uri, remoteSize, fullLocalPath);
            /*}
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Error connecting to URI (Exception={0})", ex.Message), ex);
            }*/

            int bytesRead = 0, bytesReadTotal = 0;

            Console.WriteLine(fullLocalPath);

            try
            {
                using (WebClient client = new WebClient())
                using (Stream streamRemote = client.OpenRead(new Uri(uri)))
                using (Stream streamLocal = new FileStream(fullLocalPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    byte[] byteBuffer = new byte[1024 * 1024 * 2]; // 2 meg buffer although in testing only got to 10k max usage.
                    int perc = 0;
                    while ((bytesRead = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                    {
                        bytesReadTotal += bytesRead;

                        

                        streamLocal.Write(byteBuffer, 0, bytesRead);
                        int newPerc = (int)((double)bytesReadTotal / (double)remoteSize * 100);
                        if (newPerc > perc)
                        {
                            //log.InfoFormat("...Downloading (BytesRead={0}, Perc={1})...", bytesReadTotal, perc);
                            perc = newPerc;
                            if (progressDelegate != null)
                                progressDelegate(perc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Error downloading file (Exception={0})", ex.Message), ex);
            }

            //log.InfoFormat("File successfully downloaded (Uri={0}, BytesDownloaded={1}/{2}, FullLocalPath={3}).",
            //    uri, bytesReadTotal, remoteSize, fullLocalPath);
        }
    }
}
