using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMap.Persistent.Base
{
    [DesignTimeVisible(false)]
    [DeferredDeletion(false)]
    [OptimisticLocking(false)]
    [NonPersistent]
    public abstract class DefaultXPObject : XPCustomObject
    {
        public DefaultXPObject() : base(Session.DefaultSession)
        {

        }

        public DefaultXPObject(Session session) : base(session)
        {

        }

        private Int64 oid;
        [Key(AutoGenerate = true), Browsable(false), Persistent("OBJECTID"),DbType("NUMBER(*,0)")]
        public Int64 Oid
        {
            get => oid;
            set => SetPropertyValue<Int64>(nameof(Oid), ref oid, value);
        }
    }

}
