using NotSoSmartSaverAPI.DTO.GoalDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IGoalProcessor
    {
        public List<Goal> getGoals(GetGoalsDTO data);

        public bool removeGoal(string goalId);

        public bool modifyGoal(ModifyGoalDTO data);

        public void addNewGoal(NewGoalDTO data);

        public bool CompleteGoal(string goalId);
        public bool addMoneyToGoal(AddMoneyDTO data);
    }
}
