using MVVM_Bsp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Bsp.ViewModel
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public CustomCommand LadeDbCmd { get; set; }
        public CustomCommand OeffneDbCmd { get; set; }

        public int AnzahlPersonen { get { return Model.Person.Personenliste.Count; } }

        public StartViewModel()
        {
            this.LadeDbCmd = new CustomCommand
                (
                    para => this.AnzahlPersonen == 0,
                    para =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnzahlPersonen"));
                    }
                );

            this.OeffneDbCmd = new CustomCommand
                (
                    para => this.AnzahlPersonen > 0,
                    para =>
                    {
                        View.ListView DbAnsicht = new View.ListView();
                        DbAnsicht.Show();

                        (para as View.StartView).Close();
                    }
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
