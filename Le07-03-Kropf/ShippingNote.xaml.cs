using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Le07_03_Kropf
{
    /// <summary>
    /// Interaction logic for ShippingNote.xaml
    /// </summary>
    public partial class ShippingNote : Window
    {
        public ShippingNote()
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
        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            // is any TextBox empty?
            if(companyName.Text == "" || streetName.Text == "" || streetNumber.Text == "" || postCode.Text == "" || town.Text == "" || surName.Text == ""
                || lastName.Text == "" || clientNumber.Text == "" || comboBox.Text == "Wählen Sie" || amountTxtBox.Text == "" || priceTxtBox.Text == "")
            {
                MessageBox.Show("Ein leeres Feld entdeckt!", "Eingabefelder-Check");
            }
            else
            {
                //gesamtpreis label
                priceSumLbl.Content = ReturnSumPrice();
                MessageBox.Show("Lieferschein erstellt", "Eingabefelder-Check");
                saveBtn.IsEnabled = true;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Compatible Files (*.txt; *.doc)|*.txt;*.doc";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.FileName = "Lieferschein KU-" + clientNumber.Text;
            if(sfd.ShowDialog() == true)
            {
                using(StreamWriter writer = new StreamWriter(sfd.OpenFile()))
                {
                    string text = "Firmenname: " + companyName.Text + ".\n" +
                                  "Anschrift: " + streetName.Text + ", " + streetNumber.Text + ", " + postCode.Text + ", " + town.Text + ".\n" +
                                  "Kundenname: " + surName.Text + ", " + lastName.Text + ".\n" +
                                  "Kundennummer: " + clientNumber.Text + ".\n" +
                                  "Bestellung: " + comboBox.Text + ", Menge: " + amountTxtBox.Text + "Stk.\n" +
                                  "Preis (pro Stk.): " + priceTxtBox.Text + " €.\n" +
                                  "Gesamtpreis (inkl. MWST): " + ReturnSumPrice() + " €.\n";
                    writer.Write(text);

                }
            }
        }
        private string ReturnSumPrice()
        {
            double sum = Convert.ToDouble(priceTxtBox.Text) * Convert.ToDouble(amountTxtBox.Text);
            sum += (sum * 0.2); 
            return Convert.ToString(Math.Round(sum, 2));
        }
    }
}
