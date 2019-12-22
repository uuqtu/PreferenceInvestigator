using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model
{
    public class Preferences
    {
        private List<KeyValuePair<string, Preference>> _preferences = new List<KeyValuePair<string, Preference>>();

        public Preferences(params object[] rawpreferences)
        {
            foreach (object obj in rawpreferences)
            {
                PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                foreach (PropertyInfo property in properties)
                {
                    Preference itemToAttatch;
                    if (Preference.Investigate(property, obj, out itemToAttatch))
                            _preferences.Add(new KeyValuePair<string, Preference>(itemToAttatch.Name, itemToAttatch));
                }
            }
        }

        public Preferences(params Preference[] preferences)
        {

        }

        public void AttatchPreferences(params object[] preferences)
        {

        }

        public void AttatchPreferences(params Preference[] preferences)
        {

        }

    }
}
