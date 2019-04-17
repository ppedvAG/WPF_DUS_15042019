using System.Linq;

namespace ppedv.HalloSerien.Model.Contracts
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;

        T GetById<T>(int id) where T : Entity;
        IQueryable<T> Query<T>() where T : Entity;

        int SaveAll();
    }
}
