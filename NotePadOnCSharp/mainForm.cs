using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadOnCSharp
{
    public partial class MainForm : Form
    {
        public interface IMainForm
        {
            string FilePath { get; }
            string Content { get; set; }
            void SetSymbolCount(int count);
            event EventHandler FileOpenClick;
            event EventHandler FileSaveClick;
            event EventHandler ContentChanged;
        }
        public partial class MainForm: Form, IMainForm
        {
            public MainForm()
            {
            InitializeComponent();
                butOpenFile.Click += ButOpenFile_Click;
                butSaveFile.Click += ButSaveFile_Click;
                fidContent.TextChanged += fidContent_TextChanged;

            }

            #region Проброс событий
            void ButOpenFile_Click(object sender, EventArgs e)
            {
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }

           void ButSaveFile_Click(object sender, EventArgs e)
           {
                if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
           }
            void fidContent_TextChanged(object sender, EventArgs e)
            {
                if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
            }


            public string FilePath
            {
                get { return fldFilePath.Text;  }
            }

            public string Content
            {
                get { return fldContent.Text; }
                set { fldContent.text = value; }
            }

            public void SetSymbolCount(int count)
            {
                lblSymbolCount.Text = count.ToString();
            }

           public event EventHandler FileOpenClick;
           public event EventHandler FileSaveClick;
           public event EventHandler ContentChanged;
        }
    }
}
