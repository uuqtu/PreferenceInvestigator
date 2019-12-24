using PreferenceInvestigator.Model.Exceptions;
using PreferenceInvestigator.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.PreferenceClasses
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PreferenceTypeAttribute : Attribute, IPreferenceType
    {
        /// <summary>
        /// This Static Variable contains all supported Types
        /// </summary>
        private static List<Type> SupporteeTypes = new List<Type>()
        {
            typeof(string),
            typeof(int),
            typeof(double),
            typeof(Enum),
            typeof(bool),
            typeof(List<string>),
        };



        private Type _attributedType;
        public Type AttributedType
        {
            get => _attributedType;
            set => _attributedType = value;
        }
        public PreferenceTypeAttribute(Type preferenceEntryType)
        {
            if (preferenceEntryType == typeof(string))
            {
                AttributedType = typeof(string);
                return;
            }
            if (preferenceEntryType == typeof(int))
            {
                AttributedType = typeof(int);
                return;
            }
            if (preferenceEntryType == typeof(double))
            {
                AttributedType = typeof(double);
                return;
            }
            if (preferenceEntryType == typeof(Enum))
            {
                AttributedType = typeof(Enum);
                return;
            }
            if (preferenceEntryType == typeof(bool))
            {
                AttributedType = typeof(bool);
                return;
            }
            if (preferenceEntryType == typeof(List<string>))
            {
                AttributedType = typeof(List<string>);
                return;
            }
            throw new PreferenceTypeDecorationException();
        }

        public PreferenceTypeAttribute(CustomTypes preferenceEntryType)
        {
            if (preferenceEntryType == CustomTypes.Path)
            {
                AttributedType = typeof(string);
                return;
            }

            throw new PreferenceTypeDecorationException();
        }

        public static bool IsSupportedType(Type t)
        {
            if (t == null) throw new ArgumentNullException("propertyType");

            foreach (Type supporteeType in SupporteeTypes)
            {
                //if (t.IsAssignableFrom(propertyType)
                if (supporteeType.Equals(t) || supporteeType.IsSubclassOf(t))
                    return true;
                if (t.BaseType == supporteeType)
                    return true;
            }
            return false;
        }

        internal static PreferenceTypeAttribute TryGetPreferenceType(Type propertyType)
        {
            if (propertyType == typeof(string))
                return new PreferenceTypeAttribute(typeof(string));
            if (propertyType == typeof(int))
                return new PreferenceTypeAttribute(typeof(int));
            if (propertyType == typeof(double))
                return new PreferenceTypeAttribute(typeof(double));
            if (propertyType.IsSubclassOf(typeof(Enum)))
                return new PreferenceTypeAttribute(typeof(Enum));
            if (propertyType == typeof(bool))
                return new PreferenceTypeAttribute(typeof(bool)); ;
            return null;
        }
    }


    public enum CustomTypes
    {
        Path,
        Password,

    }
}
