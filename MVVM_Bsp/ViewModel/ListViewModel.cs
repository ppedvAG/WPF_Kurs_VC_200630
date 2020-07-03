using MVVM_Bsp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Bsp.ViewModel
{
    public class ListViewModel
    {
        //Command-Properties
        public CustomCommand NeuCmd { get; set; }
        public CustomCommand AendernCmd { get; set; }
        public CustomCommand LoeschenCmd { get; set; }
        public CustomCommand SchliessenCmd { get; set; }

        //Listen-Property, welche auf die Liste des Models verweist
        public ObservableCollection<Model.Person> Personenliste { get { return Model.Person.Personenliste; } }

        public ListViewModel()
        {
            //Command-Definitionen
            //Hinzufügen einer neuen Person
            this.NeuCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    para => true,
                    //Exe:
                    para =>
                    {
                        //Instanzieren eines neuen DetailViews
                        View.DetailView neuePersonenDialog = new View.DetailView();
                        //Zuweisung einer neuen Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        (neuePersonenDialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person();

                        //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult (wird true, wenn der Benutzer OK klickt)
                        if (neuePersonenDialog.ShowDialog() == true)
                            //Hinzufügen der neuen Person zu Liste
                            Model.Person.Personenliste.Add((neuePersonenDialog.DataContext as DetailViewModel).AktuellePerson);
                    }
                );
            //Ändern einer bestehenden Person
            this.AendernCmd = new CustomCommand
                (
                    //CanExe: Kann ausgeführt werden, wenn der Parameter (der im DataGrid ausgewählte Eintrag) eine Person ist.
                    //Fungiert als Null-Prüfung
                    para => para is Model.Person,
                    //Exe:
                    para =>
                    {
                        //Vgl. NeuCmd (s.o.)
                        View.DetailView neuePersonenDialog = new View.DetailView();
                        //Zuweisung einer Kopie der ausgewählten Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        (neuePersonenDialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person(para as Model.Person);
                        //Ändern des Titels des neuen DetailViews
                        (neuePersonenDialog as View.DetailView).Title = "Ändere " + (para as Model.Person).Vorname + " " + (para as Model.Person).Nachname;

                        if (neuePersonenDialog.ShowDialog() == true)
                            //Austausch der (veränderten) Person-Kopie mit dem Original in der Liste
                            Model.Person.Personenliste[Model.Person.Personenliste.IndexOf(para as Model.Person)] = (neuePersonenDialog.DataContext as DetailViewModel).AktuellePerson;

                    }
                );
            //Löschen einer Person
            this.LoeschenCmd = new CustomCommand
                (
                    //CanExe: s.o.
                    para => para is Model.Person,
                    //Exe:
                    para =>
                    {
                        //Anzeige einer MessageBox, ob Löschvorgang wirklich gewollt ist
                        Model.Person person = para as Model.Person;
                        if (MessageBox.Show($"Soll {person.Vorname} {person.Nachname} wirklich gelöscht werden?", "Lösche Person", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            //Löschen der ausgewählten Person
                            Model.Person.Personenliste.Remove(person);
                    }
                );
            //Schließen des Programms
            this.SchliessenCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    para => true,
                    //Exe: Schließen der Applikation
                    para => Application.Current.Shutdown()
                ); ;
        }
    }
}
