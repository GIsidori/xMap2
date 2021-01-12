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

    [Persistent(@"EV_Tombino")]
    public partial class Tombino : EventoPuntuale
    {
        string fNome;
        public string Nome
        {
            get { return fNome; }
            set { SetPropertyValue<string>(nameof(Nome), ref fNome, value); }
        }
        double fLarghezza;
        [DevExpress.Xpo.DisplayName(@"Larghezza (mt.)")]
        public double Larghezza
        {
            get { return fLarghezza; }
            set { SetPropertyValue<double>(nameof(Larghezza), ref fLarghezza, value); }
        }
        Strada fStrada;
        [Association(@"TombinoReferencesStrada"), NoForeignKey]
        public Strada Strada
        {
            get { return fStrada; }
            set { SetPropertyValue<Strada>(nameof(Strada), ref fStrada, value); }
        }
    }

}