using FinancialInstitution.exceptions;
using FinancialInstitution.services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    public class Profile
    {
        private int _userId;

        [Key]
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

        private string _firstName;

        [Required]
        [StringLength(255)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (!EntitiesValidations.ValidateName(value))
                {
                    throw new CustomInvalidDataException("First name is not valid");
                }
                _firstName = value;
            }
        }

        private string _middleName;

        [StringLength(255)]
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                /*if (!EntitiesValidations.ValidateName(value))
                {
                    throw new CustomInvalidDataException("Middle name is not valid");
                }*/
                _middleName = value;
            }
        }

        private string _lastName;

        [Required]
        [StringLength(255)]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (!EntitiesValidations.ValidateName(value))
                {
                    throw new CustomInvalidDataException("Last name is not valid");
                }
                _lastName = value;
            }
        }

        private string _email;

        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!EntitiesValidations.ValidateEmail(value))
                {
                    throw new CustomInvalidDataException("Email address is not valid");
                }
                _email = value;
            }
        }

        private int _age;

        
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if(value < 0 || value > 150)
                {
                    throw new CustomInvalidDataException("Invalid age");
                }
                _age = value;
            }
        }

        private string _phoneNumber;

        [Required]
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (!EntitiesValidations.ValidatePhoneNumber(value))
                {
                    throw new CustomInvalidDataException("Phone number is not valid");
                }
                _phoneNumber = value;
            }
        }

        private string _adress;

        [Required]
        public string Address
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
            }
        }

        private GenderEnum _gender;

        
        public GenderEnum Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        private byte[] _img;
        public byte[] Img
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
            }
        }

        private MaritalStatusEnum _maritalStatus;
        public MaritalStatusEnum MaritalStatus
        {
            get
            {
                return _maritalStatus;
            }
            set
            {
                _maritalStatus = value;
            }
        }

        private DateTime _dateOfBirth;

        [Required]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
            }
        }

        private string _sinNumber;

        [Required]
        public string SinNumber
        {
            get
            {
                return _sinNumber;
            }
            set
            {
                if (!EntitiesValidations.ValidateSinNumber(value))
                {
                    throw new CustomInvalidDataException("SIN number is not valid");
                }
                _sinNumber = value;
            }
        }


        public virtual User User { get; set; }


    }


    public enum GenderEnum
    {
        Male,
        Female,
        Other
    }

    public enum MaritalStatusEnum
    {
        Married,
        Single,
        Other
    }
}
