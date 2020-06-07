using FlagsGame.Core;
using System;
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
        private string PATHJSON = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Data\results.json";
        public event ShowOptionDelegate showOption;
        public FinishGameView(Session session)
        {
            _session = session;
            InitializeComponent();
        }

        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var current = _session.ResultsList.Find(x => x.Current);
            current.Name = txtName.Text;
            current.DateGame = DateTime.Now;
            _session.ResultsList.ForEach(x => x.Current = false);

            if (!_session.IsTrainning)
            {
                var jsonResults = JsonSerializer.Serialize(_session.ResultsList);
                File.WriteAllText(PATHJSON, jsonResults);
                showOption(new ResultsView(_session));
            }
            else
            {
                _session.ResultsList.Remove(current);
                showOption(new OptionsView(_session));
            }
            
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_session.IsTrainning)
            {
                txtName.Visibility = Visibility.Hidden;
                lblName.Visibility = Visibility.Hidden;
            }
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Text = string.Empty;
        }
    }
}
