using System;

namespace BlackJackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
     class deck
    {
        List<int> cards = new List<int>();
        public void deckAdd()
        {
            for(int i = 2; i <= 10; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    cards.Add(i);
                }
            }
        }
    }
}
