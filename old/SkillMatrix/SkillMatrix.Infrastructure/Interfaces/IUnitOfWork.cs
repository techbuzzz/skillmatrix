using System.Threading.Tasks;

namespace SkillMatrix.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        Task<int> CommitAsyncWithStatus();
    }
}