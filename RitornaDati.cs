using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProgetApiJsonEsterno.Dati.Models;

namespace Progetto2JsonEsteno
{
   
    public class RitornaDati
    {
        public static HttpClient client = new HttpClient();

        public static RootObject  DatiFilms(string input) {

            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
           
                var dati = GetProductAsync("http://www.omdbapi.com/?apikey=f2aa739c&s="+input).Result;

                return dati;
           


        }


        public static async Task<RootObject> GetProductAsync(string path)
        {
            RootObject films = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // qui si deserializza da json in rootObject
                films = await response.Content.ReadAsAsync<RootObject>();


            }
            return films;
        }


    }



}


