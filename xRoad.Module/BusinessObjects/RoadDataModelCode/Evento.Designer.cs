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

    [Persistent(@"EVENTO")]
    public partial class Evento : XPObject
    {
        Strada fStrada;
        [NoForeignKey]
        public Strada Strada
        {
            get { return fStrada; }
            set { SetPropertyValue<Strada>(nameof(Strada), ref fStrada, value); }
        }
        double fInizio;
        public double Inizio
        {
            get { return fInizio; }
            set { SetPropertyValue<double>(nameof(Inizio), ref fInizio, value); }
        }
        double fFine;
        public double Fine
        {
            get { return fFine; }
            set { SetPropertyValue<double>(nameof(Fine), ref fFine, value); }
        }
        double fOffset;
        public double Offset
        {
            get { return fOffset; }
            set { SetPropertyValue<double>(nameof(Offset), ref fOffset, value); }
        }
        PosizioneEvento fPosizione;
        public PosizioneEvento Posizione
        {
            get { return fPosizione; }
            set { SetPropertyValue<PosizioneEvento>(nameof(Posizione), ref fPosizione, value); }
        }
        DateTime? fDataInizio;
        public DateTime? DataInizio
        {
            get { return fDataInizio; }
            set { SetPropertyValue<DateTime?>(nameof(DataInizio), ref fDataInizio, value); }
        }
        DateTime? fDataFine;
        public DateTime? DataFine
        {
            get { return fDataFine; }
            set { SetPropertyValue<DateTime?>(nameof(DataFine), ref fDataFine, value); }
        }
        Atto fAtto;
        [Aggregated]
        public Atto Atto
        {
            get { return fAtto; }
            set { SetPropertyValue<Atto>(nameof(Atto), ref fAtto, value); }
        }
    }

}
