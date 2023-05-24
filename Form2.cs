using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProphetLu_s_Translation_Reference_Tool
{
    public partial class Form2 : Form
    {
        private bool EngineIsChanged = false;
        private string translateEgine = "";
        private Form1 From;

        Dictionary<int, string> engineIndex = new Dictionary<int, string>
        {
            { 0,"ChatGPT" },
            { 1,"百度翻译" },
            {2,"有道翻译" }

        };

        public Form2(Form1 from,string engine,string appid,string key)
        {
            InitializeComponent();
            int e = 0;
            if (engine != "")
            {
                switch (engine){
                    case "ChatGPT": e=0; break;
                    case "百度翻译": e=1; break;
                    case "有道翻译": e=2; break;
                }
            }
            this.apiSelectCombo.SelectedValue = e;
            this.apiSelectCombo.Text = engine;
            if (appid != "")
            {
                this.setApiLinkText.Text = appid;
            }
            if (key != "")
            {
                this.setApiKeyText.Text = key;
            }
            From = from;
        }

        private void referenceLabel_Click(object sender, EventArgs e)
        {

        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            From.setAttributte(this.translateEgine, this.setApiLinkText.Text, this.setApiKeyText.Text);
            File.WriteAllText("Key.txt", string.Empty);
            File.AppendAllText("Key.txt", $"{this.translateEgine}\n");
            File.AppendAllText("Key.txt", $"{this.setApiLinkText.Text}\n");
            File.AppendAllText("Key.txt", $"{this.setApiKeyText.Text}\n");
            From.activateReferenceButton();
            this.Close();
        }

        private void setApiKeyText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void apiSelectCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (engineIndex[this.apiSelectCombo.SelectedIndex]!=translateEgine)
            {
                this.translateEgine =engineIndex[this.apiSelectCombo.SelectedIndex];
                this.EngineIsChanged = true;
            }
            this.setApiLinkText.Text = "";
            this.setApiKeyText.Text = "";
            if (engineIndex[this.apiSelectCombo.SelectedIndex] == "ChatGPT")
            {
                this.setApiLabel.Visible= false;
                this.setApiLinkText.Visible = false;
            }
            if (engineIndex[this.apiSelectCombo.SelectedIndex] == "有道翻译")
            {
                MessageBox.Show("还没做,请选择其他引擎");
                this.setApiLabel.Visible = true; this.setApiLinkText.Visible = true;
            }
            else
            {
                this.setApiLabel.Visible = true; this.setApiLinkText.Visible = true;
            }

        }
    }
}
