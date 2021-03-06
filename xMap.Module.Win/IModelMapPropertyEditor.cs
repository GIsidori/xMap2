﻿using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xMap.Persistent.Base;

namespace xMap.Module.Win
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
            if (node is IModelCommonMemberViewItem mm)
            {
                return mm.PropertyEditorTypes.Contains(typeof(Editors.DevEx.MapEditor));
                //return mm.PropertyEditorType == typeof(Editors.DevEx.MapEditor);
            }
            //ITypeInfo elementType = GetTypeInfo(node, propertyName);
            //if (elementType != null)
            //{
            //    //return elementType.Type == typeof(NetTopologySuite.Geometries.Geometry);
            //    bool rc = typeof(IXPGeometry).IsAssignableFrom(elementType.Type);
            //    return rc;
            //}
            return false;
        }
    }
}
