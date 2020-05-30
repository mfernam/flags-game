using FlagsGame.Core;
using FlagsGame.Core.Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para FinishGameView.xaml
    /// </summary>
    public partial class FinishGameView : Window
    {
        Session _session = null;
        private string PATHJSON = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Data\results.json";
        public event ShowOptionDelegate showOption;
        public FinishGameView(Session session)
        {
            _session = session;
            InitializeComponent();
        }

        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            _session.ResultsList.Find(x => x.Current).Name = txtName.Text;
            _session.ResultsList.ForEach(x => x.Current = false);
            var jsonResults = JsonSerializer.Serialize(_session.ResultsList);
            File.WriteAllText(PATHJSON, jsonResults);
            this.Close();
        }
    }
}
