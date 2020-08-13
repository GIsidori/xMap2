using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using NetTopologySuite.Geometries;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class EventoPuntuale
    {
        public EventoPuntuale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private GeometriaEventoPuntuale geometria;

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Always), NoForeignKey]
        public GeometriaEventoPuntuale GeometriaEventoPuntuale
        {
            get => geometria;
            set
            {
                if (geometria == value)
                    return;

                GeometriaEventoPuntuale prevGeom = geometria;
                geometria = value;

                if (IsLoading)
                    return;

                if (prevGeom != null && prevGeom.EventoPuntuale == this)
                    prevGeom.EventoPuntuale = null;

                if (geometria != null)
                    geometria.EventoPuntuale = this;

                OnChanged(nameof(GeometriaEvento));

            }
        }

        public Geometry Shape { get => geometria?.Shape; set { if (geometria != null) geometria.Shape = value; } }

    }

}
