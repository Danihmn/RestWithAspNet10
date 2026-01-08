using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Data.Context;
using RestWithAspNet10.Models.Base;
using Serilog;

namespace RestWithAspNet10.Repositories.Implementations
{
    public class RepositoryImplementation<T> : IRepository<T> where T : ModelBase
    {
        protected MsSqlContext _context;
        private DbSet<T> _dataSet;

        public RepositoryImplementation (MsSqlContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public List<T> FindAll ()
        {
            return _dataSet.ToList();
        }

        public T FindById (long id)
        {
            return _dataSet.Find(id);
        }

        public T Create (T item)
        {
            var createditem = _context.Add(item).Entity;

            _context.SaveChanges();

            return createditem;
        }

        public T Update (T item)
        {
            try
            {
                var existingItem = _dataSet.Find(item.Id);

                if (existingItem == null) Log.Error("Item não encontrado, falha ao tentar alterar");

                _dataSet.Entry(existingItem).CurrentValues.SetValues(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception e)
            {
                Log.Error("Falha ao tentar alterar item: " + e.Message);
                return null;
            }

        }

        public void Delete (long id)
        {
            var existingItem = _dataSet.Find(id);

            if (existingItem == null) Log.Error("Item não encontrado, falha ao tentar excluir");

            _dataSet.Remove(existingItem);
            _context.SaveChanges();
        }

        public bool Exists (long id)
        {
            return _dataSet.Any(e => e.Id == id);
        }
    }
}
