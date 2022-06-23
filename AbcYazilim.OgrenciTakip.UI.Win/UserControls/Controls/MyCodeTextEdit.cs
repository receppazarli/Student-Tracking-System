using System.CodeDom;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(defaultType: true)]
    public class MyCodeTextEdit : MyTextEdit
    {
        public MyCodeTextEdit()
        {
            Properties.Appearance.BackColor = Color.PaleGoldenrod;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaxLength = 20;
            StatusBarAciklama = "Kod Giriniz.";
        }
    }
}