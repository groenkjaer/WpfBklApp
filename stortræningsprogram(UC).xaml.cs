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

namespace WpfBklApp
{
    /// <summary>
    /// Interaction logic for stortræningsprogram_UC_.xaml
    /// </summary>
    public partial class stortræningsprogram_UC_ : UserControl
    {
        public stortræningsprogram_UC_()
        {
            InitializeComponent();
            //programlabel txt = new programlabel();
            //txt.TextblockMe.Text = "Bænkpres";
            //txt.TextblockMe.FontSize = 30;
            //Grdoevelse.Children.Add(txt);

            //programlabel txt2 = new programlabel();
            //txt2.TextblockMe.Text = "Primære muskelgruppe: Bryst og triceps Sekundær muskelgruppe: Biceps, underarm og øvre ryg";
            //txt2.TextblockMe.FontSize = 20;
            //Grdbeskrivelse.Children.Add(txt2);

            //programlabel txt3 = new programlabel();
            //txt3.TextblockMe.Text = "Brystmusklerne";
            //txt.TextblockMe.FontSize = 30;
            //Grdmuskelgruppefokus.Children.Add(txt3);

            //programlabel txt4 = new programlabel();
            //txt4.TextblockMe.Text = "60 kg x 3sæt";
            //txt.TextblockMe.FontSize = 20;
            //Grdbelastning.Children.Add(txt4);

            //programlabel txt5 = new programlabel();
            //txt5.TextblockMe.Text = "8 reps";
            //txt.TextblockMe.FontSize = 30;
            //Grdgentagelser.Children.Add(txt5);

            //programlabel txt6 = new programlabel();
            //txt6.TextblockMe.Text = "1 min";
            //txt.TextblockMe.FontSize = 30;
            //Grdpausetid.Children.Add(txt6);

            string[] arr = Database.TraeningsProgram();

            programlabel txt = new programlabel();
            txt.TextblockMe.Text = arr[0];
            txt.TextblockMe.FontSize = 30;
            Grdoevelse.Children.Add(txt);

            programlabel txt2 = new programlabel();
            txt2.TextblockMe.Text = arr[1];
            txt2.TextblockMe.FontSize = 20;
            Grdbeskrivelse.Children.Add(txt2);

            programlabel txt3 = new programlabel();
            txt3.TextblockMe.Text = arr[2]; 
            txt.TextblockMe.FontSize = 30;
            Grdmuskelgruppefokus.Children.Add(txt3);

            programlabel txt4 = new programlabel();
            txt4.TextblockMe.Text = arr[3] + " x " + arr[6] + " sæt";
            txt.TextblockMe.FontSize = 20;
            Grdbelastning.Children.Add(txt4);

            programlabel txt5 = new programlabel();
            txt5.TextblockMe.Text = arr[4];
            txt.TextblockMe.FontSize = 30;
            Grdgentagelser.Children.Add(txt5);

            programlabel txt6 = new programlabel();
            txt6.TextblockMe.Text = arr[5];
            txt.TextblockMe.FontSize = 30;
            Grdpausetid.Children.Add(txt6);
        }

    }
}
