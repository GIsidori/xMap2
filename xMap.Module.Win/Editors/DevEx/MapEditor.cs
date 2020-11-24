using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xMap.Persistent.Base;

namespace xMap.Module.Win.Editors.DevEx
{
    [PropertyEditor(typeof(IXPGeometry),false)]
    public class MapEditor:WinPropertyEditor
    {
        private MapControl mapControl;
        IModelMapPropertyEditor info;

        public MapEditor(Type objectType,IModelMemberViewItem info):base(objectType,info)
        {
            this.info = info as IModelMapPropertyEditor;
        }

        protected override void Dispose(bool disposing)
        {
            if (mapControl != null)
                mapControl = null;
            base.Dispose(disposing);
        }
        protected override object CreateControlCore()
        {
            mapControl = new MapControl();
            mapControl.AddLayers(info);
            return mapControl;
        }

        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            ReadValue();
        }

        protected override void ReadValueCore()
        {
            if (mapControl != null)
            {
                BindingList<IXPGeometry> list = new BindingList<IXPGeometry>();
                if (CurrentObject is IXPGeometry geom)
                {
                    list.Add(geom);
                }
                mapControl.RefreshDataSource(list);
            }
        }

        protected override object GetControlValueCore()
        {
            return this.PropertyValue;
        }

    }
}
