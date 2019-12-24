using PreferenceInvestigator.Model.Interfaces;
using PreferenceInvestigator.Model.Storage;
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
        private IStorageHandler _storageHandler = null;

        public Preferences(IStorageHandler storageHandler, params object[] rawpreferences)
        {
            _storageHandler = storageHandler;

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

        public Preferences(IStorageHandler storageHandler, params Preference[] preferences)
        {
            _storageHandler = storageHandler;

        }

        public void AttatchPreferences(params object[] preferences)
        {

        }

        public void AttatchPreferences(params Preference[] preferences)
        {

        }

        public bool Save()
        {
            return _storageHandler.Save(_preferences);
        }
        public Dictionary<string, Preference> Load()
        {
            return _storageHandler.Load();
        }


        public void Reset()
        {

        }

    }
}
