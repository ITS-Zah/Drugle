using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
namespace PhoneApp5
{
    public partial class GameOver : PhoneApplicationPage
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}