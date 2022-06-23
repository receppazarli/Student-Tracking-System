using System;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Dll.Base;
using AbcYazilim.OgrenciTakip.Dll.Dto;
using AbcYazilim.OgrenciTakip.Dll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AbcYazilim.OgrenciTakip.UI.Win.Forms.BaseForms;
using AbcYazilim.OgrenciTakip.UI.Win.Functions;
using DevExpress.XtraEditors;

namespace AbcYazilim.OgrenciTakip.UI.Win.Forms.OkulForms
{
    public partial class OkulEditForm : BaseEditForm
    {
        public OkulEditForm()
        {

            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new OkulBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Okul;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new OkulS() : ((OkulBll)Bll).Single(FilterFunctions.Filter<Okul>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            txtKod.Text = ((OkulBll)Bll).YeniKodVer();
            txtOkulAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (OkulS)OldEntity;

            txtKod.Text = entity.Kod;
            txtOkulAdi.Text = entity.OkulAdi;
            btnIl.Id = entity.IlId;
            btnIl.Text = entity.IlAdi;
            btnIlce.Id = entity.IlceId;
            btnIlce.Text = entity.IlceAdi;
            memoAciklama.Text = entity.Aciklama;
            tglSDurum.IsOn = entity.Durum;

        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Okul
            {
                Id = Id,
                Kod = txtKod.Text,
                OkulAdi = txtOkulAdi.Text,
                IlId = Convert.ToInt64(btnIl.Id),
                IlceId = Convert.ToInt64(btnIlce.Id),
                Aciklama = memoAciklama.Text,
                Durum = tglSDurum.IsOn
            };

            ButonEnabledDurum();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
            {
                if (sender == btnIl)
                    sec.Sec(btnIl);
                else if (sender == btnIlce)
                    sec.Sec(btnIlce, btnIl);
            }
        }

        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != btnIl) return; 
            btnIl.ControlEnabledChange(btnIlce);
        }
    }
}