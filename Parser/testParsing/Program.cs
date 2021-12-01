using HtmlAgilityPack;
using System;

namespace testParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb w = new HtmlWeb();
            var hd = w.Load("https://pokemongolife.ru/pokemony/");

            var cites = hd.DocumentNode.SelectNodes("//a[@class='navbar-brand']");

            foreach (var cite in cites)
                Console.WriteLine(cite.InnerText);
        }
    }
}
