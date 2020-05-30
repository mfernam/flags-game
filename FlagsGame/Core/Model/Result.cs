
using System;

namespace FlagsGame.Core.Model
{
    public class Result : IComparable
    {
        private string _name = string.Empty;
        private int _correctAnswers = 0;
        private int _wrongAnswers = 0;
        private long time;
        private bool current = false;
        public Result() { }
        public int NumQuestions { get => _correctAnswers+_wrongAnswers; }
        public string Name { get => _name; set => _name = value; }
        public int CorrectAnswers { get => _correctAnswers; set => _correctAnswers = value; }
        public int WrongAnswers { get => _wrongAnswers; set => _wrongAnswers = value; }
        public long Time { get => time; set => time = value; }
        public bool Current { get => current; set => current = value; }

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
