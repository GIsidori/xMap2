using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xMap.Module;
using xMap.Persistent.Base;
using xMap.Persistent.BaseImpl;

namespace xMap.Module.Win.Editors.DevEx
{
    [ListEditor(typeof(IXPGeometry), false)]
    public class MapListEditor : ListEditor
    {
        private MapControl map;

        public MapListEditor(IModelListView model):base(model)
        {

        }

        public override void Dispose()
        {
            map = null;
            base.Dispose();
        }

        public override SelectionType SelectionType => SelectionType.Full;

        public override IList GetSelectedObjects()
        {
            if (map == null)
                return new List<object>();
            return map.GetSelectedItems();
        }

        public override void Refresh()
        {
        }

        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (map == null)
                return;

            map.AddLayers(this.ObjectTypeInfo, this.Model);
            map.RefreshDataSource(DataSource);
        }

        protected override object CreateControlsCore()
        {
            map = new MapControl();

            SubscribeMapEvents();

            return map;
        }

        private void SubscribeMapEvents()
        {
            map.MapItemClick += Map_MapItemClick;
            map.MapItemDoubleClick += Map_MapItemDoubleClick;

            map.ObjectSelected += Map_ObjectSelected;
            
        }

        private void Map_ObjectSelected(object sender, ObjectSelectedEventArgs e)
        {
            OnSelectionChanged();
        }

        private void Map_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            OnSelectionChanged();
        }

        private void Map_MapItemDoubleClick(object sender, MapItemClickEventArgs e)
        {
            this.OnProcessSelectedItem();
        }

    }
}
