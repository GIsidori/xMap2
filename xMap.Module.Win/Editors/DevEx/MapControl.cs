﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraMap;
using xMap.Persistent.Base;
using System.Data.SqlTypes;

namespace xMap.Module.Win.Editors.DevEx
{
    public partial class MapControl : UserControl
    {

        IBindingList bindingList;

        public MapControl()
        {
            InitializeComponent();
            layer.DataLoaded += this.Layer_DataLoaded;
            map.MapEditor.MapItemEdited += this.MapEditor_MapItemEdited;
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
                            SqlChars str = new SqlChars(new SqlString(shp.ExportToWkt()));
                            geom.Shape = Microsoft.SqlServer.Types.SqlGeometry.STGeomFromText(str, 25832);
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
    ;
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
                    storage.Items.Add(new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.STSrid));
                }
            }

            //storage.SourceCoordinateSystem = new CartesianSourceCoordinateSystem() { CoordinateConverter = new UTMCartesianToGeoConverter(32, Hemisphere.Northern) };

            map.ResumeRender();

        }

        private void Layer_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            map.ZoomToFitLayerItems(0.4);
        }

    }
}