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

namespace slideshow2
{
    public partial class Form1 : Form
    {
        string Dirpath;

        int imgindex;

       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)

            {

                comboBox1.Items.Add(i);

                comboBox1.SelectedIndex = 0;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr != DialogResult.Cancel)

            {

                listBox1.Items.Clear();

                Dirpath = folderBrowserDialog1.SelectedPath;

                string[] files = Directory.GetFiles(Dirpath, "*.Jpg");

                foreach (string file in files)

                {
    
                    int pos = file.LastIndexOf("||");

                    string FName = file.Substring(pos + 1);

                    listBox1.Items.Add(FName);

                }

                listBox1.SelectedIndex = imgindex = 0;

                btnprev.Enabled = true;

                btnnext.Enabled = btnshow.Enabled = true;

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (btnshow.Text == "Slide Show")

            {

                btnshow.Text = "stop show";

                timer1.Interval = int.Parse(comboBox1.Text) * 1000;

                timer1.Start();

            }

            else

            {

                timer1.Stop();

                btnshow.Text = "Slide Show";

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       //     pictureBox1.ImageLocation = listBox1.SelectedItem.ToString();

             pictureBox1.ImageLocation = Dirpath + "\\" + listBox1.SelectedItem;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (imgindex > 0)

            {

                imgindex -= 1;

                if (imgindex == 0)

                {

                    btnprev.Enabled = false;

                }

                if (imgindex < listBox1.Items.Count - 1)

                    btnnext.Enabled = true;

                listBox1.SelectedIndex = imgindex;

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (imgindex < listBox1.Items.Count - 1)

            {

                imgindex += 1;

                if (imgindex == listBox1.Items.Count - 1)

                    btnnext.Enabled = false;

                if (imgindex > 0)

                    btnprev.Enabled = true;

                listBox1.SelectedIndex = imgindex;

            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            btnnext.PerformClick();
        }
    }
}
