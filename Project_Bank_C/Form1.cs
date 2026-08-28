using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using clsBussinseLibrary;

namespace Project_Bank_C
{
    public partial class FrmLogin : Form
    {
       

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void mtbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtbUserName.Text))
            {
                e.Cancel = true;
                mtbUserName.Focus();
                errorProvider1.SetError(mtbUserName, "UserName is empty !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(mtbUserName, "");
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                mtbPassword.PasswordChar = '\0';
            }
            else
            {

                mtbPassword.PasswordChar = '.';
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.BackColor = Color.FromArgb(26, 35, 58);
            pnlLogin.BackColor = Color.FromArgb(26, 35, 58);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsBLoginRegister.IsPassed(mtbPassword.Text,mtbUserName.Text))
            {
                Form frm = new FrmInterFace();
                frm.ShowDialog();
                mtbUserName.Focus();
                mtbUserName.Text = "";
                mtbPassword.Text = "";
               
            }
            else
            {

                MessageBox.Show("Invalid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbUserName.Focus();
                mtbUserName.Text = "";
                mtbPassword.Text = "";
            }
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
