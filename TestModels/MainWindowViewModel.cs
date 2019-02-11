using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TestModels
{
    public class MainWindowViewModel
    {
        public Person NeuePerson { get; set; } = new Person();

        public List<object> PossibleColors => new List<object>()
        {
            Color.Green,
            Color.Red,
            Color.Blue
        };

        public DelegateCommand ChangeLieblingsfarbeCommand { get; set; }

        public MainWindowViewModel()
        {
            ChangeLieblingsfarbeCommand = new DelegateCommand(p =>
            {
                NeuePerson.Lieblingsfarbe = Color.FromName(p.ToString());
            });
        }

    }
}
