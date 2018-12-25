using System;
namespace ProgetApiJsonEsterno.Dati.Models
{
    public class FilmSearch
    {
        public FilmSearch()
        {
        }
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
