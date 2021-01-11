using DataAccess.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorkPattern
{
    public interface IUnitOfWorkPattern : IDisposable //Disposable özelliği verdik uygulamanın daha verimli çalışması
    {    //ve bellekteki işini bitirince belleği temizlemesi için.
    
        IRepositoryPattern<T> RepositoryPattern<T>() where T : class; //UnitOfWork üzerinden RepositoryPattern
        //classımıza ulaşmak için yazdığımız satır.
        int Save(); //CRUD işlemlerini save'lemek (veri tabanına işlemek) için kullandığımız method.
    }
}
