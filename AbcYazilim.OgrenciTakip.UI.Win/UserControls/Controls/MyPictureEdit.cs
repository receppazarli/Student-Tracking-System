using System.ComponentModel;
using System.Drawing;
using AbcYazilim.OgrenciTakip.UI.Win.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(defaultType: true )]
    public class MyPictureEdit : PictureEdit, IStatusBarKisaYol
    {
        public MyPictureEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.Appearance.ForeColor = Color.Maroon; // REsim olmadığı zaman orada görünceke yazının rengi
            Properties.NullText = "Resim Yok"; // Resim olmadığında yazıcak yazı
            Properties.SizeMode = PictureSizeMode.Stretch; // Resim eklediğimiz anda otomatik onu pictureedit'e yazıcak
            Properties.ShowMenu = false; // resim için yakınlaştır küçült büyült tarzında bir menü geliyor onu kapatıyoruz bu menü yü kendimiz yazıcaz.
        }

        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
    }
}