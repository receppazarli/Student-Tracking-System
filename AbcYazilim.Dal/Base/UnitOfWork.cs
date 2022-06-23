using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Text;
using AbcYazilim.Dal.Interfaces;
using AbcYazilim.OgrenciTakip.Common.Messages;

namespace AbcYazilim.Dal.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        #region Variables

        private readonly DbContext _context;

        #endregion

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        public IRepository<T> Rep => new Repository<T>(_context); // Unit of workten Repositortye rahat bir şekilde ulaşım sağladık.



        public bool Save()
        {
            try
            {
                //try
                //{

                //    _context.SaveChanges();
                //}
                //catch (DbEntityValidationException e)
                //{
                //    foreach (var eve in e.EntityValidationErrors)
                //    {

                //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //                ve.PropertyName, ve.ErrorMessage);
                //        }
                //    }
                //    throw;
                //}

                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    Messages.HataMesaji(ex.Message);
                    return false;
                }

                // Yukarıda gelen hatanın sayısını alıyor ona göre de aşağıda işlem yaptırıyoruz.
                switch (sqlEx.Number)
                {
                    case 208: // 208 Sql hatası veritabanında istenilen tablonun bulunamaması durumunda çıkıyor.
                        Messages.HataMesaji("İşlem Yapmak istediğiniz Tablo Veritabanında bulunamadı.");
                        break;
                    case 547:
                        Messages.HataMesaji("Seçilen Kartın İşlem Görmüş Hareketleri Var Kart Silinemez.");
                        break;
                    case 2601:
                    // bu ikiside birbirine yakın hatalar olduğu için bu şekilde alt alta yazdık aynı mesajı döndürüyolar.
                    case 2627:
                        Messages.HataMesaji("Girmiş Olduğunuz Id Daha Önce Daha Önce Kullanılmıştır.");
                        break;
                    case 4060: // Çok çok nadir bir durum ama yaptık  
                        Messages.HataMesaji("İşlem Yapmak İstediğiniz Veritabanı Sunucuda Bulunamadı.");
                        break;
                    case 18456:
                        Messages.HataMesaji("Server'a bağlanılmak İstenilen Kullanıcı Adı Veya Şifre Hatalıdır.");
                        break;
                    default:
                        Messages.HataMesaji(sqlEx.Message);
                        break;

                }

                return false;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }



            return true; // eğer hata alıp catch'e düşerse hata alıcak zaten düşmesse de true döndürücek.   

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
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}