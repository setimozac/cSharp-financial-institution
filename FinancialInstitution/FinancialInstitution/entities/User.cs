﻿using FinancialInstitution.exceptions;
using FinancialInstitution.services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    public class User
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _password;

        [Required]
        [StringLength(255)]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (!EntitiesValidations.ValidatePassword(value))
                {
                    throw new CustomInvalidDataException("password format: Minimum eight characters, at least one letter and one number");
                }
                _password = value;
            }
        }

        private int _passCode;

        [Required]
        public int PassCode
        {
            get
            {
                return _passCode;
            }
            set
            {
                if (!EntitiesValidations.ValidatePassCode(value+""))
                {
                    throw new CustomInvalidDataException("pass code must be 4 digits");
                }
                _passCode = value;
            }
        }

        private bool _isEmployee;

        [Required]
        public bool IsEmployee
        {
            get
            {
                return _isEmployee;
            }
            set
            {
                _isEmployee = value;
            }
        }

        public string AccountNum { get => $"number of Accounts: {Accounts.Count()}"; }


        public virtual ICollection<Account> Accounts { get; set; }
        public virtual Profile Profile { get; set; }
        
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
