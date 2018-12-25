using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProgetApiJsonEsterno.Dati.Models;

namespace Progetto2JsonEsteno
{ // questa variante usa .Result per avere i dati
    //si puo usare il system.net.http.formating.extewnsion oppure microsoft.aspNet.WebApi.Client
    class Variante2
    {
        public static HttpClient client = new HttpClient();

        //ho modificato il nome della funzione
        static void Main2(string[] args)
        {
            Console.WriteLine("insrisci il nome di un film");
            var input = Console.ReadLine();

            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try {
                var dati = GetProductAsync("http://www.omdbapi.com/?apikey=f2aa739c&s=" + input).Result;
                ShowProduct(dati);
            }catch(Exception ex) {
                Console.Write(ex.Message);
            }








        }

        public static void ShowProduct(RootObject dati)
        {
            // monstra i dati per il input di ricerca
            foreach (var r in dati.Search)
            {
                Console.WriteLine(r.Title);
            }
            // creare cartelle e file con i risultati


        }




        public static async Task<RootObject> GetProductAsync(string path)
        {
            RootObject films = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                films = await response.Content.ReadAsAsync<RootObject>();


            }
            return films;
        }
    }

}
