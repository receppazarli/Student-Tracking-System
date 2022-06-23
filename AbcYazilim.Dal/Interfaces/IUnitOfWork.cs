using System;

namespace AbcYazilim.Dal.Interfaces
{
    // Biz verilerimizi ekleme silme güncelleme vb işlemlerde IRepository e gönderiyoruz ama veri tabanına gitmiyor Save işlemimiz yok yani 
    // Bu IUnitOfWork de bize bu işi yapmamızı sağlıyor.
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Rep { get; }
        bool Save();
    }
}