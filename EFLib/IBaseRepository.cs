using EFlib.Entites;

namespace EFlib
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IDbSet<T> GetDbSet();
        IDbSet<T> GetContext();
    }
}