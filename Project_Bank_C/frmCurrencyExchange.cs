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
    public partial class frmCurrencyExchange : Form
    {
        int ImageCounter;
        DataTable dt = new DataTable();
        public frmCurrencyExchange()
        {
            InitializeComponent();
        }

        void SearchForUpdate()
        {
            foreach(DataRow row in clsBCurrencies.RetrievDataOfCurrencies().Rows)
            {
                string Code = row["Code"].ToString();
                if (Code == cbBaseCurrency.Text)
                {
                    
                    clsBCurrencies _BCurrencies = new clsBCurrencies(Convert.ToInt32(cbBaseCurrency.SelectedValue), Convert.ToDouble(nudNewSellRate.Value), Convert.ToDouble(nudNewBuyRate.Value));

                    _BCurrencies.Save();
                }
          
            }
            
        }

        bool IspnlUpdateNull()
        {
            if (nudNewSellRate.Value == 0 || nudNewBuyRate.Value == 0||cbBaseCurrency.SelectedIndex==-1)
                return true;
            return false;
        }

        bool IsPnlCalculateNull()
        {
            if (nudAmount.Value == 0 || cbFrom.SelectedIndex == -1 || cbTo.SelectedIndex == -1)
                return true;
            return false;
        }

        public void FillDGVOfCurrencies()
        {
           dt = clsBCurrencies.RetrievDataOfCurrencies();
            dt.Columns.Add("Flag", typeof(System.Drawing.Image));
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    //string Path = row["ImagePath"].ToString();
                    //if (System.IO.File.Exists(Path))
                    //{
                    //    row["Flag"] = System.Drawing.Image.FromFile(Path);

                    //}
                    //else
                    //{
                    //    row["Flag"] = null;
                    //}



                    //this way it is to combin the path from DB and local pc and check if there is an error like /  .
                    //AppContext.BaseDirectory this bring path from local pc and combin it with relativePath that is brought from DB.
                    string relativePath = row["ImagePath"].ToString();

                    string fullPath = System.IO.Path.Combine(AppContext.BaseDirectory,relativePath);

                    if (System.IO.File.Exists(fullPath))
                    {
                        row["Flag"] = System.Drawing.Image.FromFile(fullPath);
                    }
                    else
                    {
                        row["Flag"] = null;
                    }

                }
                catch
                {
                    row["Flag"] = null;
                }
            }

            dgvCurrencies.DataSource = null;
            dgvCurrencies.DataSource = dt;

            dgvCurrencies.Columns["ImagePath"].Visible = false;
            if (dgvCurrencies.Columns["Flag"] is DataGridViewImageColumn imageCol)
            {
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
              //  dgvCurrencies.RowTemplate.Height = 100;
                dgvCurrencies.Columns["Flag"].Width = 40;
            }
            if (dgvCurrencies.Columns["Flag"] != null)
            {
                dgvCurrencies.Columns["Flag"].DisplayIndex = 1;
            }
            dgvCurrencies.Columns["ID"].Width = 40;
              cbBaseCurrency.DataSource = dt.Copy();
            cbBaseCurrency.DisplayMember = "Code";
            cbBaseCurrency.ValueMember = "ID";

            cbFrom.DataSource = dt.Copy();
            cbFrom.DisplayMember = "Code";
            cbFrom.ValueMember = "ID";

            cbTo.DataSource = dt.Copy();
            cbTo.DisplayMember = "Code";
            cbTo.ValueMember = "ID";
        }
        private void frmCurrencyExchange_Load(object sender, EventArgs e)
        {
            FillDGVOfCurrencies();


            this.BackColor = Color.FromArgb(25, 36, 58);
            btnAddCurrency.BackColor = Color.FromArgb(25, 36, 58);
            btnCalculate.BackColor = Color.FromArgb(25, 36, 58);
            btnSaveUpdate.BackColor = Color.FromArgb(25, 36, 58);
            lbCurrencyCalculator.ForeColor = Color.FromArgb(25, 36, 58);
            lbCurrencyExchange.ForeColor = Color.FromArgb(25, 36, 58);
            lbUpdateCurrencyRate.ForeColor = Color.FromArgb(25, 36, 58);
           

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(128, 255, 128);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
           if(IspnlUpdateNull())
            {
                MessageBox.Show("Fill Form for update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SearchForUpdate();
                FillDGVOfCurrencies();
                MessageBox.Show("Done Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Clear()
        {
            mtbSearch.Clear();
            nudAmount.Value = 0;
            nudNewBuyRate.Value = 0;
            nudNewSellRate.Value = 0;
            tbResualt.Clear();
            cbBaseCurrency.SelectedIndex = -1;
            cbFrom.SelectedIndex = -1;
            cbTo.SelectedIndex = -1;
        }

        decimal GetResaultOfAmount(string SellRate,string BuyRate)
        {
            if (cbTo.Text == cbFrom.Text)
                return nudAmount.Value;

            if ("USD" == cbTo.Text)
            {
                decimal.TryParse(BuyRate, out decimal Value);
                return (nudAmount.Value / Value);

            }
            if ("USD" == cbFrom.Text)
            {

                decimal.TryParse(SellRate, out decimal Value);
                return (nudAmount.Value*Value);
                
            }
            decimal.TryParse(BuyRate, out decimal ValueBuy);
            decimal usd = nudAmount.Value /ValueBuy;
            decimal.TryParse(SellRate, out decimal ValueSell);
            return usd *ValueSell;
        }

        void Calculate()
        {
        
            string valueofSell = "";
            string valueofBuy = "";



            foreach (DataRow row in clsBCurrencies.RetrievDataOfCurrencies().Rows)
            {
                string From = row["Code"].ToString();
                if (From == cbFrom.Text)
                    valueofBuy = row["BuyRate"].ToString();

                string To = row["Code"].ToString();
                if (To == cbTo.Text)
                    valueofSell = row["SellRate"].ToString();

            }
            tbResualt.Text = Math.Round(GetResaultOfAmount(valueofSell,valueofBuy),2).ToString();


        }

        private void btnSaveUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnSaveUpdate.BackColor = Color.CornflowerBlue;
        }

        private void btnSaveUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnSaveUpdate.BackColor = Color.FromArgb(25,36,58);

        }

        private void btnCalculate_MouseEnter(object sender, EventArgs e)
        {
            btnCalculate.BackColor = Color.CornflowerBlue;

        }

        private void btnCalculate_MouseLeave(object sender, EventArgs e)
        {
            btnCalculate.BackColor = Color.FromArgb(25, 36, 58);

        }

        private void btnAddCurrency_MouseEnter(object sender, EventArgs e)
        {
            btnAddCurrency.BackColor = Color.CornflowerBlue;

        }

        private void btnAddCurrency_MouseLeave(object sender, EventArgs e)
        {
            btnAddCurrency.BackColor = Color.FromArgb(25, 36, 58);

        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.Black;

        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.Gainsboro;
            btnClear.ForeColor = Color.White;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsPnlCalculateNull())
            {
                MessageBox.Show("Fill Form", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
                Calculate();
           
        }

        bool CheckPermission()
        {

            if (Convert.ToInt32(UserSession.Permission) == -1)
                return true;

            MessageBox.Show("Access Denied : Contact to admain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return false;
        }

        private void btnAddCurrency_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Name = "btn1";
            btn.Size = new Size(12, 13);
            
            panel1.Controls.Add(btn);

            if (!CheckPermission())
                return;

            Form frm = new FrmAddCurrency();
            frm.ShowDialog();
        }

        public void AddFlagToListView(Image FlagImage)
        {
            MessageBox.Show("Count : " + imageListFlag.Images.Count.ToString());
            if(FlagImage!=null)
            imageListFlag.Images.Add(FlagImage);
            MessageBox.Show("Count : " + imageListFlag.Images.Count.ToString());
            FillDGVOfCurrencies();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBCurrencies.DeleteCountries((int)dgvCurrencies.CurrentRow.Cells[0].Value);
            FillDGVOfCurrencies();
        }

        private void mtbSearch_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"Code like '%{mtbSearch.Text}%'";
            
        }
    }
}
