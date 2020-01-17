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
    /// Interaction logic for Oprettræningsprogram.xaml
    /// </summary>
    public partial class Oprettræningsprogram : Window
    {
        public Oprettræningsprogram()
        {
            InitializeComponent();
            
        }

        private void Annuller_Click(object sender, RoutedEventArgs e)
        {
            HovedmenuMedlem hovedmenu = new HovedmenuMedlem();
            hovedmenu.Show();
            Close();
        }

        private void GemProgram_Click(object sender, RoutedEventArgs e)
        {
          

        }

        private void OpretNyØvelse_click(object sender, RoutedEventArgs e)
        {

        }

    }
}
