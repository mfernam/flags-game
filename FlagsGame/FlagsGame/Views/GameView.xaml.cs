using System.Windows.Controls;
using System.Text.Json;
using System.IO;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using FlagsGame.Core;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        GamePlayView _gamePlayView = null;
        List<Country> selectedCountries = null;
        Session _session = null;

        public event ShowOptionDelegate showOption;
        public GameView(Session session)
        {
            _session = session;
            InitializeComponent();
        }
        public delegate void ShowOptionDelegate(UserControl viewControl);



        private void btnAfrica_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string location = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\africa.json";
            var jsonString = File.ReadAllText(location, System.Text.Encoding.UTF8);

            _session.CountryList = JsonSerializer.Deserialize<List<Country>>(jsonString);

            showOption(new GamePlayView(_session.CountryList));

        }
    }
}
