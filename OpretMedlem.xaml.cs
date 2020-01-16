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

namespace WpfBklApp
{
    /// <summary>
    /// Interaction logic for OpretMedlem.xaml
    /// </summary>
    public partial class OpretMedlem : Window
    {
        public OpretMedlem()
        {
            InitializeComponent();
        }

        private void opretBruger_Click(object sender, RoutedEventArgs e)
        {
            string s = Database.OpretNyBruger(txtFirstname.Text, txtLastname.Text, txtEmail.Text, passKodeord.Password, passKodeordGentag.Password, comboBoxKoen.Text, txtAlder.Text);
            MessageBox.Show(s);

            if (s == "Du har nu oprettet en bruger")
            {
                Window login = new Login();
                login.Show();
                this.Close();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window login = new Login();
            login.Show();
            this.Close();
        }
    }
}
