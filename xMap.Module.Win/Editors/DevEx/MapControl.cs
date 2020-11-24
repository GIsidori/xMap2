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
using DevExpress.ExpressApp.Model;
using xMap.Persistent.Base;
using xMap.Persistent.BaseImpl;
using DevExpress.ExpressApp;

namespace xMap.Module.Win.Editors.DevEx
{
    public partial class MapControl : DevExpress.XtraMap.MapControl
    {

        private VectorItemsLayer layer;
        private SqlGeometryItemStorage storage;
        Dictionary<string, string> dataSourceProperties = new Dictionary<string, string>();
        private object DataSource;

        public MapControl()
        {
        }

        public VectorItemsLayer Layer => layer;

        public void AddLayers(IModelMap info)
        {
            DevExpress.XtraMap.CartesianSourceCoordinateSystem cartesianSourceCoordinateSystem1 = new DevExpress.XtraMap.CartesianSourceCoordinateSystem();
            DevExpress.XtraMap.UTMCartesianToGeoConverter utmCartesianToGeoConverter1 = new DevExpress.XtraMap.UTMCartesianToGeoConverter();

            layer = new VectorItemsLayer();
            storage = new SqlGeometryItemStorage();
            Layers.Add(layer);
            layer.Data = storage;
            layer.ItemStyle.Stroke = System.Drawing.Color.FromArgb(192, 0, 0);
            layer.ItemStyle.StrokeWidth = 3;

            utmCartesianToGeoConverter1.UtmZone = 32;
            cartesianSourceCoordinateSystem1.CoordinateConverter = utmCartesianToGeoConverter1;
            storage.SourceCoordinateSystem = cartesianSourceCoordinateSystem1;

            MapEditor.ShowEditorPanel = info.ShowToolbar;
            foreach (var item in info.MapLayers.OrderBy(l => l.Index))
            {
                LayerBase layer = null;
                switch (item.LayerType)
                {
                    case LayerType.WMSLayer:
                        layer = AddWMSLayer(item.Uri, item.LayerName);
                        break;
                    case LayerType.BingMapLayer:
                        string bingKey = ((IModelMapOptions)((IModelApplication)info.Root).Options).BingKey;
                        layer = AddBingMap(bingKey);
                        break;
                    case LayerType.VectorLayer:
                        string dataSourceProperty = item.DataSourceProperty;
                        layer = AddVectorLayer(dataSourceProperty, item.LayerName);
                        break;
                }
                if (layer != null)
                    layer.Visible = item.Visible;
            }

            layer.DataLoaded += this.Layer_DataLoaded;
            MapEditor.MapItemEdited += this.MapEditor_MapItemEdited;

        }

        private LayerBase AddVectorLayer(string dataSourceProperty, string layerName)
        {
            var _layer = new DevExpress.XtraMap.VectorItemsLayer();
            var _storage = new DevExpress.XtraMap.SqlGeometryItemStorage();
            _layer.Name = layerName;
            _layer.Data = _storage;
            _storage.SourceCoordinateSystem = storage.SourceCoordinateSystem;
            Layers.Add(_layer);
            dataSourceProperties.Add(layerName, dataSourceProperty);
            return _layer;

        }

        private LayerBase AddWMSLayer(string uri, string layerName)
        {
            ImageLayer imageLayer = new ImageLayer();
            WmsDataProvider dataProvider = new WmsDataProvider();
            dataProvider.ServerUri = uri;
            dataProvider.ActiveLayerName = layerName;
            imageLayer.DataProvider = dataProvider;
            Layers.Add(imageLayer);
            return imageLayer;
        }

        private LayerBase AddBingMap(string bingKey)
        {
            var layer = new ImageLayer()
            {
                DataProvider = new BingMapDataProvider()
                {
                    BingKey = bingKey
                }
            };
            Layers.Add(layer);
            return layer;
        }

        public void RefreshDataSource(object dataSource)
        {
            DataSource = dataSource;
            SuspendRender();
            storage.Items.Clear();
            if (dataSource is IBindingList bindingList)
            {
                foreach (IXPGeometry item in bindingList)
                {
                    if (item.Shape != null)
                    {
                        objectRecords[item.Oid] = item;
                        AddItem(item, storage); // storage.Items.Add(new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.SRID));
                    }
                    foreach (var pair in dataSourceProperties)
                    {
                        IBindingList list;
                        var vl = Layers[pair.Key] as VectorItemsLayer;
                        var stor = vl.Data as SqlGeometryItemStorage;
                        stor.Items.Clear();
                        var xpo = item as DevExpress.Xpo.XPBaseObject;
                        var mInfo = xpo.ClassInfo.GetMember(pair.Value);
                        if (typeof(IXPGeometry).IsAssignableFrom(mInfo.MemberType))
                        {
                            list = new BindingList<IXPGeometry>();
                            list.Add(mInfo.GetValue(xpo));
                        }
                        else
                            list = xpo.GetMemberValue(pair.Value) as IBindingList;
                       
                        foreach (IXPGeometry innerItem in list)
                        {
                            AddItem(innerItem, stor);
                        }
                    }

                }
            }

            ResumeRender();

        }

        Dictionary<int,IXPGeometry> objectRecords = new Dictionary<int,IXPGeometry>();

        private object GetXPGeometry(int oid)
        {
            IXPGeometry result = null;
            objectRecords.TryGetValue(oid, out result);
            return result;
        }

        public object GetRow(MapItem item)
        {
            int oid = (int) item.Attributes[nameof(XPSTGeometry.Oid)].Value;
            return GetXPGeometry(oid);
        }


        private SqlGeometryItem AddItem(IXPGeometry item, SqlGeometryItemStorage storage)
        {
            SqlGeometryItem sqlStorageItem = null;
            if (item.Shape != null)
            {
                sqlStorageItem = new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.SRID);
                foreach (DevExpress.Xpo.Metadata.XPMemberInfo info in item.ClassInfo.PersistentProperties)
                {
                    sqlStorageItem.Attributes.Add(new MapItemAttribute() { Name = info.Name, Value = info.GetValue(item) });
                }
                storage.Items.Add(sqlStorageItem);
            }

            return sqlStorageItem;

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
                        IXPGeometry geom = (IXPGeometry)((IBindingList)DataSource).AddNew();
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

        private void Layer_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            ZoomToFitLayerItems();
        }



    }
}
