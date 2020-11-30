using NotSoSmartSaverAPI.DTO.GoalDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IGoalProcessor
    {
        public Task<List<Goal>> getGoals(GetGoalsDTO data);

        public Task<bool> removeGoal(string goalId);

        public Task<bool> modifyGoal(ModifyGoalDTO data);

        public Task addNewGoal(NewGoalDTO data);

        public Task<bool> CompleteGoal(string goalId);
        public Task<bool> addMoneyToGoal(AddMoneyDTO data);
    }
}
