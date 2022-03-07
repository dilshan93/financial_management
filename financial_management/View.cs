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

namespace financial_management
{
    public partial class View : Form
    {
        BudgetStore dbStore;
        public TransactionsModel model { get; set; }

        public View(BudgetStore dbStore)
        {
            InitializeComponent();
            this.dbStore = dbStore;
        }

        private void Load_View4(object sender, EventArgs e)
        {
            this.dtgTransDataView.DataSource = this.dbStore.TransactionsDb;
        }
    }
}
