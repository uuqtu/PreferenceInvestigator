using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Interfaces
{
    public interface IStorageMode : IDisposable
    {
        void Connect();
        bool SafeAssemblywise(Dictionary<string, Preference> preferences);
        bool SafeAssemblywise(Dictionary<string, Preference> preferences, bool silent);
        bool SafeSingleFile(Dictionary<string, Preference> preferences);
        bool SafeSingleFile(Dictionary<string, Preference> preferences, string path);
        bool SafeSingleFile(Dictionary<string, Preference> preferences, string path, bool silent);
        Dictionary<string, Preference> LoadAssemblywise(string path);
        Dictionary<string, Preference> LoadAssemblywise(string path, bool silentIoEx);
        Dictionary<string, Preference> LoadAssemblywise(string path, bool silentIoEx, bool silentAllEx);
        Dictionary<string, Preference> LoadAssemblywise(string path, bool silentIoEx, bool silentAllEx, bool holdOnException);
        Dictionary<string, Preference> LoadSingleFile();
        Dictionary<string, Preference> LoadSingleFile(bool silentIoEx);
        Dictionary<string, Preference> LoadSingleFile(bool silentIoEx, bool silentAllEx);
        Dictionary<string, Preference> LoadSingleFile(bool silentIoEx, bool silentAllEx, bool holdOnException);
    }

    public enum StorageModes
    {
        SqLite,
        Xml,
        Ini
    }
}
