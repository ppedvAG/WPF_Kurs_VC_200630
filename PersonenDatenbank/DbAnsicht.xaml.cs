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
using System.Windows.Shapes;

namespace PersonenDatenbank
{
    /// <summary>
    /// Interaction logic for DbAnsicht.xaml
    /// </summary>
    public partial class DbAnsicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        public DbAnsicht()
        {
            InitializeComponent();

            Personenliste.Add(new Person() { Vorname = "Otto", Nachname = "Meier", Geburtsdatum = new DateTime(2002, 5, 12), Verheiratet = true, Geschlecht = Gender.Männlich, Lieblingsfarbe = Colors.Blue });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Müller", Geburtsdatum = new DateTime(1989, 4, 4), Verheiratet = false, Geschlecht = Gender.Weiblich, Lieblingsfarbe = Colors.Green });
            Personenliste.Add(new Person() { Vorname = "Marie", Nachname = "Schmidt", Geburtsdatum = new DateTime(1977, 12, 17), Verheiratet = true, Geschlecht = Gender.Divers, Lieblingsfarbe = Colors.Yellow });

            this.DataContext = this;
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            Dialog neuerPersonenDialog = new Dialog();

            if (neuerPersonenDialog.ShowDialog() == true)
                Personenliste.Add(neuerPersonenDialog.DataContext as Person);
        }

        private void Btn_Aendern_Click(object sender, RoutedEventArgs e)
        {
            Dialog aendernDialog = new Dialog();
            Person person = new Person(Dgd_Personen.SelectedItem as Person);
            aendernDialog.DataContext = person;
            aendernDialog.Title = $"{person.Vorname} {person.Nachname}";

            if (aendernDialog.ShowDialog() == true)
                Personenliste[Personenliste.IndexOf(Dgd_Personen.SelectedItem as Person)] = person;
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            Person person = Dgd_Personen.SelectedItem as Person;
            if (MessageBox.Show($"Soll {person.Vorname} {person.Nachname} wirklich gelöscht werden?", "Lösche Person", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Personenliste.Remove(person);
        }

        private void Mim_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
