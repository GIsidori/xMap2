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

    public partial class EventoLineare
    {
        public EventoLineare(Session session) : base(session) { }
        public override void AfterConstruction() 
        {
            this.TipoGeometria = TipoGeometriaEvento.Lineare;
            base.AfterConstruction(); 
        }


    }

}
