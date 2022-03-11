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
    public partial class Category : Form
    {
        BudgetStore dbStore;
        public Category(BudgetStore dbStore)
        {
            InitializeComponent();
            this.dbStore = dbStore;
        }

        private void SaveCategory(object sender, EventArgs e)
        {

            String categoryName = this.txtCategoryName.Text;
            if (categoryName == null || categoryName == String.Empty)
            {

                MessageBox.Show("Name Can't be Empty!", "Hey", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Save new category
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Name = categoryName;
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.CreateCategory(dbStore, categoryDTO);

            MessageBox.Show("Category successfully added!", "Hey", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshListView();
        }

        private void Load_Categories(object sender, EventArgs e)
        {
            RefreshListView();
        }

        public void RefreshListView()
        {
            lsCategories.Items.Clear();
            foreach (BudgetStore.CategoryDbRow row in dbStore.Tables["CategoryDb"].Rows)
            {
                string[] items = new string[2];
                items[0] = row["Id"].ToString();
                items[1] = row["Name"].ToString();

                ListViewItem listViewItem = new ListViewItem(items);
                lsCategories.Items.Add(listViewItem);
            };
            btnDelete.Enabled = false;

        }

        private void Enabled_Selected(object sender, EventArgs e)
        {
            if (lsCategories.SelectedItems.Count == 1)
            {
                btnDelete.Enabled = true;
            }
        }

        private void Remove_Category(object sender, EventArgs e)
        {
            int id = int.Parse(lsCategories.SelectedItems[0].SubItems[0].Text);

            DataTable dtable = dbStore.Tables["TransactionsDb"];
            DataRow[] dRow = dtable.Select("CategoryId = '" + id + "'");
            if (dRow.Length > 0)
            {
                MessageBox.Show(" Please Delete Transactions Under This Category First !", "Hey", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (id > 0)
            {
                CategoryModel categoryModel = new CategoryModel();
                categoryModel.DeleteCategory(dbStore, id);
                RefreshListView();
            }

        }
    }
}
