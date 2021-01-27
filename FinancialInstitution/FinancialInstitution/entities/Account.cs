using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    public class Account
    {
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

        private string _accountNumber;

        [Key]
        [Required]
        [StringLength(255)]
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

        [Required]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                _createdDate = value;
            }
        }

        private AccountTypeEnum _accountType;

        [Required]
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

        [Required]
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


        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual User User { get; set; }
    }

    public enum AccountTypeEnum
    {
        Checking,
        Saving,
        TaxFreeSaving,
        creadit
    }
}
