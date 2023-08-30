using System.IO.Compression;
using System.ComponentModel;

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
                progressBar.Enabled = true;
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

                downloadWorker.RunWorkerAsync();
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 50;
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

        private async Task Download()
        {
            string path, fileURL, downloadURL;
            HttpClient client = new HttpClient();
            HttpClient _client = new HttpClient();

            path = Application.StartupPath + @"files.zip";
            fileURL = "https://drive.google.com/uc?export=download&id=1H_mkmsD34GGfC68_GByXcv832inwTDHu";
            downloadURL = await _client.GetStringAsync(fileURL);

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
                        }
                    }
                    while (isMoreToRead);
                }
            }
        }

        private async void downloadWork_DoWork(object sender, DoWorkEventArgs e)
        {
            var task = Download();
            task.Wait();

            string _path = Application.StartupPath;

            if (Directory.Exists(_path + @"ReMind"))
            {
                await Task.Run(() => Directory.Delete(_path + @"ReMind", true));
            }
            await Task.Run(() => ZipFile.ExtractToDirectory(_path + @"files.zip", _path + @"ReMind"));

            await Task.Run(() => File.Delete(_path + @"files.zip"));
        }

        private void downloadWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void downloadWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cancel_btn.Enabled = false;
            Submit_btn.Enabled = true;
            Submit_btn.Text = "Done";
            ProgressText.Text = "Complete!";
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;
        }
    }
}
