using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    class Search
    {

        public string search(string[] arr)
        {

            Console.WriteLine("Введите имя покемона которого хотите найти");
            string name = Console.ReadLine();
            string result = "";


            foreach (var item in arr)
            {
                if (item == name)
                {
                    result =("Покемон по имени "+ name.ToString() + " найден!!!" );
                    break;
                }
                else
                {
                    result = ("Покемон по имени " + name.ToString() + " не найден :(");
                }
            }

            return result;

        }


        public string search2(List<string> arr)
        {
            Console.WriteLine("Введите имя покемона");
            string name = Console.ReadLine();
            string result =  arr.Find(item => item == name);

            if (name == result)
            {
                return "Покемон по имени " + result + " найден !!!";
            }
            else
            {
                return "Покемон по имени " + name + " не найден :(";
            }


            
        }








    }
}
