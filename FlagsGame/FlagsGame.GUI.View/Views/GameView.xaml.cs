using System.Windows.Controls;
using System.Text.Json;
using System.IO;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using FlagsGame.Core;
using System.Windows;
using System.Linq;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        Session _session = null;
        GameFlagView _gamePlayView = null;
        static string LOCATION = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Data\{0}.json";
        string[] continentList = { "africa","asia","europe","america","oceania"};

        public event ShowOptionDelegate showOption;
        public GameView(Session session)
        {
            _session = session;
            _gamePlayView = new GameFlagView(_session);

            _gamePlayView.showOption += ShowOption;
            InitializeComponent();
        }
        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void btnAll_Click(object sender, RoutedEventArgs e) {
            List<Country> AllCountry = new List<Country>();
            foreach(string location in continentList)
            {
                AllCountry.AddRange(GetCountries(string.Format(LOCATION,location)));
            }
            _session.CountryList = AllCountry;
            AssignContinent("All");
            if (_session.Mode == GameMode.FLAGS)
            {
                showOption(new GameFlagView(_session));
            }
            else if (_session.Mode == GameMode.COUNTRIES)
            {
                showOption(new GameCountryView(_session));
            }
        }

        private void ShowOption(UserControl _viewControl)
        {
            showOption(new OptionsView(_session));
        }
      
        private void btnContinent_Click(object sender, RoutedEventArgs e)
        {
            string continent = ((Button)sender).Name;
            _session.CountryList = GetCountries(String.Format(LOCATION, continent));
            AssignContinent(CapitalizeContinent(continent));
            if (_session.Mode == GameMode.FLAGS)
            {
                showOption(new GameFlagView(_session));
            }
            else if(_session.Mode == GameMode.COUNTRIES)
            {
                showOption(new GameCountryView(_session));
            }
            
        }

        string CapitalizeContinent(string name)
        {
            string nameCapitalized = name.Substring(0, 1).ToUpper() + name.Substring(1);
            return nameCapitalized;
        }

        private List<Country> GetCountries(string continent)
        {
            var jsonString = File.ReadAllText(continent, System.Text.Encoding.UTF8);
            return JsonSerializer.Deserialize<List<Country>>(jsonString);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            showOption(new OptionsView(_session));
        }

        private void AssignContinent(string continent)
        {
            foreach(Country country in _session.CountryList)
            {
                country.Continent = continent;
            }
        }

    }
}
