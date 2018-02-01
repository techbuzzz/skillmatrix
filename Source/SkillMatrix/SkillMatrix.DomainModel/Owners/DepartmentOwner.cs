using SkillMatrix.DomainModel.Organisation;

namespace SkillMatrix.DomainModel.Owners
{
    public class DepartmentOwner: Owner
    {
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }

    }
}
