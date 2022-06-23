using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using AbcYazilim.OgrenciTakip.UI.Win.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;


namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(defaultType: true)]
    public class MyToggleSwitch : ToggleSwitch, IStatusBarAciklama
    {
        public MyToggleSwitch()
        {
            Name = "tglDurum"; // Her seferinde 1 tane kullanıcağımız için default olarak ismini böyle atıyoruz.
            Properties.OffText = "Pasif"; // Kapalıyken
            Properties.OnText = "Aktif"; // Açıkkken
            Properties.AutoHeight = false; // Yüksekliği kapattık 
            Properties.AutoWidth = true; // Genişliği açtık çünkü layouta koyduğumuzda otomatik büyüyebilmesi için
            Properties.GlyphAlignment = HorzAlignment.Far; // Text'in neresinde yer alıcağını ayarlıyoruz. Burda solda yer alsın dedik.
            Properties.Appearance.ForeColor = Color.Maroon;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; } = "Kartın Kullanım Durumunu Seçiniz.";
    }
}