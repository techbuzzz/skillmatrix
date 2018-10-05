using System.Data.Entity.ModelConfiguration;
using SkillMatrix.DomainModel.Base;

namespace SkillMatrix.Data.Configurations.Entity
{
    public class BaseEntityConfiguration : EntityTypeConfiguration<BaseEntity>
    {
        public BaseEntityConfiguration()
        {
            HasRequired(c => c.CreatedBy).WithMany().HasForeignKey(c => c.CreatedById);
            HasRequired(c => c.UpdatedBy).WithMany().HasForeignKey(c => c.UpdatedById);
        }
    }
}