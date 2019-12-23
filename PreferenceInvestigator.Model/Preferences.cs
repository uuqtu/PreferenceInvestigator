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
        private Dictionary<string, Preference> _preferences = new Dictionary<string, Preference>();

        public Preferences(params object[] rawpreferences)
        {
            foreach (object rawPreference in rawpreferences)
            {
                PropertyInfo[] properties = rawPreference.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                
                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (!propertyInfo.CanRead || !propertyInfo.CanWrite)
                    {
                        continue;
                    }
                    else
                    {
                        if (Preference.TryInvestigate(propertyInfo, rawPreference, out var itemToAttatch))
                            _preferences.Add(itemToAttatch.Name, itemToAttatch);
                    }
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
