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

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlockHome_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void StPanelCreate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Create create = new Create();
            TboxCreateUser.Foreground = Brushes.Gray;
            create.Owner = this;
            create.Left = this.Left + 247;
            create.Top = this.Top;
            create.Topmost = true;

            create.ShowDialog();
            TboxCreateUser.Foreground = Brushes.White;
        }

        private void AddToExisting_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddToExisting addToExisting = new AddToExisting();
            TboxAddToExisting.Foreground = Brushes.Gray;
            addToExisting.Owner = this;
            addToExisting.Left = this.Left + 247;
            addToExisting.Top = this.Top;
            addToExisting.Topmost = true;

            addToExisting.ShowDialog();
            TboxAddToExisting.Foreground = Brushes.White;
        }

        private void StPanelUpdateAcount_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UpdateAccount updateAccount = new UpdateAccount();
            TboxUpdateAcount.Foreground = Brushes.Gray;
            updateAccount.Owner = this;
            updateAccount.Left = this.Left + 247;
            updateAccount.Top = this.Top;
            updateAccount.Topmost = true;

            var result = updateAccount.ShowDialog();
            TboxUpdateAcount.Foreground = Brushes.White;
        }

        private void StPanelAccountDetails_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AccountDetails accountDetails = new AccountDetails();
            TboxAccountDetails.Foreground = Brushes.Gray;
            accountDetails.Owner = this;
            accountDetails.Left = this.Left + 247;
            accountDetails.Top = this.Top;
            accountDetails.Topmost = true;

            accountDetails.ShowDialog();
            TboxAccountDetails.Foreground = Brushes.White;
        }

        
    }
}
