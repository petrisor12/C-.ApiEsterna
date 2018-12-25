using System;
using System.Collections.Generic;

namespace ProgetApiJsonEsterno.Dati.Models
{
    public class RootObject
    {// e stato utilizzato json2csharp.com per la transformazione dei json in classi
        // e stato utilizzato jsonformatter.curiousconcept.com per vedere in modo chiaro il risultato della api, cioe il json
        public RootObject()
        {
        }
        public List<FilmSearch> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
