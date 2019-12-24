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
        private IStorageConfig _handlerConfig;
        public IStorageConfig HandlerConfig
        {
            get => _handlerConfig;
            private set => _handlerConfig = value;
        }
        private IStorageImplementation _storageImplementation;
        public IStorageImplementation StorageImplementation
        {
            get => _storageImplementation;
            private set => _storageImplementation = value;
        }
        public StorageHandler(IStorageConfig cfg)
        {
            HandlerConfig = cfg;
            EvaluateInstanciation();
        }

        private void EvaluateInstanciation()
        {
            switch (HandlerConfig.FileType)
            {
                case FileTypes.Ini:
                    StorageImplementation = new IniStorage(HandlerConfig);
                    break;
                case FileTypes.SqLite:
                    StorageImplementation = new SqLiteStorage(HandlerConfig);
                    break;
                case FileTypes.Xml:
                    StorageImplementation = new XmlStorage(HandlerConfig);
                    break;
            }
        }

        public bool Save(Dictionary<string, Preference> _preferences)
        {
            switch (HandlerConfig.StorageMode)
            {
                case StorageMode.AssemblyWise:
                    return StorageImplementation.SafeAssemblywise(_preferences,
                                                                  HandlerConfig.ThrowOnSaveException);
                case StorageMode.SingleFile:
                    return StorageImplementation.SafeSingleFile(_preferences, 
                                                                HandlerConfig.FilePath,
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
                    return StorageImplementation.LoadSingleFile(HandlerConfig.FilePath,
                                                                HandlerConfig.ThrowOnReadIoException,
                                                                HandlerConfig.ThrowOnReadException,
                                                                HandlerConfig.AbortOnReadException);
            }
            return null;
        }
    }
}
