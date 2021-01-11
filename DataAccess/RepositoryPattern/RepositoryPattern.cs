using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace DataAccess.RepositoryPattern
{
    public class RepositoryPattern<T> : IRepositoryPattern<T> where T : class
    {
        //Interface'imizden kalıtım aldırdık ve interface'de method gövdesi yazılmadığı için burada
        //method gövdelerini oluşturduk.
        private DbContext _context; //Database içeriği oluşturduk, !!-entity tipinde değil-!!
        private DbSet<T> _dbset; //Database'de işlem yapmamızı sağlayacak generic dbset'imizi oluşturduk.
        public RepositoryPattern(DbContext context) //Dependency Injection uyguladık classın constructor(yapıcı method).
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public void Add(T entity) //CRUD işlemlerinin method gövdelerini oluşturduk.
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public T Get(int id)
        {
            return _dbset.Find(id);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> condition)
        {
            return _dbset.Where(condition).ToList();
        }
    }
}
