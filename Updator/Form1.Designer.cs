namespace Updator
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProgressText = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Submit_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.downloadWork = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ProgressText
            // 
            this.ProgressText.AutoSize = true;
            this.ProgressText.Location = new System.Drawing.Point(22, 35);
            this.ProgressText.Margin = new System.Windows.Forms.Padding(5);
            this.ProgressText.Name = "ProgressText";
            this.ProgressText.Size = new System.Drawing.Size(141, 12);
            this.ProgressText.TabIndex = 0;
            this.ProgressText.Text = "Press Start to Download";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(19, 64);
            this.progressBar.Margin = new System.Windows.Forms.Padding(10);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(396, 23);
            this.progressBar.TabIndex = 1;
            // 
            // Submit_btn
            // 
            this.Submit_btn.Location = new System.Drawing.Point(340, 103);
            this.Submit_btn.Name = "Submit_btn";
            this.Submit_btn.Size = new System.Drawing.Size(75, 23);
            this.Submit_btn.TabIndex = 2;
            this.Submit_btn.Text = "Start";
            this.Submit_btn.UseVisualStyleBackColor = true;
            this.Submit_btn.Click += new System.EventHandler(this.Submit_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(259, 103);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.Cancel_btn.TabIndex = 3;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // downloadWork
            // 
            this.downloadWork.WorkerReportsProgress = true;
            this.downloadWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloadWork_DoWork);
            this.downloadWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.downloadWork_ProgressChanged);
            this.downloadWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.downloadWork_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(434, 141);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Submit_btn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ProgressText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.Text = "Editor Updator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProgressText;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button Submit_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.ComponentModel.BackgroundWorker downloadWork;
    }
}

