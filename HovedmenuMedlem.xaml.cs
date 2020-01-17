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
    /// Interaction logic for HovedmenuMedlem.xaml
    /// </summary>
    public partial class HovedmenuMedlem : Window
    {
        public HovedmenuMedlem()
        {
            InitializeComponent();
        }

        private void btnGemVaegt_Click(object sender, RoutedEventArgs e)
        {
            //Database.Vaegt = SerialCommunication.HentVaegt() + "KG"; TEST
            Database.Vaegt = "400kg";
            txtVaegt.Text = Database.Vaegt;

            if (!string.IsNullOrEmpty(Database.Maal) && !string.IsNullOrEmpty(Database.Vaegt))
            {
                MessageBox.Show(Database.UploadVaegt());
            }
        }

        private void btnSaetMaal_Click(object sender, RoutedEventArgs e)
        {
            Database.Maal = txtMaal.Text;

            if (!string.IsNullOrEmpty(Database.Maal) && !string.IsNullOrEmpty(Database.Vaegt))
            {
                MessageBox.Show(Database.UploadVaegt());
            }
        }

        private void Opretprogrampas_Click(object sender, RoutedEventArgs e)
        {
            Oprettræningsprogram opret = new Oprettræningsprogram();
            opret.Show();
            Close();
        }
    }
}
