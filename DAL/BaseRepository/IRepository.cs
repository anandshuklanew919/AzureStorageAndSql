
namespace DAL.BaseRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        void Delete(TEntity model);
        void DeleteById(object Id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object Id);
        void Modify(TEntity model);
        void Update(TEntity model);
        void DetachEntity(TEntity model);
    }
}