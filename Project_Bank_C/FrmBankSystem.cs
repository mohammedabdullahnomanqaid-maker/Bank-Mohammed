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
using System.Data;
using clsBussinseLibrary;
using clsUserSessionLibrary;

namespace Project_Bank_C
{
    public partial class FrmBankSystem : Form
    {

        clsBClients _BClients = new clsBClients();
     
        void FillForDelete()
        {
            foreach(DataRow row in clsBClients.RetrievDataOfClients().Rows)
            {
                if (mtbClient.Text== row["Ac_Num"].ToString())
                {
                    lbID.Text = row["ID"].ToString();
                    lbName.Text = row["Name"].ToString();
                    lbAccountNumber.Text = row["Ac_Num"].ToString();
                    lbPhone.Text = row["Phone"].ToString();
                    lbEmail.Text = row["Email"].ToString();
                    lbAge.Text = row["DateOfBirth"].ToString();
                    lbCountry.Text = row["CountryName"].ToString();
                    lbGender.Text = row["Gender"].ToString(); 
                    lbBalanceD.Text = row["Balance"].ToString();
                    lbDateRegister.Text = row["DateRegister"].ToString();
                    return;
                }
            }

            MessageBox.Show(mtbClientU.Text + " Not found", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        void FillForUpdate()
        {
            foreach (DataRow row in clsBClients.RetrievDataOfClients().Rows)
            {
                if (mtbClientU.Text == row["Ac_Num"].ToString())
                {
                    lbIDU.Text = row["ID"].ToString();
                    lbNameU.Text = row["Name"].ToString();
                    lbAccountNumberU.Text = row["Ac_Num"].ToString();
                    lbPhoneU.Text = row["Phone"].ToString();
                    lbEmailU.Text = row["Email"].ToString();
                    lbAgeU.Text = row["DateOfBirth"].ToString();
                    lbCountryU.Text = row["CountryName"].ToString();
                    lbGenderU.Text = row["Gender"].ToString();
                    lbBalanceU.Text = row["Balance"].ToString();
                    lbDateRegisterU.Text = row["DateRegister"].ToString();
                    return;
                }
            }
            MessageBox.Show(mtbClientU.Text + " Not found","Faild",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        void BoxClear()
        {
            mtbClient.Clear();
            tbNameU.Text = "";
            mtbAccountNumberU.Text = "";
            mtbPhoneU.Text = "";
            tbEmailU.Text = "";
            cbMonthU.SelectedIndex = -1;
            cbMonthU.SelectedIndex = -1;
            cbGenderU.SelectedIndex = -1;
            cbAccountNumberU.SelectedIndex = -1;
            cbZeroU.SelectedIndex = 0;
            cbPinCodeU.SelectedIndex = 0;
            cbCountryU.SelectedIndex = 0;

            mtbClientU.Text = "";
            mtbDayU.Text = "";
            mtbYearU.Text = "";
            mtbBalance.Text = "";
        }

        void SaveToDB()
        {

            //line = counter.ToString();

            int day,year,month;
            day = Convert.ToInt32(mtbDay.Text);
             month= Convert.ToInt32(cbMonth.SelectedIndex);
            year= Convert.ToInt32(mtbYear.Text);

            int index = 0;

            index =Convert.ToInt32(cbCountry.SelectedIndex.ToString())+1;

            if (cbGender.SelectedItem.ToString() == "Male")
                _BClients.Gender = 'M';
            else
                _BClients.Gender = 'F';


            _BClients.Name = tbName.Text;
            _BClients.Ac_Num = mtbAccountNumber.Text;
            _BClients.CountryID = index;
            _BClients.Phone = mtbPhoneNumber.Text;
            _BClients.Email = tbEmail.Text;
            _BClients.DateOfBirth =new DateTime(year,month,day);
            mtbAccountBalance.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (decimal.TryParse(mtbAccountBalance.Text, out decimal value))
            {
                _BClients.Balance = 0;
            }
            _BClients.Save();

            if (decimal.TryParse(mtbAccountBalance.Text, out value))
            {
                clsBTransaction.Deposite(mtbAccountNumber.Text, value);
            }


        }

        bool SaveUpdateClientU()
        {



            int Day = Convert.ToInt32(mtbDayU.Text);
            int year = Convert.ToInt32(mtbYearU.Text);
            int month = Convert.ToInt32(cbMonthU.SelectedIndex.ToString());

            DateTime BirtDay = new DateTime(year, month + 1, Day);
            DateTime Today = DateTime.Today;
            char Gender;
            if (cbGenderU.SelectedItem.ToString() == "Male")
            {
                Gender = 'M';
            }
            else
            {
                Gender = 'F';
            }
            clsBClients BClients = new clsBClients(Convert.ToInt32(cbAccountNumberU.SelectedValue), tbNameU.Text,cbCountryU.SelectedIndex+1, tbEmailU.Text, mtbPhoneU.Text, new DateTime(year, month, Day), mtbAccountNumberU.Text,Gender,Convert.ToDecimal(lbBalanceU.Text));

            return (BClients.Save()==false);

        }

        public FrmBankSystem()
        {
            InitializeComponent();

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPinCode.SelectedIndex = cbCountry.SelectedIndex;
            cbZero.SelectedIndex= cbCountry.SelectedIndex;


            mtbPhoneNumber.Mask = "("+ cbPinCode.Text + ")"+ cbZero.Text;

        }

        void ResetForm()
        {
            tbName.Clear();
            mtbAccountNumber.Clear();

            cbZero.SelectedIndex = 0;
            cbPinCode.SelectedIndex = 0;
            cbCountry.SelectedIndex = 0;

            mtbPhoneNumber.Clear();
            tbEmail.Clear();
            mtbDay.Clear();
            cbMonth.SelectedIndex = -1;
            mtbYear.Clear();
            cbGender.SelectedIndex = -1;
            mtbAccountBalance.Clear();
            tbName.Focus();

        }

        bool isValidAccountNumber()
        {
            foreach (DataRow row in clsBClients.RetrievDataOfClients().Rows)
            {

                    if (mtbAccountNumber.Text == row["Ac_Num"].ToString())
                    {
                        mtbAccountNumber.Focus();
                        MessageBox.Show("Unvaild AccountNumber ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        errorProvider1.SetError(mtbAccountNumber, "this accountNumber already used ! ");
                        return true;
                    }
                    else
                    {
                        errorProvider1.SetError(mtbAccountNumber, "");
                        tbName.Focus();
                    }

                
            }
            return false;

        }

        bool isValidAccountNumberForUpdate()
        {

            foreach (DataRow row in clsBClients.RetrievDataOfClients().Rows)
            {

                if(lbAccountNumberU.Text==row["Ac_Num"].ToString())
                {
                    errorProvider1.SetError(mtbAccountNumberU, "");
                    tbNameU.Focus();
                    return false;
                }

                if (mtbAccountNumberU.Text == row["Ac_Num"].ToString())
                {
                    mtbAccountNumberU.Focus();
                    errorProvider1.SetError(mtbAccountNumberU, "this accountNumber already used ! ");
                    return true;
                }
                else
                {
                    errorProvider1.SetError(mtbAccountNumberU, "");
                    tbNameU.Focus();
                }

            }
            return false;

        }

        bool IsFullAllTextBox()
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(mtbAccountNumber.Text) ||
                string.IsNullOrWhiteSpace(mtbDay.Text) || string.IsNullOrWhiteSpace(mtbYear.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) || string.IsNullOrWhiteSpace(mtbPhoneNumber.Text) ||
                (cbGender.SelectedIndex == -1) || cbMonth.SelectedIndex == -1)
            {
                return true;
            }
            return false;


        }

        bool IsFullAllTextBoxForUpdate()
        {
            if (string.IsNullOrWhiteSpace(tbNameU.Text)||
                string.IsNullOrWhiteSpace(mtbDayU.Text) || string.IsNullOrWhiteSpace(mtbYearU.Text) ||
                string.IsNullOrWhiteSpace(tbEmailU.Text) || string.IsNullOrWhiteSpace(mtbPhoneU.Text) ||
                 (cbGenderU.SelectedIndex == -1) || cbMonthU.SelectedIndex == -1)
            {
                return true;
            }
            return false;


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (IsFullAllTextBox())
            {
                MessageBox.Show("Fill all box ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }



            if (isValidAccountNumber())
            {
                return;
            }

            SaveToDB();
            FillDataGridView();
           
            ResetForm();

        }

        void isAdmin()
        {
            if (UserSession.UserName != "Admin")
            {
                mtbAccountBalance.Text = "0";

                mtbAccountBalance.Enabled = false;
            }
            else
            {

            }
        }

        void FillDataGridView()
        {
            DataTable dt= clsBClients.RetrievDataOfClients();
            dgvClients.DataSource = dt;
            dgvClients.Columns["ID"].Width = 40;
            dgvClients.Columns["Name"].Width = 200;
            dgvClients.Columns["CountryName"].Width = 150;
            dgvClients.Columns["Email"].Width = 220;
            dgvClients.Columns["Phone"].Width = 190;
            dgvClients.Columns["DateOfBirth"].Width = 130;
            dgvClients.Columns["DateRegister"].Width = 170;
            dgvClients.ColumnHeadersDefaultCellStyle.Font = new Font("Akhbar MT", 12, FontStyle.Bold);
            dgvClients.DefaultCellStyle.Font = new Font("Akhbar MT", 10, FontStyle.Regular);

            cbClient.DataSource = dt;
            cbClient.DisplayMember = "Ac_Num";
            cbClient.ValueMember = "ID";

            cbAccountNumberU.DataSource = dt;
            cbAccountNumberU.DisplayMember = "Ac_Num";
            cbAccountNumberU.ValueMember = "ID";

            dt= clsBCurrencies.RetrieveDataOfCountry();

            cbZero.DataSource = dt.Copy();
            cbZero.DisplayMember = "PhoneFormat";
            cbZero.ValueMember = "CountryID";

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
                                        //when fill cobobox by datasource the copiler by default select the first item
           cbCountryU.SelectedIndex = 1;// so I intialize the index=0 the compiler think it is a default value
            cbCountry.SelectedIndex = 1; // not selected so it does not go to event selectedIndexChange but 
                                        // when I intialize it index=1 the copiler go to event because one it is not a 
            cbCountryU.SelectedIndex = 0;//default value and when after intialize it by one i can intialize it by 0 
            cbCountry.SelectedIndex = 0;// because we changed the default value before

        }
        private void FrmBankSystem_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(26, 35, 58);
            isAdmin();
            FillDataGridView();

            lbUserFullAdd.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullShow.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullU.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullD.Text = UserSession.UserName + " : " + UserSession.FullName;
    
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.CornflowerBlue;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Red;
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            btnShow.BackColor = Color.Blue;
        }

        private void btnShow_MouseLeave(object sender, EventArgs e)
        {
            btnShow.BackColor = Color.CornflowerBlue;
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.Blue;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseEnter_2(object sender, EventArgs e)
        {
            btnUpadate.BackColor = Color.Blue;
        }

        private void btnUpadate_MouseLeave(object sender, EventArgs e)
        {
            btnUpadate.BackColor = Color.CornflowerBlue;
        }

        private void btnShowU_MouseEnter(object sender, EventArgs e)
        {
            btnShowU.BackColor = Color.Blue;

        }

        private void btnShowU_MouseLeave(object sender, EventArgs e)
        {
            btnShowU.BackColor = Color.CornflowerBlue;

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            FillForDelete();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure !", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int Index = Convert.ToInt32(cbClient.SelectedValue);
                
                clsBClients.DeleteClients(Index);
                FillDataGridView();
                MessageBox.Show("Done Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnShowU_Click(object sender, EventArgs e)
        {
            
            FillForUpdate();
        }

        private void btnUpadate_Click(object sender, EventArgs e)
        {

            if (IsFullAllTextBoxForUpdate())
            {
                MessageBox.Show("Fill all box ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (isValidAccountNumberForUpdate())
            {
                return;
            }

            if (MessageBox.Show("Are you sure !", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes& SaveUpdateClientU())
            {
                MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataGridView();
            }
            else
            {
                MessageBox.Show("Updated Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            ResetForm();
            BoxClear();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCountryU_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbZeroU.SelectedIndex = cbCountryU.SelectedIndex;
            cbPinCodeU.SelectedIndex = cbCountryU.SelectedIndex;
            mtbPhoneU.Mask = "(" + cbPinCodeU.Text + ")" + cbZeroU.Text;

        }

        private void cbAccountNumberU_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtbClientU.Text = cbAccountNumberU.Text;
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtbClient.Text = cbClient.Text;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _BClients.Status = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _BClients.Status = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure !", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsBClients.DeleteClients((int)dgvClients.CurrentRow.Cells[0].Value);
                FillDataGridView();
                MessageBox.Show("Done Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dgvClients.DataSource = clsBClients.SearchClientByName(tbSearch.Text);
        }
    }
}
