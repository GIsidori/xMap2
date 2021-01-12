using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace xRoad.Module.BusinessObjects
{
    public enum TipoLocalizzazione
    {
        Odometrica,         //Progressiva chilometrica su strada
        Coordinate,         //Coordinate geografiche
        Toponomastica,      //Via e Numero Civico
        Catasto,            //Dati catastali
    }

    public enum TipoCoordinata
    {
        Geografica,
        Proiettata
    }

    public enum StatoManutenzione
    {
        Normale,
        DaPianificare,
        Urgente
    }

    public enum LivelloGrafo
    {
        LivelloComune = 0,
        Livello1 = 1,
        Livello2 = 2
    }

    public enum TipoGeometriaEvento
    {
        Puntuale,
        Lineare
    }
}