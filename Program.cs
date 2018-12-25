using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProgetApiJsonEsterno.Dati.Models;

namespace Progetto2JsonEsteno
{
    //si puo usare il system.net.http.formating.extewnsion oppure microsoft.aspNet.WebApi.Client
    class Program
    {
       
       

          static void Main(string[] args)
        {
            var ripeti = true;
            do
            {
                Console.WriteLine("inserisci il nome di un film");
                var input = Console.ReadLine();
                var datoFilm = new RootObject();
                datoFilm = RitornaDati.DatiFilms(input);


                ShowFilms(datoFilm);
                Console.WriteLine("Vuoi continuare?qualsiasi tasto oppure N");
                var risposta= Console.ReadKey();
                if (risposta.Key == ConsoleKey.N)
                    ripeti = false;
            } while (ripeti);
           







        }

      public  static void ShowFilms(RootObject dati)
        {
            var path = @"/Users/piero/Documents/cSharp/lezione13/Progetto2JsonEsteno/Progetto2JsonEsteno/DatiRichiesti/";
;
            // monstra i dati per il input di ricerca
            foreach (var r in dati.Search)
            {
                Console.WriteLine($"TITOLO film:  {r.Title}\n ANNO:  {r.Year} \n TIPO: {r.Type}\n POSTER:  {r.Poster}\n COD: {r.imdbID}\n");
                Console.WriteLine("-----------------------------");
            }
            // creare cartelle e file con i risultati
            //de vazuti documentatia per creare cartelle e file  CON JSON (PRIMA SI SERIALIZZA L'OGGETTO )e per scaricare file ( DOWNLOAD in questo caso imagine)
            //se i dati esistono gia cancello il direttore, altrimenti creo il direttore
            if (Directory.Exists(path))
            {

                Directory.Delete(path, true);

            }
            else
            { Directory.CreateDirectory(path); };
            //inserisco i dati ottenuti dalle api nelle diretory e file

            foreach (var m in dati.Search) {
              
               if (!(Directory.Exists(path + m.Title)))
                {
                    Directory.CreateDirectory(path + m.Title);
                    string json = JsonConvert.SerializeObject(m, Formatting.Indented);
                    File.WriteAllText(path + m.Title + "/" + m.Title + ".json", json);
                    var webClient = new WebClient();

                    webClient.DownloadFile(m.Poster, path + m.Title + "/" + m.Title + ".jpg");
                    //modifico ogni immagine per aggiungere la scrita copywrite
                 var   image1 = new Bitmap(path + m.Title + "/" + m.Title + ".jpg", true);
                    string testo = "Copywrite";
                   
                    Point location = new Point(10, image1.Height-20);




                    using (Graphics graphics = Graphics.FromImage(image1
                    ))
                    {
                        using (Font arialFont = new Font("Arial", 10))
                        {
                            graphics.DrawString(testo, arialFont, Brushes.White, location);
                           
                        }
                    }

                    image1.Save(path + m.Title + "/" + m.Title + ".jpg");//save the image file
                }




            }

        }





    }

}
