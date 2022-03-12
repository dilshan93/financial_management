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
    public partial class Transactions : Form
    {
        BudgetStore dbStore;
        public Transactions(BudgetStore dbStore)
        {
            InitializeComponent();
            this.dbStore = dbStore;
        }

        
        private void AddTransaction(object sender, EventArgs e)
        {
            

        }

        public BudgetStore GetDbStor()
        {

            return dbStore;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          //  label1.Text = Format
        }

        private void Load_AddTransaction(object sender, EventArgs e)
        {
            // Load categories
            DataTable dTable = dbStore.Tables["CategoryDb"];
            foreach (DataRow row in dTable.Rows)
            {
                comTransCategory.Items.Add(row["Name"].ToString());
            }
        }

        private void Submit_Transaction(object sender, EventArgs e)
        {
            string name = txtTransName.Text;
            string amount = txtTransAmount.Text;

            if (name == null || amount == "" || comTransCategory.SelectedIndex == -1 || comTransType.SelectedIndex == -1)
            {
                MessageBox.Show("Some fields are empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Create new transaction object
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
            Boolean result = transactionsModel.SaveTransaction(transactionDTO, dbStore);
            if (result == true)
            {

                MessageBox.Show("Transaction Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();

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
