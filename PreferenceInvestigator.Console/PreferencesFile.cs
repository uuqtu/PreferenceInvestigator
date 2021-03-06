﻿using PreferenceInvestigator.Model.Attributes;
using PreferenceInvestigator.Model.PreferenceClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Console
{
    public class PreferencesFile
    {

        public PreferencesFile()
        {
            StringTest = "Default-String";
            BooleanTest = true;
            FilePath = Path.Combine("Test", "Path");
            EnumTest = TestEnum.Element1;
            Double = 0.0;
            Int = 0;
            SourceSelection = new List<string> { "Element1", "Element2", "Element3" };
        }

        [PreferenceCharacteristics("String-Test", Category = "Test/String")]
        [PreferenceTypeAttribute(typeof(string))]
        [PreferenceRelation]
        public string StringTest { get; set; }

        [PreferenceCharacteristics("Boolean-Test", Category = "Test/Boolean")]
        [PreferenceRelation]
        public bool BooleanTest { get; set; }

        [PreferenceCharacteristics("Path-Test", Category = "Test/Path")]
        [PreferenceType(CustomTypes.Path)]
        [PreferenceRelation]
        public string FilePath { get; set; }

        [PreferenceCharacteristics("Enum-Test", Category = "Test/Enum")]
        [PreferenceTypeAttribute(typeof(Enum))]
        [PreferenceRelation]
        public TestEnum EnumTest { get; set; }

        [PreferenceCharacteristics("Double-Test", Category = "Test/Double")]
        public double Double { get; set; }

        [PreferenceCharacteristics("Int-Test", Category = "Test/Int")]
        public int Int { get; set; }

        [PreferenceCharacteristics("List-Test", Category = "Test/List")]
        [PreferenceType(typeof(List<string>))]
        [PreferenceRelation]
        public List<string> SourceSelection { get; set; }
    }

    public enum TestEnum
    {
        Element1,
        Element2,
        Element3
    }
}
