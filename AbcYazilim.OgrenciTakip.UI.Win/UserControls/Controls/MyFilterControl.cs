using System.ComponentModel;
using AbcYazilim.OgrenciTakip.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(defaultType: true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            ShowGroupCommandsIcon = true; // Bir grupla ilgili filtreleme yaparken o grupla ilgili imagın çıkmasını sağlıyor. 3 nokta işareti olan ikon var onun gelmesini sağlıyor. 
        }

        public string StatusBarAciklama { get; set; } = "Filtre metni Giriniz.";
    }
}