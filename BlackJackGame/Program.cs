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
                Console.WriteLine("Balance: " + money);
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
                    else Console.WriteLine("Bust!"); bj.deckRemove(); continue;
                }
                bool hitstand = true;
                while(hitstand == true)
                {
                    Console.WriteLine("Hit/Stand");
                    string input = Console.ReadLine();
                    if (input == "Hit")
                    {
                        player.Add(bj.draw());
                        Console.WriteLine("Card is " + player[2] + "\nTotal is " + player.Sum(x => Convert.ToInt32(x)));
                        if (player.Sum(x => Convert.ToInt32(x)) > 21)
                        {
                            if (player.Contains(11))
                            {
                                player.Remove(player.IndexOf(11));
                                player.Add(1);
                            } 
                            else Console.WriteLine("Bust!"); bj.deckRemove(); continue;
                        }
                    }
                    else if (input == "Stand")
                    {
                        hitstand = false;
                    }
                    else Console.WriteLine("Invalid input, reset");
                }
                bool dealerturn = true;
                while(dealerturn == true)
                {
                    if (dealer.Sum(x => Convert.ToInt32(x)) > 16)
                    {
                        dealer.Add(bj.draw());
                        if (dealer.Sum(x => Convert.ToInt32(x)) > 21)
                        {
                            if (dealer.Contains(11))
                            {
                                dealer.Remove(dealer.IndexOf(11));
                                dealer.Add(1);
                            }
                            else Console.WriteLine("Dealer bust!"); money += bet + bet; bj.deckRemove(); continue;
                        }
                    }
                    else dealerturn = false;
                }
                if (dealer.Sum(x => Convert.ToInt32(x)) < player.Sum(x => Convert.ToInt32(x)))
                {
                    Console.WriteLine("Player win!");
                    money += bet + bet;
                    bj.deckRemove();
                    continue;
                }
                else if (dealer.Sum(x => Convert.ToInt32(x)) > player.Sum(x => Convert.ToInt32(x)))
                {
                    Console.WriteLine("Dealer win!");
                    bj.deckRemove();
                    continue;
                }
                else Console.WriteLine("Tie!"); money += bet; bj.deckRemove(); continue;
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
