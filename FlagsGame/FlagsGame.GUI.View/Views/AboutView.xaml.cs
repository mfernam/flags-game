using FlagsGame.Core;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
        string LOCATION_PDF = AppDomain.CurrentDomain.BaseDirectory + @"Resources\instructions.pdf";
        public event ShowOptionDelegate showOption;
        public AboutView()
        {
            InitializeComponent();
        }
        public delegate void ShowOptionDelegate(UserControl viewControl);

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            showOption(new OptionsView(Session.Instance));
        }

        private void btnDocument_Click(object sender, RoutedEventArgs e)
        {
            //new FileStream(LOCATION_PDF, FileMode.Open, FileAccess.Read);
            var browser = new WebBrowser();
            browser.Navigate(LOCATION_PDF);

        }
    }
}
