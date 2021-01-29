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

            DbGlobals.ctx = new DbContextDemo();
            DbGlobals.ctx.Users.AddOrUpdate(_currentUserProfile);
            DbGlobals.ctx.SaveChanges();
            AccountDetailsRequestResult?.Invoke(_currentUserProfile);
            DialogResult = true;
        }
    }
}
