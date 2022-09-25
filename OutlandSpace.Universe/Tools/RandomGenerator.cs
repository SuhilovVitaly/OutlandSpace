using System;

namespace OutlandSpace.Universe.Tools
{
    public class RandomGenerator
    {
        private static readonly Random RandomBase = new((int)DateTime.UtcNow.Ticks);

        public static int GetInteger(int min = 0, int max = 0)
        {
            return RandomBase.Next(min, max);
        }
    }
}