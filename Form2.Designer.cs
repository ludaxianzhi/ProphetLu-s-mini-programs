namespace ProphetLu_s_Translation_Reference_Tool
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            referenceLabel = new Label();
            setApiLabel = new Label();
            setKeyLabel = new Label();
            setApiLinkText = new TextBox();
            setApiKeyText = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            apiSelectCombo = new ComboBox();
            SuspendLayout();
            // 
            // referenceLabel
            // 
            referenceLabel.AutoSize = true;
            referenceLabel.Font = new Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            referenceLabel.Location = new Point(16, 15);
            referenceLabel.Name = "referenceLabel";
            referenceLabel.Size = new Size(166, 32);
            referenceLabel.TabIndex = 0;
            referenceLabel.Text = "翻译引擎设置";
            // 
            // setApiLabel
            // 
            setApiLabel.AutoSize = true;
            setApiLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            setApiLabel.Location = new Point(46, 80);
            setApiLabel.Name = "setApiLabel";
            setApiLabel.Size = new Size(63, 28);
            setApiLabel.TabIndex = 1;
            setApiLabel.Text = "appid";
            // 
            // setKeyLabel
            // 
            setKeyLabel.AutoSize = true;
            setKeyLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            setKeyLabel.Location = new Point(46, 149);
            setKeyLabel.Name = "setKeyLabel";
            setKeyLabel.Size = new Size(44, 28);
            setKeyLabel.TabIndex = 2;
            setKeyLabel.Text = "Key";
            // 
            // setApiLinkText
            // 
            setApiLinkText.Location = new Point(163, 79);
            setApiLinkText.Name = "setApiLinkText";
            setApiLinkText.Size = new Size(560, 27);
            setApiLinkText.TabIndex = 3;
            // 
            // setApiKeyText
            // 
            setApiKeyText.Location = new Point(163, 153);
            setApiKeyText.Name = "setApiKeyText";
            setApiKeyText.Size = new Size(560, 27);
            setApiKeyText.TabIndex = 4;
            setApiKeyText.TextChanged += setApiKeyText_TextChanged;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(441, 360);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(147, 62);
            saveButton.TabIndex = 5;
            saveButton.Text = "保存设置";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(605, 360);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(147, 62);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // apiSelectCombo
            // 
            apiSelectCombo.FormattingEnabled = true;
            apiSelectCombo.Items.AddRange(new object[] { "ChatGPT", "百度翻译", "有道翻译" });
            apiSelectCombo.Location = new Point(277, 19);
            apiSelectCombo.Name = "apiSelectCombo";
            apiSelectCombo.Size = new Size(178, 28);
            apiSelectCombo.TabIndex = 7;
            apiSelectCombo.SelectedIndexChanged += apiSelectCombo_SelectedIndexChanged_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(apiSelectCombo);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(setApiKeyText);
            Controls.Add(setApiLinkText);
            Controls.Add(setKeyLabel);
            Controls.Add(setApiLabel);
            Controls.Add(referenceLabel);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label referenceLabel;
        private Label setApiLabel;
        private Label setKeyLabel;
        private TextBox setApiLinkText;
        private TextBox setApiKeyText;
        private Button saveButton;
        private Button cancelButton;
        private ComboBox apiSelectCombo;
    }
}