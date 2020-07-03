﻿using MVVM_Bsp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM_Bsp.Model
{      

    public class Person : IDataErrorInfo
    {
        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        public static void LadePersonenAusDb()
        {
            Personenliste.Add(new Person() { Vorname = "Otto", Nachname = "Meier", Geburtsdatum = new DateTime(2002, 5, 12), Verheiratet = true, Geschlecht = Gender.Männlich, Lieblingsfarbe = Colors.Blue });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Müller", Geburtsdatum = new DateTime(1989, 4, 4), Verheiratet = false, Geschlecht = Gender.Weiblich, Lieblingsfarbe = Colors.Green });
            Personenliste.Add(new Person() { Vorname = "Marie", Nachname = "Schmidt", Geburtsdatum = new DateTime(1977, 12, 17), Verheiratet = true, Geschlecht = Gender.Divers, Lieblingsfarbe = Colors.Yellow });
        }

        private string vorname;
        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }

        private string nachname;
        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set { geburtsdatum = value; }
        }

        private bool verheiratet;
        public bool Verheiratet
        {
            get { return verheiratet; }
            set { verheiratet = value; }
        }

        private Color lieblingsfarbe;
        public Color Lieblingsfarbe
        {
            get { return lieblingsfarbe; }
            set { lieblingsfarbe = value; }
        }

        private Gender geschlecht;
        private Person person;

        public Gender Geschlecht
        {
            get { return geschlecht; }
            set { geschlecht = value; }
        }

        public string Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Vorname):
                        if (Vorname.Length <= 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                        if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben enthalten.";
                        break;
                    case nameof(Nachname):
                        if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                        if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben enthalten.";
                        break;
                    case nameof(Geburtsdatum):
                        if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                        if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                        break;
                    case nameof(Lieblingsfarbe):
                        if (Lieblingsfarbe.ToString().Equals("#00000000")) return "Wählen Sie Ihre Libelingsfarbe aus.";
                        break;
                }
                return "";
            }
        }

        public Person()
        {
            Geburtsdatum = DateTime.Now;
            this.Vorname = "";
            this.Nachname = "";
        }

        public Person(Person person)
        {
            this.Vorname = person.Vorname;
            this.Nachname = person.Nachname;
            this.Verheiratet = person.Verheiratet;
            this.Lieblingsfarbe = person.Lieblingsfarbe;
            this.Geschlecht = person.Geschlecht;
            this.Geburtsdatum = new DateTime(person.Geburtsdatum.Year, person.Geburtsdatum.Month, person.Geburtsdatum.Day);
        }
    }
}

