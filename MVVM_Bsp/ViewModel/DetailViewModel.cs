using MVVM_Bsp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Bsp.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        //Property, welche die neue oder zu bearbeitende Person in der Modelklasse verweist
        public Model.Person AktuellePerson
        {
            get { return Model.Person.AktuellePerson; }
            set
            {
                Model.Person.AktuellePerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AktuellePerson"));
            }
        }

        //Command-Properties
        public CustomCommand OkCmd { get; set; }
        public CustomCommand AbbruchCmd { get; set; }

        public DetailViewModel()
        {
            //OK-Command (Bestätigung)
            this.OkCmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden. Eine Prüfung auf die Validierung der einzelnen EIngabefelder findet schon in der GUI (vgl. DetailView) statt.
                    para => true,
                    //Exe:
                    para =>
                    {
                        //Erstellung des Strings für die MessageBox
                        Model.Person person = this.AktuellePerson;
                        string ausgabe = $"{person.Vorname} {person.Nachname} ({person.Geschlecht})\n{person.Geburtsdatum.ToShortDateString()}\n{person.Lieblingsfarbe}\n";
                        if (person.Verheiratet) ausgabe += "Ist Verheiratet\n";
                        ausgabe += "Abspeichern?";

                        //Nachfrage auf Korrektheit der Daten per MessageBox
                        if (MessageBox.Show(ausgabe, $"{person.Vorname} {person.Nachname}", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //Setzen des DialogResults des Views (welches per Parameter übergeben wurde) auf true, damit das LIstView weiß, dass es weiter
                            //machen kann (d.h. die neuen Person einfügen bzw. austauschen)
                            (para as View.DetailView).DialogResult = true;
                            //Schließen des Views
                            (para as View.DetailView).Close();
                        }
                    }
                );
            //Abbruch-Cmd
            this.AbbruchCmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden
                    para => true,
                    //Exe: Schließen des Fensters
                    para => (para as View.DetailView).Close()
                ); ;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
