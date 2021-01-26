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
using System.Windows.Shapes;

namespace FinancialInstitution
{
    /// <summary>
    /// Interaction logic for ClientInsertPassword.xaml
    /// </summary>
    public partial class ClientInsertPassword : Window
    {
        private string InsertedPass = "";
        public ClientInsertPassword()
        {
            InitializeComponent();
        }

        private void ImageOne_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(TboxPass.Text.Length < 4)
            {
                TboxPass.Text += "*";
                InsertedPass += "1";
            }
            
        }

        private void ImageTwo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 4)
            {
                TboxPass.Text += "*";
                InsertedPass += "2";
            }
        }

        private void ImageThree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 4)
            {
                TboxPass.Text += "*";
                InsertedPass += "3";
            }
        }

        private void ImageFour_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                TboxPass.Text += "*";
                InsertedPass += "4";
            }
        }

        private void ImageFive_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                TboxPass.Text += "*";
                InsertedPass += "5";
            }
        }

        private void ImageSix_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                TboxPass.Text += "*";
                InsertedPass += "6";
            }
        }

        private void ImageSeven_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                TboxPass.Text += "*";
                InsertedPass += "7";
            }
        }

        private void ImageEight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                TboxPass.Text += "*";
                InsertedPass += "8";
            }
        }

        private void ImageNine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                TboxPass.Text += "*";
                InsertedPass += "9";
            }
        }

        private void ImageZero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length < 5)
            {
                TboxPass.Text += "*";
                InsertedPass += "0";
            }
        }

        private void ImageCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TboxPass.Text = "";
            InsertedPass = "";
        }

        private void ImageOk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TboxPass.Text.Length == 4)
            {
                TboxPass.Text = "Correct";
                TboxPass.Foreground = Brushes.Green;
                TboxPass.FontSize = 26;
            }
        }
    }
}
