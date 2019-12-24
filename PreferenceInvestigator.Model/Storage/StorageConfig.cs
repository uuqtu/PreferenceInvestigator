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
        private FileTypes _fileType;
        public FileTypes FileType
        {
            get => _fileType;
            private set => _fileType = value;
        }
        private StorageMode _storageMode;
        public StorageMode StorageMode
        {
            get => _storageMode;
            private set => _storageMode = value;
        }
        private bool _throwOnSaveException;
        public bool ThrowOnSaveException
        {
            get => _throwOnSaveException;
            set => _throwOnSaveException = value;
        }
        private string _baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        public string BaseDirectory
        {
            get => _baseDirectory;
            set => _baseDirectory = value;
        }
        private bool _throwOnReadIoException;
        public bool ThrowOnReadIoException
        {
            get => _throwOnReadIoException;
            set => _throwOnReadIoException = value;
        }
        private bool _throwOnReadException;
        public bool ThrowOnReadException
        {
            get => _throwOnReadException;
            set => _throwOnReadException = value;
        }
        private bool _abortOnReadException;
        public bool AbortOnReadException
        {
            get => _abortOnReadException;
            set => _abortOnReadException = value;
        }
        private bool _createSubDirectoryForPreferences;
        public bool CreateSubDirectoryForPreferences
        {
            get => _createSubDirectoryForPreferences;
            set => _createSubDirectoryForPreferences = value;
        }
        private string _subDirectory;
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
        private string _machineUniqueIdentifier;
        public string MachineUniqueIdentifier
        {
            get => new DeviceIdBuilder().AddProcessorId().AddMotherboardSerialNumber().ToString();
        }

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


    }
}
