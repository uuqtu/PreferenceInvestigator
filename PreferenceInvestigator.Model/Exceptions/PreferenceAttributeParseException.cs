using PreferenceInvestigator.Model.Attributes;
using PreferenceInvestigator.Model.PreferenceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Exceptions
{
    public class PreferenceAttributeParseException : Exception
    {
        public PreferenceAttributeParseException(string message, PreferenceCharacteristicsAttribute characteristics) : base(message)
        {
        }

        public PreferenceAttributeParseException(string message, PreferenceTypeAttribute type) : base(message)
        {
        }

        public PreferenceAttributeParseException(string message, PreferenceRelationAttribute relation) : base(message)
        {
        }
    }
}
