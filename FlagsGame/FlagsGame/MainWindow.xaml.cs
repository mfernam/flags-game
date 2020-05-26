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
        private AboutView _aboutView = null;
        private ResultsView _resultsView = null;
        

        public MainWindow()
        {
            _optionsView = new OptionsView(_session);
            _settingsView = new SettingsView(_session);
            _gameView = new GameView();
            _aboutView = new AboutView();
            _resultsView = new ResultsView();
            _optionsView.showOption += ShowOption;
            _settingsView.showOption += ShowOption;
            InitializeComponent();
        }

        void ShowOption(UserControl _viewControl)
        {
            _contentControl.Children.Clear();
            if (_viewControl.GetType() == typeof(OptionsView))
            {
                _contentControl.Children.Add(_optionsView);
            }
            if (_viewControl.GetType() == typeof(GameView))
            {
                _contentControl.Children.Add(_gameView);
            }
            if (_viewControl.GetType() == typeof(SettingsView))
            {
                _contentControl.Children.Add(_settingsView);
            }
            if (_viewControl.GetType() == typeof(AboutView))
            {
                _contentControl.Children.Add(_aboutView);
            }
            if (_viewControl.GetType() == typeof(ResultsView))
            {
                _contentControl.Children.Add(_resultsView);
            }
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _contentControl.Children.Add(_optionsView);
        }
    }
}
