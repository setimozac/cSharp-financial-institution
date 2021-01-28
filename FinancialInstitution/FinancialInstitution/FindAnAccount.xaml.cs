using FinancialInstitution.entities;
using FinancialInstitution.globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for AddToExisting.xaml
    /// </summary>
    public partial class FindAnAccount : Window
    {
        private string _firstName = "";
        private string _lastName = "";
        private string _email = "";
        private string _accountNumber = "";
        private List<Profile> result;
        public FindAnAccount()
        {
            InitializeComponent();
        }

        private void TboxFirstName_KeyUp(object sender, KeyEventArgs e)
       {
            _firstName = TboxFirstName.Text;
            RunQuery();
        }

        private void TboxLastName_KeyUp(object sender, KeyEventArgs e)
        {
            _lastName = TboxLastName.Text;
            RunQuery();
        }

        private void TboxEmail_KeyUp(object sender, KeyEventArgs e)
        {
            _email = TboxEmail.Text;
            RunQuery();
        }

        private void TboxAccountNum_KeyUp(object sender, KeyEventArgs e)
        {
            _accountNumber = TboxAccountNum.Text;
            RunQuery();
        }

        private void RunQuery()
        {

            
            result = (from u in DbGlobals.ctx.Profiles
                            join a in DbGlobals.ctx.Accounts on u.UserId equals a.UserId
                            where u.FirstName.StartsWith(_firstName) && u.LastName.StartsWith(_lastName) && u.Email.StartsWith(_email) && a.AccountNumber.StartsWith(_accountNumber)
                            select u).ToList();


            LvUser.ItemsSource = result;
            LvUser.Items.Refresh();
                
            if(_firstName == "" && _lastName == "" && _email == "" && _accountNumber == "")
            {
                result = null;
                LvUser.ItemsSource = result;
                LvUser.Items.Refresh();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(LvUser.SelectedIndex == -1 || LvUser.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select one user!");
                return;
            }

            MainWindow.LogedInClient = ((Profile)LvUser.SelectedItem).User;
            DialogResult = true;
        }
    }
}
