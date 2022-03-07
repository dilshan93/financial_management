using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
