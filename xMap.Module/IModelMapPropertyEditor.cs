using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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


    public interface IModelMap:IModelNode,IModelMapLayer
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

    public interface IModelMapListView : IModelListView, IModelMap
    {
    }

    public interface IModelMapPropertyEditor : IModelPropertyEditor,IModelMap
    {
    }

    public enum LayerType
    {
        VectorLayer,
        WMSLayer,
        BingMapLayer,
        InformationLayer
    }

    [Description("Descrive le proprietà del layer.")]
    public interface IModelMapLayer : IModelNode
    {

        [Category("Map")]
        LayerType LayerType { get; set; }
        [Category("Map")]
        string LayerName { get; set; }
        [Category("Map")]
        string Uri { get; set; }
        [Category("Map")]
        [DefaultValue(true)]
        bool Visible { get; set; }
        [Category("Map")]
        string DataSourceProperty { get; set; }
        [Category("Map")]
        FontStyle? FontStyle { get; set; }
        [Category("Map")]
        Color? FillColor { get; set; }
        [Category("Map")]
        Color? StrokeColor { get; set; }
        [Category("Map")]
        Color? TextColor { get; set; }
        [Category("Map")]
        Color? TextGlowColor { get; set; }
        [Category("Map")]
        int? StrokeWidth { get; set; }
        [Category("Map")]
        VisibilityMode? TitleVisible { get; set; }
    
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
            if (node is IModelMapListView ml)
                return ml.ModelClass.TypeInfo.ImplementedInterfaces.Any(i => i.Type == typeof(IXPGeometry));
            return false;
        }
    }
}
