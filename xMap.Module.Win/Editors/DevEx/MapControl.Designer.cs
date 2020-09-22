﻿namespace xMap.Module.Win.Editors.DevEx
{
    partial class MapControl
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraMap.CartesianMapCoordinateSystem cartesianMapCoordinateSystem5 = new DevExpress.XtraMap.CartesianMapCoordinateSystem();
            DevExpress.XtraMap.CartesianSourceCoordinateSystem cartesianSourceCoordinateSystem5 = new DevExpress.XtraMap.CartesianSourceCoordinateSystem();
            DevExpress.XtraMap.CartesianSourceCoordinateSystem cartesianSourceCoordinateSystem1 = new DevExpress.XtraMap.CartesianSourceCoordinateSystem();
            this.map = new DevExpress.XtraMap.MapControl();
            this.layer = new DevExpress.XtraMap.VectorItemsLayer();
            this.storage = new DevExpress.XtraMap.SqlGeometryItemStorage();
            this.imageLayer1 = new DevExpress.XtraMap.ImageLayer();
            this.wmsDataProvider1 = new DevExpress.XtraMap.WmsDataProvider();
            this.sqlGeometryItemStorage1 = new DevExpress.XtraMap.SqlGeometryItemStorage();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // map
            // 
            cartesianMapCoordinateSystem5.MeasureUnit = DevExpress.XtraMap.MeasureUnit.Meter;
            this.map.CoordinateSystem = cartesianMapCoordinateSystem5;
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.Layers.Add(this.layer);
            this.map.Layers.Add(this.imageLayer1);
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.MapEditor.ShowEditorPanel = true;
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(907, 562);
            this.map.TabIndex = 0;
            this.layer.Data = this.storage;
            this.storage.SourceCoordinateSystem = cartesianSourceCoordinateSystem5;
            this.imageLayer1.DataProvider = this.wmsDataProvider1;
            this.wmsDataProvider1.ServerUri = "https://sitportal.provincia.ra.it/arcgis/services/publish/CTR/MapServer/WMSServer" +
    "";
            this.sqlGeometryItemStorage1.SourceCoordinateSystem = cartesianSourceCoordinateSystem1;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.map);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(907, 562);
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl map;
        private DevExpress.XtraMap.VectorItemsLayer layer;
        private DevExpress.XtraMap.SqlGeometryItemStorage storage;
        private DevExpress.XtraMap.SqlGeometryItemStorage sqlGeometryItemStorage1;
        private DevExpress.XtraMap.ImageLayer imageLayer1;
        private DevExpress.XtraMap.WmsDataProvider wmsDataProvider1;
    }
}
