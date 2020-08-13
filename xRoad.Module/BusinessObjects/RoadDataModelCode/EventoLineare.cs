using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using xMap.Persistent.Base;
using NetTopologySuite.Geometries;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class EventoLineare : IXPGeometry
    {
        public EventoLineare(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private GeometriaEventoLineare geometria;

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Always), NoForeignKey]
        public GeometriaEventoLineare GeometriaEventoLineare
        {
            get => geometria;
            set
            {
                if (geometria == value)
                    return;

                GeometriaEventoLineare prevGeom = geometria;
                geometria = value;

                if (IsLoading)
                    return;

                if (prevGeom != null && prevGeom.EventoLineare == this)
                    prevGeom.EventoLineare = null;

                if (geometria != null)
                    geometria.EventoLineare = this;

                OnChanged(nameof(GeometriaEvento));

            }
        }

        public Geometry Shape { get => geometria?.Shape; set { if (geometria != null) geometria.Shape = value; } }
    }

}
