using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using FlagsGame.Core;
using FlagsGame.GUI.Controller;
using FlagsGame.GUI.View.Views;

namespace FlagsGame.GUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Session _session = Session.Instance;
        private OptionsView _optionsView = null;
        private GameView _gameView = null;
        private SettingsView _settingsView = null;
        

        public MainWindow()
        {
            _optionsView = new OptionsView(_session);
            _settingsView = new SettingsView(_session);
            _optionsView._showOption += ShowOption;
            _settingsView._showOption += ShowOption;
            InitializeComponent();
        }

        void ShowOption(UserControl _viewControl)
        {
            _contentControl.Children.Clear();
            if (_viewControl.GetType()== typeof(GameView)){
               _contentControl.Children.Add((GameView)_viewControl);
            }
            if(_viewControl.GetType() == typeof(SettingsView)){
                _contentControl.Children.Add((SettingsView)_viewControl);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _contentControl.Children.Add(_optionsView);
        }

    }
}
