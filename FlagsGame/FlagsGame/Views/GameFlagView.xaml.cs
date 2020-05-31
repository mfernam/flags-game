using FlagsGame.Core;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Windows;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para GameFlagView.xaml
    /// </summary>
    public partial class GameFlagView : UserControl
    {
        Session _session = null;
        Label lblAnswer = null;
        Result _result = null;
        Stopwatch _stopWatch = null;
        FinishGameView _finishGameView = null;
        string LOCATION_IMG = @"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Images\{0}.png";

        public event ShowOptionDelegate showOption;
        public GameFlagView(Session session)
        {
            _result = new Result();
            _result.Current = true;
            _session = session;
            _stopWatch = new Stopwatch();
            _finishGameView = new FinishGameView(_session);
            InitializeComponent();
        }

        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void InitQuestion()
        {
            _stopWatch.Start();
            var random = new Random();
            List<Country> selectedCountries = new List<Country>();
            selectedCountries = _session.CountryList.OrderBy(x=>random.Next()).Take(4).ToList();
            int index = 1;
            Country question = (Country)selectedCountries.OrderBy(x => random.Next()).Take(1).FirstOrDefault();
            lblCountry.Content = question.Name;
            lblAnswer = new Label();
            lblAnswer.Name = question.CodCountry;
            lblAnswer.Visibility = Visibility.Hidden;
            foreach (Country country in selectedCountries)
            {
                Button btn = (Button)gameArea.FindName("btn" + index);
                btn.Name = country.CodCountry;
                Image img = (Image)gameArea.FindName("img" + index);
                var uri = String.Format(LOCATION_IMG, country.CodCountry);
                img.Source = new BitmapImage(new Uri(uri));
                index++;
            }
        }

        private void gameArea_Loaded(object sender, RoutedEventArgs e)
        {
            _result.Continent = _session.CountryList[0].Continent;
            InitQuestion();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (_result.NumQuestions < 15)
            {
                lblCorrect.Content = btn.Name.Equals(lblAnswer.Name) ? ++_result.CorrectAnswers : _result.CorrectAnswers;
                lblWrong.Content = !btn.Name.Equals(lblAnswer.Name) ? ++_result.WrongAnswers : _result.WrongAnswers;
                
                InitQuestion();
            }
            else
            {
                _stopWatch.Stop();
                _result.Time = _stopWatch.Elapsed.Ticks;
                _session.ResultsList.Add(_result);
                FinishGame();
            }
        }

        void ShowResults(UserControl viewControl)
        {
            showOption(new ResultsView(_session));
        }
        private void FinishGame()
        {            
            _finishGameView.showOption += ShowResults;
            _finishGameView.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.showOption(new GameView(_session));
        }
    }
}
