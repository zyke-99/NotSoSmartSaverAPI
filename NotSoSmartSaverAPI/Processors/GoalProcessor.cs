using NotSoSmartSaverAPI.DTO.GoalDTO;
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
        public void addNewGoal(NewGoalDTO data)
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
        }

        public List<Goal> getGoals(GetGoalsDTO data)
        {
            NSSSContext context = new NSSSContext();
            var listOfGoals = context.Goal.Where(a => a.Ownerid == data.ownerId).ToList();
            return listOfGoals;
        }

        public bool modifyGoal(ModifyGoalDTO data)
        {
            NSSSContext context = new NSSSContext();
            Goal goal = context.Goal.First(a => a.Goalid == data.goalId);
            goal.Goalname = data.newGoalName;
            goal.Moneyrequired = data.newMoneyRequired;
            goal.Goalexpectedtime = data.newExpectedTime;
            context.SaveChanges();
            return true;

        }
        public bool modifyAllocatedMoney(ModifyAllocatedMoneyDTO data)
        {
            NSSSContext context = new NSSSContext();
            Goal goal = context.Goal.First(a => a.Goalid == data.goalId);
            goal.Moneyallocated = data.newAllocatedMoney;
            context.SaveChanges();
            return true;
        }

        public bool removeGoal(string goalId)
        {
            NSSSContext context = new NSSSContext();
            context.Remove(context.Goal.Single(a => a.Goalid == goalId));
            context.SaveChanges();
            return true;
        }
    }
}
