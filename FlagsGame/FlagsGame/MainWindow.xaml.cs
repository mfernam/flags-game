using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using FlagsGame.Core;
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
        private GameFlagView _gameFlagsView = null;
        private FinishGameView _finishGameView = null;
        private GameCountryView _gameCountryView = null;
        string LOCATION_LOGO = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Images\JFFlogo.jpg";

        public MainWindow()
        {
            _optionsView = new OptionsView(_session);
            _settingsView = new SettingsView(_session);
            _gameView = new GameView(_session);
            _aboutView = new AboutView();
            _resultsView = new ResultsView(_session);
            _finishGameView = new FinishGameView(_session);

            _finishGameView.showOption += ShowOption;
            _optionsView.showOption += ShowOption;
            _settingsView.showOption += ShowOption;
            _gameView.showOption += ShowOption;
            _resultsView.showOption += ShowOption;

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
            if (_viewControl.GetType() == typeof(GameFlagView))
            {
                _gameFlagsView = new GameFlagView(_session);
                _gameFlagsView.showOption += ShowOption;
                _contentControl.Children.Add(_gameFlagsView);
            }
            if(_viewControl.GetType() == typeof(GameCountryView))
            {
                _gameCountryView = new GameCountryView(_session);
                _gameCountryView.showOption += ShowOption;
                _contentControl.Children.Add(_gameCountryView);
            }
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            imgLogo.Source = new BitmapImage(new Uri(LOCATION_LOGO));
            _contentControl.Children.Add(_optionsView);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
