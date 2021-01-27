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
                _email = value;
            }
        }

        private int _age;

        [Required]
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
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

        private MarialStatusEnum _marialStatus;
        public MarialStatusEnum MarialStatus
        {
            get
            {
                return _marialStatus;
            }
            set
            {
                _marialStatus = value;
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

    public enum MarialStatusEnum
    {
        Married,
        Single,
        Other
    }
}
