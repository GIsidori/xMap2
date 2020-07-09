using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Entity.Model.Metadata;
using System.Diagnostics.Tracing;
using DevExpress.Persistent.BaseImpl;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class GeometriaEventoLineare
    {
        public GeometriaEventoLineare() : base() { }
        public GeometriaEventoLineare(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public override Evento Evento { get => EventoLineare; set => EventoLineare = (EventoLineare)value; }

        private EventoLineare evento;

        public EventoLineare EventoLineare
        {
            get => evento;
            set
            {
                if (evento == value)
                    return;

                EventoLineare prevEv = evento;
                evento = (EventoLineare) value;

                if (IsLoading)
                    return;

                if (prevEv != null && prevEv.GeometriaEvento == this)
                    prevEv.GeometriaEvento = null;

                if (evento != null)
                    evento.GeometriaEvento = this;

                OnChanged(nameof(Evento));

            }
        }
    }

}
