using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbcYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace AbcYazilim.OgrenciTakip.Model.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        // bu colum attribute u programı çalıştırdığımda database oluşturulduğu anda property leri sıralamaya yarıyor. burda yaptıklarımda Id 0. olarak yani 1 Kod kısmıda 2. olarak gelecek.
        // Key yazarakta Id nin primary key olduğunu belirledik.
        // 3. kısımda create database yaptıktan sonra Id lerin hepsini otomatik olarak 1'er 1'er artan sayılar yapıyor. Biz bunu istmiyoruz o yüzden bunu kappattık.
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        // Required null geçilemez anlamında
        // 3.kısımda da kod için harf sınırlaması yaptık.
        [Column(Order = 1), Required, StringLength(20)]
        public virtual string Kod { get; set; }

        // Not : Database'i oluşturup ondan sonra key yapma lenght belirtme özellikleri katıp açma gibi bazı işler gerçekleşmeyebilir. Databasi oluşturmadan önce bu işlemleri yaptıktan sonra
        // database'i oluşturursak istediğimiz değişikliklerin hepsi gerçekleşmiş bir halde gelir database miz.
    }
}