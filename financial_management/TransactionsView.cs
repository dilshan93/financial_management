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
    public partial class TransactionsView : Form
    {
        BudgetStore dbStore;
        public TransactionsView(BudgetStore dbStore)
        {
            InitializeComponent();
            this.dbStore = dbStore;
        }

        private void OpenTransaction_Save(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(dbStore);
            transactions.ShowDialog();
            RefreshTransactionData();
        }

        private void Lorad_Transactions(object sender, EventArgs e)
        {
            RefreshTransactionData();
        }

        public void RefreshTransactionData()
        {
            lsTransactions.Items.Clear();

            foreach (TransactionsDbRow row in dbStore.Tables["TransactionsDb"].Rows)
            {
                
                string[] items = new string[6];
                items[0] = row["Id"].ToString();
                items[1] = DateTime.Parse(row["Date"].ToString()).ToString("d");
                items[2] = row["Name"].ToString();
                items[3] = row["Type"].ToString();
                items[4] = row.GetParentRow("CategoryDb_TransactionsDb")["Name"].ToString();
                items[5] = row["Amount"].ToString();

                ListViewItem listViewItem = new ListViewItem(items);
                lsTransactions.Items.Add(listViewItem);

            }
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void Update_Transactions(object sender, EventArgs e)
        {
            int id = int.Parse(lsTransactions.SelectedItems[0].SubItems[0].Text);
            UpdateTransactions updateTransactions = new UpdateTransactions(id, dbStore);
            updateTransactions.ShowDialog();
            updateTransactions.Dispose();
            RefreshTransactionData();
        }

        private void Enabled_Selected(object sender, EventArgs e)
        {
            if (lsTransactions.SelectedItems.Count == 1)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void Remove_Transaction(object sender, EventArgs e)
        {

            int id = int.Parse(lsTransactions.SelectedItems[0].SubItems[0].Text);
            if (id > 0)
            {
                TransactionsModel transactionsModel = new TransactionsModel();
                transactionsModel.DeleteTransaction(dbStore, id);
                RefreshTransactionData();
            }
            
        }
    }
}
