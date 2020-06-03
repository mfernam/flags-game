using FlagsGame.Core;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        List<Result> filterList = null;
        public ResultsView(Session session)
        {
            _session = session;
            var jsonString = File.ReadAllText(PATHRESULTS, System.Text.Encoding.UTF8);
            var listResults = JsonSerializer.Deserialize<List<Result>>(jsonString);
            _session.ResultsList = listResults;
            _session.ResultsList.Sort();
            filterList = _session.ResultsList;
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

        private void SetFilterList(List<Result> filterList)
        {
            dgResults.ItemsSource = null;
            dgResults.ItemsSource = filterList;
        }

        private void txtField_TextChanged(object sender, TextChangedEventArgs e)
        {            
            filterList =
                !string.IsNullOrEmpty(txtPlayer.Text) && !string.IsNullOrEmpty(txtTime.Text) ?
                _session.ResultsList.Where(x => x.Name.ToLower().Contains(txtPlayer.Text.ToLower()) && x.Time.Equals(txtTime.Text)).ToList() :
                !string.IsNullOrEmpty(txtPlayer.Text) ?
                _session.ResultsList.Where(x => x.Name.ToLower().Contains(txtPlayer.Text.ToLower())).ToList() : 
                !string.IsNullOrEmpty(txtTime.Text) ? 
                _session.ResultsList.Where(x => x.Time.Equals(txtTime.Text)).ToList() :
                _session.ResultsList;
            SetFilterList(filterList);
        }

        private void cbContinent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var continent = ((ComboBoxItem)cbContinent.SelectedItem).Name;
            var content = ((ComboBoxItem)cbContinent.SelectedItem).Content.ToString();
            filterList =
                !string.IsNullOrEmpty(content) ?
                _session.ResultsList.Where(x => x.Continent.ToLower().Contains(continent.ToLower())).ToList() :                
                _session.ResultsList;
            SetFilterList(filterList);
        }
    }
}
