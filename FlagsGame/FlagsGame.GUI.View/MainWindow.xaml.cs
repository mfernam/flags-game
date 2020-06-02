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
        private SelectionGameView _selectionGameView = null;

        public MainWindow()
        {
            _optionsView = new OptionsView(_session);
            _finishGameView = new FinishGameView(_session);
            _selectionGameView = new SelectionGameView(_session);

            _selectionGameView.showOption += ShowOption;
            _finishGameView.showOption += ShowOption;
            _optionsView.showOption += ShowOption;

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
                _gameView = (GameView)_viewControl;
                _gameView.showOption += ShowOption;
                _contentControl.Children.Add(_gameView);
            }
            if (_viewControl.GetType() == typeof(SettingsView))
            {
                _settingsView = (SettingsView)_viewControl;
                _settingsView.showOption += ShowOption;
                _contentControl.Children.Add(_settingsView);
            }
            if (_viewControl.GetType() == typeof(AboutView))
            {
                _aboutView = (AboutView)_viewControl;
                _contentControl.Children.Add(_aboutView);
            }
            if (_viewControl.GetType() == typeof(ResultsView))
            {
                _resultsView = (ResultsView)_viewControl;
                _resultsView.showOption += ShowOption;
                _contentControl.Children.Add(_resultsView);
            }
            if (_viewControl.GetType() == typeof(GameFlagView))
            {
                _gameFlagsView = (GameFlagView)_viewControl;
                _gameFlagsView.showOption += ShowOption;
                _contentControl.Children.Add(_gameFlagsView);
            }
            if(_viewControl.GetType() == typeof(GameCountryView))
            {
                _gameCountryView = (GameCountryView)_viewControl;
                _gameCountryView.showOption += ShowOption;
                _contentControl.Children.Add(_gameCountryView);
            }
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _contentControl.Children.Add(_optionsView);
        }

        
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
