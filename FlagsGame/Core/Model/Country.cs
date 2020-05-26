using System;

namespace FlagsGame.Core.Model
{
    public class Country
    {
        string codCountry = string.Empty;
        string name = string.Empty;
        int population;
        int area;
        public string CodCountry { get => codCountry; set => codCountry = value; }
        public string Name { get => name; set => name = value; }
        public int Population { get => population; set => population = value; }
        public int Area { get => area; set => area = value; }
    }
}
