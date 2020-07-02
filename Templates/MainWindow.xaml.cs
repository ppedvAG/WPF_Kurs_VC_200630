using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Properties vom Typ ObservableCollection informieren die GUI automatisch über Veränderungen (z.B. neuer Listeneintrag). Sie eignen sich besonders gut
        //für eine Bindung an ein ItemControl (z.B. ComboBox, ListBox, DataGrid, ...)
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();

            //Erstellen von Bsp-Daten
            Personenliste.Add(new Person() { Vorname = "Otto", Nachname = "Meier", Alter = 56 });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Müller", Alter = 34 });
            Personenliste.Add(new Person() { Vorname = "Jürgen", Nachname = "Fischer", Alter = 23 });

            //Setzen der ItemSource (Datenquelle) der Listbox
            Lbx_Personen.ItemsSource = Personenliste;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("KLICK");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Erhöhung des Alters der Person im DataContextes des Windows
            (this.DataContext as Person).Alter++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Hinzufügen einer neuen Person
            Personenliste.Add(new Person() { Vorname = "Hans", Nachname = "Vogel", Alter = 98 });
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Ausgabe einer Person
            Person person = Lbx_Personen.SelectedItem as Person;
            MessageBox.Show(person.Vorname);
        }
    }
}
