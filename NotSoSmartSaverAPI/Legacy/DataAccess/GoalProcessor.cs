using Newtonsoft.Json;
using NotSoSmartSaverWFA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NotSoSmartSaverWFA.DataAccess
{
    class GoalProcessor : IGoalProcessor
    {

        string goalDataPath = @"../../../Data/Goals.json";
        

        public void addNewGoal(string ownerId, string goalName, double moneyRequired, DateTime goalExpectedTime)
        {
            if (File.Exists(goalDataPath) == true)
            {
                string jsonR = File.ReadAllText(goalDataPath);
                var listOfLines = File.ReadAllLines(goalDataPath);
                var goalList = JsonConvert.DeserializeObject<List<Goal>>(jsonR);
                var newGoal = new Goal(Guid.NewGuid().ToString(), ownerId, goalName, moneyRequired, goalExpectedTime);
                goalList.Add(newGoal);
                var jsonW = JsonConvert.SerializeObject(goalList, Formatting.Indented);
                File.WriteAllText(goalDataPath, jsonW);
            }
            else
            {
                var newGoal = new Goal(Guid.NewGuid().ToString(), ownerId, goalName, moneyRequired, goalExpectedTime);
                var goalList = new List<Goal>();
                goalList.Add(newGoal);
                var jsonW = JsonConvert.SerializeObject(goalList, Formatting.Indented);
                File.WriteAllText(goalDataPath, jsonW);
            }
        }

        public List<Goal> getGoals(string ownerId)
        {
            var userGoalList = new List<Goal>();

            if (File.Exists(goalDataPath) == true)
            {
                string json = File.ReadAllText(goalDataPath);
                var goalList = JsonConvert.DeserializeObject<List<Goal>>(json);

                foreach (var goal in goalList)
                {
                    if (goal.ownerId == ownerId)
                    {
                        userGoalList.Add(goal);
                    }
                }
            }

            return userGoalList;
        }

        public void modifyGoalMoneyAllocated(string goalId, double newMoneyAllocated)
        {
           if (File.Exists(goalDataPath) == true)
            {
                string jsonR = File.ReadAllText(goalDataPath);
                var goalList = JsonConvert.DeserializeObject<List<Goal>>(jsonR);

                foreach (var goal in goalList)
                {
                    if (goal.goalId == goalId)
                    {
                        goal.moneyAllocated = newMoneyAllocated;
                    }
                }

                string jsonW = JsonConvert.SerializeObject(goalList, Formatting.Indented);
                File.WriteAllText(goalDataPath, jsonW);
            }
        }

        public void modifyGoalMoneyRequired(string goalId, double newMoneyRequired)
        {
            if (File.Exists(goalDataPath) == true)
            {
                string jsonR = File.ReadAllText(goalDataPath);
                var goalList = JsonConvert.DeserializeObject<List<Goal>>(jsonR);

                foreach (var goal in goalList)
                {
                    if (goal.goalId == goalId)
                    {
                        goal.moneyRequired = newMoneyRequired;
                    }
                }

                string jsonW = JsonConvert.SerializeObject(goalList, Formatting.Indented);
                File.WriteAllText(goalDataPath, jsonW);
            }
        }

        public void modifyGoalName(string goalId, string newGoalName)
        {
            if (File.Exists(goalDataPath) == true)
            {
                string jsonR = File.ReadAllText(goalDataPath);
                var goalList = JsonConvert.DeserializeObject<List<Goal>>(jsonR);

                foreach (var goal in goalList)
                {
                    if (goal.goalId == goalId)
                    {
                        goal.goalName = newGoalName;
                    }
                }

                string jsonW = JsonConvert.SerializeObject(goalList, Formatting.Indented);
                File.WriteAllText(goalDataPath, jsonW);
            }
        }

        public void removeGoal(string goalId)
        {
            if (File.Exists(goalDataPath) == true)
            {
                string jsonR = File.ReadAllText(goalDataPath);
                var goalList = JsonConvert.DeserializeObject<List<Goal>>(jsonR);
                goalList.RemoveAll(x => x.goalId.Equals(goalId));
                var jsonW = JsonConvert.SerializeObject(goalList, Formatting.Indented);
                File.WriteAllText(goalDataPath, jsonW);
            }
        }
    }
}
