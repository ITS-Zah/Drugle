using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System;
namespace PhoneApp5
{
    public partial class Instruction : PhoneApplicationPage
    {
        public Instruction()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Start_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game.xaml", UriKind.Relative));
        }
    }
}