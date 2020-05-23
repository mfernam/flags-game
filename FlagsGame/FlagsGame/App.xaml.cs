using FlagsGame.Core;
using System.Windows;
using System.Globalization;
using System.Threading;

namespace FlagsGame.GUI.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
        }
    }
}
