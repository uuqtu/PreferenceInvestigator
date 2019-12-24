using DeviceId;
using PreferenceInvestigator.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Storage
{
    public class StorageConfig : IStorageConfig
    {
        #region private Variables
        private FileTypes _fileType;
        private StorageMode _storageMode;
        private bool _throwOnSaveException;
        private string _baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        private bool _throwOnReadIoException;
        private bool _throwOnReadException;
        private bool _abortOnReadException;
        private bool _createSubDirectoryForPreferences;
        private string _subDirectory;
        private string _machineUniqueIdentifier;
        #endregion
        #region public Variables
        public FileTypes FileType
        {
            get => _fileType;
            private set => _fileType = value;
        }
        public StorageMode StorageMode
        {
            get => _storageMode;
            private set => _storageMode = value;
        }
        public bool ThrowOnSaveException
        {
            get => _throwOnSaveException;
            set => _throwOnSaveException = value;
        }
        public string BaseDirectory
        {
            get => _baseDirectory;
            set => _baseDirectory = value;
        }
        public bool ThrowOnReadIoException
        {
            get => _throwOnReadIoException;
            set => _throwOnReadIoException = value;
        }
        public bool ThrowOnReadException
        {
            get => _throwOnReadException;
            set => _throwOnReadException = value;
        }
        public bool AbortOnReadException
        {
            get => _abortOnReadException;
            set => _abortOnReadException = value;
        }
        public bool CreateSubDirectoryForPreferences
        {
            get => _createSubDirectoryForPreferences;
            set => _createSubDirectoryForPreferences = value;
        }
        public string SubDirectory
        {
            get => _subDirectory;
            set => _subDirectory = value;
        }
        private string _preferencesBaseName;
        public string PreferencesBaseName
        {
            get => _preferencesBaseName;
            internal set => _preferencesBaseName = value;
        }
        public string MachineUniqueIdentifier
        {
            get => new DeviceIdBuilder().AddProcessorId().AddMotherboardSerialNumber().ToString();
        }
        #endregion
        #region c'tor
        public StorageConfig(string baseName, FileTypes fileType, StorageMode mode)
        {
            PreferencesBaseName = baseName;
            FileType = fileType;
            StorageMode = mode;
        }

        public StorageConfig(string baseName, string path, FileTypes fileType, StorageMode mode)
        {
            PreferencesBaseName = baseName;
            BaseDirectory = path;
            FileType = fileType;
            StorageMode = mode;
        }
        #endregion
    }
}
