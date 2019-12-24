using PreferenceInvestigator.Model.Interfaces;
using PreferenceInvestigator.Model.Storage.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Storage
{
    public class StorageHandler : IStorageHandler
    {
        #region private Variables
        private IStorageConfig _handlerConfig;
        private IStorageImplementation _storageImplementation;
        #endregion
        #region public Variables
        public IStorageConfig HandlerConfig
        {
            get => _handlerConfig;
            private set => _handlerConfig = value;
        }
        public IStorageImplementation StorageImplementation
        {
            get => _storageImplementation;
            private set => _storageImplementation = value;
        }
        #endregion
        #region c'tor
        public StorageHandler(IStorageConfig cfg)
        {
            HandlerConfig = cfg;
            EvaluateInstanciation();
        }
        private void EvaluateInstanciation()
        {
            switch (HandlerConfig.FileType)
            {
                case FileTypes.ini:
                    StorageImplementation = new IniStorage(HandlerConfig);
                    break;
                case FileTypes.sqlite:
                    StorageImplementation = new SqLiteStorage(HandlerConfig);
                    break;
                case FileTypes.xml:
                    StorageImplementation = new XmlStorage(HandlerConfig);
                    break;
            }
        }
        #endregion
        #region Save and Load Methods
        public bool Save(Dictionary<string, Preference> _preferences)
        {
            switch (HandlerConfig.StorageMode)
            {
                case StorageMode.AssemblyWise:
                    return StorageImplementation.SafeAssemblywise(_preferences,
                                                                  HandlerConfig.ThrowOnSaveException);
                case StorageMode.SingleFile:
                    return StorageImplementation.SafeSingleFile(_preferences,
                                                                HandlerConfig.BaseDirectory,
                                                                HandlerConfig.ThrowOnSaveException);
            }
            return false;
        }
        public Dictionary<string, Preference> Load()
        {
            switch (HandlerConfig.StorageMode)
            {
                case StorageMode.AssemblyWise:
                    return StorageImplementation.LoadAssemblywise(HandlerConfig.ThrowOnReadIoException,
                                                                  HandlerConfig.ThrowOnReadException,
                                                                  HandlerConfig.AbortOnReadException);
                case StorageMode.SingleFile:
                    return StorageImplementation.LoadSingleFile(HandlerConfig.BaseDirectory,
                                                                HandlerConfig.ThrowOnReadIoException,
                                                                HandlerConfig.ThrowOnReadException,
                                                                HandlerConfig.AbortOnReadException);
            }
            return null;
        }
        #endregion
    }
}
