using System.Numerics;

namespace FactorizationMethod
{
    public class Inverse
    {
        private static BigInteger Egcd(BigInteger left,
                              BigInteger right,
                          out BigInteger leftFactor,
                          out BigInteger rightFactor)
        {
            leftFactor = 0;
            rightFactor = 1;
            BigInteger u = 1;
            BigInteger v = 0;
            BigInteger gcd = 0;

            while (left != 0)
            {
                BigInteger q = right / left;
                BigInteger r = right % left;

                BigInteger m = leftFactor - u * q;
                BigInteger n = rightFactor - v * q;

                right = left;
                left = r;
                leftFactor = u;
                rightFactor = v;
                u = m;
                v = n;

                gcd = right;
            }

            return gcd;
        }

        public static BigInteger gcd(BigInteger m, BigInteger n)
        {
            BigInteger x, y;
            return Egcd(m,n,out x,out y);
        }

        public static BigInteger ModInverse(BigInteger value, BigInteger modulo)
        {
            BigInteger x, y;

            Egcd(value, modulo, out x, out y);

            if (x < 0)
                x += modulo;

            return x % modulo;
        }
    }
}
