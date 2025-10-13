using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataEF
{
    public class MyDataManager<T> where T : MyProjectEntity
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public MyDataManager()
        {
            _context = new MyDbContext(); //dbcontext bagka
            _dbSet = _context.Set<T>(); //  eritabnı tablosuna erisim
        }


        public void Insert(T entity)
        {

            _dbSet.Add(entity); // rkle
            _context.SaveChanges(); /// kaydet

        }

        // hatasız calsııyor ama ıd yoksa hata alıyorum 
        public void Delete(T entity)
        {
            _dbSet.Attach(entity); // ? ef de  talıbe al yani hangi kolon hangi tablo falan ne yapcagını bıl demek
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {

            var entity = _dbSet.Find(id);// Veritabanından nesneyi çek

            if (entity != null)
            {
                _dbSet.Remove(entity); // sil
                _context.SaveChanges(); // kaydet
            }
            //else
            //{
            //    Console.WriteLine("Silinecek nesne veritabanında bulunamadı.");
            //}
        }
        public void Update(T entity) // BUARADA DEFAULT BUTUN TABLOLARI VERMEZSEM HATA ALIYORUM 
        {
            var dbEntity = _dbSet.Find(entity.Id); // Veritabanındaki mevcut kayıt
            if (dbEntity != null)
            {

                _context.Entry(dbEntity).CurrentValues.SetValues(entity); //fark olan yerleri güncelle ama ama her kolonu tek tek belirtmen gerek
                _context.SaveChanges(); // kaydet
            }
        }
        //public void Update(T entity) // BURADA DEAFULTTA BELİRTMEDGIM YERLERİ SIFIR KABUL EDER AMA BAZI NOKRTALARDA BU DURUM HATA MESAJI VERİR 
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}



    }
}
