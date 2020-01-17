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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            if (SerialCommunication.ComPortIsSet == false)
            {
                Window com = new ComValg();
                com.Topmost = true;
                com.Show();
            }
            
        }

        private void goToOpretBruger_Click(object sender, RoutedEventArgs e)
        {
            Window opret = new OpretMedlem();
            opret.Show();
            this.Close();
        }

        private void goToMenu_Click(object sender, RoutedEventArgs e)
        {
            string s = Database.Login(txtEmail.Text, passKodeord.Password);
            MessageBox.Show(s);
            if (Database.UserId != 0 && Database.Status == "Instruktør")
            {
                Window hovedMenuAdmin = new HovedmenuAdmin();
                hovedMenuAdmin.Show();
                this.Close();
            } 
            else if (Database.UserId != 0)
            {
                Window hovedMenuMedlem = new HovedmenuMedlem();
                hovedMenuMedlem.Show();
                this.Close();
            }
        }
    }
}
