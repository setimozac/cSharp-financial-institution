using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinancialInstitution.entities;
using FinancialInstitution.globals;
using FinancialInstitution.services;
using Innovative.SolarCalculator;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsLoggedIn = true;
        public User LoggedInEmp = null;
        public static User LogedInClient = null;
        
        public MainWindow()
        {
            InitializeComponent();
            DbGlobals.ctx = new DbContextDemo();
            ResetContent();
            CreateAdminAccount();


        }

        

        private void ResetContent()
        {
            BtnEmpSignOut.Visibility = Visibility.Hidden;
            BtnClientSignOut.Visibility = Visibility.Hidden;
            StkAuth.Visibility = Visibility.Visible;
            TblEmpInfo.Text = "";
            TboxEmail.Text = "";
            TboxPass.Password = "";
        }

        private void TextBlockHome_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void StPanelCreate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(LoggedInEmp != null)
            {
                Create create = new Create();
                TboxCreateUser.Foreground = Brushes.Gray;
                create.Owner = this;
                create.Left = this.Left + 247;
                create.Top = this.Top;
                create.Topmost = true;

                /*create.RequestResult += u => { LogedInClient = u; };*/
                bool? createResult = create.ShowDialog();
                TboxCreateUser.Foreground = Brushes.White;
                if (createResult == true)
                {
                    BtnClientSignOut.Visibility = Visibility.Visible;
                    TblClientInfo.Text = LogedInClient.Profile.FirstName;
                }
            }
            
        }

        private void FindAccount_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LoggedInEmp != null)
            {
                FindAnAccount findAnAccount = new FindAnAccount();
                TboxFindAnAccount.Foreground = Brushes.Gray;
                findAnAccount.Owner = this;
                findAnAccount.Left = this.Left + 247;
                findAnAccount.Top = this.Top;
                findAnAccount.Topmost = true;

                var result = findAnAccount.ShowDialog();
                TboxFindAnAccount.Foreground = Brushes.White;
                if(result == true)
                {
                    BtnClientSignOut.Visibility = Visibility.Visible;
                    TblClientInfo.Text = LogedInClient.Profile.FirstName;
                }
            }
                
        }

        private void StPanelUpdateAcount_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LoggedInEmp != null && LogedInClient != null)
            {
                UpdateAccount updateAccount = new UpdateAccount();
                TboxUpdateAcount.Foreground = Brushes.Gray;
                updateAccount.Owner = this;
                updateAccount.Left = this.Left + 247;
                updateAccount.Top = this.Top;
                updateAccount.Topmost = true;

                var result = updateAccount.ShowDialog();
                
            }
            TboxUpdateAcount.Foreground = Brushes.White;

        }

        private void StPanelAccountDetails_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LoggedInEmp != null && LogedInClient != null)
            {
                AccountDetails accountDetails = new AccountDetails();
                TboxAccountDetails.Foreground = Brushes.Gray;
                accountDetails.Owner = this;
                accountDetails.Left = this.Left + 247;
                accountDetails.Top = this.Top;
                accountDetails.Topmost = true;

                accountDetails.ShowDialog();
                
            }
            TboxAccountDetails.Foreground = Brushes.White;

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

        private void MenuItemClientLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedInEmp != null)
            {
                ClientInsertPassword clientPassword = new ClientInsertPassword(null);
                TboxAccountDetails.Foreground = Brushes.Gray;
                clientPassword.Owner = this;
                clientPassword.Left = this.Left + 247;
                clientPassword.Top = this.Top;
                clientPassword.Topmost = true;

                clientPassword.ShowDialog();
            }
        }

        private void StPanelTransaction_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LoggedInEmp != null && LogedInClient != null)
            {
                Transaction transaction = new Transaction();
                TboxTransaction.Foreground = Brushes.Gray;
                transaction.Owner = this;
                transaction.Left = this.Left + 247;
                transaction.Top = this.Top;
                transaction.Topmost = true;

                transaction.ShowDialog();
                
            }
            TboxTransaction.Foreground = Brushes.White;
        }

        private void MenueItemTakePhoto_Click(object sender, RoutedEventArgs e)
        {
            Camera camera = new Camera();
            camera.Owner = this;

            camera.ShowDialog();
        }


        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string email = TboxEmail.Text;
            string pass = TboxPass.Password;
            if (TboxEmail.Text.Trim() == "" || TboxPass.Password.Trim() == "")
            {
                email = "";
                pass = "";
                return;
            }
            
            LoggedInEmp = (ProfileQueries.FetchEmployee(email, pass));
            if(LoggedInEmp != null)
            {
                StkAuth.Visibility = Visibility.Hidden;
                email = "";
                pass = "";
                TblEmpInfo.Text = LoggedInEmp.Profile.Email;
                BtnEmpSignOut.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Email or Password is not correct!");               
                pass = "";
            }

        }

        private void BtnEmpSignOut_Click(object sender, RoutedEventArgs e)
        {
            ResetContent();
            LoggedInEmp = null;
        }

        private void BtnClientSignOut_Click(object sender, RoutedEventArgs e)
        {
            LogedInClient = null;
            BtnClientSignOut.Visibility = Visibility.Hidden;
            TblClientInfo.Text = "";
        }

        private void CreateAdminAccount()
        {
            List<User> users = DbGlobals.ctx.Users.ToList();
            if (users.Count > 0) return;
            DbGlobals.ctx.Users.Add(new User() { Password = "123456789a", PassCode = 1234, IsEmployee = true });
            DbGlobals.ctx.SaveChanges();
            DbGlobals.ctx.Profiles.Add(new Profile()
            {
                UserId = 1,
                FirstName = "admin",
                MiddleName = "",
                LastName = "admin",
                Email = "admin@gmail.com",
                Age = 38,
                PhoneNumber = "5553460192",
                Address = "Montreal",
                Gender = GenderEnum.Male,
                MaritalStatus = MaritalStatusEnum.Married,
                DateOfBirth = DateTime.Today,
                SinNumber = "123456789"
            });
            DbGlobals.ctx.SaveChanges();


            DbGlobals.ctx.Accounts.Add(new Account() { UserId = 1, AccountNumber = "4522698876", AccountType = AccountTypeEnum.Checking, CreatedDate = DateTime.Today, Balance = 1000.00 });
            DbGlobals.ctx.SaveChanges();
            TblEmpInfo.Text = DbGlobals.ctx.Accounts.ToList<Account>()[0].AccountType.ToString();
            DbGlobals.ctx.Transactions.Add(new entities.Transaction() { UserId = 1, RecieverUserId = 1, AccountNumber = "4522698876", RecieverAccountNumber = "4522698876", TransactionDate = DateTime.Now, Amount = 200.50 });
            DbGlobals.ctx.SaveChanges();
        }
    }
}
