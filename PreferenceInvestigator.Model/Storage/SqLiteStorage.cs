using PreferenceInvestigator.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Storage
{
    public class SqLiteStorage : StorageBase
    {
        public override void Connect()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadAssemblywise(string path)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadAssemblywise(string path, bool silentIoEx)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadAssemblywise(string path, bool silentIoEx, bool silentAllEx)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadAssemblywise(string path, bool silentIoEx, bool silentAllEx, bool holdOnException)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadSingleFile()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadSingleFile(bool silentIoEx)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadSingleFile(bool silentIoEx, bool silentAllEx)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, Preference> LoadSingleFile(bool silentIoEx, bool silentAllEx, bool holdOnException)
        {
            throw new NotImplementedException();
        }

        public override bool SafeAssemblywise(Dictionary<string, Preference> preferences)
        {
            throw new NotImplementedException();
        }

        public override bool SafeAssemblywise(Dictionary<string, Preference> preferences, bool silent)
        {
            throw new NotImplementedException();
        }

        public override bool SafeSingleFile(Dictionary<string, Preference> preferences)
        {
            throw new NotImplementedException();
        }

        public override bool SafeSingleFile(Dictionary<string, Preference> preferences, string path)
        {
            throw new NotImplementedException();
        }

        public override bool SafeSingleFile(Dictionary<string, Preference> preferences, string path, bool silent)
        {
            throw new NotImplementedException();
        }
    }
}
