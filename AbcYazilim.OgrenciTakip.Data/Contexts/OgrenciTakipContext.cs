using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Emit;
using AbcYazilim.OgrenciTakip.Data.OgrenciTakipMigration;
using AbcYazilim.OgrenciTakip.Model.Entities;

namespace AbcYazilim.OgrenciTakip.Data.Contexts
{
    public class OgrenciTakipContext : BaseDbContext<OgrenciTakipContext, Configuration>
    {
        public OgrenciTakipContext()  //: base("name=OgrenciTakipContext") bu ilemi iptal ettik çünkü baseDbContext te bu iþlemi yaptýk.
        {
            // Þimdi burda okul entity sini düþün orda baz prop lar var bu proplarý select yaparken bunlar gelicek ama içinde Il Il ve Ilce Ilce þeklinde de prop larým olduðu için
            // bütün illeri ve ilçeleri getirmek isticek. Buda bana yavaþlatma kazandýrýcak bu yüzden bu iþlemi false yapýyorum.
            // Performans kaybýna sebeb oluyor ve select iþleminin uzun sürmesine sebeb oluyor.
            Configuration.LazyLoadingEnabled = false;
        }

        // bu constuctor un anlamý ise basedb çalýþtýðý anda bu constructoruda çalýþtýrsýn diye
        public OgrenciTakipContext(string connectionString) : base(connectionString: connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // PluralizingTableNameConvention iþlemi database e bizim entity lerimizi çoðul ek alarak gitmesini saðlýyor ama biz burda bunu istemiyoruz o yüzden onu siliyoruz.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 1 e çok iliþkili tablolarda mesela il ilçe tablosu ben bursayý sildim otomatik bursanýn ilçeleride gidiyor ama ben aþaðýdaki iþlemi silerek bunu engelledim.
            // bu iþlemi heryere deðil bazý yerlerde özel tanýmlamalar yapýcaz.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // yukarýdakinin aynýsý çok a çok tablolarda
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        #region DbSet<>

        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }

        #endregion
    }
}

