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
    public partial class View : Form
    {
        BudgetStore dbStore;
        public TransactionsModel model { get; set; }

        public View(BudgetStore dbStore)
        {
            InitializeComponent();
            this.dbStore = dbStore;
        }


        private void Load_View(object sender, EventArgs e)
        {
            double TodayIncome = 0;
            double TodayExpense = 0;

            double WeekIncome = 0;
            double WeekExpense = 0;

            foreach (TransactionsDbRow row in dbStore.Tables["TransactionsDb"].Rows)
            {

                if (DateTime.Parse(row["Date"].ToString()) == DateTime.Today)
                {
                    if (row["Type"].ToString() == "Income")
                    {
                        TodayIncome += double.Parse(row["Amount"].ToString());
                    }
                    else
                    {
                        TodayExpense += double.Parse(row["Amount"].ToString());
                    }
                }

                if (DateTime.Parse(row["Date"].ToString()) >= DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek))
                {
                    if (row["Type"].ToString() == "Income")
                    {
                        WeekIncome += double.Parse(row["Amount"].ToString());
                    }
                    else
                    {
                        WeekExpense += double.Parse(row["Amount"].ToString());
                    }
                }

            }

            lblDayExpense.Text = TodayExpense.ToString();
            lblDayIncome.Text = TodayIncome.ToString();
            lblWeekExpense.Text = WeekExpense.ToString();
            lblWeekIncome.Text = WeekIncome.ToString();
            LordRecentTransactions();
            NextWeekPrediction();
        }

        public void LordRecentTransactions()
        {
            DataTable dTable = dbStore.Tables["TransactionsDb"];
            DataRow[] dataRows;

           

            
            for (int i = 0; i < 7; i++)
            {
                double LoadTodayIncome = 0;
                double LoadTodayExpense = 0;

                dataRows = dTable.Select("Date = '" + DateTime.Today.AddDays(-1 * i) + "'");
                foreach (DataRow row in dataRows)
                {
                    if (row["Type"].ToString() == "Income")
                    {
                        LoadTodayIncome += double.Parse(row["Amount"].ToString());
                    }
                    else
                    {
                        LoadTodayExpense += double.Parse(row["Amount"].ToString());
                    }
                }

                string[] s1= new string[3];
                s1[0] = DateTime.Today.AddDays(-1 * i).ToString("d"); // remove time, filter only date 
                s1[1] = LoadTodayIncome.ToString();
                s1[2] = LoadTodayExpense.ToString();

                ListViewItem listItems = new ListViewItem(s1);
                lstRecentTarnsaction.Items.Add(listItems);
            }

        }

        public void NextWeekPrediction()
        {
            double totalNextWeekIncome = 0;
            double totalNextWeekExpense = 0;

            DataTable dTable = dbStore.Tables["TransactionsDb"];
            DataRow[] dataRows;

            double nextWeekIncome = 0;
            double nextWeekExpense = 0;

            // Get week befor last week total

            DateTime today = DateTime.Today;
            DateTime weekBeforLastWeekStart = DateTime.Today.AddDays(-(int)today.DayOfWeek - 14);
            DateTime weekBeforlastWeekEnd = DateTime.Today.AddDays(-(int)today.DayOfWeek -7);
            dataRows = dTable.Select("Date >= '" + weekBeforLastWeekStart + "' AND Date < '" + weekBeforlastWeekEnd + "'");
            foreach (DataRow row in dataRows)
            {
                if (row["Type"].ToString() == "Income")
                {
                    nextWeekIncome += double.Parse(row["Amount"].ToString());
                }
                else
                {
                    nextWeekExpense += double.Parse(row["Amount"].ToString());
                }
            }

            // Get last week total

           
            DateTime lastWeekStart = DateTime.Today.AddDays(-(int)today.DayOfWeek - 7);
            DateTime lastWeekEnd = DateTime.Today.AddDays(-(int)today.DayOfWeek);
            dataRows = dTable.Select("Date >= '" + lastWeekStart + "' AND Date < '" + lastWeekEnd + "'");
            foreach (DataRow row in dataRows)
            {
                if (row["Type"].ToString() == "Income")
                {
                    nextWeekIncome += double.Parse(row["Amount"].ToString());
                }
                else
                {
                    nextWeekExpense += double.Parse(row["Amount"].ToString());
                }
            }

            // get Avarage next week
            totalNextWeekIncome += nextWeekIncome / 2;
            totalNextWeekExpense += nextWeekExpense / 2;

            lblNextIncome.Text = totalNextWeekIncome.ToString();
            lblNextExpense.Text = totalNextWeekExpense.ToString();
            

        }
    }
}
