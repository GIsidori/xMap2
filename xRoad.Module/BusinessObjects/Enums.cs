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
        Toponomastica,      //Via e Numero Civico
        Coordinate          //Coordinate geografiche
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
        Livello1,
        Livello2
    }
}