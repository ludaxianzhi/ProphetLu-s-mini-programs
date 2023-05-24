using Newtonsoft.Json;
using System.Formats.Asn1;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProphetLu_s_Translation_Reference_Tool
{
    public partial class Form1 : Form
    {

        List<string> maintext;
        int col = 0;
        int maxLine;
        List<string> nowShow;
        int i = -1;
        string pthfrom;
        public Form1()
        {
            InitializeComponent();
            string textPath = "translating.text";
            string keyPath = "Key.txt";
            List<string> settings = readFromTxt(keyPath);
            this.translateEngine = settings[0];
            this.translateAPI = settings[1];
            this.translateAPIKey = settings[2];
            this.translatingtext = ReadTextFile(textPath);
            if( this.translatingtext!=null && this.translatingtext != "")
            {

                this.pthfrom = translatingtext;
                this.activateComponets();
                this.maintext = readFromTxt(translatingtext);
                if (this.maintext.Count > 0)
                {
                    this.maxLine = this.maintext.Count;
                    nowShow = this.maintext.GetRange(0, this.maxLine >= 16 ? this.maxLine : 16);
                    this.textBox1.Text = MergeText(nowShow);
                    this.textBox2.Text = this.maintext[0];
                    this.textBox3.Text = this.maintext[1];
                    this.preTextButton.Enabled = true;
                    if (this.maintext.Count > 5)
                    {
                        this.nextTextButton.Enabled = true;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void activateComponets()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true; textBox4.Enabled = true;
            ComformChangesButton.Enabled = true;
        }
        public void activateReferenceButton()
        {
            ReferenceButton.Enabled = true;
        }

        private void optionButton_Click(object sender, EventArgs e)
        {
            Form2 subform = new Form2(this, this.translateEngine, this.translateAPI, this.translateAPIKey);
            subform.Show();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            string txtPth = getFileFromExplore();
            if (txtPth != "")
            {
                this.pthfrom = txtPth;
                this.activateComponets();
                this.maintext = readFromTxt(txtPth);
                if (this.maintext.Count > 0)
                {
                    this.maxLine = this.maintext.Count;
                    nowShow = this.maintext.GetRange(0, this.maxLine >= 16 ? this.maxLine : 16);
                    this.textBox1.Text = MergeText(nowShow);
                    this.textBox2.Text = this.maintext[0];
                    this.textBox3.Text = this.maintext[1];
                    this.preTextButton.Enabled = true;
                    if (this.maintext.Count > 5)
                    {
                        this.nextTextButton.Enabled = true;
                    }
                }
                File.WriteAllText("translating.text", txtPth);
            }
        }

        string getFileFromExplore()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                return file;
            }
            else return "";
        }

        List<string> readFromTxt(string pth)
        {

            string path = pth;
            List<string> list = new List<string>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                list.Add(line);
            }
            return list;
        }

        public string MergeText(List<string> texts)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string text in texts)
            {
                stringBuilder.AppendLine(text);
            }

            return stringBuilder.ToString();
        }

        private void nextTextButton_Click(object sender, EventArgs e)
        {
            if (this.col <= this.maxLine - 5)
            {
                this.col += 4;
                this.textBox2.Text = maintext[this.col];
                this.textBox3.Text = maintext[this.col + 1];
                nowShow = this.maintext.GetRange(this.col, this.col + 16 >= maxLine ? maxLine - this.col : 16);
                this.textBox1.Text = MergeText(nowShow);
                if (this.preTextButton.Enabled == false) this.preTextButton.Enabled = true;
                this.i = -1;
            }
            else
            {
                this.nextTextButton.Enabled = false;
            }
        }

        private void preTextButton_Click(object sender, EventArgs e)
        {
            if (this.col > 0)
            {
                this.col -= 4;
                this.textBox2.Text = maintext[this.col];
                this.textBox3.Text = maintext[this.col + 1];
                int precol = this.col - 4 >= 0 ? this.col - 4 : 0;
                nowShow = this.maintext.GetRange(precol, precol + 16 >= this.maxLine ? maxLine - precol : 16);
                this.textBox1.Text = MergeText(nowShow);
                if (this.nextTextButton.Enabled == false) { this.nextTextButton.Enabled = true; }
                this.i = -1;
            }
            else
            {
                this.preTextButton.Enabled = false;
            }
        }

        private void ComformChangesButton_Click(object sender, EventArgs e)
        {
            this.maintext[this.col + 1] = this.textBox3.Text;
            showtext();
            if (this.col <= this.maxLine - 5)
            {
                this.col += 4;
                this.textBox2.Text = maintext[this.col];
                this.textBox3.Text = maintext[this.col + 1];
            }
            this.tranlateProgress.Value = this.col / this.maxLine;

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void PageUP_Click(object sender, EventArgs e)
        {
            if (this.i == -1)
            {
                int ncol = this.col - 16 >= 0 ? this.col - 16 : 0;
                this.nowShow = this.maintext.GetRange(ncol, ncol + 16 >= this.maxLine - 1 ? this.maxLine - ncol : 16);
                this.textBox1.Text = MergeText(nowShow);
                this.i = ncol;
            }
            if (this.i != -1)
            {
                int ncol = this.i - 16 >= 0 ? this.i - 16 : 0;
                this.nowShow = this.maintext.GetRange(ncol, ncol + 16 >= this.maxLine - 1 ? this.maxLine - ncol : 16);
                this.textBox1.Text = MergeText(nowShow);
                this.i = ncol;
            }

        }

        private void Pagedown_Click(object sender, EventArgs e)
        {
            if (this.i == -1)
            {
                int ncol = this.col + 16 >= this.maxLine ? this.maxLine : this.col + 16;
                this.nowShow = this.maintext.GetRange(ncol, ncol + 16 >= this.maxLine - 1 ? this.maxLine - ncol : 16);
                this.textBox1.Text = MergeText(nowShow);

                if (ncol <= this.maxLine) this.i = ncol;
            }
            if (this.i != -1)
            {
                int ncol = this.i + 16 >= this.maxLine ? this.maxLine : this.i + 16;
                this.nowShow = this.maintext.GetRange(ncol, ncol + 16 >= this.maxLine - 1 ? this.maxLine - ncol : 16);
                this.textBox1.Text = MergeText(nowShow);
                if (ncol <= this.maxLine) this.i = ncol;
            }
        }

        private void locate_Click(object sender, EventArgs e)
        {
            nowShow = this.maintext.GetRange(this.col, this.col + 16 >= this.maxLine - 1 ? this.maxLine - this.col : 16);
            this.textBox1.Text = MergeText(nowShow);
            this.i = -1;
        }

        void showtext()
        {
            textBox1.Text = MergeText(this.maintext.GetRange(this.col, this.col + 16 > this.maxLine ? this.maxLine - this.col : 16));
        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void save0_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(this.pthfrom, MergeText(this.maintext));
            }
            catch (Exception ex) { }
        }

        private void save_as_Click(object sender, EventArgs e)
        {
            string txtPth = getFileFromExplore();
            try
            {
                File.WriteAllText(txtPth, MergeText(this.maintext));
            }
            catch (Exception ex) { }
        }

        private void ReferenceButton_Click(object sender, EventArgs e)
        {
            if (this.translateEngine == "ChatGPT")
            {
                GetTranslationFromGPT engine = new GetTranslationFromGPT(this.translateAPIKey);
                string t1 = textBox2.Text.Substring(11);
                if (t1 != "") this.textBox4.Text = engine.GetTranslation(t1).ToString();

            }
            else if (this.translateEngine == "百度翻译")
            {
                WebClient client = new WebClient();
                string fromTranslate = textBox3.Text.Substring(11);
                if (!string.IsNullOrEmpty(fromTranslate))
                {
                    //client_id为自己的api_id，q为翻译对象，from为翻译语言，to为翻译后语言
                    Random random = new Random();
                    int randnum = random.Next(1000000000);
                    string s1 = $"{this.translateAPI}{fromTranslate}{randnum}{this.translateAPIKey}";
                    string checkcode = CalculateMD5(s1);
                    string request = $"http://api.fanyi.baidu.com/api/trans/vip/translate?q={fromTranslate}&from=jp&to=zh&appid={this.translateAPI}&salt={randnum}&sign={checkcode}";
                    var buffer = client.DownloadData(request);
                    string result = Encoding.UTF8.GetString(buffer);
                    StringReader sr = new StringReader(result);
                    JsonTextReader jsonReader = new JsonTextReader(sr); //引用Newtonsoft.Json 自带
                    JsonSerializer serializer = new JsonSerializer();
                    var r = serializer.Deserialize<TranClass>(jsonReader); //因为获取后的为json对象 ，实行转换
                    textBox4.Text = r.Trans_result[0].dst;
                }
            }

        }

        private void optionButton_Click_1(object sender, EventArgs e)
        {
            Form2 subform = new Form2(this,this.translateEngine,this.translateAPI,this.translateAPIKey);
            subform.Show();
          
        }

        public string CalculateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}