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
using Innovative.SolarCalculator;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsLoggedIn = true;
        public Client LogedInClient = null;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void TextBlockHome_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void StPanelCreate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(IsLoggedIn)
            {
                User newUser = new User();
                Create create = new Create(newUser);
                TboxCreateUser.Foreground = Brushes.Gray;
                create.Owner = this;
                create.Left = this.Left + 247;
                create.Top = this.Top;
                create.Topmost = true;

                create.RequestResult += u =>
                {
                    newUser = u;
                };
                bool? result = create.ShowDialog();
                if (result == true)
                {
                    // Use database context to save the new user
                    //ctx.Users.Add(newUser);
                    //ctx.SaveChanges();
                }
                TboxCreateUser.Foreground = Brushes.White;
            }
            
        }

        private void FindAccount_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsLoggedIn)
            {
                FindAnAccount findAnAccount = new FindAnAccount();
                TboxFindAnAccount.Foreground = Brushes.Gray;
                findAnAccount.Owner = this;
                findAnAccount.Left = this.Left + 247;
                findAnAccount.Top = this.Top;
                findAnAccount.Topmost = true;

                findAnAccount.ShowDialog();
                TboxFindAnAccount.Foreground = Brushes.White;
            }
                
        }

        private void StPanelUpdateAcount_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsLoggedIn && LogedInClient != null)
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
            if (IsLoggedIn && LogedInClient != null)
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
            if (IsLoggedIn)
            {
                ClientInsertPassword clientPassword = new ClientInsertPassword();
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
            if (IsLoggedIn && LogedInClient != null)
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
    }
}
