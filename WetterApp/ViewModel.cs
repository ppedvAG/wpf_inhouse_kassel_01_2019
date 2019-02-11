using MVVMHelperLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetterApp
{
    public class ViewModel : ModelBase
    {
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public ObservableCollection<Stadt> Städte { get; set; } = new ObservableCollection<Stadt>();

        private string _neueStadt;
        public string NeueStadt
        {
            get { return _neueStadt; }
            set
            {
                _neueStadt = value;
                SetValue(ref _neueStadt, value);
                AddCommand.OnCanExecuteChanged();
            }
        }

        public ViewModel()
        {
            AddCommand = new DelegateCommand(p =>
            {
                Stadt stadt = new Stadt(NeueStadt);
                Städte.Add(stadt);
            },
            p =>
            {
                if (string.IsNullOrEmpty(NeueStadt))
                    return false;
                if (Städte.Any(stadt => stadt.Name == NeueStadt))
                    return false;

                return true;
            }
            );

            DeleteCommand = new DelegateCommand(p =>
            {
                if (p is Stadt stadt)
                {
                    Städte.Remove(stadt);
                }
            });
        }
    }
}