using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.DomainModel.Personalize
{
    public class Favourite: BaseEntity
    {
        public string AccountId { get; set; }
    }
}
