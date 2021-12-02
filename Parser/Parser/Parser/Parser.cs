using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Parser
{
    class Parser
    {
        public List<string> Parsing()
        {
            IWebDriver driver = new ChromeDriver();

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");

            driver = new ChromeDriver(service, options);

            driver.Url = @"https://pokemongolife.ru/pokemony/";

            List<string> pokemons = new List<string>();

            for (int i = 0; i < 30; i++)
            {
                var NamePokemons = driver.FindElements(By.XPath(".//div[@id='dle-content']/a[@class='soft3-item soft-fix']"));
                foreach (IWebElement NamePokemon in NamePokemons)
                {
                    pokemons.Add(NamePokemon.Text);
                }
                Thread.Sleep(2000);
                IWebElement FriendAddRequest = driver.FindElement(By.XPath(".//span[@class='pnext']"));
                FriendAddRequest.Click();
            }
            driver.Quit();
            return  pokemons;
            
        }

    }
}