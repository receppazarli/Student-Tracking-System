using AbcYazilim.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Common.Functions;

namespace AbcYazilim.Dal.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Variables

        // yerel bir değişken olduğu için ' _ ' isimlendirme yaparken bu işareti kullanıyoruz.
        // Readonly bir tip teki değişken sadece okunabilir veri ataması olmaz 2 tane durum dışında
        // Bu değişkenlere değer atama sadece 2 şekilde olur bir oluşturduğun anda = koyup null demek mesela
        // veya ilgili classın contructor unda atama yapılabilir.
        private readonly DbContext _context; //  readonly sadece okunabilir bir değişken yani buna değer atayamayız. birde bu context database i temsil ediyor.
        private readonly DbSet<T> _dbSet; // Buda Entityleri temsil ediyor.  

        #endregion
        public Repository(DbContext context)
        {
            if (context == null) return;
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Insert(T entity)
        {
            _context.Entry( entity).State = EntityState.Added;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
        }
        public void Update(T entity)
        {
            _context.Entry(entity: entity).State = EntityState.Modified;
        }

        public void Update(T entity, IEnumerable<string> fields)
        {
            _dbSet.Attach(entity: entity); // Hangi entityle çalışacağımız bildirdik.
            var entry = _context.Entry(entity: entity); // entity nin fields ları arasında update işlemi yapacağımız belirtiyoruz.
            foreach (var field in fields)
            {
                entry.Property(propertyName: field).IsModified = true;
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity: entity).State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            _context.Entry(entity: entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity: entity).State = EntityState.Deleted;
            }
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null
                ? _dbSet.Select(selector: selector).FirstOrDefault()
                : _dbSet.Where(predicate: filter).Select(selector: selector).FirstOrDefault();
        }

        // IQueryable demek Sql kodu hazırla demek. bu func ı çalıştırıp gelen filtre ve selecttor u baz alıp sql kod hazırlıcal ama henüz bu kod sql e gidip çalıştırılmamış olacak
        // ancak biz daha sonra bu kodun sonunda to list vb. func kullanırsak servera gidecek ordaki select işlemini yapacak ve geriye değer döndürecek.
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {

            return filter == null ? _dbSet.Select(selector: selector) : _dbSet.Where(predicate: filter).Select(selector: selector);
        }

        public string YeniKodVer(KartTuru kartTuru, Expression<Func<T, string>> filter, Expression<Func<T, bool>> @where = null)
        {
            string Kod()
            {
                string kod = null;
                var kodDizi = kartTuru.ToName().Split(' ');

                for (int i = 0; i < kodDizi.Length - 1; i++)
                {
                    kod += kodDizi[i];

                    if (i + 1 < kodDizi.Length - 1)
                    {
                        kod += " ";
                    }
                }

                return kod += "-0001";
            }

            string YeniKodVer(string kod)//06Okul-0001
            {
                var sayisalDegerler = "";
                foreach (var karakter in kod) // 0001
                {
                    if (char.IsDigit(karakter))
                    {
                        sayisalDegerler += karakter;
                    }
                    else
                    {
                        sayisalDegerler = "";
                    }
                }

                var artisSonrasiDeger = (int.Parse(sayisalDegerler) + 1).ToString(); //00049  // 50
                var fark = kod.Length - artisSonrasiDeger.Length;
                if (fark < 0)
                {
                    fark = 0;
                }

                var yeniDeger = kod.Substring(0, fark);
                yeniDeger += artisSonrasiDeger; // Okul-0050

                return yeniDeger;
            }

            // Yukarıdan gelen where null ise yani where ile bir sorgu gönderilmemişse  dbset ten max yap 
            // Bölye değilse dbset where varsa where i göndereceksin 
            // Ondan sonrada maxi götürüceksin filteri verip bize arttırılmış olaraka kodu geri vereceksin.
            var maxKod = where == null ? _dbSet.Max(filter) : _dbSet.Where(where).Max(filter);

            return maxKod == null ? Kod() : YeniKodVer(maxKod);
        }

        #region Dispose

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(obj: this);
        }

        #endregion
    }
}