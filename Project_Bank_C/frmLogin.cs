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
using clsUserSessionLibrary;

namespace Project_Bank_C
{
    public partial class frmLoginRegister : Form
    {

     
        public frmLoginRegister()
        {
            InitializeComponent();
        }
        void FillDgvOfLoginRegister()
        {
            dgvLoginRegsiter.DataSource = clsBLoginRegister.RetrievDataOfLoginRegister();
            dgvLoginRegsiter.Columns["LoginID"].Width = 140;
            dgvLoginRegsiter.Columns["Password"].Width = 140;
            dgvLoginRegsiter.Columns["Permission"].Width = 140;
            dgvLoginRegsiter.Columns["UserName"].Width = 140;
            dgvLoginRegsiter.Columns["DateTimeOfRegister"].Width = 530;
        }
        private void frmLoginRegister_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(25, 36, 58);
            FillDgvOfLoginRegister();
            UploadLoginRegister();
            lbUserFullTotal.Text = UserSession.UserName + " : " + UserSession.FullName;
        }

        void UploadLoginRegister()
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
