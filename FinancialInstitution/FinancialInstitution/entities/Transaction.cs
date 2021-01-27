using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    public class Transaction
    {
        private int _transactionNumber;

        [Key]
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

        
        [ForeignKey("User")]
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

        [ForeignKey("User2")]
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

        [ForeignKey("Account")]
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

        [ForeignKey("Account2")]
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

        [Required]
        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set
            {
                _transactionDate = value;
            }
        }

        private double _amount;

        [Required]
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


        public virtual Account Account { get; set; }
        public virtual Account Account2 { get; set; }
        public virtual User User { get; set; }
        public virtual User User2 { get; set; }
    }
}
