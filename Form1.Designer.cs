using Microsoft.VisualBasic;
using System;
using System.DirectoryServices;
using System.Net;
using System.Security.Cryptography;
using System.Text;



namespace ProphetLu_s_Translation_Reference_Tool
{
    partial class Form1
    {
        string translatingtext = null;
        private string translateEngine = "";
        private string translateAPI = "";
        private string translateAPIKey = "";
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            optionButton = new Button();
            selectFileButton = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            preTextButton = new Button();
            nextTextButton = new Button();
            ComformChangesButton = new Button();
            ReferenceButton = new Button();
            tranlateProgress = new ProgressBar();
            PageUP = new Button();
            Pagedown = new Button();
            locate = new Button();
            save0 = new Button();
            save_as = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AllowDrop = true;
            textBox1.Location = new Point(14, 38);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(902, 313);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // optionButton
            // 
            optionButton.FlatStyle = FlatStyle.System;
            optionButton.Location = new Point(24, 0);
            optionButton.Margin = new Padding(3, 4, 3, 4);
            optionButton.Name = "optionButton";
            optionButton.Size = new Size(85, 33);
            optionButton.TabIndex = 1;
            optionButton.Text = "设置";
            optionButton.UseVisualStyleBackColor = true;
            optionButton.Click += optionButton_Click_1;
            // 
            // selectFileButton
            // 
            selectFileButton.FlatStyle = FlatStyle.System;
            selectFileButton.Location = new Point(115, 0);
            selectFileButton.Margin = new Padding(3, 4, 3, 4);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(85, 33);
            selectFileButton.TabIndex = 2;
            selectFileButton.Text = "选择文件";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 414);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(815, 91);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(14, 514);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(815, 91);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(14, 614);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(815, 91);
            textBox4.TabIndex = 5;
            // 
            // preTextButton
            // 
            preTextButton.Location = new Point(837, 414);
            preTextButton.Margin = new Padding(3, 4, 3, 4);
            preTextButton.Name = "preTextButton";
            preTextButton.Size = new Size(90, 45);
            preTextButton.TabIndex = 6;
            preTextButton.Text = "上一句";
            preTextButton.UseVisualStyleBackColor = true;
            preTextButton.Click += preTextButton_Click;
            // 
            // nextTextButton
            // 
            nextTextButton.Location = new Point(837, 460);
            nextTextButton.Margin = new Padding(3, 4, 3, 4);
            nextTextButton.Name = "nextTextButton";
            nextTextButton.Size = new Size(90, 45);
            nextTextButton.TabIndex = 7;
            nextTextButton.Text = "下一句";
            nextTextButton.UseVisualStyleBackColor = true;
            nextTextButton.Click += nextTextButton_Click;
            // 
            // ComformChangesButton
            // 
            ComformChangesButton.Location = new Point(837, 514);
            ComformChangesButton.Margin = new Padding(3, 4, 3, 4);
            ComformChangesButton.Name = "ComformChangesButton";
            ComformChangesButton.Size = new Size(90, 92);
            ComformChangesButton.TabIndex = 8;
            ComformChangesButton.Text = "确认修改";
            ComformChangesButton.UseVisualStyleBackColor = true;
            ComformChangesButton.Click += ComformChangesButton_Click;
            // 
            // ReferenceButton
            // 
            ReferenceButton.Location = new Point(837, 614);
            ReferenceButton.Margin = new Padding(3, 4, 3, 4);
            ReferenceButton.Name = "ReferenceButton";
            ReferenceButton.Size = new Size(90, 92);
            ReferenceButton.TabIndex = 9;
            ReferenceButton.Text = "查看参考";
            ReferenceButton.UseVisualStyleBackColor = true;
            ReferenceButton.Click += ReferenceButton_Click;
            // 
            // tranlateProgress
            // 
            tranlateProgress.Location = new Point(14, 358);
            tranlateProgress.Name = "tranlateProgress";
            tranlateProgress.Size = new Size(902, 43);
            tranlateProgress.TabIndex = 11;
            tranlateProgress.Click += progressBar1_Click;
            // 
            // PageUP
            // 
            PageUP.Location = new Point(928, 38);
            PageUP.Name = "PageUP";
            PageUP.Size = new Size(70, 98);
            PageUP.TabIndex = 12;
            PageUP.Text = "向上翻页";
            PageUP.UseVisualStyleBackColor = true;
            PageUP.Click += PageUP_Click;
            // 
            // Pagedown
            // 
            Pagedown.Location = new Point(928, 256);
            Pagedown.Name = "Pagedown";
            Pagedown.Size = new Size(70, 95);
            Pagedown.TabIndex = 13;
            Pagedown.Text = "向下翻页";
            Pagedown.UseVisualStyleBackColor = true;
            Pagedown.Click += Pagedown_Click;
            // 
            // locate
            // 
            locate.Location = new Point(928, 142);
            locate.Name = "locate";
            locate.Size = new Size(70, 108);
            locate.TabIndex = 14;
            locate.Text = "定位文本";
            locate.UseVisualStyleBackColor = true;
            locate.Click += locate_Click;
            // 
            // save0
            // 
            save0.Location = new Point(206, 2);
            save0.Name = "save0";
            save0.Size = new Size(61, 31);
            save0.TabIndex = 16;
            save0.Text = "保存";
            save0.UseVisualStyleBackColor = true;
            save0.Click += save0_Click;
            // 
            // save_as
            // 
            save_as.Location = new Point(273, 4);
            save_as.Name = "save_as";
            save_as.Size = new Size(63, 29);
            save_as.TabIndex = 17;
            save_as.Text = "另存为";
            save_as.UseVisualStyleBackColor = true;
            save_as.Click += save_as_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 721);
            Controls.Add(save_as);
            Controls.Add(save0);
            Controls.Add(locate);
            Controls.Add(Pagedown);
            Controls.Add(PageUP);
            Controls.Add(tranlateProgress);
            Controls.Add(ReferenceButton);
            Controls.Add(ComformChangesButton);
            Controls.Add(nextTextButton);
            Controls.Add(preTextButton);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(selectFileButton);
            Controls.Add(optionButton);
            Controls.Add(textBox1);
            HelpButton = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "翻译辅助程序v0.1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button optionButton;
        private Button selectFileButton;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button preTextButton;
        private Button nextTextButton;
        private Button ComformChangesButton;
        private Button ReferenceButton;


        public void setAttributte(string engine = "", string API = "", string Key = "")
        {
            if (engine != "") this.translateEngine = engine;
            if (API != "") this.translateAPI = API;
            if (Key != "") this.translateAPIKey = Key;
        }

        public string ReadTextFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {

                }
            }

            return string.Empty;
        }
        private ProgressBar tranlateProgress;
        private Button PageUP;
        private Button Pagedown;
        private Button locate;
        private Button save0;
        private Button save_as;
    }




}