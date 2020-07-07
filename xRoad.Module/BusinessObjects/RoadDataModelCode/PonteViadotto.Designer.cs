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

    [Persistent(@"PONTE")]
    [DevExpress.Persistent.Base.DefaultClassOptions]
    public partial class Ponte : Evento
    {
        string fNome;
        public string Nome
        {
            get { return fNome; }
            set { SetPropertyValue<string>(nameof(Nome), ref fNome, value); }
        }
        string fClassificazione;
        public string Classificazione
        {
            get { return fClassificazione; }
            set { SetPropertyValue<string>(nameof(Classificazione), ref fClassificazione, value); }
        }
        TipoImpalcato fTipoImpalcato;
        public TipoImpalcato TipoImpalcato
        {
            get { return fTipoImpalcato; }
            set { SetPropertyValue<TipoImpalcato>(nameof(TipoImpalcato), ref fTipoImpalcato, value); }
        }
        TipoSpalla fTipoSpalla;
        public TipoSpalla TipoSpalla
        {
            get { return fTipoSpalla; }
            set { SetPropertyValue<TipoSpalla>(nameof(TipoSpalla), ref fTipoSpalla, value); }
        }
        int fNumeroCampate;
        public int NumeroCampate
        {
            get { return fNumeroCampate; }
            set { SetPropertyValue<int>(nameof(NumeroCampate), ref fNumeroCampate, value); }
        }
        double fLunghMaxCampata;
        public double LunghMaxCampata
        {
            get { return fLunghMaxCampata; }
            set { SetPropertyValue<double>(nameof(LunghMaxCampata), ref fLunghMaxCampata, value); }
        }
        DateTime fDataIspezione;
        public DateTime DataIspezione
        {
            get { return fDataIspezione; }
            set { SetPropertyValue<DateTime>(nameof(DataIspezione), ref fDataIspezione, value); }
        }
        string fNote;
        public string Note
        {
            get { return fNote; }
            set { SetPropertyValue<string>(nameof(Note), ref fNote, value); }
        }
        string fProprietà;
        public string Proprietà
        {
            get { return fProprietà; }
            set { SetPropertyValue<string>(nameof(Proprietà), ref fProprietà, value); }
        }
        string fElementoAttraversato;
        public string ElementoAttraversato
        {
            get { return fElementoAttraversato; }
            set { SetPropertyValue<string>(nameof(ElementoAttraversato), ref fElementoAttraversato, value); }
        }
        string fCodiceARS;
        public string CodiceARS
        {
            get { return fCodiceARS; }
            set { SetPropertyValue<string>(nameof(CodiceARS), ref fCodiceARS, value); }
        }
    }

}
