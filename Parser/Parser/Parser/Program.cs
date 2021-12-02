using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Search search = new Search();



            List<string> pokemons2 = parser.Parsing();
            string[] pokemons = pokemons2.ToArray();
            



            

            var sw1 = new Stopwatch();
            var sw2 = new Stopwatch();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Какую функцию поиска желаете использовать 1 или 2");
                string result = Console.ReadLine();
                if (result == "1")
                {
                    sw1.Start();
                    Console.WriteLine(search.search(pokemons));
                    sw1.Stop();
                    Console.WriteLine(sw1.Elapsed);
                }
                else if (result == "2")
                {
                    sw2.Start();
                    Console.WriteLine(search.search2(pokemons2));
                    sw2.Stop();
                    Console.WriteLine(sw2.Elapsed);
                }
                else
                {
                    Console.WriteLine("Вы не правильно указали функцию поиска");
                }

                Console.WriteLine("Желаете ли снова выбрать функцию Y/N ?");
                string answer = Console.ReadLine();

                if (answer == "Y")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

            }

            
        }


    }
}