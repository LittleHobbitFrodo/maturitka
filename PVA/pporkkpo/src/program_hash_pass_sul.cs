using System;
using System.Security.Cryptography;

namespace Sul
{
    class Uzivatel
    {
    
        private string pass;
        private const int SaltLength = 16;
        private const int HashLength = 32;
        private const int Iter = 100000;

        public Uzivatel(string pass)
        {
            this.pass = HashPass(pass);
        }

        public string Pass
        {
            get { return pass; }
            set { Console.WriteLine("forbidden"); }
        }

        private static string HashPass(string pass)
        {
            byte[] RandomSalt = new byte[SaltLength];
            
            RandomNumberGenerator.Fill(RandomSalt);
            
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(pass, RandomSalt, Iter, HashAlgorithmName.SHA256, HashLength);
                
            return Convert.ToBase64String(Combine(RandomSalt, hash));
        }

        public bool Validate(string pass)
        {
            int k;
            byte[] storedPass = Convert.FromBase64String(this.pass);
            byte[] possibleSalt = new byte[SaltLength];

            Array.Copy(storedPass, 0, possibleSalt, 0, SaltLength);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(pass, possibleSalt, Iter, HashAlgorithmName.SHA256, HashLength);

            for(k = 0; k < HashLength; k++)
            {
                if(hash[k] != storedPass[SaltLength + k])
                {
                    return false;
                }
            }

            return true;
        }

        public void SavePass(string path)
        {
            if(path == null)
            {
                throw new ArgumentException("Path cannot be null");
            }
        }

        private static byte[] Combine(byte[] one, byte[] two)
        {
            byte[] ret = new byte[one.Length + two.Length];

            Array.Copy(one, 0, ret, 0, one.Length);
            Array.Copy(two, 0, ret, one.Length, two.Length);

            return ret;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Uzivatel jaja = new Uzivatel("1234567890");
            Console.WriteLine(jaja.Pass);
            Console.WriteLine(jaja.Validate("1234567890"));
        }
    }
}