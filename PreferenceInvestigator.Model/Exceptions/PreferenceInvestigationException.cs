using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Exceptions
{
    public class PreferenceInvestigationException : Exception
    {
        public PreferenceInvestigationException(string message, object rawobj, PropertyInfo propertyInfo) : base(message)
        {
        }
    }
}
