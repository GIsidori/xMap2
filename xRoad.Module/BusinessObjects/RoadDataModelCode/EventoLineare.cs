using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using xMap.Persistent.Base;
using Microsoft.SqlServer.Types;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class EventoLineare : IXPGeometry
    {
        public EventoLineare(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private GeometriaEventoLineare geometria;

        public override GeometriaEvento GeometriaEvento { get => GeometriaEventoLineare; set => GeometriaEventoLineare = (GeometriaEventoLineare) value; }


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

                if (prevGeom != null && prevGeom.Evento == this)
                    prevGeom.Evento = null;

                if (geometria != null)
                    geometria.Evento = this;

                OnChanged(nameof(GeometriaEvento));

            }
        }

        public SqlGeometry Shape { get => geometria?.Shape; set { if (geometria != null) geometria.Shape = value; } }

    }

}
