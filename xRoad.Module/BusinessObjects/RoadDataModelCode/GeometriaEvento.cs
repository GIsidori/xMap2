using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public abstract partial class GeometriaEvento
    {
        public GeometriaEvento() : base() { }
        public GeometriaEvento(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private long? oidEvento;
        [Persistent("Evento")]
        protected long? OidEvento
        {
            get => oidEvento;
            set => SetPropertyValue<long?>(nameof(OidEvento), ref oidEvento, value);
        }

        private Evento evento;

        [NoForeignKey, NonPersistent]
        public Evento Evento
        {
            get => evento;
            set
            {
                if (evento == value)
                    return;

                Evento prevEv = evento;
                evento = value;

                if (IsLoading)
                    return;

                OidEvento = evento.Oid;

                if (prevEv != null && prevEv.GeometriaEvento == this)
                    prevEv.GeometriaEvento = null;

                if (evento != null)
                    evento.GeometriaEvento = this;

                OnChanged(nameof(Evento));

            }
        }
    }

}
