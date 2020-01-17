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
using System.IO.Ports;

namespace WpfBklApp
{
    /// <summary>
    /// Interaction logic for ComValg.xaml
    /// </summary>
    public partial class ComValg : Window
    {
        public ComValg()
        {
            InitializeComponent();
            foreach (string s in SerialPort.GetPortNames())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = s;
                cmbComs.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SerialCommunication.ComNr = cmbComs.Text;
            MessageBox.Show("Com is set to " + SerialCommunication.ComNr);
            this.Close();
        }
    }
}
