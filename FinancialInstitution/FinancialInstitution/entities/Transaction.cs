using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    public class Transaction
    {
        private int _transactionNumber;
        public int TransactionNumber
        {
            get
            {
                return _transactionNumber;
            }
            set
            {
                _transactionNumber = value;
            }
        }

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

        private int _recieverUserId;
        public int RecieverUserId
        {
            get
            {
                return _recieverUserId;
            }
            set
            {
                _recieverUserId = value;
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

        private string _recieverAccountNumber;
        public string RecieverAccountNumber
        {
            get
            {
                return _recieverAccountNumber;
            }
            set
            {
                _recieverAccountNumber = value;
            }
        }

        private DateTime _transactionDate;
        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set
            {
                _transactionDate = value;
            }
        }

        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        public virtual User User { get; set; }
    }
}
