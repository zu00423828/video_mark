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

namespace video_mark
{
    public partial class Form1 : Form
    {
        string path;
        double time;
        FileStream fs ;
        StreamWriter sw;
        FileStream fs2;
        StreamWriter sw2;
        string filename;


        public Form1()
        {
            InitializeComponent();
 


        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            sw.Close();
            fs.Close();
            sw2.Close();
            fs2.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            /*OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "xls files (*.*)|*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(dialog.FileName);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "(*.mp4;)|*.mp4;";
            if (opn.ShowDialog() == DialogResult.OK)
            {
                //this.media.URL = opn.FileName;
                path = opn.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.media.URL = path;
            this.media.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.media.Ctlcontrols.pause();
            time = this.media.Ctlcontrols.currentPosition;
            this.media.Ctlcontrols.pause();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.currentPosition = time;
            this.media.Ctlcontrols.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            time = this.media.Ctlcontrols.currentPosition;
            TimeSpan times = TimeSpan.FromSeconds(time-0.5f);
            string str = times.ToString(@"hh\:mm\:ss\.ff");
            //MessageBox.Show(str);
            sw.Write(str + "\n");
            sw.Flush();


            TimeSpan times2 = TimeSpan.FromSeconds(time - 0.27f);
            string str2 = times2.ToString(@"hh\:mm\:ss\.ff");
            //MessageBox.Show(str);
            sw2.Write(str2 + "\n");
            sw2.Flush();



        }

        private void button7_Click(object sender, EventArgs e)
        {
            filename = textBox1.Text;
            if (filename.IndexOf(".txt") != -1)
            {
                fs = new FileStream(filename, FileMode.Create);
                sw = new StreamWriter(fs);
                this.textBox1.Visible = false;
                this.button7.Visible = false;
                label1.Text = filename;
                this.button8.Visible = true;


                fs2 = new FileStream("new"+filename, FileMode.Create);
                sw2 = new StreamWriter(fs2);

            }
            else MessageBox.Show("檔名不正確");
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Application.Restart();
            
        }
    }
}
