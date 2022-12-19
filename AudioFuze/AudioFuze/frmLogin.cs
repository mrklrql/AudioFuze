using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AudioFuze
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AF_Users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void label5_Click(object sender, EventArgs e)
        {
            Form frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.DarkGray;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.SlateBlue;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passwordtxt.PasswordChar = '\0';
            }
            else
            {
                passwordtxt.PasswordChar = '•';
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + usernametxt.Text + "' and password= '" + passwordtxt.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password< Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernametxt.Text = "";
                passwordtxt.Text = "";
                usernametxt.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usernametxt.Text = "";
            passwordtxt.Text = "";
            usernametxt.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Code to close the app
            System.Environment.Exit(0);
        }
    }
}
