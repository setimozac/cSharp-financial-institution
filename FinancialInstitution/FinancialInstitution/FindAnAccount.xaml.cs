﻿using FinancialInstitution.entities;
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
        private HashSet<Profile> uniqeItems;
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

            uniqeItems = new HashSet<Profile>(result);
            RefreshResult();


            if (_firstName == "" && _lastName == "" && _email == "" && _accountNumber == "")
            {
                result = null;
                uniqeItems = null;
                RefreshResult();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(LvUser.SelectedIndex == -1 || LvUser.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select one user!");
                return;
            }
            this.Topmost = false;
            User user = ((Profile)LvUser.SelectedItem).User;
            ClientInsertPassword clientInsertPassword = new ClientInsertPassword(user);
            clientInsertPassword.Owner = this;
            clientInsertPassword.ShowDialog();
            if (clientInsertPassword.DialogResult == true)
            {
                MainWindow.LogedInClient = user;
                DialogResult = true;
            }
            
        }

        private void RefreshResult()
        {
            /*LvUser.ItemsSource = result;*/
            LvUser.ItemsSource = uniqeItems;
            LvUser.Items.Refresh();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
