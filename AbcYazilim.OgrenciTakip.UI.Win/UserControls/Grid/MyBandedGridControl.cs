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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;

namespace AbcYazilim.OgrenciTakip.UI.Win.UserControls.Grid
{
    [ToolboxItem(defaultType: true)]
    public class MyBandedGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (MyBandedGridView)CreateView(name: "MyBandedGridView");

            // Band panel için burdaki işlemleri ekledik diğer işlemler diğer gridimizde de mevcut
            view.Appearance.BandPanel.ForeColor = Color.DarkBlue;
            view.Appearance.BandPanel.Font = new Font(family: new FontFamily(name: "Tahoma"), emSize: 8.25f, style: FontStyle.Bold);
            view.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.BandPanelRowHeight = 40; // Bu değeri 2 kon yüksekliği olarak yaptık.



            // Burdaki özelliklere açıklama yazmadım çünkü bunların hepsinin açıklamasını MyGridControl de yaptım.
            view.Appearance.ViewCaption.BackColor = Color.Maroon;
            view.Appearance.HeaderPanel.BackColor = Color.Maroon;
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            view.Appearance.FooterPanel.BackColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(family: new FontFamily(name: "Tahoma"), emSize: 8.25f, style: FontStyle.Bold);

            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true;

            view.OptionsPrint.AutoWidth = false;
            view.OptionsPrint.PrintFooter = false;
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.RowAutoHeight = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            // Burda kolon diye dizi yapıp 2 tane kolonu bu şekilde oluşturuyorum. 
            var columns = new[]
            {
                new BandedGridColumn
                {
                    Caption = "Id",
                    FieldName = "Id",
                    OptionsColumn = {AllowEdit = false, ShowInCustomizationForm = false}
                    // Bu şekilde yazmak yerine yukarıdaki gibi kullanım yapabiliriz 2 side olur ama yukarıda yazarken OptionsColum kısmını otomatik olarak getirmiyor elle yazmamız gerekiyor.
                    // Buu kullanmak istersem dizi şeklinde yapmadan GridControldeki gibi yapıp dışarıda kullanmam gerek.
                    // idColumn.OptionsColumn.AllowEdit = false;
                    // idColumn.OptionsColumn.ShowInCustomizationForm = false;
                },
                new BandedGridColumn
                {
                    Caption = "Kod",
                    FieldName = "Kod",
                    Visible = true,

                    OptionsColumn = { AllowEdit = false, ShowInCustomizationForm = false},
                    AppearanceCell =
                    {
                        TextOptions= {HAlignment = HorzAlignment.Center},
                        Options = { UseTextOptions = true}
                    }

                }
            };
            view.Columns.AddRange(columns: columns); // AdRange yaptık kolonlarımızı dizi olarak yazdığımız için.

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection: collection);
            collection.Add(regInfo: new MyBandedGridInfoRegistrator());
        }

        private class MyBandedGridInfoRegistrator : BandedGridInfoRegistrator
        {
            public override string ViewName => "MyBandedGridView";
            public override BaseView CreateView(GridControl grid) => new MyBandedGridView(ownerGrid: grid);

        }
    }

    public class MyBandedGridView : BandedGridView, IStatusBarKisaYol
    {

        #region Properties

        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }

        #endregion

        public MyBandedGridView() { }

        public MyBandedGridView(GridControl ownerGrid) : base(ownerGrid: ownerGrid) { }

        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column: column);

            if (column.ColumnEdit == null) return;
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            }
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyGridColumnCollection(view: this);
        }

        private class MyGridColumnCollection : BandedGridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view: view) { }
            protected override GridColumn CreateColumn()
            {
                var column = new MyBandedGridColumn();
                column.OptionsColumn.AllowEdit = false;
                return column;
            }
        }
    }

    public class MyBandedGridColumn : BandedGridColumn, IStatusBarKisaYol
    {
        #region Properties
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        #endregion
    }

}