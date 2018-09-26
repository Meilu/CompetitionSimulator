using System;
using System.Collections.Generic;
using System.Text;

namespace CompetitionSimulator.Core.Model
{
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int count = list.Count;
            while (count > 1)
            {
                count--;
                int index = Math.RandomGenerator.Next(count + 1);
                T value = list[index];
                list[index] = list[count];
                list[count] = value;
            }
        }
    }
}
