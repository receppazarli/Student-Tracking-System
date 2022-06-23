using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Dll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AbcYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using AbcYazilim.OgrenciTakip.UI.Win.Show;

namespace AbcYazilim.OgrenciTakip.UI.Win.Forms.OkulForms
{
    public partial class OkulListForm : BaseListForm
    {
        public OkulListForm()
        {
            InitializeComponent();
            Bll = new OkulBll();
        }

        protected override void DegiskenleriDoldur()
        {
            // Burda ki amacımız base list forma göndericeğimiz değerleri burda tanımlıcaz.

            Tablo = grvOkulKartlari;
            BaseKartTuru = KartTuru.Okul;
            FormShow = new ShowEditForms<OkulEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            // burda bll katmandan çekmiş olduğumuz veriyi tablomuzun data source na eklicez.

            Tablo.GridControl.DataSource = ((OkulBll) Bll).List(FilterFunctions.Filter<Okul>(AktifKartlariGoster)); 
        }
    }
}