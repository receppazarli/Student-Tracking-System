using System.ComponentModel;
using System.Drawing;
using AbcYazilim.OgrenciTakip.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    public class MyTextEdit : TextEdit, IStatusBarKisaYol
    {
        [ToolboxItem(defaultType: true)]
        public MyTextEdit()
        {
            // burda tanımladığım özellikler default değer olarak gelicek istersem bunları companenti kullandığım zaman değiştirebilicem.
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.MaxLength = 50;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
    }
}
