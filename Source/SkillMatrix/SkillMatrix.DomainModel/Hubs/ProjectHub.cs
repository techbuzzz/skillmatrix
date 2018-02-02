using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Projects;

namespace SkillMatrix.DomainModel.Hubs
{
    public class ProjectHub: Hub
    {
        public string ProjectId { get; set; }


        public virtual Project Project { get; set; }

    }
}
