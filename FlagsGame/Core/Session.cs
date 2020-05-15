using System;
using Xamarin.Forms;

namespace Core
{
    public class Session
    {
        string language;
        ResourceDictionary dict;
        Session()
        {
            this.dict = new ResourceDictionary();
        }

        public string Language { get => language; set => language = value; }
    }
}
