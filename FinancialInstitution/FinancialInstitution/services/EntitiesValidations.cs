using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinancialInstitution.services
{
    public class EntitiesValidations
    {



        // bool ValidatePassword(string input)
        // bool ValidatePassCode(string input)
        // bool ValidateAccountNumber(string input)
        // bool ValidateName(string input)
        // bool ValidateEmail(string input)
        // bool ValidatePhoneNumber(string input)
        // bool ValidateSinNumber(string input)


        public static bool ValidatePassword(string input)
        {



            // Minimum eight characters, at least one letter and one number
            Match match = Regex.Match(input, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }

        // validate the passcode
        public static bool ValidatePassCode(string input)
        {



            // 4 digits
            Match match = Regex.Match(input, @"^[0-9]{4}$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }

        // validate the Account number
        public static bool ValidateAccountNumber(string input)
        {



            
            Match match = Regex.Match(input, @"^\w{1,17}$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }

        // validate the first name - last name - middle name
        public static bool ValidateName(string input)
        {



            
            Match match = Regex.Match(input, @"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }


        // validate the femail address
        public static bool ValidateEmail(string input)
        {



            
            Match match = Regex.Match(input, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }

        // validate Phone number
        public static bool ValidatePhoneNumber(string input)
        {



            
            Match match = Regex.Match(input, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }

        public static bool ValidateSinNumber(string input)
        {



            
            Match match = Regex.Match(input, @"^[0-9]{9}$",
                RegexOptions.IgnoreCase);

            return match.Success;
        }
    }
}
