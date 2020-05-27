
namespace FlagsGame.Core.Model
{
    public class Result
    {
        private string _name = string.Empty;
        private int _correctAnswers = 0;
        private int _wrongAnswers = 0;
        public Result() { }
        public int NumQuestions { get => _correctAnswers+_wrongAnswers; }
        public string Name { get => _name; set => _name = value; }
        public int CorrectAnswers { get => _correctAnswers; set => _correctAnswers = value; }
        public int WrongAnswers { get => _wrongAnswers; set => _wrongAnswers = value; }
    }
}
