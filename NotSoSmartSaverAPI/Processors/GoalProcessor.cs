using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.DTO.GoalDTO;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Processors
{
    public class GoalProcessor : IGoalProcessor

        
    {
        private readonly IIncomeProcessor _incomeProcessor;
        private readonly IExpensesProcessor _expensesProcessor;
        public GoalProcessor(IIncomeProcessor incomeProcessor, IExpensesProcessor expensesProcessor)
        {
            _incomeProcessor = incomeProcessor;
            _expensesProcessor = expensesProcessor;
        }
        public Task addNewGoal(NewGoalDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            var newGoal = new Goal
            {
                Goalid = Guid.NewGuid().ToString(),
                Ownerid = data.ownerId,
                Moneyrequired = data.moneyRequired,
                Moneyallocated = 0,
                Goaltime = DateTime.Now,
                Goalexpectedtime = data.goalExpectedTime,
                Goalname = data.goalName
            };
            context.Goal.Add(newGoal);
        });

        public Task<List<Goal>> getGoals(GetGoalsDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            var listOfGoals = context.Goal.Where(a => a.Ownerid == data.ownerId).ToList();
            return listOfGoals;
        });

        public Task<bool> modifyGoal(ModifyGoalDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Goal goal = context.Goal.First(a => a.Goalid == data.goalId);
            goal.Goalname = data.newGoalName;
            goal.Moneyrequired = data.newMoneyRequired;
            goal.Goalexpectedtime = data.newExpectedTime;
            context.SaveChanges();
            return true;
        });

        public bool modifyAllocatedMoney(ModifyAllocatedMoneyDTO data)
        {
            NSSSContext context = new NSSSContext();
            Goal goal = context.Goal.First(a => a.Goalid == data.goalId);
            goal.Moneyallocated = data.newAllocatedMoney;
            context.SaveChanges();
            return true;
        }

        public async Task<bool> addMoneyToGoal(AddMoneyDTO data)
        {
            if (data.moneyToAdd <= await Task.Run(() => _expensesProcessor.getUserMoneyAsync(new UserIdDTO { userId = data.userId})))
            {
                if (data.goalAllocatedMoney + data.moneyToAdd > data.goalRequiredMoney)
                {
                    await _expensesProcessor.AddExpense(new NewExpenseDTO
                    {
                        userId = data.userId,
                        ownerId = data.userId,
                        expenseName = "Goal: " + data.goalName,
                        moneyUsed = data.goalRequiredMoney - data.goalAllocatedMoney,
                        expenseCategory = CategoryEnum.Goal
                    });
                    modifyAllocatedMoney(new ModifyAllocatedMoneyDTO { goalId = data.goalId, newAllocatedMoney = data.goalRequiredMoney });

                }
                else
                {
                    await _expensesProcessor.AddExpense(new NewExpenseDTO
                    {
                        userId = data.userId,
                        ownerId = data.userId,
                        expenseName = "Goal: " + data.goalName,
                        moneyUsed = data.moneyToAdd,
                        expenseCategory = CategoryEnum.Goal
                    });
                    modifyAllocatedMoney(new ModifyAllocatedMoneyDTO { goalId = data.goalId, newAllocatedMoney = data.goalAllocatedMoney + data.moneyToAdd});

                }
            }
            return true;
        }

        public Task<bool> removeGoal(string goalId) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Goal goal = context.Goal.Single(a => a.Goalid == goalId);
            context.Remove(goal);
            context.SaveChanges();
            _incomeProcessor.AddIncome(new NewIncomeDTO
            {
                userId = goal.Ownerid,
                ownerId = goal.Ownerid,
                incomeName = "Removed goal",
                moneyReceived = goal.Moneyallocated

            });
            return true;
        });

        public Task<bool> CompleteGoal(string goalID) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Goal goal = context.Goal.First(x => x.Goalid == goalID);
            if (goal.Moneyallocated == goal.Moneyrequired)
            {
                context.Goal.Remove(goal);
                context.SaveChanges();
                return true;
            }
            else return false;
        });
    }
}
