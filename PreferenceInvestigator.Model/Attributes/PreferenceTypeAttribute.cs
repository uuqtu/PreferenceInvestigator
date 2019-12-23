using PreferenceInvestigator.Model.Interfaces;
using PreferenceInvestigator.Model.PreferenceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class PreferenceTypeAttribute : Attribute, IPreferenceType
    {
        public PreferenceTypeAttribute()
        {

        }

        public abstract List<Type> SupportedTypes { get; }


        public bool SupportedType(Type propertyType)
        {
            if (propertyType == null) throw new ArgumentNullException("propertyType");

            foreach (Type t in SupportedTypes)
            {
                //if (t.IsAssignableFrom(propertyType)
                if (propertyType.Equals(t) || propertyType.IsSubclassOf(t))
                    return true;
            }
            return false;
        }


        public static PreferenceTypeAttribute TryGetPreferenceType(Type type)
        {
            if (type == typeof(string))
                return new StringAttribute();
            if (type == typeof(int))
                return new IntegerAttribute();
            if (type == typeof(double))
                return new DoubleAttribute();
            if (type.IsSubclassOf(typeof(System.Enum)))
                return new EnumAttribute();
            if (type == typeof(bool))
                return new BooleanAttribute();
            return null;
        }


    }
}
