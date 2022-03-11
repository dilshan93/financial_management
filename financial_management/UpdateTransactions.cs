using financial_management.DataObjects;
using financial_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static financial_management.BudgetStore;

namespace financial_management
{
    public partial class UpdateTransactions : Form
    {
        int transId;
        BudgetStore dbStore;
        public UpdateTransactions(int id, BudgetStore dbStore)
        {
            InitializeComponent();
            this.transId = id;
            this.dbStore = dbStore;
        }

        private void UpdateTransactions_Load(object sender, EventArgs e)
        {
            // Load_categories
            DataTable dtCat = dbStore.Tables["CategoryDb"];
            foreach (DataRow row in dtCat.Rows)
            {
                comTransCategory.Items.Add(row["Name"].ToString());
            }

            // Load_transaction
            TransactionsModel transactionsModel = new TransactionsModel();

            TransactionDTO transactionDTO = transactionsModel.LoadTransactionData(transId, dbStore);

            txtTransName.Text = transactionDTO.Name;
            comTransType.Text = transactionDTO.Type.ToString();
            txtTransAmount.Text = transactionDTO.Amount.ToString();
            comTransCategory.Text = transactionDTO.CategoryName;
            chkWeekly.Checked = transactionDTO.IsRepete;
            dtpTransDate.Value = transactionDTO.Date;
        }

        private void Update_Transaction(object sender, EventArgs e)
        {
            string name = txtTransName.Text;
            string amount = txtTransAmount.Text;

            if (name == null || amount == "" || comTransCategory.SelectedIndex == -1 || comTransType.SelectedIndex == -1)
            {
                MessageBox.Show("Some fields are empty!", "Hey", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Update transaction object
            TransactionDTO transactionDTO = new TransactionDTO();
            transactionDTO.Name = name;
            transactionDTO.Amount = double.Parse(amount);
            transactionDTO.Date = DateTime.Parse(dtpTransDate.Text);
            transactionDTO.Type = comTransType.Text;
            transactionDTO.IsRepete = chkWeekly.Checked;

            DataTable dtCat = dbStore.Tables["CategoryDb"];
            DataRow[] catId = dtCat.Select("Name = '" + comTransCategory.Text + "'");
            foreach (DataRow row in catId)
            {
                transactionDTO.CategoryId = (int)row["Id"];
            }

            TransactionsModel transactionsModel = new TransactionsModel();
            Boolean result = transactionsModel.UpdateTransaction(transactionDTO, dbStore, transId);
            if (result == true)
            {

                MessageBox.Show("Update Complete", "Hey", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void ValidateAmountFeild(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
