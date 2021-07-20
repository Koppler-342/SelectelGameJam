
using System;

namespace Utils
{
    public static class ShuffleArray
    {
        public static void Shuffle<T> (T[] array)
        {
            Random _random = new Random();
            
            int n = array.Length;
            
            while (n > 1) 
            {
                int k = _random.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}