using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xMap.Module;
using xMap.Persistent.Base;
using xMap.Persistent.BaseImpl;

namespace xMap.Module.Win.Editors.DevEx
{
    [ListEditor(typeof(IXPGeometry), true)]
    public class MapListEditor : ListEditor
    {
        private MapControl mapControl;
        private string keyProperty;

        public MapListEditor(IModelListView info) : base(info)
        {
            this.AllowEdit = true;
            keyProperty = info.ModelClass.KeyProperty;
        }

        public override void Dispose()
        {
            mapControl = null;
            base.Dispose();

        }

        public override SelectionType SelectionType => SelectionType.None;

        public override IList GetSelectedObjects()
        {
            return new List<object>();
        }

        public override void Refresh()
        {
            if (mapControl == null)
                return;
        }

        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (mapControl == null)
                return;

            mapControl.RefreshDataSource(dataSource);
        }

        protected override object CreateControlsCore()
        {
            mapControl = new MapControl();
            return mapControl;
        }
    }
}
