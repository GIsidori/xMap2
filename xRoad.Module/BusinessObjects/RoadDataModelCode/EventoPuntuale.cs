using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xMap.Persistent.Base;
using NetTopologySuite.Geometries;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public abstract partial class EventoPuntuale:IXPGeometry
    {
        public EventoPuntuale(Session session) : base(session) { }

        public Geometry Shape
        {
            get => ((IXPGeometry)fGeometria)?.Shape;
            set => ((IXPGeometry)fGeometria).Shape = value;
        }

        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
