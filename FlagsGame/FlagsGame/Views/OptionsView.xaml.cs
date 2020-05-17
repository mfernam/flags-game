using System.Windows;
using System.Windows.Controls;
using FlagsGame.Core;

namespace FlagsGame.GUI.View
{
    /// <summary>
    /// Lógica de interacción para OptionsView.xaml
    /// </summary>
    public partial class OptionsView : UserControl
    {
        private Session _session = null;
        public OptionsView()
        {
            InitializeComponent();
        }
        public OptionsView(Session session)
        {
            this._session = session;
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsView settingsWindow = new SettingsView();
            settingsWindow.ShowDialog();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnScores_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
