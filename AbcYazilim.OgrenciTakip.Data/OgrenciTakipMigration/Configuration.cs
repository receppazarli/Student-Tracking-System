using System.Data.Entity.Migrations;
using AbcYazilim.OgrenciTakip.Data.Contexts;

namespace AbcYazilim.OgrenciTakip.Data.OgrenciTakipMigration
{
    // bunu yapmamızın amacı yaptığımız baseDbContext te parametre olarak bir configration istiyoruz o cofig i burda ayarlıycaz.
    public class Configuration : DbMigrationsConfiguration<OgrenciTakipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;  // Migrations işlemlerini otomatik yap demek
            AutomaticMigrationDataLossAllowed = true; // Buda işlem yaparken  veri kaybı olması durumu olucaksa bunada izin veriyoruz.
            // Veri kaybı hangi durumlarda olur komple satır mı silinir nasıl olur
            // o şekilde direk bir veri kaybı değil  
            // long tipinde bir alanım olsun bunu daha sonra geldim it tipine dönüştürdüm long tipinde ayarlıyken bir veri varsa 
            // long tan int e dönüştürürken bir veri kaybı yaşanabilir. Veri tabanında veri varsa yoksa direk dönüştürücek.
            // eğer veri varsa değiştirirken hata çıkıcak ben true yapmasaydım işlemi yapmıcaktı ama şimdi işlemi yapıcak.

        }
    }
}