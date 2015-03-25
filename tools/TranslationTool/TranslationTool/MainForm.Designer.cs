namespace TranslationTool
{
    partial class MainForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelURL = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.buttonChangeEncoding = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonReplacement = new System.Windows.Forms.Button();
            this.groupBoxCreation = new System.Windows.Forms.GroupBox();
            this.groupBoxTransformation = new System.Windows.Forms.GroupBox();
            this.labelNoticeNoReplacementFile = new System.Windows.Forms.Label();
            this.groupBoxCreation.SuspendLayout();
            this.groupBoxTransformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(11, 23);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(32, 12);
            this.labelURL.TabIndex = 0;
            this.labelURL.Text = "URL:";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxURL.Location = new System.Drawing.Point(47, 20);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(604, 21);
            this.textBoxURL.TabIndex = 1;
            this.textBoxURL.TextChanged += new System.EventHandler(this.textBoxURL_TextChanged);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Enabled = false;
            this.buttonDownload.Location = new System.Drawing.Point(47, 47);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 2;
            this.buttonDownload.Text = "&Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDownload.Location = new System.Drawing.Point(62, 233);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(594, 21);
            this.progressBarDownload.TabIndex = 3;
            this.progressBarDownload.Visible = false;
            // 
            // buttonChangeEncoding
            // 
            this.buttonChangeEncoding.Enabled = false;
            this.buttonChangeEncoding.Location = new System.Drawing.Point(53, 59);
            this.buttonChangeEncoding.Name = "buttonChangeEncoding";
            this.buttonChangeEncoding.Size = new System.Drawing.Size(234, 23);
            this.buttonChangeEncoding.TabIndex = 4;
            this.buttonChangeEncoding.Text = "&Change Encoding & Remove script";
            this.buttonChangeEncoding.UseVisualStyleBackColor = true;
            this.buttonChangeEncoding.Click += new System.EventHandler(this.buttonChangeEncoding_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(11, 34);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(29, 12);
            this.labelFile.TabIndex = 5;
            this.labelFile.Text = "File:";
            // 
            // textBoxFile
            // 
            this.textBoxFile.AllowDrop = true;
            this.textBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFile.Location = new System.Drawing.Point(47, 32);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(604, 21);
            this.textBoxFile.TabIndex = 6;
            this.textBoxFile.TextChanged += new System.EventHandler(this.textBoxFile_TextChanged);
            this.textBoxFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFile_DragDrop);
            this.textBoxFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFile_DragEnter);
            // 
            // buttonReplacement
            // 
            this.buttonReplacement.Enabled = false;
            this.buttonReplacement.Location = new System.Drawing.Point(302, 59);
            this.buttonReplacement.Name = "buttonReplacement";
            this.buttonReplacement.Size = new System.Drawing.Size(111, 23);
            this.buttonReplacement.TabIndex = 7;
            this.buttonReplacement.Text = "&Replacement";
            this.buttonReplacement.UseVisualStyleBackColor = true;
            this.buttonReplacement.Click += new System.EventHandler(this.buttonReplacement_Click);
            // 
            // groupBoxCreation
            // 
            this.groupBoxCreation.Controls.Add(this.textBoxURL);
            this.groupBoxCreation.Controls.Add(this.labelURL);
            this.groupBoxCreation.Controls.Add(this.buttonDownload);
            this.groupBoxCreation.Location = new System.Drawing.Point(15, 12);
            this.groupBoxCreation.Name = "groupBoxCreation";
            this.groupBoxCreation.Size = new System.Drawing.Size(657, 80);
            this.groupBoxCreation.TabIndex = 8;
            this.groupBoxCreation.TabStop = false;
            this.groupBoxCreation.Text = "Creation";
            // 
            // groupBoxTransformation
            // 
            this.groupBoxTransformation.Controls.Add(this.labelNoticeNoReplacementFile);
            this.groupBoxTransformation.Controls.Add(this.textBoxFile);
            this.groupBoxTransformation.Controls.Add(this.buttonChangeEncoding);
            this.groupBoxTransformation.Controls.Add(this.buttonReplacement);
            this.groupBoxTransformation.Controls.Add(this.labelFile);
            this.groupBoxTransformation.Location = new System.Drawing.Point(15, 110);
            this.groupBoxTransformation.Name = "groupBoxTransformation";
            this.groupBoxTransformation.Size = new System.Drawing.Size(657, 100);
            this.groupBoxTransformation.TabIndex = 9;
            this.groupBoxTransformation.TabStop = false;
            this.groupBoxTransformation.Text = "Transformation";
            // 
            // labelNoticeNoReplacementFile
            // 
            this.labelNoticeNoReplacementFile.AutoSize = true;
            this.labelNoticeNoReplacementFile.ForeColor = System.Drawing.Color.Red;
            this.labelNoticeNoReplacementFile.Location = new System.Drawing.Point(437, 64);
            this.labelNoticeNoReplacementFile.Name = "labelNoticeNoReplacementFile";
            this.labelNoticeNoReplacementFile.Size = new System.Drawing.Size(115, 12);
            this.labelNoticeNoReplacementFile.TabIndex = 8;
            this.labelNoticeNoReplacementFile.Text = "No replacement file";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 295);
            this.Controls.Add(this.groupBoxTransformation);
            this.Controls.Add(this.groupBoxCreation);
            this.Controls.Add(this.progressBarDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Translation Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxCreation.ResumeLayout(false);
            this.groupBoxCreation.PerformLayout();
            this.groupBoxTransformation.ResumeLayout(false);
            this.groupBoxTransformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.Button buttonChangeEncoding;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonReplacement;
        private System.Windows.Forms.GroupBox groupBoxCreation;
        private System.Windows.Forms.GroupBox groupBoxTransformation;
        private System.Windows.Forms.Label labelNoticeNoReplacementFile;
    }
}

