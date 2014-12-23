using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMing.Helper.Helper
{
    public class RandomHelper
    {
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static int GetRandom(int max)
        {
            Random r = new Random(GetRandomSeed());

            return r.Next(max);
        }
    }
}
