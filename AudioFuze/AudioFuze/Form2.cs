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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
   
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AF_Users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm1 = new Form1();
            frm1.Show();
            this.Hide();

            if (Usernametextbox1.Text == "" && PasswordTextbox1.Text == "" && PasswordtextBox2.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (PasswordTextbox1.Text == PasswordtextBox2.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users Values ('"+Usernametextbox1.Text+"','"+PasswordTextbox1.Text+"')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Usernametextbox1.Text = "";
                PasswordTextbox1.Text = "";
                PasswordtextBox2.Text = "";

                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else 
            {
                MessageBox.Show("Password does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextbox1.Text = "";
                PasswordtextBox2.Text = "";
                PasswordTextbox1.Focus();
            }  
        }
        private void Form2_Load(object sender, EventArgs e)
        {
 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PasswordTextbox1.PasswordChar = '\0';
                PasswordtextBox2.PasswordChar = '\0';
            }
            else
            {
                PasswordTextbox1.PasswordChar = '•';
                PasswordtextBox2.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usernametextbox1.Text = "";
            PasswordTextbox1.Text = "";
            PasswordtextBox2.Text = "";
            Usernametextbox1.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Code to close the app
            System.Environment.Exit(0);
        }
    }
}
