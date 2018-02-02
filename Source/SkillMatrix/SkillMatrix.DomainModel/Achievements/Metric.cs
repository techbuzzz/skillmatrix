using System.Collections.Generic;
using SkillMatrix.DomainModel.Achievements;

namespace SocialGoal.Model.Models
{
    public class Metric
    {
        public int MetricId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }

    }

    //new Metric { Type ="%"},
    //new Metric { Type ="$"},
    //new Metric { Type ="$ M"},
    //new Metric { Type ="Rs"},
    //new Metric { Type ="Hours"},
    //new Metric { Type ="Km"},
    //new Metric { Type ="Kg"},
    //new Metric { Type ="Years"}
}
