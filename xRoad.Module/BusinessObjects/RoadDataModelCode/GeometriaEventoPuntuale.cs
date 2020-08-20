using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Entity.Model.Metadata;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class GeometriaEventoPuntuale
    {
        public GeometriaEventoPuntuale() : base() { }
        public GeometriaEventoPuntuale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }


        //private EventoPuntuale evento;
        //[NonPersistent]
        //public EventoPuntuale EventoPuntuale
        //{
        //    get => evento;
        //    set
        //    {
        //        if (evento == value)
        //            return;

        //        EventoPuntuale prevEv = evento;
        //        evento = value;

        //        if (IsLoading)
        //            return;

        //        OidEvento = evento?.Oid;

        //        if (prevEv != null && prevEv.GeometriaEventoPuntuale == this)
        //            prevEv.GeometriaEventoPuntuale = null;

        //        if (evento != null)
        //            evento.GeometriaEventoPuntuale = this;

        //        OnChanged(nameof(Evento));

        //    }
        //}

    }

}
