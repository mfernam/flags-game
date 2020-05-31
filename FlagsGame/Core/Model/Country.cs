using System;

namespace FlagsGame.Core.Model
{
    public class Country
    {
        string codCountry = string.Empty;
        string name = string.Empty;
        int population;
        double area;
        string _continent = string.Empty;
        public string CodCountry { get => codCountry; set => codCountry = value; }
        public string Name { get => name; set => name = value; }
        public int Population { get => population; set => population = value; }
        public double Area { get => area; set => area = value; }
        public string Continent { get => _continent; set => _continent = value; }
    }
}
