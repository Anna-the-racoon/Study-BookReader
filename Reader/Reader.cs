using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reader
{
    public partial class FormReader : Form
    {
        private string bookName;
        private string placeToSave;
        public FormReader()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region File
        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                var open = new OpenFileDialog();
                open.Filter = "All Files(*.*)|*.*| Text Files(*.txt; *.epub; *.rtf; *.docx) | *.txt; *.epub; *.rtf; .docx|| ";
                open.FilterIndex = 2;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    var reader = File.OpenText(open.FileName);
                    bookName = open.SafeFileName.ToString();
                    placeToSave = open.FileName.ToString();
                    richTextBoxBook.Text = reader.ReadToEnd(); 
                    reader.Close(); 
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.Text = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }
        #endregion

        #region Search
        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int start = 0;
                int end = richTextBoxBook.Text.LastIndexOf(toolStripTextBoxSearch.Text);

                richTextBoxBook.SelectAll();
                richTextBoxBook.SelectionBackColor = Color.White;

                while (start < end)
                {
                    richTextBoxBook.Find(toolStripTextBoxSearch.Text, start, richTextBoxBook.TextLength, RichTextBoxFinds.MatchCase);

                    richTextBoxBook.SelectionBackColor = Color.Yellow;

                    start = richTextBoxBook.Text.IndexOf(toolStripTextBoxSearch.Text, start) + 1;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void toolStripTextBoxSearch_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripTextBoxSearch.Text = null;
                toolStripTextBoxSearch.ForeColor = Color.Black;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void richTextBoxBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripTextBoxSearch.Text == "")
                {
                    toolStripTextBoxSearch.ForeColor = Color.Gray;
                    toolStripTextBoxSearch.Text = "Enter the text";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }
        #endregion

        #region Back_colour

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.BackColor = Color.White;
                whiteToolStripMenuItem.Checked = true;
                blackToolStripMenuItem.Checked = false;
                grayToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.BackColor = Color.Black;
                whiteToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = true;
                grayToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.BackColor = Color.Gray;
                whiteToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                grayToolStripMenuItem.Checked = true;
                yellowToolStripMenuItem.Checked = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.BackColor = Color.Yellow;
                whiteToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                grayToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }
        #endregion

        #region Text_colour

        private void blackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.ForeColor = Color.Black;
                blackToolStripMenuItem1.Checked = true;
                whiteToolStripMenuItem1.Checked = false;
                redToolStripMenuItem.Checked = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void whiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.ForeColor = Color.White;
                blackToolStripMenuItem1.Checked = false;
                whiteToolStripMenuItem1.Checked = true;
                redToolStripMenuItem.Checked = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.ForeColor = Color.Red;
                blackToolStripMenuItem1.Checked = false;
                whiteToolStripMenuItem1.Checked = false;
                redToolStripMenuItem.Checked = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }
        #endregion

        #region Page
        private void toolStripButtonLeft_Click(object sender, EventArgs e)
        {
            try
            {
                var position = richTextBoxBook.SelectionStart;
                var row = richTextBoxBook.GetLineFromCharIndex(position);
                richTextBoxBook.SelectionStart = richTextBoxBook.GetLineFromCharIndex(position) - 10;
                richTextBoxBook.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void toolStripButtonRight_Click(object sender, EventArgs e)
        {
            try
            {
                var position = richTextBoxBook.SelectionStart;
                var row = richTextBoxBook.GetLineFromCharIndex(position);
                richTextBoxBook.SelectionStart = richTextBoxBook.GetLineFromCharIndex(position) + 10;
                richTextBoxBook.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }
        #endregion

        private void toolStripButtonPutToFavorites_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxBook.SelectionBackColor = Color.DeepPink;
                richTextBoxBook.SaveFile(placeToSave);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }

        private void toolStripButtonBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                //richTextBoxBook.SelectionBackColor = ;
                richTextBoxBook.SaveFile(placeToSave);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception: {exception.Message}");
            }
        }
    }
}
