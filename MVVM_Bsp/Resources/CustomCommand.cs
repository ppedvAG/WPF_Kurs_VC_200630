using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Bsp.Resources
{
    //Klasse, welche die Commands (bzw. deren zu befüllende Hülle) zu Verfügung stellt (vgl. Modul 13)
    public class CustomCommand : ICommand
    {
        //Delegatedefinition
        public delegate bool CanExecuteDelegate(object parameter);
        public delegate void ExecuteDelegate(object parameter);

        //Eigenschaftsdefinitionen
        public CanExecuteDelegate CanExecuteMethode { get; set; }
        public ExecuteDelegate ExecuteMethode { get; set; }

        //Konstruktor
        public CustomCommand(CanExecuteDelegate can, ExecuteDelegate exe)
        {
            this.CanExecuteMethode = can;
            this.ExecuteMethode = exe;
        }

        //Eventanmeldung
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methoden
        public bool CanExecute(object parameter)
        {
            return this.CanExecuteMethode(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethode(parameter);
        }
    }
}
