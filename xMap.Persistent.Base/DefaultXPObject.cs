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

        private int oid;
        [Key(AutoGenerate = true), Browsable(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue<int>(nameof(Oid), ref oid, value);
        }
    }

}
