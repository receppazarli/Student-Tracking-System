using System;
using System.ComponentModel;
using System.Drawing;
using AbcYazilim.OgrenciTakip.UI.Win.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{

    [ToolboxItem(defaultType: true)] // Bu bir attribute  burda yaptığımız myButtonEdit'i toolbox ta gösterilmesi için işlem yapıyoruz. 
    /*
     * Burda Kendi butonumuz için class oluşturup sonrasında ise ona normalde olan butonun bütün özelliklerini ekledik  ve status barlarımızı interface yapıp onlarıda property olarak ekledik
     * interface yapmamızın sebebi onu diğer companentlerimizde de kullanmak. Her button IStatusBarKisaYol interface ni kullanarak implemente olucak
     */
    public class MyButtonEdit : ButtonEdit, IStatusBarKisaYol
    {

        public MyButtonEdit()
        {
            // Aşağıdaki işlem sayesinde  Button Edit'in text kısmına herhangi bir yazı yazamayız
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan; // Butonun üstüne gelindiğinde renginin değişmesi için.
        }

        //Daah önceden button editte mecvut olan bir işlemi burda override edip istediğimiz işlemi yaptırıyoruz. enter tuşuna bastığımız zaman bir sonraki controle geçicek
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }

        #region Events
        private long? _id;

        [Browsable(browsable: false)] // bu özelliği property de gizlicek.
        public long? Id    // long? =nullable<long> bu şekilde yazmak yerine kısaltılmışını yazdık.
        {

            get => _id; // => işareti return anlamına gelmekte ve süslü paranteze gerek kalmıyor.
            set
            {
                var oldValue = _id;
                var newValue = value;

                if (newValue == oldValue) return; // Yeni değerle eski değer eşitse direk return yapıyor işleme gerek yok.
                _id = value;

                // IdChanged?.Invoke Idchanged boş değilse anlamına geliyor. Invoke da çağır anlamında boş değilse çağır.
                // Bu şekilde if ile yapmak yerinede direk aşağıda eventi eklediğim kısıma =delegate{}; yazıncada oda işimizi görüyor.
                //IdChanged?.Invoke Ben aşağıdaki yeri kullanıcam 54. satırdakini
                IdChanged(sender: this, e: new IdChangedEventsArgs(oldValue: oldValue, newValue: newValue)); // IdChanged Eventi tetikleniyor.

                EnabledChange(this, EventArgs.Empty);
            }
        }
        public event EventHandler<IdChangedEventsArgs> IdChanged = delegate { }; // yukarıda bahsettiğim kısım
        // delegate{} null'a düşme ihitmalini yok ediyoruz her türlü boş bir delegate atanacak ve null olmayacak. Sadece hafıza yer kaplıyor ama çok küçük bir yer  

        // Bu event örneğin il ilçe seçili 2 side ben ili sildim ili sildiğim anda ilçe otomatik olarak boşaltıp pasif duruma getirecek.
        public event EventHandler EnabledChange = delegate { };

        #endregion
    }

    public class IdChangedEventsArgs : EventArgs
    {
        public IdChangedEventsArgs(long? oldValue, long? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public long? OldValue { get; }
        public long? NewValue { get; }
    }
}

