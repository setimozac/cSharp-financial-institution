using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    public class Profile
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

        private string _firstName;
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
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
            }
        }

        private string _sinNumber;
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

    public enum MaritalStatusEnum
    {
        Married,
        Single,
        Other
    }
}
