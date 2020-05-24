using System.Windows;
using System.Windows.Controls;
using FlagsGame.Core;
using FlagsGame.GUI.View.Views;

namespace FlagsGame.GUI.View
{
    /// <summary>
    /// Lógica de interacción para OptionsView.xaml
    /// </summary>
    public partial class OptionsView : UserControl
    {
        Session _session = null;
        GameView _gameView = null;
        SettingsView _settingsView = null;
        AboutView _aboutView = null;
        ResultsView _resultsView = null;

        public event ShowOptionDelegate showOption;
        public OptionsView(Session session)
        {
            this._session = session;
            _settingsView = new SettingsView(_session);
            _gameView = new GameView();
            _aboutView = new AboutView();
            _resultsView = new ResultsView();
            InitializeComponent();
        }

        public delegate void ShowOptionDelegate(UserControl controlView);


        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {            
            showOption(_settingsView);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            showOption(_gameView);
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            showOption(_aboutView);
        }

        private void btnScores_Click(object sender, RoutedEventArgs e)
        {
            showOption(_resultsView);
        }
    }
}
