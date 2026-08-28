
namespace Project_Bank_C
{
    partial class frmCurrencyExchange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrencyExchange));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCurrencyExchange = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbResualt = new System.Windows.Forms.TextBox();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lbCurrencyCalculator = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nudNewBuyRate = new System.Windows.Forms.NumericUpDown();
            this.nudNewSellRate = new System.Windows.Forms.NumericUpDown();
            this.cbBaseCurrency = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.lbUpdateCurrencyRate = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAddCurrency = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvCurrencies = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mtbSearch = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.imageListFlag = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBuyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewSellRate)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencies)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbCurrencyExchange);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(177, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 523);
            this.panel1.TabIndex = 0;
            // 
            // lbCurrencyExchange
            // 
            this.lbCurrencyExchange.AutoSize = true;
            this.lbCurrencyExchange.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrencyExchange.Location = new System.Drawing.Point(416, 11);
            this.lbCurrencyExchange.Name = "lbCurrencyExchange";
            this.lbCurrencyExchange.Size = new System.Drawing.Size(164, 19);
            this.lbCurrencyExchange.TabIndex = 5;
            this.lbCurrencyExchange.Text = "Currency Exchange";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(18, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(995, 486);
            this.panel3.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.tbResualt);
            this.panel9.Controls.Add(this.cbTo);
            this.panel9.Controls.Add(this.cbFrom);
            this.panel9.Controls.Add(this.nudAmount);
            this.panel9.Controls.Add(this.btnClear);
            this.panel9.Controls.Add(this.btnCalculate);
            this.panel9.Controls.Add(this.lbCurrencyCalculator);
            this.panel9.Location = new System.Drawing.Point(674, 199);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(296, 254);
            this.panel9.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Resualt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "From";
            // 
            // tbResualt
            // 
            this.tbResualt.Enabled = false;
            this.tbResualt.Location = new System.Drawing.Point(88, 147);
            this.tbResualt.Multiline = true;
            this.tbResualt.Name = "tbResualt";
            this.tbResualt.Size = new System.Drawing.Size(175, 26);
            this.tbResualt.TabIndex = 5;
            // 
            // cbTo
            // 
            this.cbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(165, 108);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(121, 21);
            this.cbTo.TabIndex = 13;
            // 
            // cbFrom
            // 
            this.cbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(15, 108);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(121, 21);
            this.cbFrom.TabIndex = 14;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(81, 48);
            this.nudAmount.Maximum = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(191, 20);
            this.nudAmount.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(37, 220);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(220, 27);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.btnClear_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(37, 183);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(220, 30);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            this.btnCalculate.MouseEnter += new System.EventHandler(this.btnCalculate_MouseEnter);
            this.btnCalculate.MouseLeave += new System.EventHandler(this.btnCalculate_MouseLeave);
            // 
            // lbCurrencyCalculator
            // 
            this.lbCurrencyCalculator.AutoSize = true;
            this.lbCurrencyCalculator.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrencyCalculator.Location = new System.Drawing.Point(4, 3);
            this.lbCurrencyCalculator.Name = "lbCurrencyCalculator";
            this.lbCurrencyCalculator.Size = new System.Drawing.Size(169, 19);
            this.lbCurrencyCalculator.TabIndex = 8;
            this.lbCurrencyCalculator.Text = "Currency Calculator";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.nudNewBuyRate);
            this.panel6.Controls.Add(this.nudNewSellRate);
            this.panel6.Controls.Add(this.cbBaseCurrency);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.btnSaveUpdate);
            this.panel6.Controls.Add(this.lbUpdateCurrencyRate);
            this.panel6.Location = new System.Drawing.Point(674, 13);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(296, 170);
            this.panel6.TabIndex = 2;
            // 
            // nudNewBuyRate
            // 
            this.nudNewBuyRate.DecimalPlaces = 2;
            this.nudNewBuyRate.Location = new System.Drawing.Point(171, 104);
            this.nudNewBuyRate.Maximum = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            this.nudNewBuyRate.Name = "nudNewBuyRate";
            this.nudNewBuyRate.Size = new System.Drawing.Size(120, 20);
            this.nudNewBuyRate.TabIndex = 12;
            // 
            // nudNewSellRate
            // 
            this.nudNewSellRate.DecimalPlaces = 2;
            this.nudNewSellRate.Location = new System.Drawing.Point(8, 104);
            this.nudNewSellRate.Maximum = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            this.nudNewSellRate.Name = "nudNewSellRate";
            this.nudNewSellRate.Size = new System.Drawing.Size(120, 20);
            this.nudNewSellRate.TabIndex = 5;
            // 
            // cbBaseCurrency
            // 
            this.cbBaseCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaseCurrency.FormattingEnabled = true;
            this.cbBaseCurrency.Location = new System.Drawing.Point(121, 45);
            this.cbBaseCurrency.Name = "cbBaseCurrency";
            this.cbBaseCurrency.Size = new System.Drawing.Size(165, 21);
            this.cbBaseCurrency.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(172, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "New Buy Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "New Sell Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Base Currency";
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUpdate.ForeColor = System.Drawing.Color.White;
            this.btnSaveUpdate.Location = new System.Drawing.Point(37, 135);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(220, 30);
            this.btnSaveUpdate.TabIndex = 7;
            this.btnSaveUpdate.Text = "Save Update";
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            this.btnSaveUpdate.MouseEnter += new System.EventHandler(this.btnSaveUpdate_MouseEnter);
            this.btnSaveUpdate.MouseLeave += new System.EventHandler(this.btnSaveUpdate_MouseLeave);
            // 
            // lbUpdateCurrencyRate
            // 
            this.lbUpdateCurrencyRate.AutoSize = true;
            this.lbUpdateCurrencyRate.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateCurrencyRate.Location = new System.Drawing.Point(5, 3);
            this.lbUpdateCurrencyRate.Name = "lbUpdateCurrencyRate";
            this.lbUpdateCurrencyRate.Size = new System.Drawing.Size(189, 19);
            this.lbUpdateCurrencyRate.TabIndex = 7;
            this.lbUpdateCurrencyRate.Text = "Update Currency Rate";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnAddCurrency);
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Location = new System.Drawing.Point(24, 406);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(644, 47);
            this.panel5.TabIndex = 1;
            // 
            // btnAddCurrency
            // 
            this.btnAddCurrency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCurrency.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCurrency.ForeColor = System.Drawing.Color.White;
            this.btnAddCurrency.Location = new System.Drawing.Point(7, 9);
            this.btnAddCurrency.Name = "btnAddCurrency";
            this.btnAddCurrency.Size = new System.Drawing.Size(143, 31);
            this.btnAddCurrency.TabIndex = 6;
            this.btnAddCurrency.Text = "Add Currency";
            this.btnAddCurrency.UseVisualStyleBackColor = true;
            this.btnAddCurrency.Click += new System.EventHandler(this.btnAddCurrency_Click);
            this.btnAddCurrency.MouseEnter += new System.EventHandler(this.btnAddCurrency_MouseEnter);
            this.btnAddCurrency.MouseLeave += new System.EventHandler(this.btnAddCurrency_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Project_Bank_C.Properties.Resources.AddCurrency1;
            this.pictureBox4.Location = new System.Drawing.Point(128, -7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(84, 61);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dgvCurrencies);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.mtbSearch);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(24, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(644, 374);
            this.panel4.TabIndex = 0;
            // 
            // dgvCurrencies
            // 
            this.dgvCurrencies.AllowUserToAddRows = false;
            this.dgvCurrencies.AllowUserToDeleteRows = false;
            this.dgvCurrencies.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrencies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCurrencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrencies.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrencies.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCurrencies.Location = new System.Drawing.Point(7, 51);
            this.dgvCurrencies.Name = "dgvCurrencies";
            this.dgvCurrencies.ReadOnly = true;
            this.dgvCurrencies.Size = new System.Drawing.Size(627, 305);
            this.dgvCurrencies.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Project_Bank_C.Properties.Resources.DeletePin;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Project_Bank_C.Properties.Resources.searchIcon1;
            this.pictureBox2.Location = new System.Drawing.Point(550, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(474, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // mtbSearch
            // 
            this.mtbSearch.Location = new System.Drawing.Point(81, 26);
            this.mtbSearch.Name = "mtbSearch";
            this.mtbSearch.Size = new System.Drawing.Size(385, 20);
            this.mtbSearch.TabIndex = 1;
            this.mtbSearch.TextChanged += new System.EventHandler(this.mtbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Currency List";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(18, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(890, 1);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Project_Bank_C.Properties.Resources.CurrencyExchange;
            this.pictureBox3.Location = new System.Drawing.Point(350, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(87, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // imageListFlag
            // 
            this.imageListFlag.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFlag.ImageStream")));
            this.imageListFlag.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFlag.Images.SetKeyName(0, "Yemen.png");
            this.imageListFlag.Images.SetKeyName(1, "Saudi.png");
            this.imageListFlag.Images.SetKeyName(2, "Oman.png");
            this.imageListFlag.Images.SetKeyName(3, "UnitatedArabEmarat.png");
            this.imageListFlag.Images.SetKeyName(4, "Qatar.png");
            this.imageListFlag.Images.SetKeyName(5, "Barhain.png");
            this.imageListFlag.Images.SetKeyName(6, "Kuwait.png");
            this.imageListFlag.Images.SetKeyName(7, "Iraq.png");
            this.imageListFlag.Images.SetKeyName(8, "Jordan.png");
            this.imageListFlag.Images.SetKeyName(9, "Egypt.png");
            this.imageListFlag.Images.SetKeyName(10, "sudan.jpg");
            this.imageListFlag.Images.SetKeyName(11, "Somalia.png");
            this.imageListFlag.Images.SetKeyName(12, "Djibouti.jpg");
            this.imageListFlag.Images.SetKeyName(13, "comoros.png");
            this.imageListFlag.Images.SetKeyName(14, "Lebanon.png");
            this.imageListFlag.Images.SetKeyName(15, "Syria.png");
            this.imageListFlag.Images.SetKeyName(16, "Palestine.png");
            this.imageListFlag.Images.SetKeyName(17, "Libya.png");
            this.imageListFlag.Images.SetKeyName(18, "Tunisia.png");
            this.imageListFlag.Images.SetKeyName(19, "Algeria.png");
            this.imageListFlag.Images.SetKeyName(20, "Morocco.png");
            this.imageListFlag.Images.SetKeyName(21, "Mauritania.png");
            this.imageListFlag.Images.SetKeyName(22, "United_States.png");
            this.imageListFlag.Images.SetKeyName(23, "Afghanistan.png");
            this.imageListFlag.Images.SetKeyName(24, "Albania.png");
            this.imageListFlag.Images.SetKeyName(25, "Argentina.png");
            this.imageListFlag.Images.SetKeyName(26, "Australia.png");
            this.imageListFlag.Images.SetKeyName(27, "Austria.png");
            this.imageListFlag.Images.SetKeyName(28, "Brazil.png");
            this.imageListFlag.Images.SetKeyName(29, "Canada.jpeg");
            this.imageListFlag.Images.SetKeyName(30, "China.png");
            this.imageListFlag.Images.SetKeyName(31, "France.png");
            this.imageListFlag.Images.SetKeyName(32, "Germany.png");
            this.imageListFlag.Images.SetKeyName(33, "India.png");
            this.imageListFlag.Images.SetKeyName(34, "Japan.png");
            this.imageListFlag.Images.SetKeyName(35, "Malaysia.png");
            this.imageListFlag.Images.SetKeyName(36, "Mexico.png");
            this.imageListFlag.Images.SetKeyName(37, "Netherlands.png");
            this.imageListFlag.Images.SetKeyName(38, "New_Zealand.png");
            this.imageListFlag.Images.SetKeyName(39, "Norway.png");
            this.imageListFlag.Images.SetKeyName(40, "Pakistan.jpg");
            this.imageListFlag.Images.SetKeyName(41, "Philippines.png");
            this.imageListFlag.Images.SetKeyName(42, "Poland.png");
            this.imageListFlag.Images.SetKeyName(43, "Russia.png");
            this.imageListFlag.Images.SetKeyName(44, "Singapore.png");
            this.imageListFlag.Images.SetKeyName(45, "South_Africa.png");
            this.imageListFlag.Images.SetKeyName(46, "south_Korea.png");
            this.imageListFlag.Images.SetKeyName(47, "Sweden.png");
            this.imageListFlag.Images.SetKeyName(48, "Switzerland.png");
            this.imageListFlag.Images.SetKeyName(49, "Thailand.png");
            this.imageListFlag.Images.SetKeyName(50, "Turkey.png");
            this.imageListFlag.Images.SetKeyName(51, "United_Kingdom.png");
            this.imageListFlag.Images.SetKeyName(52, "Ukraine.png");
            this.imageListFlag.Images.SetKeyName(53, "Vietnam.png");
            this.imageListFlag.Images.SetKeyName(54, "Zimbabwe.png");
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::Project_Bank_C.Properties.Resources.logoutNavy;
            this.pictureBox5.Location = new System.Drawing.Point(-7, -3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(59, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_Bank_C.Properties.Resources.FlagNavy;
            this.pictureBox1.Location = new System.Drawing.Point(-7, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 523);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmCurrencyExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 512);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmCurrencyExchange";
            this.Text = "MBank";
            this.Load += new System.EventHandler(this.frmCurrencyExchange_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewBuyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewSellRate)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencies)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox mtbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbCurrencyExchange;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lbCurrencyCalculator;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Label lbUpdateCurrencyRate;
        private System.Windows.Forms.Button btnAddCurrency;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.NumericUpDown nudNewBuyRate;
        private System.Windows.Forms.NumericUpDown nudNewSellRate;
        private System.Windows.Forms.ComboBox cbBaseCurrency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbResualt;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.NumericUpDown nudAmount;
        public System.Windows.Forms.ImageList imageListFlag;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridView dgvCurrencies;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}