using NotSoSmartSaverWFA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverWFA.DataAccess
{
    interface IGoalProcessor
    {
        List<Goal> getGoals(string ownerId);

        void removeGoal(string goalId);

        void modifyGoalName(string goalId, string newGoalName);

        void modifyGoalMoneyRequired(string goalId, double newMoneyRequired);

        void modifyGoalMoneyAllocated(string goalId, double newMoneyAllocated);

        void addNewGoal(string ownerId, string goalName, double moneyRequired, DateTime goalExpectedTime);

    }
}
