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

namespace Controls
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

        //EventHandler werden durch die ihnen zugeteilten Events im XAML-File aufgerufen
        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            //Änderung des Hintergrunds des Fensters
            Wnd_Main.Background = new SolidColorBrush(Colors.Yellow);

            //Anzeigen einer MessageBox mit dem Wert des Sliders
            MessageBox.Show(Sdr_Value.Value.ToString());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Schließen des aktuellen Fensters
            this.Close();

            //Schließen der ganzen Applikation
            Application.Current.Shutdown();
        }
    }
}
