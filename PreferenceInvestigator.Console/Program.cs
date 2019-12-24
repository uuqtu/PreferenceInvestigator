﻿using PreferenceInvestigator.Model.Interfaces;
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

            IStorageConfig cfg = new StorageConfig("Settings", FileTypes.xml, StorageMode.AssemblyWise)
            {
                AbortOnReadException = true,
                BaseDirectory = "",
                //FileType = FileTypes.Ini,
                //StorageMode = StorageMode.AssemblyWise,
                ThrowOnReadException = true,
                ThrowOnReadIoException = true,
                ThrowOnSaveException = true,
                CreateSubDirectoryForPreferences = true,
                SubDirectory = "Settings",
                
            };
            IStorageHandler hndlr = new StorageHandler(cfg);


            PreferenceInvestigator.Model.Preferences investigator = new Model.Preferences(hndlr, preferences);



        }
    }
}
