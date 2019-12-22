﻿using PreferenceInvestigator.Model.Attributes;
using PreferenceInvestigator.Model.TypeAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Console
{
    public class SettingsFile
    {

        public SettingsFile()
        {
            StringTest = "Default-String";
            BooleanTest = true;
            FilePath = Path.Combine("Test", "Path");
            EnumTest = TestEnum.Element1;
            Double = 0.0;
            Int = 0;
            SourceSelection = new List<string> { "Element1", "Element2", "Element3" };
        }

        [PreferenceElement("String-Test", Category = "Test/String")]
        public string StringTest { get; set; }

        [PreferenceElement("Boolean-Test", Category = "Test/Boolean")]
        public bool BooleanTest { get; set; }

        [PreferenceElement("Path-Test", Category = "Test/Path")]
        [PathAttribute()]
        public string FilePath { get; set; }

        [PreferenceElement("Enum-Test", Category = "Test/Enum")]
        public TestEnum EnumTest { get; set; }

        [PreferenceElement("Double-Test", Category = "Test/Double")]
        public double Double { get; set; }

        [PreferenceElement("Int-Test", Category = "Test/Int")]
        public int Int { get; set; }

        [PreferenceElement("List-Test", Category = "Test/List")]
        [ListAttribute()]
        public List<string> SourceSelection { get; set; }
    }

    public enum TestEnum
    {
        Element1,
        Element2,
        Element3
    }
}
