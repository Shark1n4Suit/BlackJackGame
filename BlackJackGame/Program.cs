using System;
using System.Collections.Generic;
/*
Class deck kommer ha metoderna draw, deckAdd och deckRemove. gör så att man kan resetta decken enkelt och dra kort som man vill
*/
namespace BlackJackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Du får välja vad ess är värt
            int ess;
            Console.WriteLine("Hej och välkommen till Black Jack");
            Console.Write("vänligen skriv in vad ess ska vara värt(1 eller 11):");
            ess= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("bra, ess är nu värt" + ess);
            Console.WriteLine("då kör vi");
            //spelare och bot får två kort
            
        }
    }
    class deck
    {
        List<int> cards = new List<int>();
        public void deckAdd()
        {
            for (int i = 2; i <= 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cards.Add(i);
                }
            }
        }
        public int draw()
        {
            Random rnd = new Random();
            return cards[rnd.Next(0, cards.Count)];
        }
        public void deckRemove()
        {
            cards.Clear();
        }
        public void addEss(int ess)
        {
            for(int i = 0; i < 4; i++)
            {
                cards.Add(ess);
            }
        }
    }
}
