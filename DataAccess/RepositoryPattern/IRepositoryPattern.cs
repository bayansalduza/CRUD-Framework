using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryPattern
{
    public interface IRepositoryPattern<T> where T : class
    {
        //Türkce anlamı ile "Depo Kalıbı" olan RepositoryPattern sınıfının classı. CRUD işlemlerini
        //tanıtırken interface class türünden yararlanmamız standartlara uyma ve katmanlı tasarıma uygun olmasını sağlıyor.
        void Add(T entity); //Ekleme methodunu tanıttık, generic type.
        void Delete(T entity); //Silme methodunu tanıttık, generic type.
        T Get(int id); //Bir key yardımı ile veri getiren getirme methodunu tanıttık, generik tipte,
        // int bir parametre istiyor, generic type.
        void Update(T entity); //Güncelleme methodunu tanıttık, generic type.
        IEnumerable<T> GetAll(Expression<Func<T, bool>> condition); //Linq tasarımı ile geriye birden fazla değer 
        //döndürmesini amaçladığımız methodu tanıttık, generic type.
    }
}
