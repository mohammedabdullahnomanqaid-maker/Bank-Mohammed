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
    public partial class FrmAddCurrency : Form
    {
        string FlagPath;
        public FrmAddCurrency()
        {
            InitializeComponent();
        }

        private void FrmAddCurrency_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(26, 35, 58);
            btnSubmit.BackColor = Color.FromArgb(26, 35, 58);
        }

        void AddCurrency()
        {
            clsBCurrencies _BCurrency = new clsBCurrencies();
            _BCurrency.CountryName = mtbCountry.Text;
            _BCurrency.CurrencyName = mtbCurrencyName.Text;
            _BCurrency.PhoneCode = mtbPhoneCode.Text;
            _BCurrency.ImagePath = FlagPath;
            _BCurrency.Code = mtbCode.Text;
            _BCurrency.Capital = mtbCapital.Text;
            _BCurrency.PhoneFormat = mtbPhoneFormat.Text;
            _BCurrency.SellRate =Convert.ToDouble(mtbSellRate.Text);
            _BCurrency.BuyRate = Convert.ToDouble(mtbBuyRate.Text);
            _BCurrency.Save();
        }

        bool IsNull()
        {

            if (mtbCountry.Text == "" || mtbCode.Text == "" || mtbBuyRate.Text == ""||mtbCapital.Text==""
                || mtbSellRate.Text == "" ||mtbPhoneCode.Text==""|| mtbCurrencyName.Text == ""||mtbPhoneFormat.Text=="")
                return true;
            return false;
        }

        void ClearAddFormOfCurrencies()
        {
            mtbCountry.Text = "";
            mtbCode.Text = "";
            mtbBuyRate.Text = "";
            mtbCapital.Text = "";
             mtbSellRate.Text = "";
            mtbPhoneCode.Text = "";
            mtbCurrencyName.Text = "";
            mtbPhoneFormat.Text = "";
               
        }

        private void btnAddFlag_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Title = "Add Flag";
            openFileDialog1.Filter = "PNG|*png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picAddFlag.Image = Image.FromFile(openFileDialog1.FileName);
                 FlagPath = openFileDialog1.FileName;
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsNull())
            {
                MessageBox.Show("Fill Form", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
             
                    AddCurrency();
                ClearAddFormOfCurrencies();
                frmCurrencyExchange frm = (frmCurrencyExchange)Application.OpenForms["frmCurrencyExchange"];
                frm.FillDGVOfCurrencies();
                //to make load for form


                MessageBox.Show("Done Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
