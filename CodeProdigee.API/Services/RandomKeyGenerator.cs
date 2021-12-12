using Konscious.Security.Cryptography;
using SecurityDriven.Core;
using System;
using System.Text;

namespace CodeProdigee.API.Services
{

    public class RandomKeyGenerator
    {
        // Instantiate random number generator.  
        // It is better to keep a single Random instance 
        // and keep using Next on the same instance.  
        private readonly CryptoRandom _random = new();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        // Generates a random password.  
        // 4-LowerCase + 4-Digits + 2-UpperCase  
        public string GarbleStringAsync()
        {
            var payload = RandomString(32);
            var randomStamp = DateTimeOffset.UtcNow.Ticks.ToString();
            var randomId = _random.NextGuid().ToString();
            byte[] saltBytes = Encoding.UTF8.GetBytes($"{randomId}{payload}{randomStamp}");
            byte[] passBytes = Encoding.UTF8.GetBytes($"{payload}");
            var argon2 = new Argon2i(passBytes)
            {
                Salt = saltBytes,
                Iterations = 3,
                DegreeOfParallelism = 1,
                MemorySize = 2048
            };
            var hashedPassword = argon2.GetBytes(32);
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
