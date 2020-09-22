using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using xMap.Persistent.Base;
using NetTopologySuite.Geometries;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class Strada:IXPGeometry
    {
        public Strada() : base() { }
        public Strada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private Percorso percorso;

        [VisibleInListView(false),VisibleInLookupListView(false)]
        public Percorso Percorso
        {
            get => percorso;
            set
            {
                if (percorso == value)
                    return;


                Percorso prev = percorso;
                percorso = value;

                if (IsLoading)
                    return;

                if (prev != null && prev.Strada == this)
                    prev.Strada = null;

                if (percorso != null)
                    percorso.Strada = this;

                OnChanged(nameof(Percorso));

            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false),VisibleInDetailView(false),VisibleInDashboards(false)]
        public Geometry Shape { get => ((IXPGeometry)percorso)?.Shape; set => ((IXPGeometry)percorso).Shape = value; }


    }

}
