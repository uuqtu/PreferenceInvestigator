using PreferenceInvestigator.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.PreferenceClasses
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
        private string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings");
        public string FilePath
        {
            get => _filePath;
            set => _filePath = value;
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

        public StorageConfig(FileTypes fileType, StorageMode mode)
        {
            FileType = fileType;
            StorageMode = mode;
        }

        public StorageConfig(string path, FileTypes fileType, StorageMode mode)
        {
            FilePath = path;
            FileType = fileType;
            StorageMode = mode;
        }


    }
}
