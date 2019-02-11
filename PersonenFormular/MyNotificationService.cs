using PersonenModels;
using System.Windows;

namespace PersonenFormular
{
    internal class MyNotificationService : INotificationService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}