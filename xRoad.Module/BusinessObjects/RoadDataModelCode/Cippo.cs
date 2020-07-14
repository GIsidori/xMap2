using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;

namespace xRoad.Module.BusinessObjects.RoadDataModel
{
    [EditorAlias("MapListEditor")]
    public partial class Cippo
    {
        public Cippo() : base() { }
        public Cippo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
