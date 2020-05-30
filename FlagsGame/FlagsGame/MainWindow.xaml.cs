using System.Windows;
using System.Windows.Controls;
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
        private GamePlayView _gamePlayView = null;
        private FinishGameView _finishGameView = null;

        public MainWindow()
        {
            _optionsView = new OptionsView(_session);
            _settingsView = new SettingsView(_session);
            _gameView = new GameView(_session);
            _aboutView = new AboutView();
            _resultsView = new ResultsView(_session);
            _gamePlayView = new GamePlayView(_session);
            _finishGameView = new FinishGameView(_session);

            _finishGameView.showOption += ShowOption;
            _optionsView.showOption += ShowOption;
            _settingsView.showOption += ShowOption;
            _gameView.showOption += ShowOption;
            _gamePlayView.showOption += ShowOption;
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
            if (_viewControl.GetType() == typeof(GamePlayView))
            {
                _gamePlayView = new GamePlayView(_session);
                _contentControl.Children.Add(_gamePlayView);
            }
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _contentControl.Children.Add(_optionsView);
        }
    }
}
