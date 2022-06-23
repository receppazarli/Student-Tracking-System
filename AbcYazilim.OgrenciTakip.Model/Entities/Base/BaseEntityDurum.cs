namespace AbcYazilim.OgrenciTakip.Model.Entities.Base
{
    public class BaseEntityDurum : BaseEntity
    {
        // Durum olduğu zamanlar da direk bunu implemente ediyoruz. Eğer durum lazım değilsede Base Entity kullanıcaz gereken yerde 
        public bool Durum { get; set; } = true;// Burda durumu true olarak ayarladık çünkü yeni bir kayıt eklemek istediğimizde defautl olarak false geliyor yani
        // pasif kart olarak alıyor biz bunu istemiyoruz o yüzden true yapıp aktif kart olarak gelmesini sağlıyoruz. 
    }
}