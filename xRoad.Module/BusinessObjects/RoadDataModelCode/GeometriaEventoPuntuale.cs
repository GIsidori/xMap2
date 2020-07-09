using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class GeometriaEventoPuntuale
    {
        public GeometriaEventoPuntuale() : base() { }
        public GeometriaEventoPuntuale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public override Evento Evento { get => EventoPuntuale; set => EventoPuntuale = (EventoPuntuale)value; }


        private EventoPuntuale evento;

        public EventoPuntuale EventoPuntuale
        {
            get => evento;
            set
            {
                if (evento == value)
                    return;

                EventoPuntuale prevEv = evento;
                evento = value;

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
