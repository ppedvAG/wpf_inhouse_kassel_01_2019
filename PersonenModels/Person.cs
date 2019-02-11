using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MVVMHelperLibrary;

namespace PersonenModels
{
    public class Person : ModelBase
    {
        private string _name = null;
        private Color _lieblingsfarbe;
        private bool _verheiratet = false;
        private int _alter = 0;

        public string Name
        {
            get => _name;
            set
            {
                SetValue(ref _name, value);
            }
        }
        public int Alter
        {
            get => _alter;
            set
            {
                SetValue(ref _alter, value);
            }
        }
        public Color Lieblingsfarbe
        {
            get => _lieblingsfarbe;
            set
            {
                SetValue(ref _lieblingsfarbe, value);
            }
        }
        public bool Verheiratet
        {
            get => _verheiratet;
            set
            {
                SetValue(ref _verheiratet, value);
            }
        }

        public Person(string name, int alter, Color lieblingsfarbe, bool verheiratet)
        {
            Name = name;
            Alter = alter;
            Lieblingsfarbe = lieblingsfarbe;
            Verheiratet = verheiratet;
        }

        //Für Initialisierung auf XAML-Basis:
        public Person()
        {

        }
    }
}
