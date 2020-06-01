
using System;

namespace FlagsGame.Core.Model
{
    public class Result : IComparable
    {
        private string _name = string.Empty;
        private int _correctAnswers = 0;
        private int _wrongAnswers = 0;
        private double time;
        private bool _current = false;
        private String _continent = string.Empty;
        private GameMode? gameMode = null;
        public Result() { }
        public int NumQuestions { get => _correctAnswers+_wrongAnswers; }
        public string Name { get => _name; set => _name = value; }
        public int CorrectAnswers { get => _correctAnswers; set => _correctAnswers = value; }
        public int WrongAnswers { get => _wrongAnswers; set => _wrongAnswers = value; }
        public double Time { get => time; set => time = value; }
        public bool Current { get => _current; set => _current = value; }
        public string Continent { get => _continent; set => _continent = value; }

        public int CompareTo(object obj)
        {
            Result result = (Result)obj;
            if (this.CorrectAnswers < result.CorrectAnswers)
            {
                return 1;
            }
            else if (this.CorrectAnswers > result.CorrectAnswers)
            {
                return -1;
            }
            
            else {
                if (this.Time < result.Time)
                {
                    return 1;
                }
                else if (this.Time < result.time)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
