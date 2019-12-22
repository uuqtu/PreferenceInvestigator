using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PreferencesFile preferences = new PreferencesFile();

            PreferenceInvestigator.Model.Preferences investigator = new Model.Preferences(preferences);

        }
    }
}
