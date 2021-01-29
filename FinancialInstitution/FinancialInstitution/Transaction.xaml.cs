using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        private readonly User _currentUser = MainWindow.LogedInClient;
        private string _fromAccountNumber = "";
        private string _toAccountNumber = "";
        private double _tempFromAccountBalance = 0;
        private Account _tempFromAccount;
        public Transaction()
        {
            InitializeComponent();
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            LblCustomerName.Content = _currentUser.Profile.FirstName + " " + ((_currentUser.Profile.MiddleName == "") ? _currentUser.Profile.LastName : _currentUser.Profile.MiddleName + " " + _currentUser.Profile.LastName);
            LblUserId.Content = _currentUser.Id;
            CbFromAccount.ItemsSource = Enum.GetValues(typeof(AccountTypeEnum));
            CbFromAccount.SelectedIndex = -1;
            CbToAccount.ItemsSource = Enum.GetValues(typeof(AccountTypeEnum));
            CbToAccount.SelectedIndex = -1;
            if(_currentUser.Transactions != null)
                LvTransaction.ItemsSource = _currentUser.Transactions.ToList<entities.Transaction>();
        }

        private void CbFromAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isFound = false;
            if (CbFromAccount.SelectedItem != null)
            {
                foreach (var account in _currentUser.Accounts)
                {
                    if (account.AccountType == (AccountTypeEnum)CbFromAccount.SelectedItem)
                    {
                        LBalanceOfFromAccount.Content = string.Format("{0:C}", account.Balance);
                        isFound = true;
                        return;
                    }
                }
            }
            
            if (!isFound)
                LBalanceOfFromAccount.Content = "";
        }

        private void CbToAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isFound = false;
            if (CbToAccount.SelectedItem != null)
            {
                foreach (var account in _currentUser.Accounts)
                {
                    if (account.AccountType == (AccountTypeEnum)CbToAccount.SelectedItem)
                    {
                        LBalanceOfToAccount.Content = string.Format("{0:C}", account.Balance);
                        isFound = true;
                        return;
                    }
                }
            }
            
            if (!isFound)
                LBalanceOfToAccount.Content = "";
        }

        private bool Calculate(string op, ComboBox comboBox, User user)
        {
            if (double.TryParse(TbAmount.Text, out double amount))
            {
                foreach (var account in user.Accounts)
                {
                    if (account.AccountType == (AccountTypeEnum)comboBox.SelectedItem)
                    {
                        if (comboBox.Name == "CbFromAccount")
                        {
                           _tempFromAccountBalance = account.Balance;
                            if (op == "plus") //deposit
                            {
                                _tempFromAccountBalance += amount;
                            }
                            else // withdraw or transfer
                            {
                                _tempFromAccountBalance -= amount;
                                if (_tempFromAccountBalance < 0)
                                {
                                    MessageBox.Show("From Account balance is not enough");
                                    return false;
                                }
                            }
                            _fromAccountNumber = account.AccountNumber;
                            _tempFromAccount = account;
                        }
                        else if (comboBox.Name == "CbToAccount") //transfer
                        {
                            _toAccountNumber = account.AccountNumber;
                            account.Balance += amount;
                            LBalanceOfToAccount.Content = string.Format("{0:C}", account.Balance);
                        }
                        return true;
                    }
                }
                MessageBox.Show("Account is not found");
                return false;
            }
            else
            {
                MessageBox.Show("Amount must be a number");
                return false;
            }
        }
        private void SaveAndRefresh(entities.Transaction newTran)
        {
            _currentUser.Transactions.Add(newTran);
            _tempFromAccount.Balance = _tempFromAccountBalance;
            DbGlobals.ctx.Users.AddOrUpdate(_currentUser);
            DbGlobals.ctx.SaveChanges();
            LBalanceOfFromAccount.Content = string.Format("{0:C}", _tempFromAccountBalance);
            if (CbToAccount.SelectedIndex == CbFromAccount.SelectedIndex)
            {
                LBalanceOfToAccount.Content = string.Format("{0:C}", _tempFromAccountBalance);
            }
            LvTransaction.ItemsSource = _currentUser.Transactions.ToList<entities.Transaction>();
            LvTransaction.Items.Refresh();
        }

        private void BtnTransactionDeposit_Click(object sender, RoutedEventArgs e)
        {
            if (Calculate("plus", CbFromAccount, _currentUser))
            {
                entities.Transaction transaction = new entities.Transaction
                {
                    UserId = _currentUser.Id,
                    RecieverUserId = _currentUser.Id,
                    AccountNumber = _fromAccountNumber,
                    RecieverAccountNumber = _fromAccountNumber,
                    TransactionDate = DateTime.Now,
                    Amount = double.Parse(TbAmount.Text)
                };
                SaveAndRefresh(transaction);
            }
        }

        private void BtnTransactionWithdraw_Click(object sender, RoutedEventArgs e)
        {
            if (Calculate("minus", CbFromAccount, _currentUser))
            {
                entities.Transaction transaction = new entities.Transaction
                {
                    UserId = _currentUser.Id,
                    RecieverUserId = _currentUser.Id,
                    AccountNumber = _fromAccountNumber,
                    RecieverAccountNumber = _fromAccountNumber,
                    TransactionDate = DateTime.Now,
                    Amount = double.Parse(TbAmount.Text)
                };
                SaveAndRefresh(transaction);
            }
        }

        private void RbToYourAccount_Checked(object sender, RoutedEventArgs e)
        {
            CbToAccount.IsEnabled = true;
            TbToOtherAccount.IsEnabled = false;
        }

        private void BtnTransactionCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void RbToOtherUserAccount_Checked(object sender, RoutedEventArgs e)
        {
            CbToAccount.IsEnabled = false;
            TbToOtherAccount.IsEnabled = true;
        }

        private void BtnTransactionTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (CbFromAccount.SelectedIndex != -1)
            {
                if (Calculate("minus", CbFromAccount, _currentUser))
                {
                    if (RbToYourAccount.IsChecked == true)
                    {
                        if (CbToAccount.SelectedIndex != -1)
                        {
                            if ((AccountTypeEnum)CbFromAccount.SelectedItem != (AccountTypeEnum)CbToAccount.SelectedItem)
                            {
                                if (Calculate("plus", CbToAccount, _currentUser))
                                {
                                    entities.Transaction transaction = new entities.Transaction
                                    {
                                        UserId = _currentUser.Id,
                                        RecieverUserId = _currentUser.Id,
                                        AccountNumber = _fromAccountNumber,
                                        RecieverAccountNumber = _toAccountNumber,
                                        TransactionDate = DateTime.Now,
                                        Amount = double.Parse(TbAmount.Text)
                                    };
                                    SaveAndRefresh(transaction);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select a different To Account");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a To Account");
                        }
                    }
                    else if (RbToOtherUserAccount.IsChecked == true)
                    {
                        if (_fromAccountNumber != TbToOtherAccount.Text)
                        {
                            List<Account> result = null;
                            result = (from a in DbGlobals.ctx.Accounts where a.AccountNumber == TbToOtherAccount.Text select a).ToList<Account>();
                            if (result.Count != 0)
                            {
                                List<User> recieverUsers = null;
                                int tempId = result[0].UserId;
                                recieverUsers = (from u in DbGlobals.ctx.Users where u.Id == tempId select u).ToList<User>();
                                entities.Transaction transaction = new entities.Transaction
                                {
                                    UserId = _currentUser.Id,
                                    RecieverUserId = result[0].UserId,
                                    AccountNumber = _fromAccountNumber,
                                    RecieverAccountNumber = TbToOtherAccount.Text,
                                    TransactionDate = DateTime.Now,
                                    Amount = double.Parse(TbAmount.Text)
                                };
                                SaveAndRefresh(transaction);
                                foreach (var account in recieverUsers[0].Accounts)
                                {
                                    if(account.AccountNumber == TbToOtherAccount.Text)
                                        account.Balance += double.Parse(TbAmount.Text);
                                }
                                recieverUsers[0].Transactions.Add(transaction);
                                DbGlobals.ctx.Users.AddOrUpdate(recieverUsers[0]);
                                DbGlobals.ctx.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("User id can't be found");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please input another account number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a To Account");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a From Account");
            }
        }
    }
}
