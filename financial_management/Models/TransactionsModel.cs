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

        public TransactionDTO LoadTransactionData(int id, BudgetStore dbStore)
        {

            TransactionsDbRow transactionsDbRow = (TransactionsDbRow)dbStore.Tables["TransactionsDb"].Rows.Find(id);
            TransactionDTO transactionDTO = new TransactionDTO();
            transactionDTO.Id = transactionsDbRow.Id;
            transactionDTO.Name = transactionsDbRow.Name;
            transactionDTO.Type = transactionsDbRow.Type;
            transactionDTO.Amount = transactionsDbRow.Amount;
            transactionDTO.CategoryId = transactionsDbRow.CategoryId;
            transactionDTO.CategoryName = transactionsDbRow.GetParentRow("CategoryDb_TransactionsDb")["Name"].ToString();
            transactionDTO.Date = transactionsDbRow.Date;
            transactionDTO.IsRepete = transactionsDbRow.Repete;

            return transactionDTO;
        }

      

        public Boolean UpdateTransaction(TransactionDTO transactionDTO, BudgetStore dbStore, int id)
        {

            TransactionsDbRow row = (TransactionsDbRow)dbStore.Tables["TransactionsDb"].Rows.Find(id); ;
            row.Name = transactionDTO.Name;
            row.Type = transactionDTO.Type;
            row.Amount = transactionDTO.Amount;
            row.CategoryId = transactionDTO.CategoryId;
            row.Date = transactionDTO.Date;
            row.Repete = transactionDTO.IsRepete;
            row.AcceptChanges();

            return true;
        }

        public Boolean DeleteTransaction(BudgetStore dbStore, int id)
        {

            dbStore.Tables["TransactionsDb"].Rows.Remove(dbStore.Tables["TransactionsDb"].Rows.Find(id));

            return true;
        }

    }
}
