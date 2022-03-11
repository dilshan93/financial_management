using financial_management.DTO;
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
    public partial class DashBordView : Form
    {
        BudgetStore dbStore = new BudgetStore();
        public DashBordView()
        {
            InitializeComponent();
        }

        private void OpenTransactions(object sender, EventArgs e)
        {
            TransactionsView transactions = new TransactionsView(dbStore);
            transactions.ShowDialog();
            transactions.Dispose();
        }

        private void OpenView(object sender, EventArgs e)
        {
            View view = new View(dbStore);
            view.ShowDialog();
        }

        private void OpenCategory(object sender, EventArgs e)
        {
            Category category = new Category(dbStore);
            category.ShowDialog();
        }

        private void Add_InitialData(object sender, EventArgs e)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Name = "Education";
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.CreateCategory(dbStore, categoryDTO);
        }

        private void Close_WindowsForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
