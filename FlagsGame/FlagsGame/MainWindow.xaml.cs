using System.Windows;
using System.Windows.Controls;
using FlagsGame.Core;

namespace FlagsGame.GUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Session _session = null;
        private OptionsView _optionsView = null;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Session session)
        {
            this._session = session;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _optionsView = new OptionsView();
            _contentControl.Children.Add(_optionsView);
        }
    }
}
