using System.Windows.Controls;
using System.Text.Json;
using System.IO;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using FlagsGame.Core;
using System.Linq;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        Session _session = null;
        GamePlayView _gamePlayView = null;
        static string AFRICA_LOCATION = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\africa.json";
        static string ASIA_LOCATION = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\asia.json";
        static string EUROPE_LOCATION = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\europe.json";
        static string NORTHA_LOCATION = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\northamerica.json";
        static string SOUTHA_LOCATION = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\southamerica.json";
        static string OCEANIA_LOCATION = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\oceania.json";
        static string[] ALL_LOCATION = { AFRICA_LOCATION, ASIA_LOCATION, EUROPE_LOCATION, NORTHA_LOCATION, SOUTHA_LOCATION, OCEANIA_LOCATION };

        public event ShowOptionDelegate showOption;
        public GameView(Session session)
        {
            _session = session;
            _gamePlayView = new GamePlayView(_session);

            _gamePlayView.showOption += ShowOption;
            InitializeComponent();
        }
        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void btnAll_Click(object sender, System.Windows.RoutedEventArgs e) {
            List<Country> AllCountry = new List<Country>();
            foreach(string location in ALL_LOCATION)
            {
                AllCountry.AddRange(GetCountries(location));
            }
            _session.CountryList = AllCountry;
            showOption(new GamePlayView(_session));
        }

        private void ShowOption(UserControl _viewControl)
        {
            showOption(new OptionsView(_session));
        }

        private void btnAfrica_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _session.CountryList= GetCountries(AFRICA_LOCATION);
            showOption(new GamePlayView(_session));
        }

        private void btnAsia_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _session.CountryList = GetCountries(ASIA_LOCATION);
            showOption(new GamePlayView(_session));
        }

        private void btnEurope_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _session.CountryList = GetCountries(EUROPE_LOCATION);
            showOption(new GamePlayView(_session));
        }

        private void btnNorthA_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _session.CountryList = GetCountries(NORTHA_LOCATION);
            showOption(new GamePlayView(_session));
        }

        private void btnSouthA_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _session.CountryList = GetCountries(SOUTHA_LOCATION);
            showOption(new GamePlayView(_session));
        }

        private void btnOceania_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _session.CountryList = GetCountries(OCEANIA_LOCATION);
            showOption(new GamePlayView(_session));
        }

        private List<Country> GetCountries(string continent)
        {
            var jsonString = File.ReadAllText(continent, System.Text.Encoding.UTF8);
            return JsonSerializer.Deserialize<List<Country>>(jsonString);
        }
    }
}
