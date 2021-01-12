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

    public abstract partial class EventoLineare:IXPGeometry
    {
        public EventoLineare(Session session) : base(session) { }


        [NonPersistent]
        [VisibleInListView(false), VisibleInLookupListView(false), VisibleInDetailView(false), VisibleInDashboards(false)]
        public Geometry Shape
        {
            get => ((IXPGeometry)Geometria)?.Shape;
            set => ((IXPGeometry)Geometria).Shape = value;
        }

        [NoForeignKey, Browsable(false),NonPersistent]
        public GeometriaLineare Geometria
        {
            get { return Session.FindObject<GeometriaLineare>(new BinaryOperator(nameof(GeometriaLineare.Evento),this.Oid)); }
        }

        public override void AfterConstruction() {
            this.TipoGeometria = TipoGeometriaEvento.Lineare;
            base.AfterConstruction(); }
    }

}
