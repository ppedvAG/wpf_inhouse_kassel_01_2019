using MVVMHelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonenModels
{
    public class MainWindowViewModel
    {
        public Person NeuePerson  { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public void SavePerson()
        {
            string verheiratet = NeuePerson.Verheiratet ? "verheiratet" : "unverheiratet";
            NotificationService.Service.ShowMessage($"{NeuePerson.Name} ({verheiratet}), Alter:  {NeuePerson.Alter}, Lieblingsfarbe: {NeuePerson.Lieblingsfarbe}");
        }

        public MainWindowViewModel()
        {
            NeuePerson = new Person();

            SaveCommand = new DelegateCommand(p => SavePerson(), p => !string.IsNullOrWhiteSpace(NeuePerson.Name));
            NeuePerson.PropertyChanged += NeuePerson_PropertyChanged;
        }

        private void NeuePerson_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }
    }
}
