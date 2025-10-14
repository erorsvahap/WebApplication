using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); // tüm kayıtları getir
        T GetById(int id); // ıdye göre kayıt getir
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save(); // basit kullanım için
    }
}
