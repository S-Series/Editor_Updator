using System;
using System.IO;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Updator
{
    public partial class Form1 : Form
    {
        private bool isDownload = false;

        public Form1()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------
        
        private void Submit_btn_Click(object sender, EventArgs e)
        {
            if (!isDownload)
            {
                isDownload = true;
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    ProgressText.Text = "Cannot connect to server";
                    Submit_btn.Text = "Close";
                    Cancel_btn.Enabled = false;
                    return;
                }
                ProgressText.Text = "Now On Downloading...";
                Submit_btn.Text = "Done";
                Submit_btn.Enabled = false;

                downloadWork.RunWorkerAsync();
            }
            else
            {
                Application.Exit();
            }
        }
        
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //-----------------------------------------------------------

        private async void downloadWork_DoWork(object sender, DoWorkEventArgs e)
        {
            string path, downloadURL;
            HttpClient client = new HttpClient();
            path = Application.StartupPath + @"1.0.0.zip";
            downloadURL = download_URL();

            using (HttpResponseMessage response = client.GetAsync(downloadURL, HttpCompletionOption.ResponseHeadersRead).Result)
            {
                response.EnsureSuccessStatusCode();

                using (Stream contentStream = await response.Content.ReadAsStreamAsync(), fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    var totalRead = 0L;
                    var totalReads = 0L;
                    var buffer = new byte[8192];
                    var isMoreToRead = true;

                    do
                    {
                        var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            await fileStream.WriteAsync(buffer, 0, read);

                            totalRead += read;
                            totalReads += 1;

                            if (totalReads % 2000 == 0)
                            {
                                Debug.WriteLine(string.Format("total bytes downloaded so far: {0:n0}", totalRead));
                            }
                        }
                    }
                    while (isMoreToRead);
                }
            }
        }

        private void downloadWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void downloadWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Submit_btn.Enabled = true;
            Cancel_btn.Enabled = false;
            //ProgressText.Text = "Download Complete!";
        }

        private string download_URL()
        {
            //return "https://drive.google.com/file/d/19MqoIKewBie9MINqspoAxS1oMQnTdOa9/view?usp=drive_link";
            
            return "https://drive.google.com/u/0/uc?id=19MqoIKewBie9MINqspoAxS1oMQnTdOa9&export=download&confirm=t&uuid=64d3da8f-ae7f-4be1-9f16-6b3d1f2a3492&at=AB6BwCC_WQW1VJpQhX2INb9jlUcB:1692152818464";
        }
    }
}
