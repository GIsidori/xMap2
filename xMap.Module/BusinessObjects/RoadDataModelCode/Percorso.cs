using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class Percorso
    {
        public Percorso() : base() { }
        public Percorso(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private Strada strada;

        public Strada Strada
        {
            get => strada;
            set
            {
                if (strada == value)
                    return;


                Strada prev = strada;
                strada = value;

                if (IsLoading)
                    return;

                if (prev != null && prev.Percorso == this)
                    prev.Percorso = null;

                if (strada != null)
                    strada.Percorso = this;

                OnChanged(nameof(Strada));

            }
        }
    }

}
