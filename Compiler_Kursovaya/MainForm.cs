using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compiler_Kursovaya.TextFolder;

namespace Compiler_Kursovaya
{
    public partial class MainForm : Form
    {
        private string newFileName = "Новый документ *";
        private bool currentLanguage = false;
        public List<File> files;
        private bool anotherFile;
        int index = 0;
        private enum LastActionType { None, Insert, Backspace, Paste }
        private LastActionType lastAction = LastActionType.None;
        private string lastText = "";
        private int lastCursorPos = 0;
        public MainForm()
        {
            InitializeComponent();
            SetupNumericPanel();
            files = new List<File>();
            File file = new File("Новый документ", "", "", "", false, false);
            TabControl.TabPages[TabControl.SelectedIndex].Text = file.filename + " *";
            this.files.Add(file);

            saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";

            CreateBtn.Click += CreateToolStripMenuItem_Click;
            OpenBtn.Click += OpenToolStripMenuItem_Click;
            SaveBtn.Click += SaveToolStripMenuItem_Click;
            CancelBtn.Click += CancelToolStripMenuItem_Click;
            RepeatBtn.Click += RepeatToolStripMenuItem_Click;
            CutBtn.Click += CutToolStripMenuItem_Click;
            CopyBtn.Click += CopyToolStripMenuItem_Click;
            PasteBtn.Click += PasteToolStripMenuItem_Click;
            HelpBtn.Click += OpenHelpToolStripMenuItem_Click;
            AboutBtn.Click += AboutToolStripMenuItem_Click;
            this.FormClosing += ExitToolStripMenuItem_Click;
            StartBtn.Click += StartToolStripMenuItem_Click;

            LoadFontComboBox();
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File file = new File(newFileName, null, null, null, false, false);
            this.files.Add(file);

            AddNewTabPage(file.filename);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string path = openFileDialog.FileName;

            File file = File.OpenFile(path);
            files.Add(file);

            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].path == path)
                {
                    TabControl.SelectedIndex = i;
                    AddNewTabPage(files[i].filename);
                    return;
                }
            }
            MessageBox.Show("Файл успешно открыт!");
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File currentFile = files[TabControl.SelectedIndex];
            SaveFile(currentFile);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File currentFile = files[TabControl.SelectedIndex];
            SaveFileAs(currentFile);
        }

        private void SaveFile(File file)
        {
            if (!string.IsNullOrEmpty(file.path))
            {
                SaveToFile(file.path, EditRTB.Text);
                TabControl.TabPages[TabControl.SelectedIndex].Text = file.filename;
            }
            else
            {
                SaveFileAs(file);
            }
        }

        private void SaveToFile(string path, string text)
        {
            System.IO.File.WriteAllText(path, text);
            files[TabControl.SelectedIndex].file_saved = true;
        }

        private void SaveFileAs(File file)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string path = saveFileDialog.FileName;
            string filename = Path.GetFileName(path);

            file.path = path;
            file.filename = filename;

            TabControl.TabPages[TabControl.SelectedIndex].Text = filename;

            SaveToFile(path, EditRTB.Text);
            file.file_saved = true;
            file.file_saved_as = true;

            MessageBox.Show("Файл успешно сохранён!");
        }

        private void AddNewTabPage(string filename)
        {
            TabPage newTab = new TabPage(filename);
            newTab.Controls.Add(this.splitContainer1);
            TabControl.TabPages.Add(newTab);
            splitContainer1.SplitterDistance = TabControl.Height / 2;

            TabControl.SelectedTab = newTab;
        }

        private void SetupNumericPanel()
        {
            NumbersBox.DrawMode = DrawMode.OwnerDrawFixed;
            NumbersBox.IntegralHeight = false;
            NumbersBox.ScrollAlwaysVisible = false;
            NumbersBox.MouseWheel += (s, e) => ((HandledMouseEventArgs)e).Handled = true;
            NumbersBox.Font = new Font("Segou UI", 12);
            EditRTB.VScroll += (s, e) => SyncScroll();
            EditRTB.TextChanged += (s, e) => UpdateLineNumbers();
            EditRTB.Resize += (s, e) => UpdateLineNumbers();
            NumbersBox.DrawItem += NumbersBox_DrawItem;
            UpdateLineNumbers();
        }

        private void UpdateLineNumbers()
        {
            int lineCount = EditRTB.Lines.Length;
            int visibleLines = EditRTB.Height / EditRTB.Font.Height;

            NumbersBox.BeginUpdate();
            NumbersBox.Items.Clear();

            for (int i = 1; i <= lineCount; i++)
            {
                NumbersBox.Items.Add(i.ToString());
            }

            NumbersBox.EndUpdate();
            SyncScroll();
        }

        private void SyncScroll()
        {
            if (NumbersBox.Items.Count == 0) return;

            int firstCharIndex = EditRTB.GetCharIndexFromPosition(new Point(0, 5));
            int firstVisibleLine = EditRTB.GetLineFromCharIndex(firstCharIndex);

            if (firstVisibleLine < NumbersBox.Items.Count)
            {
                NumbersBox.TopIndex = firstVisibleLine;
            }
            NumbersBox.ItemHeight = (int)(EditRTB.Font.Size * 1.7);
        }

        private void NumbersBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                e.Graphics.DrawString(
                    NumbersBox.Items[e.Index].ToString(),
                    NumbersBox.Font,
                    Brushes.Black,
                    e.Bounds.Location
                );
            }
            e.DrawFocusRectangle();
        }

        private void EditRTB_TextChanged(object sender, EventArgs e)
        {
            int index = TabControl.SelectedIndex;

            if (anotherFile == true)
            {
                anotherFile = false;
                return;
            }
            if (index >= 0)
            {
                if (files[index].file_saved == true)
                {
                    files[index].file_saved = false;
                    TabControl.TabPages[TabControl.SelectedIndex].Text = files[TabControl.SelectedIndex].filename + " *";
                }
            }
            lastCursorPos = EditRTB.SelectionStart;
            if (
                EditRTB.SelectionLength == 0 &&
                EditRTB.Text.Length > lastText.Length &&
                lastCursorPos > 0 &&
                lastAction != LastActionType.Backspace &&
                lastAction != LastActionType.Paste
                )
            {
                lastAction = LastActionType.Insert;
                lastText = EditRTB.Text.Substring(lastCursorPos - 1, 1);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            File file = new File(newFileName, null, EditRTB.Text, null, false, false);

            TabControl.TabPages[TabControl.SelectedIndex].Controls.Add(this.splitContainer1);

            files[this.index].EditText = EditRTB.Text;

            anotherFile = true;
            EditRTB.Text = files[TabControl.SelectedIndex].EditText;
            DataGridView.Rows.Clear();
            QuadDGV.Rows.Clear();
            REDGV.Rows.Clear();

            this.index = TabControl.SelectedIndex;
        }

        private void NumbersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NumbersBox.SelectedIndex != -1)
            {
                int selectedLine = NumbersBox.SelectedIndex;

                int charIndex = EditRTB.GetFirstCharIndexFromLine(selectedLine);

                int lineLength = EditRTB.Lines[selectedLine].Length;
                EditRTB.Select(charIndex, lineLength);
                EditRTB.Focus();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var file in files)
            {
                if (!file.file_saved)
                {
                    DialogResult result = MessageBox.Show(
                        $"Сохранить файл \"{file.filename}\"?",
                        "Сохранение файла",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.Yes)
                    {
                        SaveFile(file);
                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            this.Close();
        }

        private void CloseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File currentFile = files[TabControl.SelectedIndex];
            CloseFile(currentFile);
        }

        private void CloseFile(File file)
        {
            if (!file.file_saved)
            {
                DialogResult result = MessageBox.Show(
                    $"Сохранить файл \"{file.filename}\"?",
                    "Сохранение файла",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    SaveFile(file);
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (TabControl.TabPages.Count == 1)
            {
                files[0].file_saved = true;
                this.Close();
            }
            else
            {
                int newIndex = (TabControl.SelectedIndex == 0) ? 1 : TabControl.SelectedIndex - 1;

                files.RemoveAt(index - 1);
                TabControl.TabPages.RemoveAt(index - 1);

                TabControl.SelectedIndex = Math.Max(0, newIndex);
            }
            this.index = TabControl.SelectedIndex;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            File currentFile = files[TabControl.SelectedIndex];
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveFile(currentFile);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                OpenFile();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                File file = new File(newFileName, null, null, null, false, false);
                this.files.Add(file);

                AddNewTabPage(file.filename);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.W))
            {
                CloseFile(currentFile);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.V))
            {
                PasteFunction();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                EditRTB.Copy();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Z))
            {
                UndoFunction();
                return true;
            }
            else if (keyData == (Keys.Back))
            {
                lastAction = LastActionType.Backspace;
                if (EditRTB.Text.Length > 0)
                {
                    if (EditRTB.SelectionLength > 0)
                    {
                        EditRTB.SelectedText = "";
                    }
                    else if (EditRTB.SelectionLength == 0)
                    {
                        EditRTB.SelectionStart--;
                        EditRTB.SelectionLength = 1;
                        EditRTB.SelectedText = "";
                    }
                }
                return true;
            }
            else
            {
                lastAction = LastActionType.Insert;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SelectAllВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRTB.SelectAll();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFunction();
        }

        private void DeleteFunction()
        {
            if (EditRTB.Text.Length > 0)
            {
                lastAction = LastActionType.Backspace;
                lastText = EditRTB.SelectedText;
                EditRTB.SelectedText = "";
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFunction();
        }

        private void PasteFunction()
        {
            if (Clipboard.ContainsText())
            {
                lastAction = LastActionType.Paste;
                lastText = Clipboard.GetText();
                EditRTB.Paste();
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRTB.Copy();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRTB.Cut();
        }

        private void RepeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (lastAction)
            {
                case LastActionType.Insert:
                    int pos = EditRTB.SelectionStart;
                    EditRTB.SelectedText = lastText;
                    EditRTB.SelectionStart = pos + lastText.Length;
                    break;

                case LastActionType.Backspace:
                    if (EditRTB.Text.Length > 0)
                    {
                        EditRTB.SelectionStart--;
                        EditRTB.SelectionLength = 1;
                        EditRTB.SelectedText = "";
                    }
                    break;

                case LastActionType.Paste:
                    EditRTB.Paste();
                    break;
            }
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoFunction();
        }

        private void UndoFunction()
        {
            if (EditRTB.CanUndo)
            {
                EditRTB.Undo();
            }
        }

        private void UpdateControlsText(Control control, ResourceManager res)
        {
            LanguageBtn.Text = res.GetString("LanguageBtn");
            newFileName = res.GetString("newFileName");

            foreach (var item in this.MainMenuStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    UpdateMenuItems(menuItem, res);
                }
            }
        }
        private void UpdateMenuItems(ToolStripMenuItem menuItem, ResourceManager res)
        {
            if (!string.IsNullOrEmpty(menuItem.Name))
            {
                string newText = res.GetString(menuItem.Name);
                if (!string.IsNullOrEmpty(newText))
                    menuItem.Text = newText;
            }


            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    UpdateMenuItems(subMenuItem, res);
                }
            }
        }

        private void LanguageBtn_Click(object sender, EventArgs e)
        {
            if (currentLanguage)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                ResourceManager res = new ResourceManager("Compiler_Kursovaya.Properties.Resources.Resources_ru", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
                currentLanguage = false;
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                ResourceManager res = new ResourceManager("Compiler_Kursovaya.Properties.Resources.Resources_en", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
                currentLanguage = true;
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Анализатор кода | Работу выполнил студент АВТФ, группы АВТ-214 - Беликов И.Ю.");
        }

        private void OpenHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "ContentsFile.chm");

                System.IO.File.WriteAllBytes(tempPath, Compiler_Kursovaya.Properties.Resources.Help);

                if (System.IO.File.Exists(tempPath))
                {
                    Help.ShowHelp(this, tempPath);
                }
                else
                {
                    MessageBox.Show("Файл справки не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии справки: " + ex.Message);
            }
        }

        private void LoadFontComboBox()
        {
            FontComboBox.Items.Add(9);
            FontComboBox.Items.Add(11);
            FontComboBox.Items.Add(12);
            FontComboBox.SelectedIndex = 2;
        }

        private void FontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font selectedFont = new Font("Segou UI", Convert.ToInt32(FontComboBox.SelectedItem));
            EditRTB.Font = selectedFont;
            NumbersBox.Font = selectedFont;
            SyncScroll();
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = EditRTB.Text;
            code = code.Trim().Replace("\t", "").Replace("\n", "").Replace("\r", "");
            if (tabControl1.SelectedTab == ParserPage)
            {
                DataGridView.Rows.Clear();
                Scanner scanner = new Scanner(code);
                List<(int, string, string, int, int)> tokens = new List<(int, string, string, int, int)>();
                (int, string, string, int, int) token;

                while ((token = scanner.GetNextToken()).Item1 != (int)TokenType.End)
                {
                    tokens.Add(token);
                }

                Parser parser = new Parser(tokens, DataGridView);
                parser.Run();
            }
            else if (tabControl1.SelectedTab == QuadPage)
            {
                QuadDGV.Rows.Clear();
                Lab5 quad = new Lab5(code);
                quad.Parse();
                if (quad.errors.Count > 0)
                {
                    quad.PrintErrors(QuadDGV);
                }
                else
                {
                    quad.DisplayQuadruplesInDataGridView(QuadDGV);
                }
            }
            else if (tabControl1.SelectedTab == REPage)
            {
                REDGV.Rows.Clear();
                string text = EditRTB.Text;

                EditRTB.SelectAll();
                EditRTB.SelectionBackColor = EditRTB.BackColor;
                EditRTB.SelectionColor = EditRTB.ForeColor;

                FindMatches(REDGV, EditRTB, text, @"[^\\\/:*?""<>|,\s]+\.(doc|docx|pdf)");
                FindMatches(REDGV, EditRTB, text, @"[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)?\s[А-ЯЁ]\.[А-ЯЁ]\.");
                FindMatches(REDGV, EditRTB, text, @"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[#?!|/@$%\^&*\-_])[A-Za-z\d#?!|/@$%\^&*\-_]{8,}");
            }
        }

        static void FindMatches(DataGridView dgv, RichTextBox rtb, string text, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                dgv.Rows.Add(match.Value, match.Index);

                rtb.Select(match.Index, match.Length);
                rtb.SelectionBackColor = Color.Yellow;
                rtb.SelectionColor = Color.Black;
            }
        }

        private void StatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatementForm form = new StatementForm();
            form.Show();
        }

        private void GrammarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrammarForm form = new GrammarForm();
            form.Show();
        }

        private void GrammarClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrammarClassForm form = new GrammarClassForm();
            form.Show();
        }

        private void AnalysMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalysisMethodForm form = new AnalysisMethodForm();
            form.Show();
        }

        private void DiagnosticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiagnosticForm form = new DiagnosticForm();
            form.Show();
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm form = new TestForm();
            form.Show();
        }

        private void ReferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferencesForm form = new ReferencesForm();
            form.Show();
        }

        private void CodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeForm form = new CodeForm();
            form.Show();
        }
    }
}
