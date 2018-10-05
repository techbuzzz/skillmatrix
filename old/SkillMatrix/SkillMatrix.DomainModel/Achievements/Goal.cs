using System;
using System.Collections.Generic;
using SkillMatrix.DomainModel.Base;
using SkillMatrix.DomainModel.Identity;

namespace SkillMatrix.DomainModel.Achievements
{
    public class Goal : BaseItem
    {
        public Goal() : base()
        {
            GoalStatusId = 1;
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double? Target { get; set; }

        public int GoalTypeId { get; set; }

        public int? MetricId { get; set; }

        public int GoalStatusId { get; set; }

        public string UserId { get; set; }



        public virtual GoalType GoalType { get; set; }

        public virtual GoalStatus GoalStatus { get; set; }



       
    }
}
