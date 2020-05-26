using System.Windows.Controls;
using System.Text.Json;
using System.IO;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        GamePlayView _gamePlayView = null;
        public GameView()
        {
            _gamePlayView = new GamePlayView();
            InitializeComponent();
        }

        private void btnAfrica_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string location = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\africa.json";
            var jsonString = File.ReadAllText(location, System.Text.Encoding.UTF8);
            
            var jsonModel = JsonSerializer.Deserialize<List<Country>>(jsonString);
            var kk = jsonModel;
        }
    }
}
