using FinancialInstitution.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ClientInsertPassword.xaml
    /// </summary>
    public partial class ClientInsertPassword : Window
    {
        private string InsertedPass = "";
        private User User;
        public ClientInsertPassword(User user)
        {
            InitializeComponent();
            User = user;
        }

        private void ImageOne_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(TboxPass.Text.Length < 4)
            {
                insertHandler("1");
            }
            else
            {
                Reset();
                insertHandler("1");
            }
            
        }

        private void ImageTwo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 4)
            {
                insertHandler("2");
            }
            else
            {
                Reset();
                insertHandler("2");
            }
        }

        private void ImageThree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 4)
            {
                insertHandler("3");
            }
            else
            {
                Reset();
                insertHandler("3");
            }
        }

        private void ImageFour_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                insertHandler("4");
            }
            else
            {
                Reset();
                insertHandler("4");
            }
        }

        private void ImageFive_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                insertHandler("5");
            }
            else
            {
                Reset();
                insertHandler("5");
            }
        }

        private void ImageSix_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                insertHandler("6");
            }
            else
            {
                Reset();
                insertHandler("6");
            }
        }

        private void ImageSeven_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                insertHandler("7");
            }
            else
            {
                Reset();
                insertHandler("7");
            }
        }

        private void ImageEight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                insertHandler("8");
            }
            else
            {
                Reset();
                insertHandler("8");
            }
        }

        private void ImageNine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                insertHandler("9");
            }
            else
            {
                Reset();
                insertHandler("9");
            }
        }

        private void ImageZero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                insertHandler("0");
            }
            else
            {
                Reset();
                insertHandler("0");
            }
        }

        private void ImageCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Reset();
        }

        private void ImageOk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (TboxPass.Text.Length == 4 && User.PassCode == int.Parse(InsertedPass))
            {
                
                TboxPass.Text = "Correct";
                TboxPass.Foreground = Brushes.Green;
                TboxPass.FontSize = 26;
                
                DialogResult = true;
            }
            else
            {
                
                
                TboxPass.Foreground = Brushes.Red;
                TboxPass.FontSize = 26;
                TboxPass.Text = "Incorrect Passcode!";
            }
            
        }

        private void Reset()
        {
            
            
            TboxPass.Text = "";
            InsertedPass = "";
            TboxPass.Foreground = Brushes.Black;
        }

        private void insertHandler(string num)
        {
            TboxPass.Text += "*";
            InsertedPass += $"{num}";
        }
    }
}
