using System;


namespace FlagsGame.Core
{
    public class Session
    {
        private string _language = string.Empty;
        private ModeGame _mode = ModeGame.COUNTRIES;

        Session()
        {
        }

        public string Language { get => _language; set => _language = value; }
        public ModeGame Mode { get => _mode; set => _mode = value; }
    }
}
