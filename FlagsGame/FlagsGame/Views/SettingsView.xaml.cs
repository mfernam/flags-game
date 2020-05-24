using FlagsGame.Core;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        Session _session = null;

        public event CloseControlDelegate closeControl;
        public SettingsView(Session session)
        {
            _session = session;
            InitializeComponent();
        }

        public delegate void CloseControlDelegate(UserControl viewControl);

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            saveChanges();
            closeControl(new OptionsView(_session));
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
