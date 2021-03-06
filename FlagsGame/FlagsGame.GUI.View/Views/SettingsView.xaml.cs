﻿using FlagsGame.Core;
using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading;
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
        private string PATHRESULTS = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Data\results.json";

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
            _session.ResultsList.Clear();
            var jsonResults = JsonSerializer.Serialize(_session.ResultsList);
            File.WriteAllText(PATHRESULTS, jsonResults);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            optionFlags.IsChecked = _session.Mode == GameMode.FLAGS;
            optionCountries.IsChecked = _session.Mode == GameMode.COUNTRIES;
            cbLanguage.SelectedIndex = _session.Language.Name == "en-US" ? 0 : 1;
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _session.Language = cbLanguage.SelectedIndex == 0 ? new CultureInfo("en-US") : new CultureInfo("es-ES");

            var language = _session.Language.Name == "es-ES" ?
                Application.Current.Resources.MergedDictionaries[1] :
                Application.Current.Resources.MergedDictionaries[0];

            Application.Current.Resources.MergedDictionaries.Add(language);
            if (!CultureInfo.CurrentCulture.Name.Equals(_session.Language))
            {
                Thread.CurrentThread.CurrentCulture = _session.Language;
            }
        }
    }
}
