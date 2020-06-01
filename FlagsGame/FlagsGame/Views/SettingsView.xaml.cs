using FlagsGame.Core;
using System.Globalization;
using System.IO;
using System.Text.Json;
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
        private string PATHRESULTS = Directory.GetCurrentDirectory() + @"Data/results.json";

        public event ShowOptionDelegate showOption;
        public SettingsView(Session session)
        {
            _session = session;
            InitializeComponent();
        }

        public delegate void ShowOptionDelegate(UserControl viewControl);

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            saveChanges();
            showOption(new OptionsView(_session));
        }

        private void saveChanges()
        {
            _session.Mode = (bool)optionCountries.IsChecked ? GameMode.COUNTRIES : GameMode.FLAGS;
            _session.Language = cbLanguage.SelectedIndex == 0 ? new CultureInfo("en-US") : new CultureInfo("es-ES");
        }

        private void btnReset(object sender, RoutedEventArgs e)
        {
            var jsonResults = JsonSerializer.Serialize(_session.ResultsList);
            File.WriteAllText(PATHRESULTS, jsonResults);
            _session.ResultsList.Clear();
        }
    }
}
