using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraMap;
using DevExpress.Xpo;
using xMap.Persistent.Base;
using System.Data.SqlTypes;
using NetTopologySuite.Geometries;
using xMap.Persistent.BaseImpl;

namespace xMap.Module.Win.Editors.DevEx
{
    public partial class MapControl : UserControl
    {

        IBindingList bindingList;
        Dictionary<string, string> dataSourceProperties = new Dictionary<string, string>();

        public MapControl()
        {
            InitializeComponent();

            layer.DataLoaded += this.Layer_DataLoaded;
            map.MapEditor.MapItemEdited += this.MapEditor_MapItemEdited;
            //this.wmsDataProvider1.ResponseCapabilities += WmsDataProvider1_ResponseCapabilities;
        }

        private void WmsDataProvider1_ResponseCapabilities(object sender, CapabilitiesRespondedEventArgs e)
        {
            // Specify an active layer for the map control.
            //this.wmsDataProvider1.ActiveLayerName = e.Layers[0].Name;
            // Recieve information on the active layer.
            //label1.Text = string.Format("Layer name: {0}, Layer title: {1}", e.Layers[0].Name, e.Layers[0].Title);
        }

        private void MapEditor_MapItemEdited(object sender, MapItemEditedEventArgs e)
        {
            foreach (var item in e.Items)
            {

                switch (e.Action)
                {
                    case MapEditorAction.None:
                        break;
                    case MapEditorAction.Move:
                        break;
                    case MapEditorAction.Rotate:
                        break;
                    case MapEditorAction.Resize:
                        break;
                    case MapEditorAction.PointUpdate:
                        break;
                    case MapEditorAction.PointAdd:
                        break;
                    case MapEditorAction.PointRemove:
                        break;
                    case MapEditorAction.Create:
                        IXPGeometry geom = (IXPGeometry)bindingList.AddNew();
                        if (item is MapShape shp)
                        {
                            //SqlChars str = new SqlChars(new SqlString(shp.ExportToWkt()));
                            geom.Shape = GeometryConverter.FromWKT(shp.ExportToWkt(), 25832);
                        }
                        break;
                    case MapEditorAction.Remove:
                        break;
                    case MapEditorAction.Copy:
                        break;
                    default:
                        break;
                }
            }
        }

        public void RefreshDataSource(object dataSource)
        {
            bindingList = dataSource as IBindingList;
            map.SuspendRender();
            storage.Items.Clear();
            if (bindingList != null)
            {
                foreach (IXPGeometry item in bindingList)
                {
                    if (item.Shape != null)
                        storage.Items.Add(new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.SRID));
                    foreach (var pair in dataSourceProperties)
                    {
                        var vl = map.Layers[pair.Key] as VectorItemsLayer;
                        var stor = vl.Data as SqlGeometryItemStorage;
                        stor.Items.Clear();
                        var xpo = item as DevExpress.Xpo.XPBaseObject;
                        IBindingList list = xpo.GetMemberValue(pair.Value) as IBindingList;
                        foreach (IXPGeometry innerItem in list)
                        {
                            stor.Items.Add(new SqlGeometryItem(innerItem.Shape.ToString(), (int)item.Shape.SRID));
                        }
                    }

                }
            }

            map.ResumeRender();

        }

        private void Layer_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            map.ZoomToFitLayerItems(0.4);
        }


        public object EditValue
        {
            get;
            set;
        }

        public bool ShowToolbar
        {
            get => map.MapEditor.ShowEditorPanel;
            set => map.MapEditor.ShowEditorPanel = value;
        }

        public LayerBase AddVectorLayer(string dataSourceProperty,string layerName)
        {
            var _layer = new DevExpress.XtraMap.VectorItemsLayer();
            var _storage = new DevExpress.XtraMap.SqlGeometryItemStorage();
            _layer.Name = layerName;
            _layer.Data = _storage;
            _storage.SourceCoordinateSystem = storage.SourceCoordinateSystem;
            map.Layers.Add(_layer);
            dataSourceProperties.Add(layerName, dataSourceProperty);
            return _layer;

        }

        public LayerBase AddWMSLayer(string uri,string layerName)
        {
            ImageLayer imageLayer = new ImageLayer();
            WmsDataProvider dataProvider = new WmsDataProvider();
            dataProvider.ServerUri = uri;
            dataProvider.ActiveLayerName = layerName;
            imageLayer.DataProvider = dataProvider;
            map.Layers.Add(imageLayer);
            return imageLayer;
        }

        public LayerBase AddBingMap(string bingKey)
        {
            var layer = new ImageLayer()
            {
                DataProvider = new BingMapDataProvider()
                {
                    BingKey = bingKey
                }
            };

            return layer;
        }


    }
}
