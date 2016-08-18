using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace PhoneApp5
{
    public partial class StartMenu : PhoneApplicationPage
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game.xaml", UriKind.Relative));
        }

        private void Ref_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Instruction.xaml", UriKind.Relative));
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Terminate();
        }
    }
}