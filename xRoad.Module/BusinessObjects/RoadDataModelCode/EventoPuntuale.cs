using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xMap.Persistent.Base;
using NetTopologySuite.Geometries;
using DevExpress.Persistent.Base;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public abstract partial class EventoPuntuale:IXPGeometry
    {
        public EventoPuntuale(Session session) : base(session) { }

        [VisibleInListView(false), VisibleInLookupListView(false), VisibleInDetailView(false), VisibleInDashboards(false)]
        public Geometry Shape
        {
            get => ((IXPGeometry)Geometria)?.Shape;
            set => ((IXPGeometry)Geometria).Shape = value;
        }

        [NoForeignKey, Browsable(false),NonPersistent]
        public GeometriaPuntuale Geometria
        {
            get { return Session.FindObject<GeometriaPuntuale>(new BinaryOperator(nameof(GeometriaPuntuale.Evento), this.Oid)); }
        }

        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
