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

namespace PersonenDatenbank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        public Dialog()
        {
            InitializeComponent();
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Person person = this.DataContext as Person;

            string ausgabe = $"{person.Vorname} {person.Nachname} ({person.Geschlecht})\n{person.Geburtsdatum.ToShortDateString()}\n{person.Lieblingsfarbe}\n";
            if (person.Verheiratet) ausgabe += "Ist Verheiratet\n";
            ausgabe += "Abspeichern?";

            if(MessageBox.Show(ausgabe, $"{person.Vorname} {person.Nachname}", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                this.DialogResult = true;
                this.Close();
            }


        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
