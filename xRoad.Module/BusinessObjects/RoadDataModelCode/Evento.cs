using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xMap.Persistent.Base;
using NetTopologySuite.Geometries;
using DevExpress.ExpressApp.Workflow.StartWorkflowConditions;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{
    public interface IEvento
    {
        Strada Strada { get; set; }
    }


    public abstract partial class Evento
    {
        public Evento(Session session) : base(session) { }

        public override void AfterConstruction() {
            DataInizio = System.DateTime.Now.Date;
            base.AfterConstruction(); }


        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case nameof(Strada):
                    Strada s = newValue as Strada;
                    Sigla = s?.Sigla;
                    break;
                case nameof(Sigla):
                    string sigla = newValue as string;
                    ((IEvento)this).Strada = Session.FindObject<Strada>(new BinaryOperator(nameof(Sigla), sigla));
                    break;
                default:
                    break;
            }
        }

    }

}
