using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DomainModel.Organisation
{
    public class DepartmentOwner: Owner
    {
        public string DepartmentId { get; set; }
    }
}
