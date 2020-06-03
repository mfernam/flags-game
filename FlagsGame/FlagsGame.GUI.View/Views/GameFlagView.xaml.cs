using FlagsGame.Core;
using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Threading;

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
        DispatcherTimer _stopWatch = null;
        FinishGameView _finishGameView = null;
        string LOCATION_IMG = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Images\{0}.png";

        public event ShowOptionDelegate showOption;
        public GameFlagView(Session session)
        {
            _result = new Result();
            _result.Current = true;
            _session = session;
            
            _stopWatch = new DispatcherTimer();
            _finishGameView = new FinishGameView(_session);

            InitializeComponent();
        }
        private void dtClockTime_Tick(object sender, EventArgs e)
        {
            _result.ElapsedTime += _stopWatch.Interval.Seconds;
            lblTime.Content = string.Format("{0}",_result.ElapsedTime);
        }

        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void InitQuestion()
        {

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
                img.Source = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
                index++;
            }
        }

        private void gameArea_Loaded(object sender, RoutedEventArgs e)
        {
            _result.Continent = _session.CountryList[0].Continent;
            _stopWatch.Tick += new EventHandler(dtClockTime_Tick);
            _stopWatch.Interval = new TimeSpan(0, 0, 1);
            _stopWatch.Start();
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
                _result.Time = lblTime.Content.ToString(); ;
                _session.ResultsList.Add(_result);
                FinishGame();
            }
        }

        void ShowResults(UserControl viewControl)
        {
            if (viewControl.GetType() == typeof(OptionsView))
            {
                showOption(new OptionsView(_session));
            }
            if (viewControl.GetType() == typeof(ResultsView))
            {
                showOption(new ResultsView(_session));
            }
            
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
