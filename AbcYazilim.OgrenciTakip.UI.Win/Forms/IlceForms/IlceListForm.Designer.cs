
namespace AbcYazilim.OgrenciTakip.UI.Win.Forms.IlceForms
{
    partial class IlceListForm
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
            this.longNavigator1 = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Navigators.LongNavigator();
            this.grcIlceKartlari = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridControl();
            this.grvIlceKartlari = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridView();
            this.colId = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colKod = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colIlceAdi = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colAciklama = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcIlceKartlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIlceKartlari)).BeginInit();
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
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // longNavigator1
            // 
            this.longNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator1.Location = new System.Drawing.Point(0, 546);
            this.longNavigator1.Name = "longNavigator1";
            this.longNavigator1.Size = new System.Drawing.Size(1030, 24);
            this.longNavigator1.TabIndex = 2;
            // 
            // grcIlceKartlari
            // 
            this.grcIlceKartlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcIlceKartlari.Location = new System.Drawing.Point(0, 109);
            this.grcIlceKartlari.MainView = this.grvIlceKartlari;
            this.grcIlceKartlari.MenuManager = this.ribbonControl;
            this.grcIlceKartlari.Name = "grcIlceKartlari";
            this.grcIlceKartlari.Size = new System.Drawing.Size(1030, 437);
            this.grcIlceKartlari.TabIndex = 3;
            this.grcIlceKartlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIlceKartlari});
            // 
            // grvIlceKartlari
            // 
            this.grvIlceKartlari.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvIlceKartlari.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.grvIlceKartlari.Appearance.FooterPanel.Options.UseFont = true;
            this.grvIlceKartlari.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvIlceKartlari.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.grvIlceKartlari.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvIlceKartlari.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvIlceKartlari.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvIlceKartlari.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.grvIlceKartlari.Appearance.ViewCaption.Options.UseForeColor = true;
            this.grvIlceKartlari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colKod,
            this.colIlceAdi,
            this.colAciklama});
            this.grvIlceKartlari.GridControl = this.grcIlceKartlari;
            this.grvIlceKartlari.Name = "grvIlceKartlari";
            this.grvIlceKartlari.OptionsMenu.EnableColumnMenu = false;
            this.grvIlceKartlari.OptionsMenu.EnableFooterMenu = false;
            this.grvIlceKartlari.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvIlceKartlari.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvIlceKartlari.OptionsPrint.AutoWidth = false;
            this.grvIlceKartlari.OptionsPrint.PrintFooter = false;
            this.grvIlceKartlari.OptionsPrint.PrintGroupFooter = false;
            this.grvIlceKartlari.OptionsView.ColumnAutoWidth = false;
            this.grvIlceKartlari.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.grvIlceKartlari.OptionsView.RowAutoHeight = true;
            this.grvIlceKartlari.OptionsView.ShowAutoFilterRow = true;
            this.grvIlceKartlari.OptionsView.ShowGroupPanel = false;
            this.grvIlceKartlari.OptionsView.ShowViewCaption = true;
            this.grvIlceKartlari.StatusBarAciklama = null;
            this.grvIlceKartlari.StatusBarKisaYol = null;
            this.grvIlceKartlari.StatusBarKisaYolAciklama = null;
            this.grvIlceKartlari.ViewCaption = "İlçe Kartları";
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
            this.colKod.Width = 150;
            // 
            // colIlceAdi
            // 
            this.colIlceAdi.Caption = "İlce Adı";
            this.colIlceAdi.FieldName = "IlceAdi";
            this.colIlceAdi.Name = "colIlceAdi";
            this.colIlceAdi.OptionsColumn.AllowEdit = false;
            this.colIlceAdi.StatusBarAciklama = null;
            this.colIlceAdi.StatusBarKisaYol = null;
            this.colIlceAdi.StatusBarKisaYolAciklama = null;
            this.colIlceAdi.Visible = true;
            this.colIlceAdi.VisibleIndex = 1;
            this.colIlceAdi.Width = 250;
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
            this.colAciklama.VisibleIndex = 2;
            this.colAciklama.Width = 450;
            // 
            // IlceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 594);
            this.Controls.Add(this.grcIlceKartlari);
            this.Controls.Add(this.longNavigator1);
            this.IconOptions.ShowIcon = false;
            this.Name = "IlceListForm";
            this.Text = "İlçe Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator1, 0);
            this.Controls.SetChildIndex(this.grcIlceKartlari, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcIlceKartlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIlceKartlari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Navigators.LongNavigator longNavigator1;
        private UserControls.Grid.MyGridControl grcIlceKartlari;
        private UserControls.Grid.MyGridView grvIlceKartlari;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colKod;
        private UserControls.Grid.MyGridColumn colIlceAdi;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}