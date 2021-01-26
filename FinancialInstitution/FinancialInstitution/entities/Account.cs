using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    class Account
    {
        private int _userId;
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        private string _accountNumber;
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                _accountNumber = value;
            }
        }

        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                _createdDate = value;
            }
        }

        private AccountTypeEnum _accountType;

        public AccountTypeEnum AccountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                _accountType = value;
            }
        }

        private double _balance;
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }
    }

    public enum AccountTypeEnum
    {
        Checking,
        Saving,
        TaxFreeSaving,
        creadit
    }
}
