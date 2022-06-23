using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    public class MyCartEdit : MyTextEdit 
    {
        [ToolboxItem(defaultType: true)]
        public MyCartEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center; // Burda control'ü kullanırken ortasına yazıcak sağa yada sola dayalı bir yazım yapmıcak
            Properties.Mask.MaskType = MaskType.Regular; // Maskemizin tipini seçtik
            Properties.Mask.EditMask = @"\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?"; // maskenin nasıl değer alıcağını yaptık
            Properties.Mask.AutoComplete = AutoCompleteType.None; // otomatik olarak değer atamaması için yaptık ör: kart hanesinin 8 tanesini girdim kalanı nı girmedim onu 0 yapıcaktı artık yapmayacak.
            StatusBarAciklama = "Kart No Giriniz.";

        }
    }
}