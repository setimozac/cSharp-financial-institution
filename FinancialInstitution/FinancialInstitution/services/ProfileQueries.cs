using FinancialInstitution.entities;
using FinancialInstitution.globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.services
{
    public class ProfileQueries
    {
        public static User FetchEmployee(string email, string pass)
        {
            
            var result = (from  u in DbGlobals.ctx.Users
                          join p in DbGlobals.ctx.Profiles on u.Id equals p.UserId
                          where p.Email.Equals(email) && u.Password.Equals(pass) && u.IsEmployee
                          select u).ToList();

            if (result.Count == 1) return result[0];
            return null;
        }
    }
}
