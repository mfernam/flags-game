using System.Globalization;

namespace FlagsGame.Core
{
    public class Session
    {
        private CultureInfo _language = new CultureInfo("es-ES");

        private static readonly Session _instance = new Session();

        static Session(){}

        private Session() { }

        public static Session Instance
        {
            get => _instance;
        }

        public CultureInfo Language {
            get {
                return _language; 
            }
            set
            {
                _language = value;
            }
    }
        public ModeGame Mode { get; set; } = ModeGame.COUNTRIES;
    }
}
