using FlagsGame.Core;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para ResultsView.xaml
    /// </summary>
    public partial class ResultsView : UserControl
    {
        private Session _session = null;
        private string PATHRESULTS = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Data\results.json";
        public event ShowOptionDelegate showOption;
        public ResultsView(Session session)
        {
            _session = session;
            var jsonString = File.ReadAllText(PATHRESULTS, System.Text.Encoding.UTF8);
            var listResults = JsonSerializer.Deserialize<List<Result>>(jsonString);
            _session.ResultsList = listResults;
            _session.ResultsList.Sort();
            InitializeComponent();
        }
        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            dgResults.ItemsSource = null;
            dgResults.ItemsSource = _session.ResultsList;  
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            showOption(new OptionsView(_session));
        }

        private void dgResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgResults.ItemsSource = null;
            dgResults.ItemsSource = _session.ResultsList;
        }
    }
}
