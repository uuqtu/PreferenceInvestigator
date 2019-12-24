using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Interfaces
{
    public interface IStorageImplementation
    {
        void Connect();
        bool SafeSingleFile(Dictionary<string, Preference> preferences, string path, bool silent);
        Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx, bool silentAllEx, bool holdOnException);
        bool SafeAssemblywise(Dictionary<string, Preference> preferences, bool silent);
        Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx, bool silentAllEx, bool holdOnException);
    }
    
    //public static Dictionary<string, Preference> GroupAssemblywise(List<Preference> preferences)
    //{
    //    return null;
    //}
}
