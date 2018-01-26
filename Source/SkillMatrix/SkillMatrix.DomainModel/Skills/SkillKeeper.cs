﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.DomainModel.Organisation;

namespace SkillMatrix.DomainModel.Skills
{
    public class SkillKeeper: Owner
    {
        public string SkillId { get; set; }
        public decimal Ratio { get; set; }
    }
}
