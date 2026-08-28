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
using System.Drawing.Drawing2D;
using clsBussinseLibrary;
using clsUserSessionLibrary;

namespace Project_Bank_C
{
    public partial class FrmManageUser : Form
    {


        int Permission;
        clsBUsers _BUsers = new clsBUsers();


        void isFullPermission()
        {
            if(rbYes.Checked)
            {
                panelPermission4.Enabled = false;
                Permission = -1;
            }
            else
            {
                panelPermission4.Enabled = true;
            }
        }

        void SaveToDB()
        {

            _BUsers.Name = tbFullName.Text;
            _BUsers.UserName = mtbUserName.Text;
            _BUsers.Password = mtbPassword.Text;
            _BUsers.Permission = Permission;
            _BUsers.Phone = mtbPhoneNumber.Text;
            _BUsers.Email = tbEmailAdd.Text;
            _BUsers.CountryID =(int) cbCountry.SelectedValue;
            _BUsers.CityID =(int)cbCity.SelectedValue;
            _BUsers.DateOfBirth = dtpDateOfBirth.Value;

            _BUsers.Save();
        }

        void ClearAddForm()
        {
            mtbUserName.Text = "";
            tbFullName.Text = "";
            mtbPassword.Text = "";
            rbNo.Checked = true;
            tbEmailAdd.Text = "";
            mtbPhoneNumber.Text = ";";
            cbCity.SelectedIndex = -1;
            cbCountry.SelectedIndex = 0;
            cbZeroOFPhone.SelectedIndex = 0;
            cbPinCode.SelectedIndex = 0;
            chkManageClient.Checked = false;
            chkManageUser.Checked = false;
            chkCurrencyExchange.Checked = false;
            chkLoginRegister.Checked = false;
            chkTransaction.Checked = false;
            Permission = 0;


             mtbUserName.Focus();
        }

        void ClearDeleteForm()
        {
            lbIDD.Text = "";
            lbUserNameD.Text = "";
            lbFullNameD.Text = "";
            lbPasswordD.Text = "";
            lbEmailD.Text = "";
            lbPhoneD.Text = "";
            lbCountryD.Text = "";
            lbCityD.Text = "";
            lbDateD.Text = "";
            lbPermissionD.Text = "";
            Permission = 0;
            tbUserD.Text = "";

            tbUserD.Focus();
        }

        void ClearUpdateForm()
        {
            mtbUserNameU.Text = "";
            tbFullNameU.Text = "";
            mtbPasswordU.Text = "";
            rbNoU.Checked = true;
            tbEmailU.Text = "";
            mtbPhoneU.Text = "";
            cbCityU.SelectedIndex = -1;
            cbCountryU.SelectedIndex = 0;
            cbZeroU.SelectedIndex = 0;
            cbPinCodeU.SelectedIndex = 0;
            chkManageClientU.Checked = false;
            chkManageUserU.Checked = false;
            chkCurrencyExchangeU.Checked = false;
            chkLoginRegisterU.Checked = false;
            chkTransaction.Checked = false;
            Permission = 0;

            ; mtbUserNameU.Focus();
        }

        void SelectedCity()
        {
            cbCity.DataSource = clsBCurrencies.RetreiveCities((int)cbCountry.SelectedValue);
            cbCity.DisplayMember = "Name";
            cbCity.ValueMember = "ID";

        }

        void SelectedCityU()
        {
            cbCityU.DataSource = clsBCurrencies.RetreiveCities(cbCountryU.SelectedIndex + 1);
            cbCityU.DisplayMember = "Name";
            cbCityU.ValueMember = "ID";

        }

        void SelectPinCodeOfPhoneNumber()
        {
            cbPinCode.SelectedIndex = cbCountry.SelectedIndex;
            cbZeroOFPhone.SelectedIndex=cbCountry.SelectedIndex;
            mtbPhoneNumber.Mask = "   (" + cbPinCode.Text + ")" + cbZeroOFPhone.Text;
        }
     
        void SelectPinCodeOfPhoneNumberU()
        {
            cbPinCodeU.SelectedIndex = cbCountryU.SelectedIndex;
            cbZeroU.SelectedIndex=cbCountryU.SelectedIndex;
            mtbPhoneU.Mask = "   (" +cbPinCodeU.Text + ")" +cbZeroU.Text ;
        }

        bool isNull()
        {
            if (mtbUserName.Text == ""||tbFullName.Text==""
                || tbEmailAdd.Text==""||mtbPassword.Text==""||mtbPhoneNumber.Text==""||cbCity.SelectedIndex==-1
                ||cbCountry.SelectedIndex==-1)
            {
                MessageBox.Show("Fill Form !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        bool isNullU()
        {
            if (mtbUserNameU.Text == "" || tbFullNameU.Text == ""
                || tbEmailU.Text == "" || mtbPasswordU.Text == "" || mtbPhoneU.Text == "" || cbCityU.SelectedIndex == -1
                || cbCountryU.SelectedIndex == -1)
            {
                MessageBox.Show("Fill Form !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        bool IsValidUserName()
        {
            foreach (DataRow row in clsBUsers.RetrieveDataOfUsers().Rows)
            {
            
                if (row["UserName"].ToString() == mtbUserName.Text)
                {

                    errorProvider1.SetError(mtbUserName, "this username already use ");
                    MessageBox.Show("Unvalid Username ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            errorProvider1.SetError(mtbUserName, "");

            return true;
        }

        bool IsValidUserNameU()
        {
            if (lbUserName.Text == mtbUserNameU.Text)
            {
                return true;
            }
            foreach (DataRow row in clsBUsers.RetrieveDataOfUsers().Rows)
            {
                if (row["UserName"].ToString() == mtbUserNameU.Text)
                {

                    errorProvider1.SetError(mtbUserNameU, "this username already use ");
                    MessageBox.Show("Unvalid Username ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            errorProvider1.SetError(mtbUserNameU, "");

            return true;
        }
        bool IsValidPassword()
        {
           foreach(DataRow row in clsBUsers.RetrieveDataOfUsers().Rows)
            { 
                if (row["Password"].ToString() == mtbPassword.Text)
                {

                    errorProvider1.SetError(mtbPassword, "this Password already use ");
                    MessageBox.Show("Unvalid Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            errorProvider1.SetError(mtbPassword, "");

            return true;
        }

        bool IsValidPasswordU()
        {

            if (lbPassword.Text == mtbPasswordU.Text)
            {
                return true;
            }

            foreach (DataRow row in clsBUsers.RetrieveDataOfUsers().Rows)
            {
                if (row["Password"].ToString() == mtbPasswordU.Text)
                {

                    errorProvider1.SetError(mtbPasswordU, "this Password already use ");
                    MessageBox.Show("Unvalid Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            errorProvider1.SetError(mtbPasswordU, "");

            return true;
        }

        bool FillUpdateCard()
        {
            foreach(DataRow row in clsBUsers.RetrieveDataOfUsers().Rows)
            {
                if (tbUsersU.Text == "Admin")
                {
                    MessageBox.Show("Updated Faild Admin can not be updated ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                if (row["UserName"].ToString()==tbUsersU.Text)
                {
                    lbID.Text = row["ID"].ToString();
                    lbUserName.Text = row["UserName"].ToString();
                    lbFullName.Text = row["Name"].ToString();
                    lbPermission.Text = row["Permission"].ToString();
                    lbEmail.Text = row["Email"].ToString();
                    lbPassword.Text = row["Password"].ToString();
                    lbPhoneU.Text = row["Phone"].ToString();
                    lbCountry.Text = row["CountryName"].ToString();
                    lbCity.Text = row["CityName"].ToString();
                    lbDateRegister.Text 
                        
                        = row["DateRegister"].ToString();
                    return true;
                }
             
            }
            return false;

        }

        void FillDeleteCard()
        {
            foreach (DataRow row in clsBUsers.RetrieveDataOfUsers().Rows)
            {
                if (row["UserName"].ToString() == tbUserD.Text)
                {
                    lbIDD.Text = row["ID"].ToString();
                    lbUserNameD.Text = row["UserName"].ToString();
                    lbFullNameD.Text = row["Name"].ToString();
                    lbPasswordD.Text = row["Password"].ToString();
                    lbPermissionD.Text = row["Permission"].ToString();
                    lbEmailD.Text = row["Email"].ToString();
                    lbPhoneD.Text = row["Phone"].ToString();
                    lbCountryD.Text = row["CountryName"].ToString();
                    lbCityD.Text = row["CityName"].ToString();
                    lbDateD.Text = row["DateRegister"].ToString();
                }
            }

        }

        void SearchUserForUpdateCard()
        {
           if(!FillUpdateCard())
                MessageBox.Show($"{tbUsersU.Text} Not Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool IsUpdateUser()
        {
            clsBUsers User = new clsBUsers(Convert.ToInt32(cbUsersU.SelectedValue), tbFullNameU.Text,
                tbEmailU.Text, mtbPhoneU.Text,Convert.ToInt32(cbCityU.SelectedValue) , mtbUserNameU.Text,
                mtbPasswordU.Text,Permission, cbCountryU.SelectedIndex + 1,Convert.ToDateTime(dtpDateU.Value));
           return !User.Save();
        }

        void SearchUserForUpdate()
        {

            if (tbUsersU.Text != "Admin")
            {
                if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes & IsUpdateUser())
                {
                    //code
                    MessageBox.Show("Updated Succesfully ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDateGridViewOfUser();
                }
                else
                {
                    MessageBox.Show("Updated Faild ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUsersU.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Updated Faild Admin can not be updated ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        void SearchUserForDelete(int ID)
        {
            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsBClients.DeleteClients(ID)) 
                {
                    MessageBox.Show("Deleted Succesfully ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDateGridViewOfUser();
                }

            }
            else
            {
                MessageBox.Show(" Faild ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserD.Text = "";
            }
        }

        bool SearchUserForShowDeleteCard()
        {

            if (tbUserD.Text == "Admin")
            {
                MessageBox.Show("Admin can not be delete ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnDelete.BackColor = Color.WhiteSmoke;
                btnDelete.Enabled = false;

                return false;
            }
            else
            {

                btnDelete.Enabled = true;
                btnDelete.BackColor = Color.FromArgb(255, 128, 128);
                FillDeleteCard();
                return true;
            }
                
          
        }
        public FrmManageUser()
        {
            InitializeComponent();
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.Blue;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.CornflowerBlue;
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Blue;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.CornflowerBlue;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.CornflowerBlue;

        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Red;

        }

       void FillDateGridViewOfUser()
        {
            DataTable dt = clsBUsers.RetrieveDataOfUsers();

            dgvUsers.DataSource = dt;
            dgvUsers.Columns["ID"].Width = 40;
            dgvUsers.Columns["Name"].Width = 200;
            dgvUsers.Columns["CountryName"].Width = 150;
            dgvUsers.Columns["Email"].Width = 220;
            dgvUsers.Columns["Phone"].Width = 120;
            dgvUsers.Columns["Password"].Width = 110;
            dgvUsers.Columns["Permission"].Width = 115;
            dgvUsers.Columns["UserName"].Width = 110;
            dgvUsers.Columns["DateOfBirth"].Width = 130;
            dgvUsers.Columns["DateRegister"].Width = 130;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font =new Font( "Akhbar MT",12,FontStyle.Bold);
            dgvUsers.DefaultCellStyle.Font =new Font( "Akhbar MT",10,FontStyle.Regular);
            cbUsersD.DataSource = dt;
            cbUsersD.DisplayMember = "UserName";
            cbUsersD.ValueMember = "ID";
            cbUsersU.DataSource = dt;
            cbUsersU.DisplayMember = "UserName";
            cbUsersU.ValueMember = "ID";

            tbUsersU.Text = "Admin";
            tbUserD.Text = "Admin";

            dt = clsBCurrencies.RetrieveDataOfCountry();


            cbZeroOFPhone.DataSource = dt.Copy();
            cbZeroOFPhone.DisplayMember = "PhoneFormat";
            cbZeroOFPhone.ValueMember = "CountryID";

            cbPinCode.DataSource = dt.Copy();
            cbPinCode.DisplayMember = "PinCode";
            cbPinCode.ValueMember = "CountryID";

            cbCountry.DataSource = dt.Copy();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";

            cbZeroU.DataSource = dt.Copy();
            cbZeroU.DisplayMember = "PhoneFormat";
            cbZeroU.ValueMember = "CountryID";

            cbPinCodeU.DataSource = dt.Copy();
            cbPinCodeU.DisplayMember = "PinCode";
            cbPinCodeU.ValueMember = "CountryID";

            cbCountryU.DataSource = dt.Copy();
            cbCountryU.DisplayMember = "CountryName";
            cbCountryU.ValueMember = "CountryID";

            cbCountry.SelectedIndex = 1;
            cbCountryU.SelectedIndex = 1;//for ignore default value  zero

            cbCountry.SelectedIndex = 0;
            cbCountryU.SelectedIndex = 0;
        }
        private void FrmManageUser_Load(object sender, EventArgs e)
        {
            FillDateGridViewOfUser();
           
            // panelSearch.BackColor = Color.FromArgb(26, 35, 58);
            lbUserFullAdd.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullShow.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullU.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullD.Text = UserSession.UserName + " : " + UserSession.FullName;
            this.BackColor = Color.FromArgb(26, 35, 58);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddEllipse(0, 0, pictureBox3.Width-1, pictureBox3.Height - 1);
            pictureBox3.Region = new Region(gp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchUserForUpdateCard();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SearchUserForShowDeleteCard();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbUsersU_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbUsersU.Text = cbUsersU.Text;
        }

        private void cbUsersD_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbUserD.Text = cbUsersD.Text;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchUserForDelete(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value));
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            cbUsersU.SelectedValue =((int) dgvUsers.CurrentRow.Cells[0].Value);
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            SearchUserForShowDeleteCard();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUserForUpdateCard();
        }

        private void cbUsersD_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tbUserD.Text = cbUsersD.Text;
        }

        private void cbUsersU_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tbUsersU.Text = cbUsersU.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isNull())
                return;



            if (!IsValidUserName())
                return;

            if (!IsValidPassword()) 
                return;

            SaveToDB();
            FillDateGridViewOfUser();

            ClearAddForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            if (isNullU())
                return;

            if (!IsValidUserNameU())
                return;

            if (!IsValidPasswordU())
                return;

            SearchUserForUpdate();
            ClearUpdateForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SearchUserForShowDeleteCard())
            {
                SearchUserForDelete(Convert.ToInt32(cbUsersD.SelectedValue));

            }
            ClearDeleteForm();
        }

        private void cbCity_DropDown(object sender, EventArgs e)
        {

            if (cbCountry.SelectedIndex != -1)
            {
                SelectedCity();
            }
        }

        private void cbCityU_DropDown(object sender, EventArgs e)
        {
            SelectedCityU();

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPinCodeOfPhoneNumber();
        }

        private void cbCountryU_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPinCodeOfPhoneNumberU();

        }

        private void tbSearchUser_TextChanged(object sender, EventArgs e)
        {
            dgvUsers.DataSource = clsBUsers.SearchUserByName(tbSearchUser.Text);

        }

        private void chkManageClientU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageClientU.Checked)
            {
                Permission += 1;
            }
            else
            {
                Permission -= 1;
            }
        }

        private void chkTransactionU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransaction.Checked)
                Permission += 4;
            else
            {
                Permission -= 4;
            }
        }

        private void chkCurrencyExchangeU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurrencyExchangeU.Checked)
            {
                Permission += 16;
            }
            else
            {
                Permission -= 16;
            }
        }

        private void chkLoginRegisterU_CheckedChanged(object sender, EventArgs e)
        {

            if (chkLoginRegisterU.Checked)
            {
                Permission += 8;
            }
            else
            {
                Permission -= 8;
            }
        }

        private void chkManageUserU_CheckedChanged(object sender, EventArgs e)
        {

            if (chkManageUserU.Checked)
            {
                Permission += 2;
            }
            else
            {
                Permission -= 2;
            }
        }

        private void rbYesU_CheckedChanged(object sender, EventArgs e)
        {
            panelPermission4U.Enabled = false;
            chkManageClientU.Checked = false;
            chkManageUserU.Checked = false;
            chkCurrencyExchangeU.Checked = false;
            chkLoginRegisterU.Checked = false;
        }

        private void rbNoU_CheckedChanged(object sender, EventArgs e)
        {
            panelPermission4U.Enabled = true;
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            isFullPermission();

        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            isFullPermission();

        }

        private void chkManageClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageClient.Checked)
                Permission += 1;

            else
            {
                Permission -= 1;

            }
        }

        private void chkManageUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageUser.Checked)
                Permission += 2;
            else
            {
                Permission -= 2;

            }
        }

        private void chkLoginRegister_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLoginRegister.Checked)
                Permission += 8;
            else
            {
                Permission -= 8;

            }
        }

        private void chkCurrencyExchange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurrencyExchange.Checked)
                Permission += 16;
            else
            {
                Permission -= 16;
            }
        }

        private void chkTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransaction.Checked)
                Permission += 4;
            else
            {
                Permission -= 4;
            }
        }
    }
}
