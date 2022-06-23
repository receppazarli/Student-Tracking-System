
namespace AbcYazilim.OgrenciTakip.UI.Win.Forms.IlForms
{
    partial class IlListForm
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
            this.grcIlKartlari = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridControl();
            this.grvIlKartlari = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridView();
            this.colId = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colKod = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colIlAdi = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            this.colAciklama = new AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcIlKartlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIlKartlari)).BeginInit();
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
            // grcIlKartlari
            // 
            this.grcIlKartlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcIlKartlari.Location = new System.Drawing.Point(0, 109);
            this.grcIlKartlari.MainView = this.grvIlKartlari;
            this.grcIlKartlari.MenuManager = this.ribbonControl;
            this.grcIlKartlari.Name = "grcIlKartlari";
            this.grcIlKartlari.Size = new System.Drawing.Size(1030, 437);
            this.grcIlKartlari.TabIndex = 3;
            this.grcIlKartlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIlKartlari});
            // 
            // grvIlKartlari
            // 
            this.grvIlKartlari.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvIlKartlari.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.grvIlKartlari.Appearance.FooterPanel.Options.UseFont = true;
            this.grvIlKartlari.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvIlKartlari.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.grvIlKartlari.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvIlKartlari.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvIlKartlari.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvIlKartlari.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.grvIlKartlari.Appearance.ViewCaption.Options.UseForeColor = true;
            this.grvIlKartlari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colKod,
            this.colIlAdi,
            this.colAciklama});
            this.grvIlKartlari.GridControl = this.grcIlKartlari;
            this.grvIlKartlari.Name = "grvIlKartlari";
            this.grvIlKartlari.OptionsMenu.EnableColumnMenu = false;
            this.grvIlKartlari.OptionsMenu.EnableFooterMenu = false;
            this.grvIlKartlari.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvIlKartlari.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvIlKartlari.OptionsPrint.AutoWidth = false;
            this.grvIlKartlari.OptionsPrint.PrintFooter = false;
            this.grvIlKartlari.OptionsPrint.PrintGroupFooter = false;
            this.grvIlKartlari.OptionsView.ColumnAutoWidth = false;
            this.grvIlKartlari.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.grvIlKartlari.OptionsView.RowAutoHeight = true;
            this.grvIlKartlari.OptionsView.ShowAutoFilterRow = true;
            this.grvIlKartlari.OptionsView.ShowGroupPanel = false;
            this.grvIlKartlari.OptionsView.ShowViewCaption = true;
            this.grvIlKartlari.StatusBarAciklama = null;
            this.grvIlKartlari.StatusBarKisaYol = null;
            this.grvIlKartlari.StatusBarKisaYolAciklama = null;
            this.grvIlKartlari.ViewCaption = "İl Kartları";
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
            // colIlAdi
            // 
            this.colIlAdi.Caption = "İl Adı";
            this.colIlAdi.FieldName = "IlAdi";
            this.colIlAdi.Name = "colIlAdi";
            this.colIlAdi.OptionsColumn.AllowEdit = false;
            this.colIlAdi.StatusBarAciklama = null;
            this.colIlAdi.StatusBarKisaYol = null;
            this.colIlAdi.StatusBarKisaYolAciklama = null;
            this.colIlAdi.Visible = true;
            this.colIlAdi.VisibleIndex = 1;
            this.colIlAdi.Width = 250;
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
            // IlListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 594);
            this.Controls.Add(this.grcIlKartlari);
            this.Controls.Add(this.longNavigator1);
            this.IconOptions.ShowIcon = false;
            this.Name = "IlListForm";
            this.Text = " İl Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator1, 0);
            this.Controls.SetChildIndex(this.grcIlKartlari, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcIlKartlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIlKartlari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Navigators.LongNavigator longNavigator1;
        private UserControls.Grid.MyGridControl grcIlKartlari;
        private UserControls.Grid.MyGridView grvIlKartlari;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colKod;
        private UserControls.Grid.MyGridColumn colIlAdi;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}