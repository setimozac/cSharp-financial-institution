using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.exceptions
{
    public class CustomInvalidDataException : Exception
    {
        public CustomInvalidDataException(string msg) :base(msg)
        {

        }
    }
}
