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
namespace xRoad.Module.BusinessObjects.RoadDataModel
{

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    public partial class TipoTransito : xMap.Persistent.Base.StringCodedDomain
    {
        string fDescrizione;
        public string Descrizione
        {
            get { return fDescrizione; }
            set { SetPropertyValue<string>(nameof(Descrizione), ref fDescrizione, value); }
        }
    }

}
