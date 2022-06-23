using System.ComponentModel.DataAnnotations;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbcYazilim.OgrenciTakip.Model.Entities
{
    public class Okul : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50)]
        public string OkulAdi { get; set; }
        public long IlId { get; set; }
        public long IlceId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }


        // aralarında ilişki kuruyorum ilce detaylı açıkladım
        public Il Il { get; set; }

        // Bu şekilde foreignKey de yapıp kullanabiliriz o zaman verilen ismin önemi yok paratez içine aramasını istediğin ismi yazdığın sürece [ForeignKey("IlceId")]
        public Ilce Ilce { get; set; }
    }
}