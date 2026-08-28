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
using System.Threading;
using clsBussinseLibrary;
using clsUserSessionLibrary;
using System.Globalization;

namespace Project_Bank_C
{
    public partial class FrmTransaction : Form
    {

        public FrmTransaction()
        {
            InitializeComponent();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btnWithdraw.BackColor = Color.Blue;
        }

        private void btnWithdraw_MouseLeave(object sender, EventArgs e)
        {
            btnWithdraw.BackColor = Color.CornflowerBlue;
        }

        private void btnDeposite_MouseEnter(object sender, EventArgs e)
        {
            btnDeposite.BackColor = Color.Blue;
        }

        private void btnDeposite_MouseLeave(object sender, EventArgs e)
        {
            btnDeposite.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnTransferT.BackColor = Color.Blue;
        }

        private void btnSubmitT_MouseLeave(object sender, EventArgs e)
        {
            btnTransferT.BackColor = Color.CornflowerBlue;
        }

        void ColorOfForm()
        {
            this.BackColor = Color.FromArgb(25, 36, 58);
            pnlAccountNumberW.BackColor = Color.FromArgb(25, 36, 58);
            pnlAccountNumberD.BackColor = Color.FromArgb(25, 36, 58);
            pnlAmountW.BackColor = Color.FromArgb(25, 36, 58);
            pnlAmountD.BackColor = Color.FromArgb(25, 36, 58);
            pnlTransfer.BackColor = Color.FromArgb(25, 36, 58);
            pnlTitleBank.BackColor = Color.FromArgb(25, 36, 58);
            pnlOfTotalaBalance.BackColor = Color.FromArgb(25, 36, 58);
            lblIVEUTILZATION.ForeColor = Color.FromArgb(25, 36, 58);
            progressBarBalance.ForeColor = Color.FromArgb(25, 36, 58);
        }

        void ActiveUser()
        {
            lbaUserFullW.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullLog.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullTotal.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullTransfer.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullD.Text = UserSession.UserName + " : " + UserSession.FullName;
        }

        void FillDgvOfTotalBalance()
        {
            dgvTransferLog.DataSource = clsBTransaction.RetrievDataOfTransferLog();
            dgvTransferLog.Columns["ID"].Width = 40;
            dgvTransferLog.Columns["TransactionDate"].Width = 190;

            dgvTotalbalance.DataSource = clsBTransaction.RetrievDataOfTotalBalance();
            //dgvTotalbalance.Columns["ID"].Width = 40;
            dgvTotalbalance.Columns["Name"].Width = 310;
            dgvTotalbalance.Columns["Ac_Num"].Width = 110;
            dgvTotalbalance.Columns["Balance"].Width = 120;

        }
        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            ColorOfForm();
            FillDgvOfTotalBalance();
       
     
         


            ActiveUser();


      

            VaultMBank();
        }

        void ClearWithdraw()
        {
            mtbAccountNumberW.Text = "";
            mtbAmountW.Text = "";
        }

        bool IsWithdrawNull()
        {
            if (mtbAccountNumberW.Text == "" || mtbAmountW.Text == "")
            {
                MessageBox.Show("Fill Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (IsWithdrawNull())
                return;



            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                mtbAmountW.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (decimal.TryParse(mtbAmountW.Text, out decimal value))
                {
                        clsBTransaction.WithDraw(mtbAccountNumberW.Text, value);
                       

                    switch (UserSession.Mode)
                    {
                        case UserSession.enMode.DoneMode:
                            MessageBox.Show("Done Successfully ? ", "Deposite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillDgvOfTotalBalance();
                            VaultMBank();
                            break;
                        case UserSession.enMode.InsuffisientMode:
                            MessageBox.Show(" Insuffecient Balance ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case UserSession.enMode.NotFoundMode:
                            MessageBox.Show(UserSession.Message + " Not Found ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }


                }
                ClearWithdraw();

            }






        }

        bool IsDepositeNull()
        {
            if (mtbAccountNumberD.Text == "" || mtbAmountD.Text == "")
            {
                MessageBox.Show("Fill Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        void ClearDepositeForm()
        {
            mtbAccountNumberD.Text = "";
            mtbAmountD.Text = "";
        }

        private void btnDeposite_Click(object sender, EventArgs e)
        {
            if (IsDepositeNull())
                return;

            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                mtbAmountD.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (decimal.TryParse(mtbAmountD.Text, out decimal value))
                {
                    clsBTransaction.Deposite(mtbAccountNumberD.Text, value);
                   switch(UserSession.Mode) 
                    {
                        case UserSession.enMode.DoneMode:
                        MessageBox.Show("Done Successfully ? ", "Deposite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDgvOfTotalBalance();
                        VaultMBank();
                            break;
                        case UserSession.enMode.InsuffisientMode:
                            MessageBox.Show(" Insuffecient Balance ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case UserSession.enMode.NotFoundMode:
                            MessageBox.Show(UserSession.Message+" Not Found ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                  
                }


            }
            else
            {
                MessageBox.Show(" Faild ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ClearDepositeForm();


        }

        bool IsTransferFormNull()
        {
            if (mtbSender.Text == "" || mtbAmountT.Text == "" || mtbGeter.Text == "")
            {
                MessageBox.Show("Fill Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        decimal GetAmountOfTransfer()
        {
            mtbAmountT.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            decimal.TryParse(mtbAmountT.Text, out decimal Amount);
            return Amount;
        }

        void ClearTransferForm()
        {
            mtbSender.Text = "";
            mtbAmountT.Text = "";
            mtbGeter.Text = "";
        }

        private void btnSubmitT_Click(object sender, EventArgs e)
        {
            if (IsTransferFormNull())
                return;

            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsBTransaction.Transfer(mtbSender.Text, mtbGeter.Text, GetAmountOfTransfer()))
                {
                    ClearTransferForm();
                    FillDgvOfTotalBalance();
                    MessageBox.Show("Done Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    switch (UserSession.Mode)
                    {
                        case UserSession.enMode.InsuffisientMode:
                            MessageBox.Show(" Insuffecient Balance ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case UserSession.enMode.NotFoundMode:
                            MessageBox.Show(mtbSender.Text + " Not Found ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                       
                    }
                    switch (UserSession.ETransfer)
                    {
                        case UserSession.enTransfer.InsuffisientMode:
                            MessageBox.Show(" Insuffecient VaultCash ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case UserSession.enTransfer.NotFoundReceiverMode:
                            MessageBox.Show(mtbGeter.Text + " Not Found ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                      

                    }
                }
            }
            ClearTransferForm();
        }

        void VaultMBank()
        {
           decimal CurrentBalance=Convert.ToDecimal(clsBTransaction.VaultMBank().Rows[0]["CurrentBalance"]);
            
            lbTotalBalance.Text = Convert.ToString("R.Y" + clsBTransaction.VaultMBank().Rows[0]["MaxCapacity"]);
            lbMaxCapacity.Text = "Capacity : R.Y" + Convert.ToString(clsBTransaction.VaultMBank().Rows[0]["MaxCapacity"]);
            lbAvaliableSpace.Text = (5000000 - CurrentBalance).ToString();

            if (progressBarBalance.Value < progressBarBalance.Maximum)
            {
                progressBarBalance.Value = Convert.ToInt32(CurrentBalance);




              //  progressBarBalance.Value += (Convert.ToInt32(CurrentBalance));
                decimal Value = (((decimal)progressBarBalance.Value / progressBarBalance.Maximum) * 100);
                lbPercent.Text = ((int)Value).ToString() + "%";
                lbPercent.Refresh();

            }

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

    }


}
