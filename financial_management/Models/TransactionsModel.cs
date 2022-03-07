 using financial_management.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static financial_management.BudgetStore;

namespace financial_management.Models
{
    public class TransactionsModel
    {
        public BudgetStore dbStores { get; set; }

        public Boolean SaveTransaction(TransactionDTO transactionDTO, BudgetStore dbStore) {

            TransactionsDbRow row = dbStore.TransactionsDb.NewTransactionsDbRow();
            row.Name = transactionDTO.Name;
            row.Type = transactionDTO.Type;
            row.Amount = transactionDTO.Amount;
            row.CategoryId = transactionDTO.CategoryId;
            row.Date = transactionDTO.Date;
            row.Repete = transactionDTO.IsRepete;
            dbStore.TransactionsDb.AddTransactionsDbRow(row);

            return true;
        }

        public BudgetStore GetDbStor()
        {

       //     if (this.dbStore == null)
       //     {

       //         this.dbStore = new BudgetStore();
      //      }

            return null;
        }

    }
}
