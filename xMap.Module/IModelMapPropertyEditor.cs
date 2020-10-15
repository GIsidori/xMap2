using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xMap.Persistent.Base;

namespace xMap.Module
{

    public interface IModelMapOptions:IModelOptions
    {
        string BingKey { get; set; }
    }


    public interface IModelMapPropertyEditor : IModelPropertyEditor
    {
        [Description("Visualizza toolbar nel controllo mappa")]
        [Category("Map")]
        [ModelBrowsable(typeof(IsMapCalculator))]
        bool ShowToolbar { get; set; }

        [Description("Elenco layers")]
        [Category("Map")]
        [ModelBrowsable(typeof(IsMapCalculator))]
        IModelMapLayers MapLayers { get; }
    }

    public enum LayerType
    {
        VectorLayer,
        WMSLayer,
        BingMapLayer,
        InformationLayer
    }

    public interface IModelMapLayer : IModelNode
    {

        LayerType LayerType { get; set; }
        string LayerName { get; set; }
        string Uri { get; set; }
        [DefaultValue(true)]
        bool Visible { get ; set ; }
        string DataSourceProperty { get; set; }
    }

    public interface IModelMapLayers : IModelNode, IModelList<IModelMapLayer>
    {

    }

    public class IsMapCalculator : VisibilityCalculatorBase, IModelIsVisible
    {
        public bool IsVisible(IModelNode node, String propertyName)
        {
            if (node is IModelMemberViewItem mm)
                return mm.ModelMember.MemberInfo.MemberTypeInfo.ImplementedInterfaces.Any(i=>i.Type == typeof(IXPGeometry));
            return false;
        }
    }
}
