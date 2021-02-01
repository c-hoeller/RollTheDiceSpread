using System;
using System.Collections.Generic;
using System.Linq;

namespace RollTheDice
{
    public static class DiceGame
    {
        public static Dictionary<int, int> GetSpread(int rolls, int numberOfDices)
        {
            // prepare spreadsheet
            var spread = new Dictionary<int, int>();
            var possibleValues = Enumerable.Range(numberOfDices, numberOfDices * 6 - (numberOfDices - 1));
            foreach (var number in possibleValues)
            {
                spread.Add(number, 0);
            }
            
            //roll the dice
            for (int i = 0; i < rolls; i++)
            {
                var sum = 0;
                for (int j = 0; j < numberOfDices; j++)
                {
                    sum += RollTheDice();
                }
                spread[sum]++;
            }

            return spread;
        }
        
        private static int RollTheDice() => new Random().Next(1, 7);

    }
}