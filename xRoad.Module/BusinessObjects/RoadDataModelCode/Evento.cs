using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class Evento
    {
        public Evento(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private GeometriaEvento geometria;

        [Aggregated,ExpandObjectMembers(ExpandObjectMembers.Always),NoForeignKey]
        public GeometriaEvento Geometria
        {
            get => geometria;
            set
            {
                if (geometria == value)
                    return;

                GeometriaEvento prevGeom = geometria;
                geometria = value;

                if (IsLoading)
                    return;

                if (prevGeom != null && prevGeom.Evento == this)
                    prevGeom.Evento = null;

                if (geometria != null)
                    geometria.Evento = this;

                OnChanged(nameof(Geometria));

            }
        }

    }

}
