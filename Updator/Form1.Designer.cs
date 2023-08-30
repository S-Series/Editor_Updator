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
            ProgressText = new Label();
            progressBar = new ProgressBar();
            Submit_btn = new Button();
            Cancel_btn = new Button();
            downloadWorker = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // ProgressText
            // 
            ProgressText.AutoSize = true;
            ProgressText.Location = new Point(22, 44);
            ProgressText.Margin = new Padding(5, 6, 5, 6);
            ProgressText.Name = "ProgressText";
            ProgressText.Size = new Size(137, 15);
            ProgressText.TabIndex = 0;
            ProgressText.Text = "Press Start to Download";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(19, 80);
            progressBar.Margin = new Padding(10, 12, 10, 12);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(396, 29);
            progressBar.TabIndex = 1;
            // 
            // Submit_btn
            // 
            Submit_btn.Location = new Point(340, 129);
            Submit_btn.Margin = new Padding(3, 4, 3, 4);
            Submit_btn.Name = "Submit_btn";
            Submit_btn.Size = new Size(75, 29);
            Submit_btn.TabIndex = 2;
            Submit_btn.Text = "Start";
            Submit_btn.UseVisualStyleBackColor = true;
            Submit_btn.Click += Submit_btn_Click;
            // 
            // Cancel_btn
            // 
            Cancel_btn.Location = new Point(259, 129);
            Cancel_btn.Margin = new Padding(3, 4, 3, 4);
            Cancel_btn.Name = "Cancel_btn";
            Cancel_btn.Size = new Size(75, 29);
            Cancel_btn.TabIndex = 3;
            Cancel_btn.Text = "Cancel";
            Cancel_btn.UseVisualStyleBackColor = true;
            Cancel_btn.Click += Cancel_btn_Click;
            // 
            // backgroundWorker1
            // 
            downloadWorker.DoWork += downloadWork_DoWork;
            downloadWorker.ProgressChanged += downloadWork_ProgressChanged;
            downloadWorker.RunWorkerCompleted += downloadWork_RunWorkerCompleted;
            downloadWorker.WorkerReportsProgress = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(434, 176);
            Controls.Add(Cancel_btn);
            Controls.Add(Submit_btn);
            Controls.Add(progressBar);
            Controls.Add(ProgressText);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ImeMode = ImeMode.On;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Editor Updator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label ProgressText;
        public ProgressBar progressBar;
        public Button Submit_btn;
        public Button Cancel_btn;
        private System.ComponentModel.BackgroundWorker downloadWorker;
    }
}

