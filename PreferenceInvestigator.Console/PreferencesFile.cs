using PreferenceInvestigator.Model.Attributes;
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
        public string StringTest { get; set; }

        [PreferenceCharacteristics("Boolean-Test", Category = "Test/Boolean")]
        public bool BooleanTest { get; set; }

        [PreferenceCharacteristics("Path-Test", Category = "Test/Path")]
        [PathAttribute()]
        public string FilePath { get; set; }

        [PreferenceCharacteristics("Enum-Test", Category = "Test/Enum")]
        public TestEnum EnumTest { get; set; }

        [PreferenceCharacteristics("Double-Test", Category = "Test/Double")]
        public double Double { get; set; }

        [PreferenceCharacteristics("Int-Test", Category = "Test/Int")]
        public int Int { get; set; }

        [PreferenceCharacteristics("List-Test", Category = "Test/List")]
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
