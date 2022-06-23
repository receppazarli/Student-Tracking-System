using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AbcYazilim.OgrenciTakip.Data.Contexts
{
    // Bu BaseDbContext i Diğer contextlerime implemente edicem bu şekilde yapmamın sebebi Dbcontext teki bazı işllemleri değiştirmek ve yeni işlemler eklemek 
    // Bu şekilde yaparak hepsinde tek tek aynı işlemi yapmaktan kurtuluyorum.
    //Contextimi generic olarak yapıyorum  hangi context olduğunu anlamak için Bir tane context istiyorum, Birde yapacağımız magration işlemlerinde ki configuration ayarları için bir config alıyorum. 
    public class BaseDbContext<TContext, TConfiguration> : DbContext where TContext : DbContext where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        // Bunu yapmamızdaki sebeb contructor a implemente olarak : Base yapıcaz buda bazı parametreler istiyor bizde bunlardan nameOrConnectionString olanı seçicez.
        // Bunu paremetre olarak oraya atmamız için bunun öncelikle static bir yapıda olması lazım.
        // typeof kullanarak yukarıdan generic olarak aldığımız context'i içine attık ve oda bize context in name ini almamızı sağladı.
        // bu değişkeni boş null olarak bırakmamız olmaz sıkıntı olabilir o yüzden bu şekilde default bir değer atıyoruz.
        private static string _nameOrConnectionString = typeof(TContext).Name;

        // Bu construtor u yönetim modelinde database oluştururken ve silerken kullanıcaz diğer işlemler onun altındaki contructor kullanıcak
        // Çünkü constructor kullanırken connectionstring göndericez name ini değil kendisini neden kendisini göndericez
        // Çünkü biz yönetim modelinde sürekli connectionstring imizi değiştiricez 
        // Çünkü bir kere genel database e bağlanırken  onun haricinde gidp oluşturmuş olduğumuz kaç tane kurum varsa herbirinin database ine ayrı ayrı  bağlanıcağımız için connectionstring sürekli değişecek.
        public BaseDbContext() : base(nameOrConnectionString: _nameOrConnectionString) { }

        // bi connectionstring alıcak parametre olarak bunuda base e göndericek.
        // Yukarıdaki ilk oluşturduğumuzda nameorconnectionstring istiyor.
        // burda ise connectionstring in kendisini istiyor.
        public BaseDbContext(string connectionString) : base(nameOrConnectionString: connectionString)
        {
            // Bunun sebebi ben bir entity yazdım sonra database oluşturmasıda yaptım sonra ona bazı yeni properties ekledim. Bu yaptığımız işlem database e gidiyor.
            // Orada properties leri karşılaştırma yapıyor bakıyor bazı properties ler eksik hemen eksik olanları database güncelleme yapıyor.
            Database.SetInitializer(strategy: new MigrateDatabaseToLatestVersion<TContext,TConfiguration>());

            // ilk etapta bunu kullanmıycaz ancak 2. kez yüklenme olduğu zaman gönderdiğimiz connectonstringle çalışmış olacak.
            _nameOrConnectionString = connectionString;
        }
    }
}   