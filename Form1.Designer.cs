namespace Email_Web_Extractor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.findWebSitesButton = new System.Windows.Forms.Button();
            this.appendToTempFileCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webPagesTempFilePathTextBox = new System.Windows.Forms.Label();
            this.pagesCountComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openWebPagesTempFileButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteWebPagesTempFileButton = new System.Windows.Forms.Button();
            this.searchRequestTextBox = new System.Windows.Forms.TextBox();
            this.pagesNamesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.emailsPathFileLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sitesPathFileLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.coresCountComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.findEmailsButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инфоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.иструкцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // findWebSitesButton
            // 
            this.findWebSitesButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.findWebSitesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.findWebSitesButton.ForeColor = System.Drawing.SystemColors.Control;
            this.findWebSitesButton.Location = new System.Drawing.Point(6, 198);
            this.findWebSitesButton.Name = "findWebSitesButton";
            this.findWebSitesButton.Size = new System.Drawing.Size(350, 36);
            this.findWebSitesButton.TabIndex = 0;
            this.findWebSitesButton.Text = "Начать поиск";
            this.findWebSitesButton.UseVisualStyleBackColor = false;
            this.findWebSitesButton.Click += new System.EventHandler(this.findWebSitesButton_Click);
            // 
            // appendToTempFileCheckBox
            // 
            this.appendToTempFileCheckBox.AutoSize = true;
            this.appendToTempFileCheckBox.Checked = true;
            this.appendToTempFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendToTempFileCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appendToTempFileCheckBox.Location = new System.Drawing.Point(8, 74);
            this.appendToTempFileCheckBox.Name = "appendToTempFileCheckBox";
            this.appendToTempFileCheckBox.Size = new System.Drawing.Size(262, 17);
            this.appendToTempFileCheckBox.TabIndex = 1;
            this.appendToTempFileCheckBox.Text = "Добавлять результаты в существующий файл";
            this.appendToTempFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поисковой запрос:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webPagesTempFilePathTextBox);
            this.groupBox1.Controls.Add(this.pagesCountComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.openWebPagesTempFileButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.deleteWebPagesTempFileButton);
            this.groupBox1.Controls.Add(this.searchRequestTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.appendToTempFileCheckBox);
            this.groupBox1.Controls.Add(this.findWebSitesButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(362, 276);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск сайтов";
            // 
            // webPagesTempFilePathTextBox
            // 
            this.webPagesTempFilePathTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webPagesTempFilePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.webPagesTempFilePathTextBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.webPagesTempFilePathTextBox.Location = new System.Drawing.Point(6, 152);
            this.webPagesTempFilePathTextBox.Name = "webPagesTempFilePathTextBox";
            this.webPagesTempFilePathTextBox.Size = new System.Drawing.Size(350, 34);
            this.webPagesTempFilePathTextBox.TabIndex = 19;
            this.webPagesTempFilePathTextBox.Text = "label9asedfasedfsefsefgsrgf";
            this.webPagesTempFilePathTextBox.Click += new System.EventHandler(this.webPagesTempFilePathTextBox_Click);
            // 
            // pagesCountComboBox
            // 
            this.pagesCountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pagesCountComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pagesCountComboBox.FormattingEnabled = true;
            this.pagesCountComboBox.Location = new System.Drawing.Point(136, 97);
            this.pagesCountComboBox.MaxDropDownItems = 10;
            this.pagesCountComboBox.Name = "pagesCountComboBox";
            this.pagesCountComboBox.Size = new System.Drawing.Size(40, 23);
            this.pagesCountComboBox.TabIndex = 17;
            this.pagesCountComboBox.SelectedIndexChanged += new System.EventHandler(this.pagesCountComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Кол-во Google страниц";
            // 
            // openWebPagesTempFileButton
            // 
            this.openWebPagesTempFileButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.openWebPagesTempFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.openWebPagesTempFileButton.ForeColor = System.Drawing.SystemColors.Control;
            this.openWebPagesTempFileButton.Location = new System.Drawing.Point(185, 240);
            this.openWebPagesTempFileButton.Name = "openWebPagesTempFileButton";
            this.openWebPagesTempFileButton.Size = new System.Drawing.Size(171, 29);
            this.openWebPagesTempFileButton.TabIndex = 9;
            this.openWebPagesTempFileButton.Text = "Открыть временный файл";
            this.openWebPagesTempFileButton.UseVisualStyleBackColor = false;
            this.openWebPagesTempFileButton.Click += new System.EventHandler(this.openWebPagesTempFileButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(5, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Путь ко временному файлу:";
            // 
            // deleteWebPagesTempFileButton
            // 
            this.deleteWebPagesTempFileButton.BackColor = System.Drawing.Color.Tomato;
            this.deleteWebPagesTempFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.deleteWebPagesTempFileButton.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteWebPagesTempFileButton.Location = new System.Drawing.Point(6, 240);
            this.deleteWebPagesTempFileButton.Name = "deleteWebPagesTempFileButton";
            this.deleteWebPagesTempFileButton.Size = new System.Drawing.Size(167, 29);
            this.deleteWebPagesTempFileButton.TabIndex = 8;
            this.deleteWebPagesTempFileButton.Text = "Удалить временный файл";
            this.deleteWebPagesTempFileButton.UseVisualStyleBackColor = false;
            this.deleteWebPagesTempFileButton.Click += new System.EventHandler(this.deleteWebPagesTempFileButton_Click);
            // 
            // searchRequestTextBox
            // 
            this.searchRequestTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchRequestTextBox.Location = new System.Drawing.Point(8, 41);
            this.searchRequestTextBox.MaxLength = 256;
            this.searchRequestTextBox.Name = "searchRequestTextBox";
            this.searchRequestTextBox.Size = new System.Drawing.Size(348, 20);
            this.searchRequestTextBox.TabIndex = 5;
            this.searchRequestTextBox.TextChanged += new System.EventHandler(this.searchRequestTextBox_TextChanged);
            // 
            // pagesNamesTextBox
            // 
            this.pagesNamesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pagesNamesTextBox.Location = new System.Drawing.Point(6, 41);
            this.pagesNamesTextBox.MaxLength = 256;
            this.pagesNamesTextBox.Name = "pagesNamesTextBox";
            this.pagesNamesTextBox.Size = new System.Drawing.Size(350, 20);
            this.pagesNamesTextBox.TabIndex = 7;
            this.pagesNamesTextBox.Text = "contacts about";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Вложенные доп страницы (через пробел)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.emailsPathFileLabel);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.sitesPathFileLabel);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.coresCountComboBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.findEmailsButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.pagesNamesTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(380, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 276);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Извлечение имейлов";
            // 
            // emailsPathFileLabel
            // 
            this.emailsPathFileLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emailsPathFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.emailsPathFileLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.emailsPathFileLabel.Location = new System.Drawing.Point(6, 176);
            this.emailsPathFileLabel.Name = "emailsPathFileLabel";
            this.emailsPathFileLabel.Size = new System.Drawing.Size(350, 34);
            this.emailsPathFileLabel.TabIndex = 23;
            this.emailsPathFileLabel.Text = "label9asedfasedfsefsefgsrgf";
            this.emailsPathFileLabel.Click += new System.EventHandler(this.emailsPathFileLabel_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(5, 153);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Путь к файлу с имейлами:";
            // 
            // sitesPathFileLabel
            // 
            this.sitesPathFileLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sitesPathFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sitesPathFileLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.sitesPathFileLabel.Location = new System.Drawing.Point(6, 126);
            this.sitesPathFileLabel.Name = "sitesPathFileLabel";
            this.sitesPathFileLabel.Size = new System.Drawing.Size(350, 34);
            this.sitesPathFileLabel.TabIndex = 21;
            this.sitesPathFileLabel.Text = "label9asedfasedfsefsefgsrgf";
            this.sitesPathFileLabel.Click += new System.EventHandler(this.sitesPathFileLabel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(5, 103);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Путь к файлу с Web-адресами:";
            // 
            // coresCountComboBox
            // 
            this.coresCountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coresCountComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.coresCountComboBox.FormattingEnabled = true;
            this.coresCountComboBox.Location = new System.Drawing.Point(97, 70);
            this.coresCountComboBox.MaxDropDownItems = 10;
            this.coresCountComboBox.Name = "coresCountComboBox";
            this.coresCountComboBox.Size = new System.Drawing.Size(40, 23);
            this.coresCountComboBox.TabIndex = 15;
            this.coresCountComboBox.SelectedIndexChanged += new System.EventHandler(this.coresCountComboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label8.Location = new System.Drawing.Point(5, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Кол-во потоков";
            // 
            // findEmailsButton
            // 
            this.findEmailsButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.findEmailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.findEmailsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.findEmailsButton.Location = new System.Drawing.Point(6, 230);
            this.findEmailsButton.Name = "findEmailsButton";
            this.findEmailsButton.Size = new System.Drawing.Size(350, 39);
            this.findEmailsButton.TabIndex = 12;
            this.findEmailsButton.Text = "Найти имейлы";
            this.findEmailsButton.UseVisualStyleBackColor = false;
            this.findEmailsButton.Click += new System.EventHandler(this.findEmailsButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.AutoSize = false;
            this.statusBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarText});
            this.statusBar.Location = new System.Drawing.Point(0, 325);
            this.statusBar.Name = "statusBar";
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusBar.Size = new System.Drawing.Size(755, 23);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 15;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusBarText
            // 
            this.statusBarText.AutoSize = false;
            this.statusBarText.ForeColor = System.Drawing.SystemColors.Control;
            this.statusBarText.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            this.statusBarText.Name = "statusBarText";
            this.statusBarText.Size = new System.Drawing.Size(736, 18);
            this.statusBarText.Text = "Ожидание...";
            this.statusBarText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программаToolStripMenuItem,
            this.инфоToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(755, 24);
            this.mainMenuStrip.TabIndex = 16;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.программаToolStripMenuItem.Text = "Программа";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // инфоToolStripMenuItem
            // 
            this.инфоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.иструкцияToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.инфоToolStripMenuItem.Name = "инфоToolStripMenuItem";
            this.инфоToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.инфоToolStripMenuItem.Text = "Инфо";
            // 
            // иструкцияToolStripMenuItem
            // 
            this.иструкцияToolStripMenuItem.Name = "иструкцияToolStripMenuItem";
            this.иструкцияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.иструкцияToolStripMenuItem.Text = "Иструкция";
            this.иструкцияToolStripMenuItem.Click += new System.EventHandler(this.иструкцияToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(13)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(755, 348);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Web Extractor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findWebSitesButton;
        private System.Windows.Forms.CheckBox appendToTempFileCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button openWebPagesTempFileButton;
        private System.Windows.Forms.Button deleteWebPagesTempFileButton;
        private System.Windows.Forms.TextBox searchRequestTextBox;
        private System.Windows.Forms.TextBox pagesNamesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Button findEmailsButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox coresCountComboBox;
        private System.Windows.Forms.ComboBox pagesCountComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label webPagesTempFilePathTextBox;
        private System.Windows.Forms.Label emailsPathFileLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label sitesPathFileLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripStatusLabel statusBarText;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инфоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem иструкцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

