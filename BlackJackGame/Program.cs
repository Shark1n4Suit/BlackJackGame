using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            deck bj = new deck();
            int bet;
            int money = 100;
            Console.WriteLine("Click enter to start");
            Console.ReadKey();
            while (true)
            {
                bj.deckAdd();
                Console.WriteLine("Enter bet value");
                bet = Convert.ToInt32(Console.ReadLine());
                money -= bet;
                List<int> player = new List<int>();
                List<int> dealer = new List<int>();
                for(int i = 0; i < 2; i++)
                {
                    player.Add(bj.draw());
                    dealer.Add(bj.draw());
                }
                Console.WriteLine("Cards are " + player[0] + " and " + player[1] + "\nTotal is " + player.Sum(x => Convert.ToInt32(x)));
                if(player.Sum(x => Convert.ToInt32(x)) == 21)
                {
                    Console.WriteLine("Blackjack!");
                    money += bet + bet;
                    bj.deckRemove();
                    continue;
                }
                if(player.Sum(x => Convert.ToInt32(x)) > 21)
                {
                    if (player.Contains(11))
                    {
                        player.Remove(player.IndexOf(11));
                        player.Add(1);
                    }
                    else Console.WriteLine("Bust!"); continue;
                }
            }
        }
    }
    class deck
    {
        List<int> cards = new List<int>();
        public void deckAdd()
        {
            for (int i = 2; i <= 11; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cards.Add(i);
                    if(i == 10)
                    {
                        for(int k = 0; k < 4; k++)
                        {
                            cards.Add(i);
                        }
                    }
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
    }
}
