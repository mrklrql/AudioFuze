using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioFuze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AudioFuze_Click(object sender, EventArgs e)
        {

        

        }
        //Create Global Variables of String Type Array to save the titles or more of the tracks and path of the track
        String[] paths, files;

        private void button1_Click(object sender, EventArgs e)
        {
            //Code to slect songs
            OpenFileDialog ofd = new OpenFileDialog();
            //Code to select multiple files
            ofd.Multiselect = true;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            { 
            
                files = ofd.SafeFileNames; //Save the names of the tracks in files array
                paths = ofd.FileNames; //Save the paths of the tracks in path array
                //Display the music titles in listbox
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]); //Display songs in listbox
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Write a code to play music
            axWindowsMediaPlayer2.URL = paths[listBox1.SelectedIndex]; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frml = new frmLogin();
            frml.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Code to close the app
            System.Environment.Exit(0);
        }
    }
    
}
