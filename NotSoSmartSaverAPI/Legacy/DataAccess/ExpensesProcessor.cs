using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace NotSoSmartSaverWFA.DataAccess
{
    class ExpensesProcessor : IExpensesProcessor
    {
        string expenseDataPath = @"C:\Users\Lenovo\source\repos\NotSoSmartSaverAPI\NotSoSmartSaverAPI\Data\Expenses.json";
        public void createNewExpense(string ownerId, string userId, string expenseName, double expenseMoneyUsed, CategoryEnum category)//, IExpensesProcessor.Category category)
        {
            if (File.Exists(expenseDataPath) == true)
            {
                string jsonR = File.ReadAllText(expenseDataPath);
                var expensesList = JsonConvert.DeserializeObject<List<Expense>>(jsonR);
                var newExpense = new Expense(Guid.NewGuid().ToString(), ownerId, userId, expenseName, expenseMoneyUsed, DateTime.Now, category);//, category);
                expensesList.Add(newExpense);
                var jsonW = JsonConvert.SerializeObject(expensesList, Formatting.Indented);
                File.WriteAllText(expenseDataPath, jsonW);
            }
            else
            {
                var newExpense = new Expense(Guid.NewGuid().ToString(), ownerId, userId, expenseName, expenseMoneyUsed, DateTime.Now, category);//, category);
                var expensesList = new List<Expense>();
                expensesList.Add(newExpense);
                var jsonW = JsonConvert.SerializeObject(expensesList, Formatting.Indented);
                File.WriteAllText(expenseDataPath, jsonW);
            }

        }



        public List<Expense> getExpenses(string ownerId)
        {
            var userExpensesList = new List<Expense>();

            if (File.Exists(expenseDataPath) == true) //Checks if file exists
            {
                string json = File.ReadAllText(expenseDataPath);
                var expensesList = JsonConvert.DeserializeObject<List<Expense>>(json);

                foreach (var expense in expensesList)
                {
                    if (expense.ownerId == ownerId)
                    {
                        userExpensesList.Add(expense);
                    }
                }

            }

            return userExpensesList;

        }



        public void modifyExpense(string expenseId, string newExpenseName, double newExpenseMoneyUsed, CategoryEnum newExpenseCategory)//, IExpensesProcessor.Category newExpenseCategory)
        {

            if (File.Exists(expenseDataPath) == true)
            {
                string jsonR = File.ReadAllText(expenseDataPath);
                var expensesList = JsonConvert.DeserializeObject<List<Expense>>(jsonR);

                foreach (var expense in expensesList)
                {
                    if (expense.expenseId == expenseId)
                    {
                        expense.expenseName = newExpenseName;
                        expense.moneyUsed = newExpenseMoneyUsed;
                        expense.expenseCategory = newExpenseCategory;
                        //expense.category = newExpenseCategory;
                    }
                }
                var jsonW = JsonConvert.SerializeObject(expensesList);
                File.WriteAllText(expenseDataPath, jsonW);
            }

        }



        public void removeExpense(string expenseId)
        {

            if (File.Exists(expenseDataPath) == true)
            {
                string jsonR = File.ReadAllText(expenseDataPath);
                var expensesList = JsonConvert.DeserializeObject<List<Expense>>(jsonR);
                expensesList.RemoveAll(x => x.expenseId.Equals(expenseId));
                var jsonW = JsonConvert.SerializeObject(expensesList);
                File.WriteAllText(expenseDataPath, jsonW);
            }

        }
    }
}

