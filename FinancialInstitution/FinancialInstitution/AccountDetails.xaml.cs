using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using FinancialInstitution.globals;
using Microsoft.Win32;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for AccountDetails.xaml
    /// </summary>
    public partial class AccountDetails : Window
    {
        public event Action<User> AccountDetailsRequestResult;
        private readonly User _currentUserProfile;
        private byte[] _currentProfileImage;
        public AccountDetails()
        {
            InitializeComponent();
            _currentUserProfile = MainWindow.LogedInClient;
            LoadUser(_currentUserProfile);
        }

        private void LoadUser(User user)
        {
            _currentProfileImage = user.Profile.Img;
            ImgCustomer.Source = Create.ByteArrayToBitmapImage(user.Profile.Img);
            TbFirstName.Text = user.Profile.FirstName;
            TbMiddleName.Text = user.Profile.MiddleName;
            TbLastName.Text = user.Profile.LastName;
            DpBirthDate.SelectedDate = user.Profile.DateOfBirth;
            CbGender.ItemsSource = Enum.GetValues(typeof(GenderEnum));
            CbGender.SelectedItem = user.Profile.Gender;
            CbMaritalStatus.ItemsSource = Enum.GetValues(typeof(MaritalStatusEnum));
            CbMaritalStatus.SelectedItem = user.Profile.MaritalStatus;
            TbAddress.Text = user.Profile.Address;
            TbPhone.Text = user.Profile.PhoneNumber;
            TbEmail.Text = user.Profile.Email;
            TbSinNumber.Text = user.Profile.SinNumber;
            foreach (var account in user.Accounts)
            {
                if (account.AccountType == AccountTypeEnum.Checking)
                {
                    CbChecking.IsChecked = true;
                }
                else if (account.AccountType == AccountTypeEnum.Saving)
                {
                    CbSaving.IsChecked = true;
                }
                else if (account.AccountType == AccountTypeEnum.TaxFreeSaving)
                {
                    CbTaxFreeSaving.IsChecked = true;
                }
                else if (account.AccountType == AccountTypeEnum.Credit)
                {
                    CbCredit.IsChecked = true;
                }
                else
                {
                    CbChecking.IsChecked = true;
                }
            }
        }

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Image files (*.jpg)|*.jpg|*.jpeg|*.png|All Files (*.*)|*.*",
                RestoreDirectory = true
            };
            if (ofd.ShowDialog() != true) return;
            try
            {
                _currentProfileImage = File.ReadAllBytes(ofd.FileName);
                ImgCustomer.Source = Create.ByteArrayToBitmapImage(_currentProfileImage);
            }
            catch (CustomInvalidDataException ex)
            {
                throw ex;
            }
        }

        private void BtnProfileCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnProfileEdit_Click(object sender, RoutedEventArgs e)
        {
            BtnImage.IsEnabled = true;
            TbFirstName.IsEnabled = true;
            TbMiddleName.IsEnabled = true;
            TbLastName.IsEnabled = true;
            DpBirthDate.IsEnabled = true;
            CbGender.IsEnabled = true;
            CbMaritalStatus.IsEnabled = true;
            TbAddress.IsEnabled = true;
            TbPhone.IsEnabled = true;
            TbEmail.IsEnabled = true;
            TbSinNumber.IsEnabled = true;
            CbChecking.IsEnabled = true;
            CbSaving.IsEnabled = true;
            CbTaxFreeSaving.IsEnabled = true;
            CbCredit.IsEnabled = true;
            BtnProfileEdit.Visibility = Visibility.Hidden;
            BtnProfileUpdate.Visibility = Visibility.Visible;
        }

        private void BtnProfileUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (TbFirstName.Text != "")
            {
                _currentUserProfile.Profile.FirstName = TbFirstName.Text;
            }
            else
            {
                MessageBox.Show("First name must be filled", "Null error", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            _currentUserProfile.Profile.MiddleName = TbMiddleName.Text;

            if (TbLastName.Text != "")
            {
                _currentUserProfile.Profile.LastName = TbLastName.Text;
            }
            else
            {
                MessageBox.Show("Last name must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DateTime.TryParse(DpBirthDate.Text, out DateTime birthDate))
            {
                _currentUserProfile.Profile.DateOfBirth = birthDate;
            }
            else
            {
                MessageBox.Show("Select the birth date", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _currentUserProfile.Profile.Gender = (GenderEnum) CbGender.SelectedItem;
            _currentUserProfile.Profile.MaritalStatus = (MaritalStatusEnum) CbMaritalStatus.SelectedItem;

            if (TbAddress.Text != "")
            {
                _currentUserProfile.Profile.Address = TbAddress.Text;
            }
            else
            {
                MessageBox.Show("Address must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbPhone.Text != "")
            {
                _currentUserProfile.Profile.PhoneNumber = TbPhone.Text;
            }
            else
            {
                MessageBox.Show("Phone must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbEmail.Text != "")
            {
                _currentUserProfile.Profile.Email = TbEmail.Text;
            }
            else
            {
                MessageBox.Show("Email must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbEmail.Text != "")
            {
                _currentUserProfile.Profile.Email = TbEmail.Text;
            }
            else
            {
                MessageBox.Show("Email must be filled", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TbSinNumber.Text != "")
            {
                _currentUserProfile.Profile.SinNumber = TbSinNumber.Text;
            }
            else
            {
                MessageBox.Show("SIN number must be filled", "Null error", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (_currentProfileImage != null)
            {
                _currentUserProfile.Profile.Img = _currentProfileImage;
            }
            else
            {
                MessageBox.Show("Photo must be selected", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool checkingFound = false;
            bool savingFound = false;
            bool taxFreeSavingFound = false;
            bool creditFound = false;
            Account checkingAccount = null;
            Account savingAccount = null;
            Account taxFreeSavingAccount = null;
            Account creditAccount = null;
            if ((CbChecking.IsChecked == true) || (CbSaving.IsChecked == true) || (CbTaxFreeSaving.IsChecked == true) || (CbCredit.IsChecked == true))
            {
                foreach (var a in _currentUserProfile.Accounts)
                {
                    if (a.AccountType == AccountTypeEnum.Checking)
                    {
                        checkingAccount = a;
                        checkingFound = true;
                    }
                    if (a.AccountType == AccountTypeEnum.Saving)
                    {
                        savingAccount = a;
                        savingFound = true;
                    }
                    if (a.AccountType == AccountTypeEnum.TaxFreeSaving)
                    {
                        taxFreeSavingAccount = a;
                        taxFreeSavingFound = true;
                    }
                    if (a.AccountType == AccountTypeEnum.Credit)
                    {
                        creditAccount = a;
                        creditFound = true;
                    }
                }

                if (CbChecking.IsChecked == true)
                {
                    if (checkingFound == false)
                        _currentUserProfile.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUserProfile.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(10).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.Checking,
                            Balance = 0,
                            User = _currentUserProfile,
                            UserId = _currentUserProfile.Id
                        });
                }
                else
                {
                    if (checkingFound == true)
                        _currentUserProfile.Accounts.Remove(checkingAccount);
                }

                if (CbSaving.IsChecked == true)
                {
                    if (savingFound == false)
                        _currentUserProfile.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUserProfile.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(10).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.Saving,
                            Balance = 0,
                            User = _currentUserProfile,
                            UserId = _currentUserProfile.Id
                        });
                }
                else
                {
                    if (savingFound == true)
                        _currentUserProfile.Accounts.Remove(savingAccount);
                }

                if (CbTaxFreeSaving.IsChecked == true)
                {
                    if (taxFreeSavingFound == false)
                        _currentUserProfile.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUserProfile.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(10).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.TaxFreeSaving,
                            Balance = 0,
                            User = _currentUserProfile,
                            UserId = _currentUserProfile.Id
                        });
                }
                else
                {
                    if (taxFreeSavingFound == true)
                        _currentUserProfile.Accounts.Remove(taxFreeSavingAccount);
                }

                if (CbCredit.IsChecked == true)
                {
                    if (creditFound == false)
                        _currentUserProfile.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUserProfile.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(10).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.Credit,
                            Balance = 0,
                            User = _currentUserProfile,
                            UserId = _currentUserProfile.Id
                        });
                }
                else
                {
                    if (creditFound == true)
                        _currentUserProfile.Accounts.Remove(creditAccount);
                }
            }
            else
            {
                MessageBox.Show("Account type must be selected at least one", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DbGlobals.ctx = new DbContextDemo();
            DbGlobals.ctx.Users.AddOrUpdate(_currentUserProfile);
            DbGlobals.ctx.SaveChanges();
            AccountDetailsRequestResult?.Invoke(_currentUserProfile);
            DialogResult = true;
        }
    }
}
