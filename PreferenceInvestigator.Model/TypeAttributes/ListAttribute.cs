using PreferenceInvestigator.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.TypeAttributes
{
    public class ListAttribute : PreferenceKindAttribute
    {
        public override List<Type> SupportedTypes => throw new NotImplementedException();
    }
}
