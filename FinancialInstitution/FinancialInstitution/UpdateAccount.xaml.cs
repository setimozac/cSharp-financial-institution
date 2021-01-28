using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using FinancialInstitution.globals;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for UpdateAccount.xaml
    /// </summary>
    public partial class UpdateAccount : Window
    {
        private readonly User _currentUser = MainWindow.LogedInClient;
        public UpdateAccount()
        {
            InitializeComponent();
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            LblCustomerName.Content = _currentUser.Profile.FirstName + " " + ((_currentUser.Profile.MiddleName == "")?_currentUser.Profile.LastName:_currentUser.Profile.MiddleName + " " + _currentUser.Profile.LastName);
            DateTime earliestDate = DateTime.Now;
            foreach (var account in _currentUser.Accounts)
            {
                if (account.AccountType == AccountTypeEnum.Checking)
                {
                    CkbChecking.IsChecked = true;
                }
                else if (account.AccountType == AccountTypeEnum.Saving)
                {
                    CkbSaving.IsChecked = true;
                }
                else if (account.AccountType == AccountTypeEnum.TaxFreeSaving)
                {
                    CkbTaxFreeSaving.IsChecked = true;
                }
                else if (account.AccountType == AccountTypeEnum.Credit)
                {
                    CkbCredit.IsChecked = true;
                }
                else
                {
                    CkbChecking.IsChecked = true;
                }
                if (account.CreatedDate < earliestDate)
                    earliestDate = account.CreatedDate;
            }
            LblOpenDate.Content = earliestDate.ToString("yyyy-MM-dd");
            LvUpdateAccount.ItemsSource = _currentUser.Accounts.ToList<Account>();
        }

        private void BtnUpdateAccountCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnUpdateAccountUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool checkingFound = false;
            bool savingFound = false;
            bool taxFreeSavingFound = false;
            bool creditFound = false;
            Account checkingAccount = null;
            Account savingAccount = null;
            Account taxFreeSavingAccount = null;
            Account creditAccount = null;
            if ((CkbChecking.IsChecked == true) || (CkbSaving.IsChecked == true) || (CkbTaxFreeSaving.IsChecked == true) || (CkbCredit.IsChecked == true))
            {
                foreach (var a in _currentUser.Accounts)
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

                if (CkbChecking.IsChecked == true)
                {
                    if (checkingFound == false)
                        _currentUser.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUser.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(5).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.Checking,
                            Balance = 0,
                            User = _currentUser,
                            UserId = _currentUser.Id
                        });
                }
                else
                {
                    if (checkingFound == true)
                        _currentUser.Accounts.Remove(checkingAccount);
                }

                if (CkbSaving.IsChecked == true)
                {
                    if (savingFound == false)
                        _currentUser.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUser.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(66).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.Saving,
                            Balance = 0,
                            User = _currentUser,
                            UserId = _currentUser.Id
                        });
                }
                else
                {
                    if (savingFound == true)
                        _currentUser.Accounts.Remove(savingAccount);
                }

                if (CkbTaxFreeSaving.IsChecked == true)
                {
                    if (taxFreeSavingFound == false)
                        _currentUser.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUser.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(777).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.TaxFreeSaving,
                            Balance = 0,
                            User = _currentUser,
                            UserId = _currentUser.Id
                        });
                }
                else
                {
                    if (taxFreeSavingFound == true)
                        _currentUser.Accounts.Remove(taxFreeSavingAccount);
                }

                if (CkbCredit.IsChecked == true)
                {
                    if (creditFound == false)
                        _currentUser.Accounts.Add(new Account
                        {
                            AccountNumber = _currentUser.Profile.FirstName.ToUpper() + string.Format("{0:F0}", (new Random(8888).NextDouble()) * 10000000),
                            CreatedDate = DateTime.Now,
                            AccountType = AccountTypeEnum.Credit,
                            Balance = 0,
                            User = _currentUser,
                            UserId = _currentUser.Id
                        });
                }
                else
                {
                    if (creditFound == true)
                        _currentUser.Accounts.Remove(creditAccount);
                }
            }
            else
            {
                MessageBox.Show("Account type must be selected at least one", "Null error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DbGlobals.ctx = new DbContextDemo();
            DbGlobals.ctx.Users.AddOrUpdate(_currentUser);
            DbGlobals.ctx.SaveChanges();
            DialogResult = true;
        }
    }
}
