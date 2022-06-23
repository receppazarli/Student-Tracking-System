using System.ComponentModel.DataAnnotations.Schema;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;

namespace AbcYazilim.OgrenciTakip.Dll.Dto
{



    // Classın adını değiştirdik OkulS yaptık S Select anlamına geliyor bide OkulL yapıcaz ordaki L de List anlamında.
    //[NotMapped] // Bu attribute bu alanları da okulun alanı gibi görüp tabloyu oluşturuken bu alanlarıda kolonlara yazamasın diye yapıyoruz. Ben şuan yoruma alıcam onu çünkü otomatik olarak almıyor zaten.
    public class OkulS : Okul
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }

    }

    public class OkulL : BaseEntity
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }

    }
}