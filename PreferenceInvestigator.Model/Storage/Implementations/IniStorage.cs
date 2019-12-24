using PreferenceInvestigator.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Storage.Implementations
{
    public class IniStorage : IStorageImplementation
    {
        private IStorageConfig _handlerConfig;
        public IStorageConfig HandlerConfig
        {
            get => _handlerConfig;
            private set => _handlerConfig = value;
        }
        public IniStorage(IStorageConfig cfg)
        {
            HandlerConfig = cfg;
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx, bool silentAllEx, bool holdOnException)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx, bool silentAllEx, bool holdOnException)
        {
            throw new NotImplementedException();
        }

        public bool SafeAssemblywise(Dictionary<string, Preference> preferences, bool silent)
        {
            throw new NotImplementedException();
        }

        public bool SafeSingleFile(Dictionary<string, Preference> preferences, string path, bool silent)
        {
            throw new NotImplementedException();
        }
    }
}
