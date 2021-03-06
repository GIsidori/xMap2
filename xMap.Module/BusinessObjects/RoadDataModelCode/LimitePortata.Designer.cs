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

    [Persistent(@"EV_LimitePortata")]
    public partial class LimitePortata : EventoLineare
    {
        double fPortata;
        [DevExpress.Xpo.DisplayName(@"Portata (Ton)")]
        public double Portata
        {
            get { return fPortata; }
            set { SetPropertyValue<double>(nameof(Portata), ref fPortata, value); }
        }
        Strada fStrada;
        [Association(@"LimitePortataReferencesStrada"), NoForeignKey]
        public Strada Strada
        {
            get { return fStrada; }
            set { SetPropertyValue<Strada>(nameof(Strada), ref fStrada, value); }
        }
    }

}
