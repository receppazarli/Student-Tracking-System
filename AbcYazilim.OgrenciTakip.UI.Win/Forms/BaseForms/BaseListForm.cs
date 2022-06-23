using System.CodeDom;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Net.Configuration;
using System.Windows.Forms;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Dll.Interfaces;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;
using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using AbcYazilim.OgrenciTakip.UI.Win.Show.Interfaces;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace AbcYazilim.OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : RibbonForm
    {
        protected IBaseFormShow FormShow;
        protected KartTuru BaseKartTuru;
        protected internal GridView Tablo;
        protected bool AktifKartlariGoster = true;
        protected internal bool MultiSelect;
        protected internal BaseEntity SelectedEntity;
        protected IBaseBll Bll;
        protected ControlNavigator Navigator;
        protected internal long? SeciliGelecekId;

        public BaseListForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            // Button Events
            foreach (BarItem button in ribbonControl.Items)
            {
                button.ItemClick += Button_ItemClick;
            }

            // Table Events
            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.KeyDown += Tablo_KeyDown;

            //Form Events
            Shown += BaseListForm_Shown;


            // aşağıdakiyle aynı işlevi gören birşey daha yapıcam bu sadece butonlar için ge.erli olucak textlerde iş yapmıycak mesela.
            //foreach (var item in ribbonControl.Items)
            //{
            //    switch (item)
            //    {
            //        // Burda baritem kullandık çünkü butonlarımızdan bazıları barbuttonitem bazılarıda barsubitem böyle olunca 2 sininde ortak olarak kalıtım aldığı ve itemclick eventinin 
            //        // bulunduğu BarItem ı bulduk.
            //        // Burdaki amacımız ise foreach le dönerek buttonlardan hangisine basıldığını yakalamaya çalışıyoruz.
            //        case BarItem button:
            //            button.ItemClick += Button_ItemClick;
            //            break;
            //    }
            //}
        }

        private void BaseListForm_Shown(object sender, System.EventArgs e)
        {
            Tablo.Focus(); // bu şekilde ilçe tablolarına focuslanıcak eğer ki tablo varsa ilk indexse focuslanıcak.
            //ButonGizleGoster();
            //SutunGizleGoster();

            // SeciliGelecekId.HasValue bu değişkenin değeri varmı yokmu kontrol ediyor . HasValue yapıyor bu işi
            // SeciliGelecekId.Value bu ise değeri varsa o değeri alıyor. Value yapıyor bu işi  
            // || !SeciliGelecekId.HasValue) return; aşağıdaki null kontrolü yerine de bu şekilde bir yazım yapabiliriz.
            if (IsMdiChild || SeciliGelecekId == null) return;
            Tablo.RowFocus("Id", SeciliGelecekId);
        }

        private void SutunGizleGoster()
        {
            throw new System.NotImplementedException();
        }

        private void ButonGizleGoster()
        {
            throw new System.NotImplementedException();
        }

        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            Tablo.OptionsSelection.MultiSelect = MultiSelect;
            // Hangi controlün navigateı olucam ben
            Navigator.NavigatableControl = Tablo.GridControl;

            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = Cursors.Default;

            // Güncellenecek. 

        }

        protected virtual void DegiskenleriDoldur() { }


        // database den çekeçeği veri için id yazıyorum ona göre kartı açıcak
        //
        protected virtual void ShowEditForm(long id)
        {
            var result = FormShow.ShowDialogEditForm(BaseKartTuru, id);
            ShowEditFormDefault(result);
        }

        // Amacımız kaydetme işlemini yaptıktan sonra form kapanıyor arkada list forma odaklanıyor list formdaki verilerin refresh yapılıp hangi kaydı
        // eklediysek ona focuslanmasını yapıyoruz.
        protected void ShowEditFormDefault(long id)
        {
            if (id <= 0) return;
            AktifKartlariGoster = true;
            FormCaptionAyarla();
            Tablo.RowFocus("Id", id);
        }

        private void EntityDelete()
        {
            throw new System.NotImplementedException();
        }

        private void SelectEntity()
        {
            if (MultiSelect)
            {
                // Güncellenecek.
            }
            else
            {
                // Seçmiş olduğumuz satırı geri döndürüp selectedentity e aktardık.
                SelectedEntity = Tablo.GetRow<BaseEntity>();
            }

            //Dialog result u okeye işaretlemiş olduk doğal olarak ta bir seçim yapmış olduğumuz belirttik. daha sonra da bu dialogresultun değerini okuyup işlem yapıcaz. 
            DialogResult = DialogResult.OK;
            // Formmu kapatma
            Close();

        }

        protected virtual void Listele() { }

        private void FiltreSec()
        {
            throw new System.NotImplementedException();
        }


        private void Yazdir()
        {
            throw new System.NotImplementedException();
        }

        private void FormCaptionAyarla()
        {
            // bu kontrolün amacı şöyle anlatayım kullanıcı eğer seçim işlemleri sırasında aktif ve pasif kartları görüntülerse bize sıkıntı olur
            // pasif olan bi kartı da seçip ekleme yapabilir bu yüzden seçim yapılan yerlerde sadece aktifkartları gösteriyoruz o yüzden de bu şekilde 
            // kontrol yaptık.
            if (btnAktifPasifKartlar == null)
            {
                Listele();
                return;
            }

            if (AktifKartlariGoster)
            {
                btnAktifPasifKartlar.Caption = "Pasif Kartlar";
                Tablo.ViewCaption = Text;
            }
            else
            {
                btnAktifPasifKartlar.Caption = "Aktif Kartlar";
                Tablo.ViewCaption = Text + " - Pasif kartlar";
            }

            Listele();
        }

        private void IslemTuruSec()
        {
            // Bazı kıısımlar Enter ve double clickle form açıyor bazıları ise seçim yapıyor o yüzen burda onları ayırt edicek işlemleri yaptık.
            if (!IsMdiChild)
            {
                // Güncellenecek
                SelectEntity();
            }
            else
            {
                btnDuzelt.PerformClick();
            }
        }


        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            // cursorü bekle durumuna geçiyor. 
            Cursor.Current = Cursors.WaitCursor;

            // Gönder butonuna basılınca
            if (e.Item == btnGonder)
            {
                // BarSubItemLink türüne cast edip link'i 0 olarak seçiyoruzbu gönder butonunu seçiyoruz sub item 1 tane var zaten o yüzden 0
                var link = (BarSubItemLink)e.Item.Links[0];
                // Burda o 0. index se foculatıyoruz seçili geliyor.
                link.Focus();
                // Burda o focuslanan menüyü açtırıyorum.
                link.OpenMenu();
                // Burda da açılan menüde 0. indexse foculu olarak getiriyorum.
                link.Item.ItemLinks[0].Focus();
            }
            // Şimdi açılan menüde ki butonların item.clicklerini yazıcaz.
            else if (e.Item == btnStandartExcelDosyası)
            { }

            else if (e.Item == btnExcelDosyasıFormatlı)
            { }

            else if (e.Item == btnExcelDosyasıFormatsız)
            { }

            else if (e.Item == btnWordDosyasi)
            { }

            else if (e.Item == btnPdfDosyasi)
            { }

            else if (e.Item == btnTxtDosyasi)
            { }

            else if (e.Item == btnYeni)
            {
                // Yetki Kontrolü

                ShowEditForm(-1);
            }

            else if (e.Item == btnDuzelt)
            {
                ShowEditForm(Tablo.GetRowId());
            }

            else if (e.Item == btnSil)
            {
                // Yetki Kontrolü
                EntityDelete();
            }

            else if (e.Item == btnSec)
            {
                SelectEntity();
            }

            else if (e.Item == btnYenile)
            {
                Listele();
            }

            else if (e.Item == btnFiltrele)
            {
                FiltreSec();
            }

            else if (e.Item == btnKolonlar)
            {
                if (Tablo.CustomizationForm == null)
                {
                    Tablo.ShowCustomization();
                }
                else
                {
                    Tablo.HideCustomization();
                }
            }

            else if (e.Item == btnYazdir)
            {
                Yazdir();
            }

            else if (e.Item == btnCikis)
            {
                Close();
            }

            else if (e.Item == btnAktifPasifKartlar)
            {
                // aktif kartları gösterin durumunun zıttını ayarladık.
                AktifKartlariGoster = !AktifKartlariGoster;
                FormCaptionAyarla();
            }

            // biz butona tıkladığımızda ilk önce cursorün şekli değişecek sonra  bekleme konummuna geçeçek  yapılacak olan işlem yapılıp bittikten sonrada durumunu default hale getirecek.
            Cursor.Current = DefaultCursor;

        }


        private void Tablo_DoubleClick(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IslemTuruSec();
            Cursor.Current = DefaultCursor;
        }

        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // gridview üstündeyken enter tuşuna basılınca 
                case Keys.Enter:
                    IslemTuruSec();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }


    }
}