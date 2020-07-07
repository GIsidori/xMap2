using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class GeometriaEvento
    {
        public GeometriaEvento() : base() { }
        public GeometriaEvento(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private Evento evento;

        public Evento Evento
        {
            get => evento;
            set
            {
                if (evento == value)
                    return;
                Evento prevEvento = evento;
                evento = value;

                if (IsLoading)
                    return;

                if (prevEvento != null && prevEvento.Geometria == this)
                    prevEvento.Geometria = null;

                if (evento != null)
                    evento.Geometria = this;
                OnChanged(nameof(Evento));
            }

        }
    }

}
