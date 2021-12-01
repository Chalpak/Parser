using System;
using System.Net.Http;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Parsing(url: "https://pokemongolife.ru/pokemony/");
        }

        private static object Parsing(string url)
        {
            try
            {
                using (HttpClientHandler hd1 = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.None})
                {
                    using (var clnt = new HttpClient(hd1))
                    {
                       using( HttpResponseMessage resp = clnt.GetAsync(url).Result)
                       {
                            if (resp.IsSuccessStatusCode)
                            {
                                var html = resp.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(html))
                                {
                                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                    doc.LoadHtml(html);

                                    var pokemons = doc.DocumentNode.SelectNodes("//div[@id='dle-content']");
                                    if (pokemons != null && pokemons.Count > 0)
                                    {
                                        foreach (var pokemon in pokemons)
                                        {
                                            var namePokemon = pokemon.SelectSingleNode("//a[@class='soft3-item soft-fix']");
                                           // if (namePokemon != null)
                                           // {
                                                string value2 = pokemon.InnerText;
                                                //string value = namePokemon.InnerText;
                                                Console.WriteLine( value2);
                                            //}
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нет покемонов");
                                    }
                                }
                            }
                       }
                    }
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return null;
        }
    }
}
