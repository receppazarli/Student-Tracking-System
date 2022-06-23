using System;
using System.ComponentModel;

namespace AbcYazilim.OgrenciTakip.Common.Functions
{
    public static class EnumFunctions
    {
        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            
            if (value == null) return null;
            // Burda 1 tane enum göndericez ve bu enum ın attribute lerine ulaşıcaz ve member üyerlerini dolaşarak bu üyelerinden description larına ulaşıcaz ve gerekli value lere ulaşıcaz.  
            var memberInfo = value.GetType().GetMember(value.ToString());
            // Burda memberınfo her ne kadar dizi olsa bile biz gelecek üyenin 1 tane oladuğunu biliyoruz ve dizi olduğu için 0. indexsini alıyoruz.
            // Alacağımız zamanda type istiyor T yi veriyoruz. false kısmı ise bize inherit ettiği member larıda alayımmı bizde false diyoruz.
            var attribute = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attribute[0];
        }

        public static string ToName(this Enum value)
        {
            if (value == null) return null;
            // Gelen value nın attribut unde dolaş gelen description tipinde olan value geri gönder.
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;

        }
    }
}