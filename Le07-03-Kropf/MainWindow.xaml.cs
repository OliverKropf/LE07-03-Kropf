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

namespace Le07_03_Kropf
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
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //when both are correct
            if (uNameTxt.Text.Equals("admin12321") && pwTxt.Text.Equals("password65456"))
            {
                pwTxt.Background = new SolidColorBrush(Colors.GreenYellow);
                uNameTxt.Background = new SolidColorBrush(Colors.GreenYellow);

                //open new wpf for ShippingOrder
                MessageBox.Show("Login Erfolgreich!", "Login Check");
                ShippingNote SN = new ShippingNote();
                SN.Show();
                Close();
            }
            // when 1 of 2 is empty
            else if (uNameTxt.Text.Equals("") || pwTxt.Text.Equals(""))
            {
                //which one exactly
                if(uNameTxt.Text.Equals("")) 
                {
                    pwTxt.Background = new SolidColorBrush(Colors.WhiteSmoke);
                    uNameTxt.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                }
                else
                {
                    pwTxt.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                    uNameTxt.Background = new SolidColorBrush(Colors.WhiteSmoke);
                }
            }
            //when 1 of 2 is correct
            else if (uNameTxt.Text.Equals("admin12321") || pwTxt.Text.Equals("password65456"))
            {
                //which one exactly
                if (uNameTxt.Text.Equals("admin12321"))
                {
                    pwTxt.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                    uNameTxt.Background = new SolidColorBrush(Colors.GreenYellow);
                }
                else
                {
                    uNameTxt.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                    pwTxt.Background = new SolidColorBrush(Colors.GreenYellow);
                }
            }
            //when 2 of 2 are incorrect
            else 
            {
                pwTxt.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                uNameTxt.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
            }
        }
    }
}
