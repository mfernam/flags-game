using FlagsGame.Core.Model;
using System.Collections.Generic;
using System.Globalization;

namespace FlagsGame.Core
{
    public class Session
    {
        private CultureInfo _language = new CultureInfo("es-ES");

        private static readonly Session _instance = new Session();

        private List<Country> _countryList = new List<Country>();
        private List<Result> _resultsList = new List<Result>();

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
        public GameMode Mode { get; set; } = GameMode.FLAGS;
        public List<Country> CountryList { get => _countryList; set => _countryList = value; }
        public List<Result> ResultsList { get => _resultsList; set => _resultsList = value; }
    }
}
