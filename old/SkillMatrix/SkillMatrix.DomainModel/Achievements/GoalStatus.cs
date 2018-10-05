using System.Collections.Generic;

namespace SkillMatrix.DomainModel.Achievements
{
    public class GoalStatus
    {
        public int GoalStatusId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }

    }

    //new GoalStatus{GoalStatusType="In Progress"},
    //new GoalStatus{GoalStatusType="On Hold"},
    //new GoalStatus{GoalStatusType="Completed"}
}
