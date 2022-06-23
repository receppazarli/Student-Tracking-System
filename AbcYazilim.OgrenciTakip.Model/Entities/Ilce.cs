using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;

namespace AbcYazilim.OgrenciTakip.Model.Entities
{
    public class Ilce : BaseEntityDurum
    {
        // burda unique false yaptık çünkü her ilçe kendi içinde 0 dan başlıcak.
        [Index("IX_Kod",IsUnique = false)]
        public override string Kod { get; set; }

        [Required,StringLength(50)]
        public string IlceAdi { get; set; }
        public long IlId { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }

        // İlçenin ile bağlı olduğunu söyledik İlçe ile il arasında bir relation oluşturduk. 
        // Magration işlemi yapılırken il adındaki propertyi yukarıda arıyacak bir realiton oluşturması gerektiğini anlıyor ve sonuna alıoyr Id ekliyor.Bunu bellekte yapıyor.
        // IlId bir alan oluşuyor. Sonra IlId diye alan var mı dolaşıyor. Eğer varsada Il ve Ilce yi birbirine bağlıyor.
        public Il Il { get; set; }
    }
} 