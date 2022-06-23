using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using AbcYazilim.OgrenciTakip.Common.Enums;

namespace AbcYazilim.Dal.Interfaces
{
    // Dispos bir interface implement ettik buda bu interfaci implemente eden classlar IDispoable da implemente ediyor böylece kullanılan class ın işlemi bittiği zaman direk hafızadan atılıyor.
    // Hafıza yer kaplaması önleniyor.
    public interface IRepository<T> : IDisposable where T : class
    {
        void Insert(T entity); // Tek entity gelmesi durumu
        void Insert(IEnumerable<T> entities); // birdne çok entity gelme durumu
        void Update(T entity);// Bu direk bütün verileri update etme
        void Update(T entity, IEnumerable<string> fields); // Bu ise gönderdiğim entit nin değişen alanları güncelleme yapacak.
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);

        // Bu şekilde TResult yazmamız önüne Tresult döndürücek anlamına geliyor.
        // bunu yapmamızın sebebide ne döndüreceğini bilmediğimiz için ondan istiyecez 
        // burda T tipinde sorgu gönderiyorum oda bana true yada false döndücek. 
        // T tipinde sorgu göndericez eğer true gelirse yani value varsa o zaman biz bu value geri gönder hangi tip olduğunuda sorgulama aşamasında gönder 
        // selector ün mantığıda gelen kayıtların arasında çeşitli filtrelemeler  yapıp istedilerimizi seçip geri gönderecek 
        TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);

        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);


        string YeniKodVer(KartTuru kartTuru, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null);
    }
}