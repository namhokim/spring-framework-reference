using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TranslationTool
{
    public partial class MainForm : Form
    {
        #region "Constants"
        private const string ReplaceRuleFile = "rrf.txt";
        private static readonly Encoding ISO_8859_1 = Encoding.GetEncoding("ISO-8859-1");
        private static readonly Encoding Utf8WithoutBOM = new System.Text.UTF8Encoding(false);
        #endregion

        #region "Private variation"
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        #endregion

        #region "MainForm"
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelNoticeNoReplacementFile.Visible = (HasRuleFile == false);
        }

        private bool HasRuleFile
        {
            get
            {
                return File.Exists(ReplaceRuleFile);
            }
        }
        #endregion

        #region "textBoxURL"
        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {
            buttonDownload.Enabled = Uri.IsWellFormedUriString(textBoxURL.Text, UriKind.Absolute);
        }
        #endregion

        #region "buttonDownload"
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(textBoxURL.Text);
            String filename = Path.GetFileName(uri.LocalPath);
            if (filename.Length == 0) filename = "index.html";

            if (File.Exists(filename))
            {
                DialogResult reply = MessageBox.Show(
                    "File already exist. Overwrite it?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reply == DialogResult.No) return;
            }

            buttonDownload.Enabled = false;
            progressBarDownload.Visible = true;

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(uri, filename, filename);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarDownload.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            textBoxFile.Text = e.UserState as string;
        }
        #endregion

        #region "textBoxFile"
        private void textBoxFile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsContentUTF8(textBoxFile.Text))
                {
                    buttonChangeEncoding.Enabled = false;
                    buttonReplacement.Enabled = true;
                }
                else
                {
                    buttonChangeEncoding.Enabled = true;
                    buttonReplacement.Enabled = false;
                }
            }
            catch (FileNotFoundException)
            {
                buttonChangeEncoding.Enabled = false;
                buttonReplacement.Enabled = false;
            }
        }

        private bool IsContentUTF8(string filename)
        {
            if (File.Exists(filename) == false)
            {
                throw new FileNotFoundException();
            }

            using (var sr = new StreamReader(filename, Utf8WithoutBOM, false))
            {
                while (sr.Peek() > 0)
                {
                    string line = sr.ReadLine();
                    if (line.Contains("charset=UTF-8")) return true;
                }
            }

            return false;
        }

        private bool HasUTF8_BOM(string filename)
        {
            if (File.Exists(filename) == false)
            {
                throw new FileNotFoundException();
            }

            using (var file = new FileStream(filename, FileMode.Open))
            {
                byte[] bom = new byte[3];
                if (file.Read(bom, 0, 3) != 3) return false;
                return (bom[0] == 0xEF && bom[1] == 0xBB && bom[2] == 0xBF);
            }
        }

        private void textBoxFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (!Directory.Exists(file))
                {
                    textBoxFile.Text = file;
                    break;
                }
            }
        }

        private void textBoxFile_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        #endregion

        #region "buttonChangeEncoding"
        private void buttonChangeEncoding_Click(object sender, EventArgs e)
        {
            buttonChangeEncoding.Enabled = false;
            progressBarDownload.Visible = true;
            progressBarDownload.Value = 0;

            string ori = textBoxFile.Text;
            string temp = Guid.NewGuid().ToString();
            PreProcessing(ori, temp);
            File.Replace(temp, ori, null);

            buttonReplacement.Enabled = true;
            progressBarDownload.Value = 100;
        }

        /// <summary>
        /// 1. 인코딩 변경
        /// 2. 인코딩 meta 엘리먼트 값 변경
        /// 3. 끝 부분 script 부분 제거
        /// </summary>
        /// <param name="originalFilename">입력 파일</param>
        /// <param name="saveToFilename">출력 파일</param>
        private void PreProcessing(string originalFilename, string saveToFilename)
        {
            const string MetaOrig = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=ISO-8859-1\">";
            const string MetaDest = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">";
            const string BeginScript = "<script type=\"text/javascript\">";
            const string EndScript = "</script>";

            long totalSize = GetFileSize(originalFilename);
            long read = 0;
            int scriptLevel = 0;
            using (var sr = new StreamReader(originalFilename, ISO_8859_1, false))
            using (var sw = new StreamWriter(saveToFilename, false, Utf8WithoutBOM))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    read += line.Length;
                    progressBarDownload.Value = (int)(read * 100 / totalSize);

                    if (line == MetaOrig)
                    {
                        sw.WriteLine(MetaDest);
                        continue;
                    }
                    else if (line == BeginScript)
                    {
                        scriptLevel++;
                    }
                    else if (line == EndScript)
                    {
                        if (scriptLevel == 2)
                        {
                            scriptLevel = 0;
                            continue;   // ignore for write "</script>"
                        }
                    }

                    if (scriptLevel == 0)
                    {
                        if (sr.Peek() >= 0) sw.WriteLine(line);
                        else sw.Write(line);
                    }
                }
            }
        }

        private long GetFileSize(string originalFilename)
        {
            FileInfo fi = new FileInfo(originalFilename);
            return fi.Length;
        }
        #endregion

        #region "buttonReplacement"
        private void buttonReplacement_Click(object sender, EventArgs e)
        {
            buttonReplacement.Enabled = false;
            progressBarDownload.Visible = true;
            progressBarDownload.Value = 0;

            if (!HasRuleFile)
            {
                DialogResult reply = MessageBox.Show(
                    "There is no replacement rule file.\r\nDo you want create it?",
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reply == DialogResult.No) return;
                MakeNewReplacementFile();
                OpenReplacementFile();
            }
            LoadReplacementDataFromFile();

            string ori = textBoxFile.Text;
            string temp = Guid.NewGuid().ToString();
            Replacement(ori, temp);
            File.Replace(temp, ori, null);

            progressBarDownload.Value = 100;
        }

        private void MakeNewReplacementFile()
        {
            using (StreamWriter sw = File.CreateText(ReplaceRuleFile))
            {
                sw.WriteLine("Replacement target 1");
                sw.WriteLine("교체될 값 1");
                sw.WriteLine();
                sw.WriteLine("Replacement target 2");
                sw.WriteLine("교체될 값 2");
            }
        }

        private void OpenReplacementFile()
        {
            Process process = Process.Start(ReplaceRuleFile);
            process.WaitForExit();
        }

        private void LoadReplacementDataFromFile()
        {
            using (StreamReader sr = File.OpenText(ReplaceRuleFile))
            {
                while (sr.Peek() > 0)
                {
                    string line1 = sr.ReadLine();
                    if (line1.Length == 0) continue;    // if not using 2 1(empty) 2 1(empty) pattern

                    if (sr.Peek() > 0)
                    {
                        string line2 = sr.ReadLine();
                        dic.Add(line1, line2);
                    }
                }
            }
        }

        private void Replacement(string originalFilename, string saveToFilename)
        {
            var keys = dic.Keys;
            if (keys.Count == 0) return;

            long totalSize = GetFileSize(originalFilename);
            long read = 0;
            using (var sr = new StreamReader(originalFilename, Utf8WithoutBOM, false))
            using (var sw = new StreamWriter(saveToFilename, false, Utf8WithoutBOM))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    read += line.Length;
                    progressBarDownload.Value = (int)(read * 100 / totalSize);

                    foreach (string k in keys)
                    {
                        line = line.Replace(k, dic[k]);
                    }

                    if (sr.Peek() >= 0) sw.WriteLine(line);
                    else sw.Write(line);
                }
            }
        }
        #endregion
    }
}
