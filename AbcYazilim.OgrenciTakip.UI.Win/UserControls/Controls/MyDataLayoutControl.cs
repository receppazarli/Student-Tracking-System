using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;


namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(defaultType: true)]
    public class MyDataLayoutControl : DataLayoutControl
    {
        public MyDataLayoutControl()
        {
            OptionsFocus.EnableAutoTabOrder = false; // Layout kullanınca sıralı bir şekilde yaptığı için otomatik olarak tab la layoutu yaptığı sıraya göre dolaşabiliyoruz.
            // Bunu kapattik k biz kendi sıramıza göre kendi verdiğimiz tabindex özelliğini kullanabilelim.
        }

        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementor(controlOwner: this);
        }
    }

    internal class MyLayoutControlImplementor : LayoutControlImplementor
    {
        public MyLayoutControlImplementor(ILayoutControlOwner controlOwner) : base(controlOwner: controlOwner)
        {
        }

        // Bu işlem layoutun içine sürkleme yaptığımız zaman attıklarımızın texlerini yazı renklerini istediğimiz renke çeviriyoruz.
        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)
        {
            var item = base.CreateLayoutItem(parent: parent);
            item.AppearanceItemCaption.ForeColor = Color.Maroon;
            return item;

        }

        // Burda ise Layoutu sürüklediğimiz anda tablo şeklini alıp gelicek yani otomatik bölünmüş halde gelicek.
        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {

            var grp = base.CreateLayoutGroup(parent: parent);
            grp.LayoutMode = LayoutMode.Table; // bu şekilde yapıp kullandığımız zaman 2 satır ve 2 sütün getiriyor kısaca layoutu 4 eşit kareye bölüyor.

            // Kolonları düzenleme ve kolon ekleme işlemleri
            // 1. Kolon
            // Burda layoutta yaptığımız kolanların 1. sine ulaştık ve boyutunu sabitledik.
            grp.OptionsTableLayoutGroup.ColumnDefinitions[index: 0].SizeType = SizeType.Absolute;
            //Burdada ilk sütünün genişliğini ayarlıyoruz. Ve burda yapılan ayarlarımız default ayar olarak yapıyoruz isteğimize göre form larda değişiklikler yapabiliriz.
            grp.OptionsTableLayoutGroup.ColumnDefinitions[index: 0].Width = 200;

            // 2. Kolon
            // Burda ise sen ilk önce sabit 200 genişliğinde bir sütün bırak kalanıda yüzde olarak büyütünce büyüsün küçültünce küçülsün.
            grp.OptionsTableLayoutGroup.ColumnDefinitions[index: 1].SizeType = SizeType.Percent; // Yüzde olarak ayarlıcam demek 
            grp.OptionsTableLayoutGroup.ColumnDefinitions[index: 1].Width = 100;

            // 3. Kolon bu normalde yok bunu kendimiz eklicez
            // Burda yeni bir sütün ekleme işlemini yapıyoruz.
            grp.OptionsTableLayoutGroup.ColumnDefinitions.Add(columnDefinition: new ColumnDefinition { SizeType = SizeType.Absolute, Width = 99 });

            // Row ekleme ve düzenleme işlemleri
            // Kendi Row larımızı oluşturacağımız için otomatik oluşan row ların hepsini temizliyoruz.
            grp.OptionsTableLayoutGroup.RowDefinitions.Clear(); // Otamatik olarak oluşturulan Row ları temizliyor.

            for (int i = 0; i < 9; i++)
            {
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(rowDefinition: new RowDefinition
                {
                    SizeType = SizeType.Absolute, //sabit olarak oluşturuyoruz.
                    Height = 24, // hoca denediği için bu değeri verdik.
                });

                // Burdaki amacımız son oluşturacağı row'u yakalayıp onu diğerlerinden farklı bir şekilde yapmak oda percent olarak yaptık ve büyüttükçe büyüme küçültükçe küçlme yapacak
                if (i + 1 != 9) continue; // Amacımız son değeri yakalamak olduğu için bu if'i kullandık i miz 9 olduğu zaman i+1 de 9 olacak ve eşit olacak bu sebebten if iptal olup program alt satırdan devam edicek
                // eşit olmadığo durumlarda ise de continue kullanarak aşağıya inmeden for dan devam etmesini sağlıyoruz.
                // burda son kolonumuzu elimizle ekleyip istediğimiz değerleri veriyoruz. Hoca önceden test ettiği için bu değerleri verdik.
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(rowDefinition: new RowDefinition
                {
                    SizeType = SizeType.Percent,
                    Height = 100
                });
            }

            return grp;

        }
    }
}