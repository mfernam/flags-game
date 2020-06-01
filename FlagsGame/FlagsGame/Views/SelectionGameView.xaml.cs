using FlagsGame.Core;
using System.Windows;
using System.Windows.Controls;

namespace FlagsGame.GUI.View.Views
{
    /// <summary>
    /// Lógica de interacción para SelectionGameView.xaml
    /// </summary>
    public partial class SelectionGameView : Window
    {
        Session _session = null;

        public event ShowOptionDelegate showOption;
        public SelectionGameView(Session session)
        {
            _session = session;
            InitializeComponent();
        }

        public delegate void ShowOptionDelegate(UserControl viewControl);
        private void GameSelection_Click(object sender, RoutedEventArgs e)
        {
            string type_game = ((Button)sender).Name;
            _session.IsTrainning = type_game == "trainning";
            showOption(new GameView(_session));
            this.Close();
        }
    }
}
