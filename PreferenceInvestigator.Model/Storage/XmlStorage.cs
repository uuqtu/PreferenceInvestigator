using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Storage
{
    public class XmlStorage : StorageBase
    {
        public override void Connect()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        #region LoadAssemblyWise
        public override Dictionary<string, Preference> LoadAssemblywise()
        {
            return LoadAssemblywise(false, false, false);
        }
        public override Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx)
        {
            return LoadAssemblywise(silentIoEx, false, false);
        }
        public override Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx, bool silentAllEx)
        {
            return LoadAssemblywise(silentIoEx, silentAllEx, false);
        }
        public override Dictionary<string, Preference> LoadAssemblywise(bool silentIoEx, bool silentAllEx, bool holdOnException)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region LoadSingleFile
        public override Dictionary<string, Preference> LoadSingleFile(string path)
        {
            return LoadSingleFile(path, false, false, false);
        }
        public override Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx)
        {
            return LoadSingleFile(path, silentIoEx, false, false);
        }
        public override Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx, bool silentAllEx)
        {
            return LoadSingleFile(path, silentIoEx, silentAllEx, false);
        }
        public override Dictionary<string, Preference> LoadSingleFile(string path, bool silentIoEx, bool silentAllEx, bool holdOnException)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region SafeAssemblyWise
        public override bool SafeAssemblywise(Dictionary<string, Preference> preferences)
        {
            return SafeAssemblywise(preferences, false);
        }
        public override bool SafeAssemblywise(Dictionary<string, Preference> preferences, bool silent)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region SafeSingleFile
        public override bool SafeSingleFile(Dictionary<string, Preference> preferences, string path)
        {
            return SafeSingleFile(preferences, path, false);
        }
        public override bool SafeSingleFile(Dictionary<string, Preference> preferences, string path, bool silent)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
