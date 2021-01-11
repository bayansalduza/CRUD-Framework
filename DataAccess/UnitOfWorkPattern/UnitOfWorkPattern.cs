using Data.Database;
using DataAccess.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorkPattern
{
    public class UnitOfWorkPattern : IUnitOfWorkPattern
    {
        private DbContext _context;
        public UnitOfWorkPattern(DbContext context) 
        {
            _context = context;
        }
        public UnitOfWorkPattern() //Constructer'ına oluşturduğumuz DbContext'i entity olarak tanıttık.
        {
            _context = new dataEntities();
        }
        public void Dispose() //Dispose işleminin method gövdesi.
        {
            _context.Dispose();
        }
        public IRepositoryPattern<T> RepositoryPattern<T>() where T : class //RepositoryPattern classımıza
        {//ulaşmak için yazdığımız kodun method gövdesi.
            return new RepositoryPattern<T>(_context);
        }

        public int Save() //Save methodunun method gövdesi.
        {
            return _context.SaveChanges();
        }
    }
}
