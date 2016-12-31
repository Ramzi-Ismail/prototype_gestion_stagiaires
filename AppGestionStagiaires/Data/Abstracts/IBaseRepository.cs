using Cplus.Entites;
using System.Data.Entity;

namespace Cplus
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IDbSet<T> GetDbSet();
        IDbSet<T> GetContext();
    }
}