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

    public partial class LimitePortata : EventoLineare
    {
        TipoPortata fPortata;
        public TipoPortata Portata
        {
            get { return fPortata; }
            set { SetPropertyValue<TipoPortata>(nameof(Portata), ref fPortata, value); }
        }
    }

}
