﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xMap.Module.BusinessObjects.DataModel
{

    [Persistent(@"PARCEL")]
    public partial class Parcel : xMap.Persistent.BaseImpl.XPSTGeometry
    {
        Owner fOwner;
        [Persistent(@"OWNER")]
        [Association(@"ParcelReferencesOwner")]
        public Owner Owner
        {
            get { return fOwner; }
            set { SetPropertyValue<Owner>(nameof(Owner), ref fOwner, value); }
        }
        string fCodice;
        [Persistent(@"CODICE")]
        public string Codice
        {
            get { return fCodice; }
            set { SetPropertyValue<string>(nameof(Codice), ref fCodice, value); }
        }
    }

}
