using GongSolutions.Wpf.DragDrop;
using MVVMHelperLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragUndDrop
{
    public class ViewModel : ModelBase, IDropTarget
    {
        public ObservableCollection<Maschine> Testdaten { get; set; } = new ObservableCollection<Maschine>()
        {
            new Maschine("Staubsauger", "10"),
            new Maschine("Bügeleisen", "11"),
            new Maschine("Waschmaschine", "12"),
            new Maschine("Ungültige Maschine", "-1"),
        };

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                SetValue(ref _text, value);
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if(dropInfo.Data is Maschine maschine && maschine.ID != "-1")
                dropInfo.Effects = System.Windows.DragDropEffects.Move;
        }

        public void Drop(IDropInfo dropInfo)
        {
            if(dropInfo.Data is Maschine maschine)
            {
                Text = maschine.Name;
                Testdaten.Remove(maschine);
            }
        }
    }

    public class Maschine
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public Maschine(string name, string iD)
        {
            Name = name;
            ID = iD;
        }
    }
}