using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using AbcYazilim.Dal.Base;
using AbcYazilim.Dal.Interfaces;
using AbcYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace AbcYazilim.OgrenciTakip.Dll.Functions
{
    public static class GeneralFunctions
    {
        public static List<string> DegisenAlanlariGetir<T>(this T oldEntity, T currentEntity)
        {
            List<string> alanlar = new List<string>();
            // currentEntity nin propertyleri arasında dolaşıcaz.
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                // oldentity deki bu propertynin oldentity sini alıyorum.
                // burda 2 tane soru işareti koyuk çünkü 2 tane null değer karşılaştırılamaz bu yüzden string.empty attık içine soru işaretide at anlamına geliyor 
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;   // prop.GetValue(currentEntity) bu alan null değer döndürüyorsa sen current.value string.empty yap demiş olduk. yukarıdakide aynı.

                // property nin 1 byte dizisi olup olmadığınınz kontrolü yapıyoruz.
                // byte sayısal bir alan bunlarıda uzunluklarıyla karşılaştırabiliriz.
                // bir tane kullanıcı kaydı var öğrenci atığı kaydın fotoğrafı yok daha sonra bu fotoğrafa bir fotoğraf ekliyor old da foto olmucak current ta fotoğraf olucak 
                // ilk te boş olduğu için empty olucak yenide de foto olunca byte alanı olucak ve bizimde bu 2 alınıda karşılaştırılması byte alanına çevirmemiz lazım.
                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))
                    {
                        oldValue = new byte[] { 0 };
                    }

                    if (string.IsNullOrEmpty(currentValue.ToString()))
                    {
                        currentValue = new byte[] { 0 };
                    }

                    // burdada karşılaştırmamızı yapıyoruz.
                    // bunlar eşit değilse alanlar listemize bu propertynin ismini eklicek.
                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                    {
                        alanlar.Add(prop.Name);
                    }
                }
                else if (!currentValue.Equals(oldValue))
                {
                    alanlar.Add(prop.Name);
                }
            }

            return alanlar;
        }

        public static string GetConnectionString()
        {
            // config manager sayeseinde connectionstring e ulaşıcak hangi connecte bizim app.configteki OgrenciTakip connectionStringine ine ulaşıcak ordaki value okuyacak ve buraya geri gönderecek.

            return ConfigurationManager.ConnectionStrings["OgrenciTakipContext"].ConnectionString;
        }

        private static TContext CreateContext<TContext>() where TContext : DbContext //,new() buda aşağıdaki koda dahil onu kullanmak için bunu yazmamız gerek.
        {
            // bu şekilde de kullanabiliriz ama parametresiz olur bize parametleri lazım olduğu için bunu kullanmıcaz. yani Tcontext geri giderken connectionString götürmesini istiyoruz.
            // return new TContext();

            // Burda TContexten cast işlemi yaptık sonra CreateInstance a contexti gönderdik ve connection stringide gönderdik.
            // Bir tane TContext diye bir connection string oluşturduk daha doğrusu birdbcontext oluşturduk tipimiz bu olucak dedik typeof lu kısım bizim dbContextimiz oldu.
            // Aynı zamanda bunun bide buna nameorconnection string biz isim göndermiyoruz da connectionstringimizi son halini göndermiş oluyoruz. 
            return (TContext)Activator.CreateInstance(typeof(TContext), GetConnectionString());
        }

        // Aşağıda ref kısmını anlattım where kısımlarında ise TEntity Class olucak ve IBaseEntity den implemente olucak. Tcontext de Db context ten iöplemente olmuş olucak. 
        // Create yapabilmemiz içib birde bize mevcut unit of workun son hali yani referansı lazım  
        public static void CreateUnitOfWork<TEntity, TContext>(ref IUnitOfWork<TEntity> uow) where TEntity : class, IBaseEntity where TContext : DbContext
        {
            // Biz burara unitofworkun son haline yani referansına ulaşacağımız için ilk önce eğer mevcut bir instance varsa onu dispose etmemiz lazım  
            // ? bu işaret nul değilse anlamına geliyor.
            uow?.Dispose();
            uow = new UnitOfWork<TEntity>(CreateContext<TContext>());
        }
    }
}