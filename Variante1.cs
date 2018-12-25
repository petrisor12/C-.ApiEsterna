using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProgetApiJsonEsterno.Dati.Models;

namespace Progetto2JsonEsteno
{
    //si puo usare il system.net.http.formating.extewnsion oppure microsoft.aspNet.WebApi.Client
    // variante 1 come da https://docs.microsoft.com/it-it/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client#create-the-console-application
    class Variante1
    {
        public static HttpClient client = new HttpClient();

        //ho modificato il nome per non avere piu punti di entrata nel progetto
        static void Main1(string[] args)
        {


            RunAsync().GetAwaiter().GetResult();





        }
        public static async Task RunAsync()
        {
            Console.WriteLine("insrisci il nome di un film");
            var input = Console.ReadLine();

            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try {
                var dati = await GetProductAsync("http://www.omdbapi.com/?apikey=f2aa739c&s=" + input);
                ShowProduct(dati);
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }




        }

        public static void ShowProduct(RootObject dati)
        {
            foreach (var r in dati.Search)
            {
                Console.WriteLine(r.Title);
            }
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
