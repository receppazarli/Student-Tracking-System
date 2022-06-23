using System;
using System.Linq;
using AbcYazilim.OgrenciTakip.Model.Entities.Base.Interfaces;

namespace AbcYazilim.OgrenciTakip.Dll.Functions
{
    public static class Converts
    {
        // Burda 2 tane entitye ihtiyacımız var doğal olarak 1 tanesi kaynak entity diğeride hedef entity
        // Biz burda mantık olarak nasıl işlem yapıcaz.
        // Kaynak entitye bir tane kaynak entity gelicek ve o entity nin propertiy leri arasında dolaşıcaz.
        // Ve o property leri  hedefteki entity'nin property lerıyla karşılaştırıcaz.
        // Eğer aynı isimdeyse kaynaktaki value alıp hedefteki property in value sine atıcaz.

        // Biz burdaki function ları Extension olarak tanımlıcaz onun içinde Hem oluşturduğumuz class ın hemde oluşturuacağımız function ın static olması lazım.
        // Aynı zamanda function lara vermiş olduğumuz ilk değişkenin de this ile tanımlanmış olması lazım . Bu 3 şartın hepsinin olasmı laızm.

        // IBaseEntity den tanımladık çünkü mutlaka bir tane ordan kaynak gelicek.
        // Eğer bu şekilde yapmazsaydık bütün entityler için ayrı ayrı convet işlemi yapmamız gerekirdi.
        public static TTarget EntityConvert<TTarget>(this IBaseEntity source)
        {
            // burda return null olarak kabul etmiyor bu yüzden  default(TTarget) göndericez.
            if (source == null) return default(TTarget);

            // Kaynaktan alıcağımız veriyi hedefe göndericez ancak henüz bir hedefimiz yok yani hedef entity yok
            // Doğal olarak Bu TTarget ten bir instance üreticez ve bir hedef entity miz olsun.
            var hedef = Activator.CreateInstance<TTarget>(); // TTarget türünden 1 tane hedef entity ürettik.

            // Şimdi hem kaynak entitylerimiz property lerine hemde hedef entitylerimizin property lerine ulaşmamız lazım 
            // Bunuda Reflection yoluyla yapabiliriz.

            var kaynakProp = source.GetType().GetProperties(); // Burda reflection yoluyla kaynak entitylerimizin property lerine ulaşmış olduk.
            var hedefProp = typeof(TTarget).GetProperties(); // Burda da reflection la hedefProp'un özelliklerine ulaşıyoruz. 

            // entitylerini propertyleri arasında dolaşıcaz.
            foreach (var kp in kaynakProp)
            {
                var value = kp.GetValue(source);
                var hp = hedefProp.FirstOrDefault(x => x.Name == kp.Name);
                if (hp != null)
                {
                    // bu şekilde tırnka yapmamızın sebebi Gelen değer "" işareti olarak geliyorsa onu veri tabanına öyle yazma onun yerine null yaz "" gelmiyorsada gelen değeri at
                    hp.SetValue(hedef, ReferenceEquals(value, "") ? null : value);
                }
            }

            return hedef;
        }
    }
}