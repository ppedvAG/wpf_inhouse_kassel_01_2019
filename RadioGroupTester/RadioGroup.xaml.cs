using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RadioGroupTester
{
    /// <summary>
    /// Interaction logic for RadioGroup.xaml
    /// </summary>
    public partial class RadioGroup : UserControl
    {



        public Orientation WrapPanelOrientation
        {
            get { return (Orientation)GetValue(WrapPanelOrientationProperty); }
            set { SetValue(WrapPanelOrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WrapPanelOrientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WrapPanelOrientationProperty =
            DependencyProperty.Register("WrapPanelOrientation", typeof(Orientation), typeof(RadioGroup), new PropertyMetadata(Orientation.Horizontal));


        public Type EumerationType
        {
            get { return (Type)GetValue(EumerationTypeProperty); }
            set { SetValue(EumerationTypeProperty, value); }
        }

        public Style FakeCheckBoxStyle
        {
            get { return (Style)GetValue(FakeCheckBoxProperty); }
            set { SetValue(FakeCheckBoxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadioButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FakeCheckBoxProperty =
            DependencyProperty.Register("FakeCheckBoxProperty", typeof(Style), typeof(RadioGroup), new PropertyMetadata(null, StyleChanged));

        private static void StyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RadioGroup group)
            {
                foreach (var item in group.wpRadioButtons.Children)
                {
                    if(item is FakeCheckBox box)
                    {
                        box.Style = (Style)e.NewValue;
                    }
                }
            }
        }


        // Using a DependencyProperty as the backing store for EumerationType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EumerationTypeProperty =
            DependencyProperty.Register(nameof(EumerationType), typeof(Type), typeof(RadioGroup), new PropertyMetadata(null, TypeChanged));

        private static void TypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RadioGroup group)
            {
                group.wpRadioButtons.Children.Clear();
                if (((Type)e.NewValue).IsEnum)
                {
                    foreach (var item in Enum.GetValues((Type)e.NewValue))
                    {
                        FakeCheckBox box = new FakeCheckBox();
                        box.Content = item.ToString();
                        box.Tag = item;
                        group.wpRadioButtons.Children.Add(box);
                    }
                }
            }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(RadioGroup), new PropertyMetadata(null, SelectedItemChanged));

        private static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is RadioGroup group)
            {
                foreach (var item in group.wpRadioButtons.Children)
                {
                    if(item is FakeCheckBox button)
                    {
                        if(button.Tag.Equals(e.NewValue))
                        {
                            button.IsChecked = true;
                            return;
                        }
                    }
                }
            }
        }

        public RadioGroup()
        {
            InitializeComponent();
            mainGrid.DataContext = this;
        }

        private void WpRadioButtons_Checked(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is FakeCheckBox box)
            {
                SelectedItem =  box.Tag;
            }
        }
    }
}