using System.ComponentModel;
using System.Drawing;
using AbcYazilim.OgrenciTakip.UI.Win.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid
{
    [ToolboxItem(defaultType: true)]
    public class MyGridControl : GridControl
    {

        // Default view üsütnde yapıcaz işlemleri biz default değerleri değiştirmek istiyoruz
        protected override BaseView CreateDefaultView()
        {
            // oluşturulan MyGridView BaseView geliyor biz bunu istemiyoruz o yüzden cast işlemi yapıyoruz Onu Gridview den alıyoruz.
            // Bu cast işlemini yapma amacımız GridView daki property lere ulaşmak o yüzden MYGridView da olabilir çünkü oda GridView den implemente oluyor.
            var view = (GridView)CreateView(name: "MyGridView");
            //  Burda yaptığımız atamaların hepsi bütün kolonlar için geçerli oluyor. Attığımız gibi bu özellikleri alıcak.
            view.Appearance.ViewCaption.ForeColor = Color.Maroon; // Burda Gridview de caption(Başlık) oluşturuyoruz.
          //  view.Appearance.ViewCaption.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);
            view.Appearance.HeaderPanel.ForeColor = Color.Maroon; // Burdada Header renklernini yaptık yani kolon başlık renklerini.
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center; // Burda da kolon başlıklarını ortalattık.

            // FooterPanel Grid deki bir özellik bu bize toplama çarpma vb kolaylıklar sunuyor. Biz burda bu özelliğin geldiğinde hangi özellik seçildiyse onun renk ayarını yaptık.
            // Bu özelliği kullanmak için griwView dan showFooterPanel özelliğini açmamız lazım biz lazım olan yerlerine göre açıcaz.
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            // Burda amacımız o yazının font'unu değiştiricez bunun için Font Özellğinde birsürü aynı isimde methodumuz var bize lazım olan değeri seçiyoruz.
            // işlemimizi yapıyoruz 8.25f'nin anlamı bizden float bir değer istediği için sonua f yazıp float olduğunu belirtiyorum.
            view.Appearance.FooterPanel.Font = new Font(family: new FontFamily(name: "Tahoma"), emSize: 8.25f, style: FontStyle.Bold);

            // Bu menu menulerde sağ tuşa bastığımzda default bi menu açılır. Filtrele benzeri tazrda biz bu menuyu kapatıcaz. False yapıcaz bizim kendi menulerimiz gelicek
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true; // Enter tuşuyla kolonların sütünları arasında dolaşıyor.

            // Bu işlemde Yazdırma işlemi yaparken yazıcıya gridi gönderdik kolonları otomatik daraltma genişletme yapmasını istemiyoruz. Bunu kapattık
            view.OptionsPrint.AutoWidth = false;
            // Yazdırma işlemi sırasında footerların gitmesini istemiyorum.
            view.OptionsPrint.PrintFooter = false;
            view.OptionsPrint.PrintGroupFooter = false;

            // Default olarak false geliyo başlığı göstermesi için açtık
            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowAutoFilterRow = true; // Otamatik filtreleme işlemini true yapıyoruz.
            view.OptionsView.ShowGroupPanel = false; // gruplama panelini kapatıyoruz.
            view.OptionsView.ColumnAutoWidth = false; // gridi büyütünce kolanlarda büyüyordu şimdi onu kapattık bizim istediğimiz genişlikte olacaklar.
            view.OptionsView.RowAutoHeight = true; // kolonu otamatik yükseltmeyi açtık ör: yazı yazdık enter yaptık yazdık enter yaptık ama kolon sabir olduğu için gözükmedi 
            // yüksekliğini artırınca otomatik o yazıya göre ayarlayıp düzenliyecek.
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button; // kolonun filtreleme işlemi button olarak geliyor.

            var idColumn = new MyGridColumn
            {
                Caption = "Id", // Kolon başlığı
                FieldName = "Id" // Verinin database deki kolon adı
            };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false; // kolonun gözükmesini engelliyoruz gizleniyor.
            view.Columns.Add(column: idColumn); // Burda da ekleme işlemini yapıyoruz.

            var kodColumn = new MyGridColumn
            {
                Caption = "Kod",
                FieldName = "Kod"
            };
            kodColumn.OptionsColumn.AllowEdit = false;
            kodColumn.Visible = true;
            kodColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center; // Başlıkları ortalamış olduk. Burda ortala diyerek sadece değer atadık bunu kullan demedik 
            // AppreranceCell options  kısmında UseTextoptions var onu true yapmazsam text ile ilgili yaptığım ayarları kullanamam onu true yapınca kullanıyorum.
            kodColumn.AppearanceCell.Options.UseTextOptions = true; // Burda text ile ilgili işlemleri göster demiş olduk.
            view.Columns.Add(column: kodColumn);

            return view; // baseview tipinde geriye değer istediği için böyle return yapıyoruz.
        }

        // Grid controlü sürüklediğimizde default olan kendi gridviewını getiriyor onu değilde bizim yaptığımız getirmesi için override işlemi yapıcaz.
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection: collection);

            collection.Add(regInfo: new MyGridInfoRegistrator()); // GridInfo kullandık çünkü gridviewı gridcontrole atıcağımız için. Bu class default bir class olduğu için kendi clasımızı oluşturuyoruz.

        }

        public class MyGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName => "MyGridView"; // benim yaptığım gridview ı almasını sağladım.
            public override BaseView CreateView(GridControl grid) => new MyGridView(ownerGrid: grid); // Bu gridview ın sahibi bu grid diyecez Constructer yapıcaz 

        }
    }

    public class MyGridView : GridView, IStatusBarKisaYol
    {
        #region Properties
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        #endregion

        // bunu yapmamızdaki amaç sürükleme yapınca designerda bunu oluşturma yapıyor ama bizden default constructor istiyor o yüzden bunu tanımlıyoruz.
        public MyGridView() { } // Oluşturma aşamasında designer.cs de bundan bir instance üretmek için kullanıcak onu oluşturduktan sonra da gridview gridcontrole bağlamak içinde aşağıdaki constructor ı kullanacak
        public MyGridView(GridControl ownerGrid) : base(ownerGrid: ownerGrid) { } // MyGridControlu sürüklerken bu devreye girecek. Diyecek ki sen bu gridControle bağlı bir GridViewssin



        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column: column);

            if (column.ColumnEdit == null) return; // ColumnEdit bir kolonu yoksa işleme devam et boş olduğu için birşey yapamıyoruz.

            // Kolonun tipi RepositoryItemDateEdit se işlemlerimizi yaptırıcaz.
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                // Gelen değerin ortalanmış olarak yazılmasını yapıcaz.AppearanceCell kullandık o içerisindeki veri için Bide AppearanceHeader var oda başlık için.
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                // Gün kısmını yazınca otomatik ay kısmına geçicek sonra da yıla. DateTimeAdvancingCaret seçtiğimiz zaman bize istediğimiz özelliği sağlıyor.
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            }
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyGridColumnCollection(view: this);
        }

        private class MyGridColumnCollection : GridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view: view) { }
            protected override GridColumn CreateColumn()
            {
                // AllowEdit default olarak true geliyor biz bunu false yapıyoruz.

                var column = new MyGridColumn();
                column.OptionsColumn.AllowEdit = false;
                return column;
            }
        }
    }

    public class MyGridColumn : GridColumn, IStatusBarKisaYol
    {


        #region Properties
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        #endregion
    }
}

