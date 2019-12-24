using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Interfaces
{
    public interface IStorageConfig
    {
        FileTypes FileType { get; }
        StorageMode StorageMode { get; }
        bool ThrowOnSaveException { get; set; }
        /// <summary>
        /// String.Empty, wenn einzelne Files verwendet werden sollen.
        /// Andernfalls wird ein Default Wert verwendet.
        /// </summary>
        string BaseDirectory { get; set; }
        bool ThrowOnReadIoException { get; set; }
        bool ThrowOnReadException { get; set; }
        bool AbortOnReadException { get; set; }
        bool CreateSubDirectoryForPreferences { get; set; }
        string SubDirectory { get; set; }
        string PreferencesBaseName { get;  }
        string MachineUniqueIdentifier { get; }
    }

    public enum FileTypes
    {
        sqlite,
        xml,
        ini
    }

    public enum StorageMode
    {
        SingleFile,
        AssemblyWise
    }




}
