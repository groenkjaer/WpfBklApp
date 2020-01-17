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
    /// Interaction logic for Setræningsprogram.xaml
    /// </summary>
    public partial class Setræningsprogram : Window
    {
        public Setræningsprogram()
        {
            InitializeComponent();

            int[] arr = Database.HentProgramId();

            foreach (int i in arr)
            {
                stortræningsprogram_UC_ uC_ = new stortræningsprogram_UC_(i);
                stackpanel.Children.Add(uC_);
            }
            
        }
    }
}
