using System.Drawing;
using System.Windows.Forms;

namespace Compiler_Kursovaya
{
    partial class MainForm
    {
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RepeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrammarClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnalysMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiagnosticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FontComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageBtn = new System.Windows.Forms.Button();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.PasteBtn = new System.Windows.Forms.Button();
            this.CutBtn = new System.Windows.Forms.Button();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.RepeatBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.EditRTB = new System.Windows.Forms.RichTextBox();
            this.NumbersBox = new System.Windows.Forms.ListBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LexemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ParserPage = new System.Windows.Forms.TabPage();
            this.QuadPage = new System.Windows.Forms.TabPage();
            this.QuadDGV = new System.Windows.Forms.DataGridView();
            this.opColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arg1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arg2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.ParserPage.SuspendLayout();
            this.QuadPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuadDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem1,
            this.EditToolStripMenuItem,
            this.TextToolStripMenuItem,
            this.StartToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem1
            // 
            this.FileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.CloseFileToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1";
            this.FileToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem1.Text = "Файл";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.CreateToolStripMenuItem.Text = "Создать";
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // CloseFileToolStripMenuItem
            // 
            this.CloseFileToolStripMenuItem.Name = "CloseFileToolStripMenuItem";
            this.CloseFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.CloseFileToolStripMenuItem.Text = "Закрыть вкладку";
            this.CloseFileToolStripMenuItem.Click += new System.EventHandler(this.CloseFileToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelToolStripMenuItem,
            this.RepeatToolStripMenuItem,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.SelectAllВсеToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.EditToolStripMenuItem.Text = "Правка";
            // 
            // CancelToolStripMenuItem
            // 
            this.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem";
            this.CancelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CancelToolStripMenuItem.Text = "Отменить";
            this.CancelToolStripMenuItem.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
            // 
            // RepeatToolStripMenuItem
            // 
            this.RepeatToolStripMenuItem.Name = "RepeatToolStripMenuItem";
            this.RepeatToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.RepeatToolStripMenuItem.Text = "Повторить";
            this.RepeatToolStripMenuItem.Click += new System.EventHandler(this.RepeatToolStripMenuItem_Click);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CutToolStripMenuItem.Text = "Вырезать";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CopyToolStripMenuItem.Text = "Копировать";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.PasteToolStripMenuItem.Text = "Вставить";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // SelectAllВсеToolStripMenuItem
            // 
            this.SelectAllВсеToolStripMenuItem.Name = "SelectAllВсеToolStripMenuItem";
            this.SelectAllВсеToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.SelectAllВсеToolStripMenuItem.Text = "Выделить все";
            this.SelectAllВсеToolStripMenuItem.Click += new System.EventHandler(this.SelectAllВсеToolStripMenuItem_Click);
            // 
            // TextToolStripMenuItem
            // 
            this.TextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatementToolStripMenuItem,
            this.GrammarToolStripMenuItem,
            this.GrammarClassToolStripMenuItem,
            this.AnalysMethodToolStripMenuItem,
            this.DiagnosticToolStripMenuItem,
            this.TestToolStripMenuItem,
            this.ReferencesToolStripMenuItem,
            this.CodeToolStripMenuItem});
            this.TextToolStripMenuItem.Name = "TextToolStripMenuItem";
            this.TextToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.TextToolStripMenuItem.Text = "Текст";
            // 
            // StatementToolStripMenuItem
            // 
            this.StatementToolStripMenuItem.Name = "StatementToolStripMenuItem";
            this.StatementToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.StatementToolStripMenuItem.Text = "Постановка задачи";
            this.StatementToolStripMenuItem.Click += new System.EventHandler(this.StatementToolStripMenuItem_Click);
            // 
            // GrammarToolStripMenuItem
            // 
            this.GrammarToolStripMenuItem.Name = "GrammarToolStripMenuItem";
            this.GrammarToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.GrammarToolStripMenuItem.Text = "Грамматика";
            this.GrammarToolStripMenuItem.Click += new System.EventHandler(this.GrammarToolStripMenuItem_Click);
            // 
            // GrammarClassToolStripMenuItem
            // 
            this.GrammarClassToolStripMenuItem.Name = "GrammarClassToolStripMenuItem";
            this.GrammarClassToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.GrammarClassToolStripMenuItem.Text = "Классификация грамматики";
            this.GrammarClassToolStripMenuItem.Click += new System.EventHandler(this.GrammarClassToolStripMenuItem_Click);
            // 
            // AnalysMethodToolStripMenuItem
            // 
            this.AnalysMethodToolStripMenuItem.Name = "AnalysMethodToolStripMenuItem";
            this.AnalysMethodToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.AnalysMethodToolStripMenuItem.Text = "Метод анализа";
            this.AnalysMethodToolStripMenuItem.Click += new System.EventHandler(this.AnalysMethodToolStripMenuItem_Click);
            // 
            // DiagnosticToolStripMenuItem
            // 
            this.DiagnosticToolStripMenuItem.Name = "DiagnosticToolStripMenuItem";
            this.DiagnosticToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.DiagnosticToolStripMenuItem.Text = "Диагностика и нейтрализация ошибок";
            this.DiagnosticToolStripMenuItem.Click += new System.EventHandler(this.DiagnosticToolStripMenuItem_Click);
            // 
            // TestToolStripMenuItem
            // 
            this.TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            this.TestToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.TestToolStripMenuItem.Text = "Тестовые примеры";
            this.TestToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // ReferencesToolStripMenuItem
            // 
            this.ReferencesToolStripMenuItem.Name = "ReferencesToolStripMenuItem";
            this.ReferencesToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.ReferencesToolStripMenuItem.Text = "Список литературы";
            this.ReferencesToolStripMenuItem.Click += new System.EventHandler(this.ReferencesToolStripMenuItem_Click);
            // 
            // CodeToolStripMenuItem
            // 
            this.CodeToolStripMenuItem.Name = "CodeToolStripMenuItem";
            this.CodeToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.CodeToolStripMenuItem.Text = "Исходный код программы";
            this.CodeToolStripMenuItem.Click += new System.EventHandler(this.CodeToolStripMenuItem_Click);
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.StartToolStripMenuItem.Text = "Пуск";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenHelpToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.HelpToolStripMenuItem.Text = "Справка";
            // 
            // OpenHelpToolStripMenuItem
            // 
            this.OpenHelpToolStripMenuItem.Name = "OpenHelpToolStripMenuItem";
            this.OpenHelpToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.OpenHelpToolStripMenuItem.Text = "Вызов справки";
            this.OpenHelpToolStripMenuItem.Click += new System.EventHandler(this.OpenHelpToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.FontComboBox);
            this.panel1.Controls.Add(this.LanguageBtn);
            this.panel1.Controls.Add(this.HelpBtn);
            this.panel1.Controls.Add(this.StartBtn);
            this.panel1.Controls.Add(this.PasteBtn);
            this.panel1.Controls.Add(this.CutBtn);
            this.panel1.Controls.Add(this.CopyBtn);
            this.panel1.Controls.Add(this.RepeatBtn);
            this.panel1.Controls.Add(this.CancelBtn);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.AboutBtn);
            this.panel1.Controls.Add(this.OpenBtn);
            this.panel1.Controls.Add(this.CreateBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 55);
            this.panel1.TabIndex = 1;
            // 
            // FontComboBox
            // 
            this.FontComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FontComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FontComboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.FontComboBox.FormattingEnabled = true;
            this.FontComboBox.Location = new System.Drawing.Point(632, 14);
            this.FontComboBox.Name = "FontComboBox";
            this.FontComboBox.Size = new System.Drawing.Size(66, 29);
            this.FontComboBox.TabIndex = 12;
            this.FontComboBox.Text = "12";
            // 
            // LanguageBtn
            // 
            this.LanguageBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.LanguageBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LanguageBtn.Location = new System.Drawing.Point(704, 0);
            this.LanguageBtn.Name = "LanguageBtn";
            this.LanguageBtn.Size = new System.Drawing.Size(80, 55);
            this.LanguageBtn.TabIndex = 11;
            this.LanguageBtn.Text = "Русский";
            this.LanguageBtn.UseVisualStyleBackColor = true;
            this.LanguageBtn.Click += new System.EventHandler(this.LanguageBtn_Click);
            // 
            // HelpBtn
            // 
            this.HelpBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_help;
            this.HelpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpBtn.Location = new System.Drawing.Point(514, 3);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(50, 50);
            this.HelpBtn.TabIndex = 10;
            this.HelpBtn.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            this.StartBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_start_100;
            this.StartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartBtn.Location = new System.Drawing.Point(458, 3);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(50, 50);
            this.StartBtn.TabIndex = 9;
            this.StartBtn.UseVisualStyleBackColor = true;
            // 
            // PasteBtn
            // 
            this.PasteBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_paste_100;
            this.PasteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PasteBtn.Location = new System.Drawing.Point(402, 3);
            this.PasteBtn.Name = "PasteBtn";
            this.PasteBtn.Size = new System.Drawing.Size(50, 50);
            this.PasteBtn.TabIndex = 8;
            this.PasteBtn.UseVisualStyleBackColor = true;
            // 
            // CutBtn
            // 
            this.CutBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_cut_100;
            this.CutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CutBtn.Location = new System.Drawing.Point(346, 3);
            this.CutBtn.Name = "CutBtn";
            this.CutBtn.Size = new System.Drawing.Size(50, 50);
            this.CutBtn.TabIndex = 7;
            this.CutBtn.UseVisualStyleBackColor = true;
            // 
            // CopyBtn
            // 
            this.CopyBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_copy_100;
            this.CopyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyBtn.Location = new System.Drawing.Point(290, 3);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(50, 50);
            this.CopyBtn.TabIndex = 6;
            this.CopyBtn.UseVisualStyleBackColor = true;
            // 
            // RepeatBtn
            // 
            this.RepeatBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_redo_96;
            this.RepeatBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RepeatBtn.Location = new System.Drawing.Point(234, 3);
            this.RepeatBtn.Name = "RepeatBtn";
            this.RepeatBtn.Size = new System.Drawing.Size(50, 50);
            this.RepeatBtn.TabIndex = 5;
            this.RepeatBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_undo_96;
            this.CancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelBtn.Location = new System.Drawing.Point(178, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(50, 50);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_save_100;
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveBtn.Location = new System.Drawing.Point(122, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(50, 50);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // AboutBtn
            // 
            this.AboutBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_info;
            this.AboutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AboutBtn.Location = new System.Drawing.Point(570, 3);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(50, 50);
            this.AboutBtn.TabIndex = 2;
            this.AboutBtn.UseVisualStyleBackColor = true;
            // 
            // OpenBtn
            // 
            this.OpenBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_opened_folder;
            this.OpenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenBtn.Location = new System.Drawing.Point(66, 3);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(50, 50);
            this.OpenBtn.TabIndex = 1;
            this.OpenBtn.UseVisualStyleBackColor = true;
            // 
            // CreateBtn
            // 
            this.CreateBtn.BackgroundImage = global::Compiler_Kursovaya.Properties.Resources.icons8_add_file_100;
            this.CreateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateBtn.Location = new System.Drawing.Point(10, 3);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(50, 50);
            this.CreateBtn.TabIndex = 0;
            this.CreateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CreateBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 582);
            this.panel2.TabIndex = 2;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ItemSize = new System.Drawing.Size(140, 30);
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 582);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl.TabIndex = 6;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 544);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Новый документ *";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MainPanel);
            this.splitContainer1.Panel1MinSize = 195;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 180;
            this.splitContainer1.Size = new System.Drawing.Size(770, 538);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.SplitterWidth = 26;
            this.splitContainer1.TabIndex = 6;
            this.splitContainer1.TabStop = false;
            // 
            // MainPanel
            // 
            this.MainPanel.AutoSize = true;
            this.MainPanel.Controls.Add(this.EditRTB);
            this.MainPanel.Controls.Add(this.NumbersBox);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.MinimumSize = new System.Drawing.Size(660, 169);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(770, 213);
            this.MainPanel.TabIndex = 5;
            // 
            // EditRTB
            // 
            this.EditRTB.AcceptsTab = true;
            this.EditRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditRTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditRTB.Location = new System.Drawing.Point(52, 0);
            this.EditRTB.Name = "EditRTB";
            this.EditRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.EditRTB.Size = new System.Drawing.Size(718, 213);
            this.EditRTB.TabIndex = 3;
            this.EditRTB.Text = "";
            this.EditRTB.WordWrap = false;
            this.EditRTB.TextChanged += new System.EventHandler(this.EditRTB_TextChanged);
            // 
            // NumbersBox
            // 
            this.NumbersBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.NumbersBox.FormattingEnabled = true;
            this.NumbersBox.IntegralHeight = false;
            this.NumbersBox.ItemHeight = 21;
            this.NumbersBox.Location = new System.Drawing.Point(0, 0);
            this.NumbersBox.MinimumSize = new System.Drawing.Size(52, 170);
            this.NumbersBox.Name = "NumbersBox";
            this.NumbersBox.Size = new System.Drawing.Size(52, 213);
            this.NumbersBox.TabIndex = 4;
            this.NumbersBox.SelectedIndexChanged += new System.EventHandler(this.NumbersBox_SelectedIndexChanged);
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeColumn,
            this.LexemColumn,
            this.PlaceColumn});
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(3, 3);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.Size = new System.Drawing.Size(756, 259);
            this.DataGridView.TabIndex = 0;
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Тип лексемы";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Width = 126;
            // 
            // LexemColumn
            // 
            this.LexemColumn.HeaderText = "Лексема";
            this.LexemColumn.Name = "LexemColumn";
            this.LexemColumn.ReadOnly = true;
            this.LexemColumn.Width = 96;
            // 
            // PlaceColumn
            // 
            this.PlaceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlaceColumn.HeaderText = "Местоположение";
            this.PlaceColumn.Name = "PlaceColumn";
            this.PlaceColumn.ReadOnly = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ParserPage);
            this.tabControl1.Controls.Add(this.QuadPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 299);
            this.tabControl1.TabIndex = 1;
            // 
            // ParserPage
            // 
            this.ParserPage.Controls.Add(this.DataGridView);
            this.ParserPage.Location = new System.Drawing.Point(4, 30);
            this.ParserPage.Name = "ParserPage";
            this.ParserPage.Padding = new System.Windows.Forms.Padding(3);
            this.ParserPage.Size = new System.Drawing.Size(762, 265);
            this.ParserPage.TabIndex = 0;
            this.ParserPage.Text = "Парсер";
            this.ParserPage.UseVisualStyleBackColor = true;
            // 
            // QuadPage
            // 
            this.QuadPage.Controls.Add(this.QuadDGV);
            this.QuadPage.Location = new System.Drawing.Point(4, 30);
            this.QuadPage.Name = "QuadPage";
            this.QuadPage.Padding = new System.Windows.Forms.Padding(3);
            this.QuadPage.Size = new System.Drawing.Size(762, 265);
            this.QuadPage.TabIndex = 1;
            this.QuadPage.Text = "Тетрады";
            this.QuadPage.UseVisualStyleBackColor = true;
            // 
            // QuadDGV
            // 
            this.QuadDGV.AllowUserToAddRows = false;
            this.QuadDGV.AllowUserToDeleteRows = false;
            this.QuadDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QuadDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.QuadDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuadDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.opColumn,
            this.arg1Column,
            this.arg2Column,
            this.resultColumn});
            this.QuadDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuadDGV.Location = new System.Drawing.Point(3, 3);
            this.QuadDGV.Name = "QuadDGV";
            this.QuadDGV.ReadOnly = true;
            this.QuadDGV.Size = new System.Drawing.Size(756, 259);
            this.QuadDGV.TabIndex = 1;
            // 
            // opColumn
            // 
            this.opColumn.HeaderText = "op";
            this.opColumn.Name = "opColumn";
            this.opColumn.ReadOnly = true;
            this.opColumn.Width = 53;
            // 
            // arg1Column
            // 
            this.arg1Column.HeaderText = "arg1";
            this.arg1Column.Name = "arg1Column";
            this.arg1Column.ReadOnly = true;
            this.arg1Column.Width = 67;
            // 
            // arg2Column
            // 
            this.arg2Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.arg2Column.HeaderText = "arg2";
            this.arg2Column.Name = "arg2Column";
            this.arg2Column.ReadOnly = true;
            // 
            // resultColumn
            // 
            this.resultColumn.HeaderText = "result";
            this.resultColumn.Name = "resultColumn";
            this.resultColumn.ReadOnly = true;
            this.resultColumn.Width = 74;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenuStrip);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Парсер";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ParserPage.ResumeLayout(false);
            this.QuadPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuadDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MainMenuStrip;
        private Panel panel1;
        private Panel panel2;
        private RichTextBox EditRTB;
        private ToolStripMenuItem FileToolStripMenuItem1;
        private ToolStripMenuItem CreateToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem SaveAsToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem CancelToolStripMenuItem;
        private ToolStripMenuItem RepeatToolStripMenuItem;
        private ToolStripMenuItem CutToolStripMenuItem;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripMenuItem PasteToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem SelectAllВсеToolStripMenuItem;
        private ToolStripMenuItem TextToolStripMenuItem;
        private ToolStripMenuItem StatementToolStripMenuItem;
        private ToolStripMenuItem GrammarToolStripMenuItem;
        private ToolStripMenuItem GrammarClassToolStripMenuItem;
        private ToolStripMenuItem AnalysMethodToolStripMenuItem;
        private ToolStripMenuItem DiagnosticToolStripMenuItem;
        private ToolStripMenuItem TestToolStripMenuItem;
        private ToolStripMenuItem ReferencesToolStripMenuItem;
        private ToolStripMenuItem CodeToolStripMenuItem;
        private ToolStripMenuItem StartToolStripMenuItem;
        private ToolStripMenuItem HelpToolStripMenuItem;
        private ToolStripMenuItem OpenHelpToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private Button CreateBtn;
        private Button HelpBtn;
        private Button StartBtn;
        private Button PasteBtn;
        private Button CutBtn;
        private Button CopyBtn;
        private Button RepeatBtn;
        private Button CancelBtn;
        private Button SaveBtn;
        private Button AboutBtn;
        private Button OpenBtn;
        private Panel MainPanel;
        private TabControl TabControl;
        private TabPage tabPage1;
        private ListBox NumbersBox;
        private SplitContainer splitContainer1;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem CloseFileToolStripMenuItem;
        private Button LanguageBtn;
        private ComboBox FontComboBox;
        private DataGridView DataGridView;
        private DataGridViewTextBoxColumn TypeColumn;
        private DataGridViewTextBoxColumn LexemColumn;
        private DataGridViewTextBoxColumn PlaceColumn;
        private TabControl tabControl1;
        private TabPage ParserPage;
        private TabPage QuadPage;
        private DataGridView QuadDGV;
        private DataGridViewTextBoxColumn opColumn;
        private DataGridViewTextBoxColumn arg1Column;
        private DataGridViewTextBoxColumn arg2Column;
        private DataGridViewTextBoxColumn resultColumn;
    }
}

