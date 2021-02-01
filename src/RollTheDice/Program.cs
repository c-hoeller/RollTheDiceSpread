using System;
using System.Collections.Generic;
using System.Linq;

namespace RollTheDice
{
    class Program
    {
        static void Main(string[] args)
        {
            string exit;
            do
            {
                int numberOfDices;
                Console.WriteLine("With how many dices do you want to play the dice Game?");
                do
                {
                    Console.WriteLine("Choose a number between 1 and 4!");
                    int.TryParse(Console.ReadLine(), out numberOfDices);
                } while (numberOfDices < 1 || numberOfDices > 4);

                int rolls;
                Console.WriteLine("How many rolls do you want?");
                Console.WriteLine("A bigger number will result in longer runtimes. Please be patient.");
                do
                {
                    Console.WriteLine("Choose a number between 1 and 100.000.000");
                    int.TryParse(Console.ReadLine(), out rolls);
                } while (rolls < 1 || rolls >= 100000000 );
                
                ShowSpread(numberOfDices, rolls);
                
                Console.WriteLine("Do you want to exit the Program?");
                Console.WriteLine("(X) for Exit.");
                exit = Console.ReadLine()?.ToUpper();
            } while (exit != "X");
        }

        private static void ShowSpread(int numberOfDices, int rolls)
        {
            var spread = DiceGame.GetSpread(rolls, numberOfDices);

            foreach (var kvp in spread)
            {
                Console.Write("There were {0,-10} rolls for number {1,-10}", kvp.Value, kvp.Key);
                var starsDivider = rolls > 1000 ? rolls / 1000 : 1;
                for (int i = 0; i < kvp.Value / starsDivider; i++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
    }
}