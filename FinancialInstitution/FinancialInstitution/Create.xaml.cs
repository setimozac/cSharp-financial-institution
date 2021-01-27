using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FinancialInstitution.entities;
using FinancialInstitution.exceptions;
using Microsoft.Win32;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public event Action<User> RequestResult;
        private readonly User _currentPerson;
        private byte[] _currentImage;
        public Create(User user)
        {
            InitializeComponent();
            RenderData();
            _currentPerson = user;
        }

        private void RenderData()
        {
            CbGender.ItemsSource = Enum.GetValues(typeof(GenderEnum));
            CbGender.SelectedIndex = 0;
            CbMaritalStatus.ItemsSource = Enum.GetValues(typeof(MaritalStatusEnum));
            CbMaritalStatus.SelectedIndex = 0;
        }

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Image files (*.jpg)|*.jpg|*.jpeg|*.png|All Files (*.*)|*.*", RestoreDirectory = true
            };
            if (ofd.ShowDialog() != true) return;
            try
            {
                _currentImage = File.ReadAllBytes(ofd.FileName);
                ImgCustomer.Source = ByteArrayToBitmapImage(_currentImage);
            }
            catch (CustomInvalidDataException ex)
            {
                throw ex;
            }
        }

        private BitmapImage ByteArrayToBitmapImage(byte[] currentImage)
        {
            var newImage = new BitmapImage();
            using (var ms = new MemoryStream(currentImage))
            {
                newImage.BeginInit();
                newImage.CacheOption = BitmapCacheOption.OnLoad;
                newImage.StreamSource = ms;
                newImage.EndInit();
                return newImage;
            }
        }

        private void BtnCreateCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnCreateSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbFirstName.Text != "")
            {
                _currentPerson.Profile.FirstName = TbFirstName.Text;
            }
            else
            {
                MessageBox.Show("First name must be filled","Null error", MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            _currentPerson.Profile.MiddleName = TbMiddleName.Text;

            if (TbLastName.Text != "")
            {
                _currentPerson.Profile.LastName = TbLastName.Text;
            }
            else
            {
                MessageBox.Show("Last name must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DateTime.TryParse(DpBirthDate.Text, out DateTime birthDate))
            {
                _currentPerson.Profile.DateOfBirth = birthDate;
            }
            else
            {
                MessageBox.Show("Select the birth date", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _currentPerson.Profile.Gender = (GenderEnum)CbGender.SelectedItem;
            _currentPerson.Profile.MaritalStatus = (MaritalStatusEnum)CbMaritalStatus.SelectedItem;

            if (TbAddress.Text != "")
            {
                _currentPerson.Profile.Address = TbAddress.Text;
            }
            else
            {
                MessageBox.Show("Address must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbPhone.Text != "")
            {
                _currentPerson.Profile.PhoneNumber = TbPhone.Text;
            }
            else
            {
                MessageBox.Show("Phone must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            if (TbEmail.Text != "")
            {
                _currentPerson.Profile.Email = TbEmail.Text;
            }
            else
            {
                MessageBox.Show("Email must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbEmail.Text != "")
            {
                _currentPerson.Profile.Email = TbEmail.Text;
            }
            else
            {
                MessageBox.Show("Email must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbSinNumber.Text != "")
            {
                _currentPerson.Profile.SinNumber = TbSinNumber.Text;
            }
            else
            {
                MessageBox.Show("SIN number must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_currentImage != null)
            {
                _currentPerson.Profile.Img = _currentImage;
            }
            else
            {
                MessageBox.Show("Photo must be selected", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbPassword.Text != "")
            {
                _currentPerson.Password = TbPassword.Text;
            }
            else
            {
                MessageBox.Show("Password must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbPassCode.Text != "")
            {
                if (int.TryParse(TbPassCode.Text, out int passcode))
                {
                    _currentPerson.PassCode = passcode;
                }
                else
                {
                    //throw new CustomInvalidDataException("Pass code must be a number");
                    MessageBox.Show("Pass code must be a number", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Pass code must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (RbIsEmployeeNo.IsChecked == true)
            {
                _currentPerson.IsEmployee = false;
            }
            else
            {
                _currentPerson.IsEmployee = true;
            }

            bool accountTypeIsSelected = false;
            if (CbChecking.IsChecked == true)
            {
                var account1 = new Account
                {
                    CreatedDate = DateTime.Now,
                    AccountType = AccountTypeEnum.Checking,
                    Balance = 0
                };
                _currentPerson.Accounts.Add(account1);
                accountTypeIsSelected = true;
            }

            if (CbSaving.IsChecked == true)
            {
                var account2 = new Account
                {
                    CreatedDate = DateTime.Now,
                    AccountType = AccountTypeEnum.Saving,
                    Balance = 0
                };
                _currentPerson.Accounts.Add(account2);
                accountTypeIsSelected = true;
            }

            if (CbTaxFreeSaving.IsChecked == true)
            {
                var account3 = new Account
                {
                    CreatedDate = DateTime.Now,
                    AccountType = AccountTypeEnum.TaxFreeSaving,
                    Balance = 0
                };
                _currentPerson.Accounts.Add(account3);
                accountTypeIsSelected = true;
            }

            if (CbCredit.IsChecked == true)
            {
                var account4 = new Account
                {
                    CreatedDate = DateTime.Now,
                    AccountType = AccountTypeEnum.Credit,
                    Balance = 0
                };
                _currentPerson.Accounts.Add(account4);
                accountTypeIsSelected = true;
            }

            if (accountTypeIsSelected != true)
            {
                MessageBox.Show("Account type must be selected at least one", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            RequestResult?.Invoke(_currentPerson);
            DialogResult = true;
        }
    }
}
