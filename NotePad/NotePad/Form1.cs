using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Form1 f1;
        //form (Form1 = ff1)
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //name
            this.Text = "NotePad";
            label1.Text = "Search";
            label2.Text = "Replace";
            this.button1.Text = "OK";

            //Defualt Font & Style
            this.textBox1.Font = new Font("Arial", 12);
            this.menuStrip1.Font = new Font(menuStrip1.Font, FontStyle.Bold);
            this.menuStrip1.Font = new Font("Mistral", 14);
            this.label1.BackColor = Color.White;
            this.label2.BackColor = Color.White;
            this.label1.Font = new Font(label1.Font, FontStyle.Bold);
            this.label2.Font = new Font(label2.Font, FontStyle.Bold);
            this.textBox2.Font = new Font(textBox2.Font, FontStyle.Bold);
            this.textBox3.Font = new Font(textBox3.Font, FontStyle.Bold);
            this.textBox2.Font = new Font("Raviel", 11);
            this.textBox3.Font = new Font("Raviel", 11);
            this.label1.Font = new Font("Mistral", 15);
            this.label2.Font = new Font("Mistral", 15);

            //default Checked
            this.wordWrapToolStripMenuItem.Checked = true;
            this.normalCaseToolStripMenuItem.Checked = true;

            // dock Property '.' Screen Size
            this.textBox1.Dock = DockStyle.Fill;

            //Start Style
            this.WindowState = FormWindowState.Maximized;

            //visible
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.button1.Visible = false;

            //Scroll
            this.textBox1.ScrollBars = ScrollBars.Both;

            //Display
            this.menuStrip1.BackColor = Color.White;
            this.textBox1.BorderStyle = BorderStyle.FixedSingle;
           
            //replace properties
            this.button1.BackColor = Color.White;
            this.button1.ForeColor = Color.Black;
            this.button1.Cursor = Cursors.Hand;
            this.button1.FlatStyle = FlatStyle.Flat;

            //Shortcut
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            upperCaseToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.U;
            lowerCaseToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.L;
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            replaceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;

         
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "NotePad";
            this.textBox1.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void upperCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.upperCaseToolStripMenuItem.Checked = true;
            this.normalCaseToolStripMenuItem.Checked = false;
            this.lowerCaseToolStripMenuItem.Checked = false;
            this.textBox1.CharacterCasing = CharacterCasing.Upper;
        }

        private void normalCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.upperCaseToolStripMenuItem.Checked = false;
            this.normalCaseToolStripMenuItem.Checked = true;
            this.lowerCaseToolStripMenuItem.Checked = false;
            this.textBox1.CharacterCasing = CharacterCasing.Normal;
        }

        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.upperCaseToolStripMenuItem.Checked = false;
            this.normalCaseToolStripMenuItem.Checked = false;
            this.lowerCaseToolStripMenuItem.Checked = true;
            this.textBox1.CharacterCasing = CharacterCasing.Lower;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                this.wordWrapToolStripMenuItem.Checked = false;
                this.textBox1.WordWrap = false;
            }

            else
            {
                this.wordWrapToolStripMenuItem.Checked = true;
                this.textBox1.WordWrap = true;
            }
        }

      
        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show ("THIS NOTEPAD IS DEVELOPED BY \n\nSHEIKH MUHAMMAD AFTAB ALTAF");

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowColor = false;
            DialogResult dr = this.fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.textBox1.Font = this.fontDialog1.Font;
            }

        }

        private void withColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowColor = true;
            DialogResult dr = this.fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.textBox1.Font = this.fontDialog1.Font;
                this.textBox1.ForeColor = this.fontDialog1.Color;
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.textBox1.ForeColor = this.colorDialog1.Color;
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.label1.Visible == true)
            {
                this.replaceToolStripMenuItem.Checked = false;
                this.textBox2.Visible = false;
                this.textBox3.Visible = false;
                this.label1.Visible = false;
                this.label2.Visible = false;
                this.button1.Visible = false;
                this.textBox2.Clear();
                this.textBox3.Clear();
            }

            else
            {
                this.replaceToolStripMenuItem.Checked = true;
                this.textBox2.Visible = true;
                this.textBox3.Visible = true;
                this.label1.Visible = true;
                this.label2.Visible = true;
                this.button1.Visible = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text.Replace(this.textBox2.Text, this.textBox3.Text);
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.button1.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult op = this.openFileDialog1.ShowDialog();

            if (op == DialogResult.OK)
            {
               
            
               
            }
         
              
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sv = this.saveFileDialog1.ShowDialog();
           
            if (sv == DialogResult.OK)
            {
                saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Filles (*.*)|*.*";
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                this.Text = saveFileDialog1.FileName;
            }
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.maronToolStripMenuItem.Checked = false;
            this.blackToolStripMenuItem.Checked = true;
            this.whiteToolStripMenuItem.Checked = false;
            this.whiteBlackToolStripMenuItem.Checked = false;
            this.textBox1.BackColor = Color.Black;
            this.textBox1.ForeColor = Color.White;
            this.menuStrip1.BackColor = Color.Black;
            this.menuStrip1.ForeColor = Color.White;
            this.label1.BackColor = Color.Black;
            this.label1.ForeColor = Color.White;
            this.label2.BackColor = Color.Black;
            this.label2.ForeColor = Color.White;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.maronToolStripMenuItem.Checked = false;
            this.blackToolStripMenuItem.Checked = false;
            this.whiteBlackToolStripMenuItem.Checked = false;
            this.whiteToolStripMenuItem.Checked = true;
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.Black;
            this.menuStrip1.BackColor = Color.White;
            this.menuStrip1.ForeColor = Color.Black;
            this.label1.BackColor = Color.White;
            this.label1.ForeColor = Color.Black;
            this.label2.BackColor = Color.White;
            this.label2.ForeColor = Color.Black;
        }

        private void maronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.blackToolStripMenuItem.Checked = false;
            this.whiteToolStripMenuItem.Checked = false;
            this.whiteBlackToolStripMenuItem.Checked= false;
            this.maronToolStripMenuItem.Checked = true;
            this.textBox1.BackColor = Color.Maroon;
            this.textBox1.ForeColor = Color.White;
            this.menuStrip1.BackColor = Color.Black;
            this.menuStrip1.ForeColor = Color.White;
            this.label1.BackColor = Color.Maroon;
            this.label1.ForeColor = Color.White;
            this.label2.BackColor = Color.Maroon;
            this.label2.ForeColor = Color.White;
        }

        private void whiteBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.blackToolStripMenuItem.Checked = false;
            this.whiteToolStripMenuItem.Checked = false;
            this.maronToolStripMenuItem.Checked = false;
            this.whiteBlackToolStripMenuItem.Checked = true;
            this.textBox1.BackColor = Color.White;
            this.textBox1.ForeColor = Color.Black;
            this.menuStrip1.BackColor = Color.Black;
            this.menuStrip1.ForeColor = Color.White;
            this.label1.BackColor = Color.White;
            this.label1.ForeColor = Color.Black;
            this.label2.BackColor = Color.White;
            this.label2.ForeColor = Color.Black;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timeDateToolStripMenuItem.Checked == false)
            {
                timeDateToolStripMenuItem.Checked = true;
                textBox1.Text = System.DateTime.Now.ToString();
            }

            else
            {
                timeDateToolStripMenuItem.Checked = false;
                this.textBox1.Clear();
            }
           
        }

    }
}
