using FlagsGame.Core;
using System.Globalization;
using System.Windows.Controls;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        Session _session = null;
        public event ShowControl _showOption;
        OptionsView _optionsView = null;
        public SettingsView(Session session)
        {
            _session = session;
            InitializeComponent();
        }

        public delegate void ShowControl(UserControl controlView);

        private void btnAccept_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            saveChanges();
            _optionsView = new OptionsView(_session);
            _showOption(_optionsView);
        }

        private void saveChanges()
        {
            _session.Mode = (bool)optionCountries.IsChecked ? ModeGame.COUNTRIES : ModeGame.FLAGS;
            _session.Language = cbLanguage.SelectedIndex == 0 ? new CultureInfo("en-US") : new CultureInfo("es-ES");

        }

        private void btnReset(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
