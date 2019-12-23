using PreferenceInvestigator.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Storage
{
    public abstract class StorageBase : IStorageMode
    {
        public abstract void Connect();
        public abstract void Dispose();
        public abstract Dictionary<string, Preference> LoadAssemblywise();
        public abstract Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx);
        public abstract Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx, bool silentAllEx);
        public abstract Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx, bool silentAllEx, bool holdOnException);
        public abstract Dictionary<string, Preference> LoadSingleFile(string path);
        public abstract Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx);
        public abstract Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx, bool silentAllEx);
        public abstract Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx, bool silentAllEx, bool holdOnException);
        public abstract bool SafeAssemblywise(Dictionary<string, Preference> preferences);
        public abstract bool SafeAssemblywise(Dictionary<string, Preference> preferences, bool silent);
        public abstract bool SafeSingleFile(Dictionary<string, Preference> preferences, string path);
        public abstract bool SafeSingleFile(Dictionary<string, Preference> preferences, string path, bool silent);
        public static Dictionary<string, Preference> GroupAssemblywise(List<Preference> preferences)
        {
            return null;
        }
    }
}
