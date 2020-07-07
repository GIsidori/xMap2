using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    public partial class Strada
    {
        public Strada() : base() { }
        public Strada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
