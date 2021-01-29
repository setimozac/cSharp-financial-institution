using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
using FinancialInstitution.services;
using Microsoft.Win32;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        System.Random random = new System.Random();
        public event Action<User> RequestResult;
        private readonly User _currentPerson = new User {Profile = new Profile(), Accounts = new List<Account>()};
        private byte[] _currentImage;
        public Create()
        {
            InitializeComponent();
            RenderData();
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
                Filter = "Image files (*.jpg)|*.jpg|*.jpeg|*.png|All Files (*.*)|*.*",
                RestoreDirectory = true
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

        public static BitmapImage ByteArrayToBitmapImage(byte[] currentImage)
        {
            var newImage = new BitmapImage();
            using ( var ms = new MemoryStream(currentImage))
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
            

            try
            {
                _currentPerson.Profile.FirstName = TbFirstName.Text;
                _currentPerson.Profile.LastName = TbLastName.Text;
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
                _currentPerson.Profile.Address = TbAddress.Text;
                _currentPerson.Profile.PhoneNumber = TbPhone.Text;
                _currentPerson.Profile.Email = TbEmail.Text;
                _currentPerson.Profile.SinNumber = TbSinNumber.Text;

            }
            catch(CustomInvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (_currentImage != null)
            {
                _currentPerson.Profile.Img = _currentImage;
            }

            if ((CbChecking.IsChecked == true) || (CbSaving.IsChecked == true) || (CbTaxFreeSaving.IsChecked == true) || (CbCredit.IsChecked == true))
            {
                if (CbChecking.IsChecked == true)
                {
                    _currentPerson.Accounts.Add(new Account
                    {
                        AccountNumber = _currentPerson.Profile.FirstName.ToUpper() + random.Next(),
                        CreatedDate = DateTime.Now,
                        AccountType = AccountTypeEnum.Checking,
                        Balance = 0,
                        User = _currentPerson,
                        UserId = _currentPerson.Id
                    });
                }

                if (CbSaving.IsChecked == true)
                {
                    _currentPerson.Accounts.Add(new Account
                    {
                        AccountNumber = _currentPerson.Profile.FirstName.ToUpper() + random.Next(),
                        CreatedDate = DateTime.Now,
                        AccountType = AccountTypeEnum.Saving,
                        Balance = 0,
                        User = _currentPerson,
                        UserId = _currentPerson.Id
                    });
                }

                if (CbTaxFreeSaving.IsChecked == true)
                {
                    _currentPerson.Accounts.Add(new Account
                    {
                        AccountNumber = _currentPerson.Profile.FirstName.ToUpper() + random.Next(),
                        CreatedDate = DateTime.Now,
                        AccountType = AccountTypeEnum.TaxFreeSaving,
                        Balance = 0,
                        User = _currentPerson,
                        UserId = _currentPerson.Id
                    });
                }

                if (CbCredit.IsChecked == true)
                {
                    _currentPerson.Accounts.Add(new Account
                    {
                        AccountNumber = _currentPerson.Profile.FirstName.ToUpper() + random.Next(),
                        CreatedDate = DateTime.Now,
                        AccountType = AccountTypeEnum.Credit,
                        Balance = 0,
                        User = _currentPerson,
                        UserId = _currentPerson.Id
                    });
                }
            }
            else
            {
                MessageBox.Show("Account type must be selected at least one", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _currentPerson.PassCode = 1234;
            _currentPerson.Password = GenerateRandoms.PasswordRandomString();
            _currentPerson.IsEmployee = false;
            _currentPerson.Transactions = new List<entities.Transaction>();
            
            DbGlobals.ctx = new DbContextDemo();
            DbGlobals.ctx.Users.Add(_currentPerson);
            DbGlobals.ctx.SaveChanges();
            MainWindow.LogedInClient = _currentPerson;
            /*RequestResult?.Invoke(_currentPerson);*/
            DialogResult = true;
        }

        private void MenueItemCalendar_Click(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Owner = this;
            calendar.Left = this.Left + 700;
            calendar.Top = this.Top;

            calendar.ShowDialog();
        }

        private void MenueItemCalculator_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            p.WaitForInputIdle();
        }

        private void MenueItemTakePhoto_Click(object sender, RoutedEventArgs e)
        {
            Camera camera = new Camera();
            camera.Owner = this;

            camera.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
