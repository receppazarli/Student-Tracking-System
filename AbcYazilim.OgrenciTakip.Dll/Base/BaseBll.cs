using System;
using AbcYazilim.OgrenciTakip.Dll.Interfaces;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using AbcYazilim.Dal.Interfaces;
using AbcYazilim.OgrenciTakip.Dll.Functions;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Common.Functions;
using AbcYazilim.OgrenciTakip.Common.Messages;
using AbcYazilim.OgrenciTakip.Model.Entities;

namespace AbcYazilim.OgrenciTakip.Dll.Base
{

    // Bll katmanında Dal katmanından gelen verileri alıp user interface katmanına göndericez user dan gelenler de dal katmanına göndericez tabi bu sırada da çeşitli kontroller yapılacak.
    //Biz burada select insert delete update burda yapılacaklar base olanlar olucak ve her kart için bir tane bll olucak.

    public class BaseBll<TEntity, TContext> : IBaseBll where TEntity : BaseEntity where TContext : DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<TEntity> _uow;

        // protected olarak erişim belirteçi belirledik çünkü sadece bu alanlara basebll implemente eden class'lardan ulaşıcaz.
        protected BaseBll() { }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        protected TResult BaseSingle<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            // Neden böyle birşeye ihtiyaç duyuyoruz. Şimdi bizim özellikle yöntetim modulünde olsun bizim kendi öğrencitakip programımızda olsun
            // Giriş yaparken sık sık connectionString değişecek bizim de her zaman güncel connnect e ihtiyacımız olacak bu nedenle bu fonksiyonu yaptık.
            // GeneralFunctonda tanımladık .
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _uow); // burda birtane unitofWork create etmiş olduk.
            return _uow.Rep.Find(filter, selector);
        }

        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector)
        {
            // Burda yine createofunitofwork oluşturucaz yani createofworkun intance sını alıcaz. Select insert update ve delete için birer instance alıcazki hep güncel instancelarla 
            // ve güncel connect lerle işlem yapmış olalım
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _uow);
            return _uow.Rep.Select(filter, selector);
        }

        protected bool BaseInsert(BaseEntity entity, Expression<Func<TEntity, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _uow);
            // validation işlemlerini yaptığımız kod bloğu buraya gelicek şuanda yapmıyoruz ama yeri burası

            // Burda şöyle bir durumuuz ortaya çıkıyor biz proje içerisinde entitylerle yapacağımız işlemleri direkt entity nin kendisiyle yapmıycaz 
            // Tüm işlemleri insert update vb. çok büyük bir bölümünde data tranfer objectleri kullanıcaz data transfer object lerle işlemleri yapıcaz
            // Sonra data transfer objectleri buraya göndericez ondan sonra buraya gelen data transfer obejctleri convert işlemine tabi tutarak  
            // Bizim normal entitylerimize çevirip ve o entityi repository katmanına gönderip ordan database e göndericez
            // Normal şartlarda data transferleri objectleri repositorye gönderemeyiz hata verir.
            // Hata vermemsi için convert işlemi yapıp ondan sonra repository e göndericez.
            _uow.Rep.Insert(entity.EntityConvert<TEntity>());

            return _uow.Save();
        }

        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<TEntity, bool>> filter)
        {



            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _uow);
            // Validation
            var degisenAlanlar = oldEntity.DegisenAlanlariGetir(currentEntity);
            // Ancak burda şöyle bir durum var değişen alanları getir ama değişen alan yoksa
            // Yani burası count olarak list of string olduğu için bir listofString listesi döndürecek ve bunun adetini sayısını alabiliriz.
            // Peki buraya gelen listofString in adeti listedeki kayıt sayısı 0 ise bir control koymamız lazım.
            if (degisenAlanlar.Count == 0) return true; // true olmasının sebebide kayıt yapmış gibi geri değer döndürmemiz lazım aksi takdirde false dönerse kaydet e bastık kayıtla ilgili hata 
            // olmuşta kayıt olmamış gibi bir durum oluyor.
            _uow.Rep.Update(currentEntity.EntityConvert<TEntity>(), degisenAlanlar);
            return _uow.Save();
        }

        // Bir tane enum tanımlıcaz çünkü silinmesi durumunda hangi kartın silindiğini yakalamamız lazım.

        protected bool BaseDelete(BaseEntity entity, KartTuru kartTuru, bool mesajVer = true) // burda mesaj ver bool değer koymamızın sebebi ise bazı durumlarda mesaj vericez bazende mesaj vermicez genel mesajla onaylama alınack
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _uow);
            if (mesajVer)
            {
                if (Messages.SilMesaj(kartTuru.ToName()) != DialogResult.Yes) return false;
            }
            _uow.Rep.Delete(entity.EntityConvert<TEntity>());
            return _uow.Save();
        }

        protected string BaseYeniKodVer(KartTuru kartTuru, Expression<Func<TEntity, string>> filter
           /* Expression<Func<Ilce, bool>> expression*/, Expression<Func<TEntity, bool>> @where = null)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _uow);
            return _uow.Rep.YeniKodVer(kartTuru, filter, where);

        }



        #region Dispose

        public void Dispose()
        {
            _ctrl?.Dispose();
            _uow?.Dispose();
        }
        #endregion
    }
}