using PreferenceInvestigator.Model.Interfaces;
using PreferenceInvestigator.Model.PreferenceClasses;
using PreferenceInvestigator.Model.Storage;
using PreferenceInvestigator.Model.Storage.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PreferencesFile preferences = new PreferencesFile();

            IStorageConfig cfg = new StorageConfig(FileTypes.Xml, StorageMode.AssemblyWise)
            {
                AbortOnReadException = true,
                FilePath = "",
                //FileType = FileTypes.Ini,
                //StorageMode = StorageMode.AssemblyWise,
                ThrowOnReadException = true,
                ThrowOnReadIoException = true,
                ThrowOnSaveException = true,
            };
            IStorageHandler hndlr = new StorageHandler(cfg);


            PreferenceInvestigator.Model.Preferences investigator = new Model.Preferences(hndlr, preferences);



        }
    }
}
