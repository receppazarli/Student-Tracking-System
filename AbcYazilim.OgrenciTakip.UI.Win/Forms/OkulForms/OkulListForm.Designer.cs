
namespace AbcYazilim.OgrenciTakip.UI.Win.Forms.OkulForms
{
    partial class OkulListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.longNavigator = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Navigators.LongNavigator();
            this.grcOkulKartlari = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridControl();
            this.grvOkulKartlari = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridView();
            this.colId = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colKod = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colOkulAdi = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colIlAdi = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colIlceAdi = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colAciklama = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOkulKartlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOkulKartlari)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1162, 109);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 640);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(1162, 24);
            this.longNavigator.TabIndex = 2;
            // 
            // grcOkulKartlari
            // 
            this.grcOkulKartlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcOkulKartlari.Location = new System.Drawing.Point(0, 109);
            this.grcOkulKartlari.MainView = this.grvOkulKartlari;
            this.grcOkulKartlari.MenuManager = this.ribbonControl;
            this.grcOkulKartlari.Name = "grcOkulKartlari";
            this.grcOkulKartlari.Size = new System.Drawing.Size(1162, 531);
            this.grcOkulKartlari.TabIndex = 3;
            this.grcOkulKartlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOkulKartlari});
            // 
            // grvOkulKartlari
            // 
            this.grvOkulKartlari.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvOkulKartlari.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.grvOkulKartlari.Appearance.FooterPanel.Options.UseFont = true;
            this.grvOkulKartlari.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvOkulKartlari.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.grvOkulKartlari.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvOkulKartlari.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvOkulKartlari.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvOkulKartlari.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.grvOkulKartlari.Appearance.ViewCaption.Options.UseForeColor = true;
            this.grvOkulKartlari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colKod,
            this.colOkulAdi,
            this.colIlAdi,
            this.colIlceAdi,
            this.colAciklama});
            this.grvOkulKartlari.GridControl = this.grcOkulKartlari;
            this.grvOkulKartlari.Name = "grvOkulKartlari";
            this.grvOkulKartlari.OptionsMenu.EnableColumnMenu = false;
            this.grvOkulKartlari.OptionsMenu.EnableFooterMenu = false;
            this.grvOkulKartlari.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvOkulKartlari.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvOkulKartlari.OptionsPrint.AutoWidth = false;
            this.grvOkulKartlari.OptionsPrint.PrintFooter = false;
            this.grvOkulKartlari.OptionsPrint.PrintGroupFooter = false;
            this.grvOkulKartlari.OptionsView.ColumnAutoWidth = false;
            this.grvOkulKartlari.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.grvOkulKartlari.OptionsView.RowAutoHeight = true;
            this.grvOkulKartlari.OptionsView.ShowAutoFilterRow = true;
            this.grvOkulKartlari.OptionsView.ShowGroupPanel = false;
            this.grvOkulKartlari.OptionsView.ShowViewCaption = true;
            this.grvOkulKartlari.StatusBarAciklama = null;
            this.grvOkulKartlari.StatusBarKisaYol = null;
            this.grvOkulKartlari.StatusBarKisaYolAciklama = null;
            this.grvOkulKartlari.ViewCaption = "Okul Kartları";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.StatusBarAciklama = null;
            this.colId.StatusBarKisaYol = null;
            this.colId.StatusBarKisaYolAciklama = null;
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisaYol = null;
            this.colKod.StatusBarKisaYolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 110;
            // 
            // colOkulAdi
            // 
            this.colOkulAdi.Caption = "Okul Adı";
            this.colOkulAdi.FieldName = "OkulAdi";
            this.colOkulAdi.Name = "colOkulAdi";
            this.colOkulAdi.OptionsColumn.AllowEdit = false;
            this.colOkulAdi.StatusBarAciklama = null;
            this.colOkulAdi.StatusBarKisaYol = null;
            this.colOkulAdi.StatusBarKisaYolAciklama = null;
            this.colOkulAdi.Visible = true;
            this.colOkulAdi.VisibleIndex = 1;
            this.colOkulAdi.Width = 160;
            // 
            // colIlAdi
            // 
            this.colIlAdi.Caption = "İl";
            this.colIlAdi.FieldName = "IlAdi";
            this.colIlAdi.Name = "colIlAdi";
            this.colIlAdi.OptionsColumn.AllowEdit = false;
            this.colIlAdi.StatusBarAciklama = null;
            this.colIlAdi.StatusBarKisaYol = null;
            this.colIlAdi.StatusBarKisaYolAciklama = null;
            this.colIlAdi.Visible = true;
            this.colIlAdi.VisibleIndex = 2;
            this.colIlAdi.Width = 130;
            // 
            // colIlceAdi
            // 
            this.colIlceAdi.Caption = "İlçe";
            this.colIlceAdi.FieldName = "IlceAdi";
            this.colIlceAdi.Name = "colIlceAdi";
            this.colIlceAdi.OptionsColumn.AllowEdit = false;
            this.colIlceAdi.StatusBarAciklama = null;
            this.colIlceAdi.StatusBarKisaYol = null;
            this.colIlceAdi.StatusBarKisaYolAciklama = null;
            this.colIlceAdi.Visible = true;
            this.colIlceAdi.VisibleIndex = 3;
            this.colIlceAdi.Width = 130;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.StatusBarAciklama = null;
            this.colAciklama.StatusBarKisaYol = null;
            this.colAciklama.StatusBarKisaYolAciklama = null;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 4;
            this.colAciklama.Width = 450;
            // 
            // OkulListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 688);
            this.Controls.Add(this.grcOkulKartlari);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "OkulListForm";
            this.Text = "Okul Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator, 0);
            this.Controls.SetChildIndex(this.grcOkulKartlari, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOkulKartlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOkulKartlari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Navigators.LongNavigator longNavigator;
        private UserControls.Grid.MyGridControl grcOkulKartlari;
        private UserControls.Grid.MyGridView grvOkulKartlari;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colKod;
        private UserControls.Grid.MyGridColumn colOkulAdi;
        private UserControls.Grid.MyGridColumn colIlAdi;
        private UserControls.Grid.MyGridColumn colIlceAdi;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}