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

    [Persistent(@"STRADA")]
    public partial class Strada : xMap.Persistent.Base.DefaultXPObject
    {
        string fSigla;
        public string Sigla
        {
            get { return fSigla; }
            set { SetPropertyValue<string>(nameof(Sigla), ref fSigla, value); }
        }
        string fDenominazione;
        public string Denominazione
        {
            get { return fDenominazione; }
            set { SetPropertyValue<string>(nameof(Denominazione), ref fDenominazione, value); }
        }
        TipoClassificaFunzionale fClassificaFunzionale;
        public TipoClassificaFunzionale ClassificaFunzionale
        {
            get { return fClassificaFunzionale; }
            set { SetPropertyValue<TipoClassificaFunzionale>(nameof(ClassificaFunzionale), ref fClassificaFunzionale, value); }
        }
        string fNumero;
        public string Numero
        {
            get { return fNumero; }
            set { SetPropertyValue<string>(nameof(Numero), ref fNumero, value); }
        }
        TipoAsse fAsse;
        public TipoAsse Asse
        {
            get { return fAsse; }
            set { SetPropertyValue<TipoAsse>(nameof(Asse), ref fAsse, value); }
        }
        TipoAmministrazione fTipoAmministrazione;
        public TipoAmministrazione TipoAmministrazione
        {
            get { return fTipoAmministrazione; }
            set { SetPropertyValue<TipoAmministrazione>(nameof(TipoAmministrazione), ref fTipoAmministrazione, value); }
        }
        string fTronco;
        public string Tronco
        {
            get { return fTronco; }
            set { SetPropertyValue<string>(nameof(Tronco), ref fTronco, value); }
        }
        [Association(@"EventoReferencesStrada")]
        public XPCollection<Evento> Eventi { get { return GetCollection<Evento>(nameof(Eventi)); } }
        [Association(@"ArcoReferencesStrada"), Aggregated]
        public XPCollection<Arco> Archi { get { return GetCollection<Arco>(nameof(Archi)); } }
        [Association(@"CippoReferencesStrada"), Aggregated]
        public XPCollection<Cippo> Cippi { get { return GetCollection<Cippo>(nameof(Cippi)); } }
    }

}
