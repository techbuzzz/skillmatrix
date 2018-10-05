using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.Infrastructure.Interfaces;
using SkillMatrix.Repository;

namespace SkillMatrix.Service
{
    public interface ISkillService
    {
    }


    public class SkillService: ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISkillRepository _skillRepository;


        public SkillService(IUnitOfWork unitOfWork, ISkillRepository skillRepository)
        {
            _unitOfWork = unitOfWork;
            _skillRepository = skillRepository;
        }
    }

   
}
