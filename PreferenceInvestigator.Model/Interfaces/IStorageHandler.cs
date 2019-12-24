using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Interfaces
{
    public interface IStorageHandler
    {
        bool Save(Dictionary<string, Preference> preferences);
        Dictionary<string, Preference> Load();
    }
}
