using FlagsGame.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
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
    }
}
