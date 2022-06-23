using System.ComponentModel;
using System.Drawing;
using AbcYazilim.OgrenciTakip.UI.Win.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(defaultType: true)]
    public class MyCalcEdit : CalcEdit,IStatusBarKisaYol
    {
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False; //Bu alanın null geçilmemesi için bu şekilde bir tanımlama yapıyoruz.
            Properties.EditMask = "n2"; // Burda maskeleme işlemi yaptık virgülden sonra 2 tane 0 koyucak kuruş girebilmek için bu işlemleri direk calcedit'in üstünde change mask diyerekte yapabiliriz.

        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Hesap Makinesi";
    }
}