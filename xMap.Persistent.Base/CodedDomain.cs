using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMap.Persistent.Base
{

    [NonPersistent]
    public class StringCodedDomain: XPCustomObject
    {
        public StringCodedDomain(Session session):base(session)
        {

        }

        private string codice;
        [Key]
        public string Codice
        {
            get => codice;
            set => SetPropertyValue<string>(nameof(Codice), ref codice, value);
        }

    }

    [NonPersistent]
    public class ShortIntegerCodedDomain:XPCustomObject
    {
        public ShortIntegerCodedDomain(Session session):base(session)
        {

        }

        private short codice;
        [Key]
        public short Codice
        {
            get => codice;
            set => SetPropertyValue<short>(nameof(Codice), ref codice, value);
        }

    }



}
