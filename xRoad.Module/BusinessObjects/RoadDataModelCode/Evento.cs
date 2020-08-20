using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xMap.Persistent.Base;
using NetTopologySuite.Geometries;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class Evento
    {
        public Evento(Session session) : base(session) { }
        public override void AfterConstruction() {
            DataInizio = System.DateTime.Now.Date;
            base.AfterConstruction(); }


        [MemberDesignTimeVisibility(false)]
        [Browsable(false)]
        private string sigla;
        public string Sigla
        {
            get { return sigla; }
            set { SetPropertyValue<string>(nameof(Sigla), ref sigla, value); }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case nameof(Strada):
                    Strada s = newValue as Strada;
                    Sigla = s?.Sigla;
                    break;
                default:
                    break;
            }
        }

    }

}
