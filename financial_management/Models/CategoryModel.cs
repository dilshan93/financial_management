using financial_management.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.Models
{
    internal class CategoryModel
    {

        // Create new category in DB
        public void CreateCategory(BudgetStore budgetStore, CategoryDTO categoryDTO)
        {
            BudgetStore.CategoryDbRow row = budgetStore.CategoryDb.NewCategoryDbRow();
            row.Name = categoryDTO.Name;
            budgetStore.CategoryDb.AddCategoryDbRow(row);
        }

        // Load category from DB
        public void LoadCategory(BudgetStore.CategoryDbRow row)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Id = row.Id;
            categoryDTO.Name = row.Name;
        }

        // Update category row in DB
        public void UpdatCategory(BudgetStore.CategoryDbRow row, String name)
        {
            row.Name = name;
            row.AcceptChanges();
        }

        public Boolean DeleteCategory(BudgetStore dbStore, int id)
        {

            dbStore.Tables["CategoryDb"].Rows.Remove(dbStore.Tables["CategoryDb"].Rows.Find(id));

            return true;
        }
    }
}
