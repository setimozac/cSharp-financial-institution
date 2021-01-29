using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.services
{
    class GenerateRandoms
    {
        private static Random random = new Random();
        public static string PasswordRandomString()
        {

            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string pass = "";
            while(!EntitiesValidations.ValidatePassword(pass))
            {
                pass = new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            

            return pass;
        }
    }
}
