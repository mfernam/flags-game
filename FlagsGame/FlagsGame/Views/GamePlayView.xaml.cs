using FlagsGame.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para GamePlayView.xaml
    /// </summary>
    public partial class GamePlayView : UserControl
    {
        List<Country> _countries = null;
        Label lblAnswer = null;
        Result _result = null;
        public GamePlayView(List<Country> countries)
        {
            _result = new Result();
            _countries = countries;
            InitializeComponent();
        }

        private void InitQuestion()
        { 
            var random = new Random();
            List<Country> selectedCountries = new List<Country>();
            selectedCountries = _countries.OrderBy(x=>random.Next()).Take(4).ToList();
            int index = 1;
            Country question = (Country)selectedCountries.OrderBy(x => random.Next()).Take(1).FirstOrDefault();
            lblCountry.Content = question.Name;
            lblAnswer = new Label();
            lblAnswer.Name = question.CodCountry;
            lblAnswer.Visibility = System.Windows.Visibility.Hidden;
            foreach (Country country in selectedCountries)
            {
                Button btn = (Button)gameArea.FindName("btn" + index);
                btn.Name = country.CodCountry;
                Image img = (Image)gameArea.FindName("img" + index);
                var uri = String.Format(@"C:\projects\flags-game\FlagsGame\FlagsGame\Resources\Images\{0}.png", country.CodCountry);
                img.Source = new BitmapImage(new Uri(uri));
                index++;
            }
        }

        private void gameArea_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            InitQuestion();
        }

        private void btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Name.Equals(lblAnswer.Name)){
                lblCorrect.Content = ++_result.CorrectAnswers;
                
            }
            else
            {
                lblWrong.Content = ++_result.WrongAnswers;
                
            }
            if(_result.NumQuestions <15)
                InitQuestion();
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
