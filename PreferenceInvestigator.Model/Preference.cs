using PreferenceInvestigator.Model.Attributes;
using PreferenceInvestigator.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model
{
    public class Preference : IPreference
    {
        #region Fields
        private readonly PropertyInfo _propertyInfo = null;
        private PropertyInfo PropertyInfo => _propertyInfo;

        private readonly object _object = null;
        public object Object => _object;

        private readonly Assembly _assembly = null;
        private Assembly Assembly => _assembly;
        public string AssemblyFilePath => Assembly.Location;

        private readonly PreferenceCharacteristicsAttribute _preferenceElement;
        public IPreferenceCharacteristics PreferenceElement => _preferenceElement;

        private readonly Attributes.PreferenceTypeAttribute _preferenceKind;
        public IPreferenceType PreferenceKind => _preferenceKind;


        private string _namePrefix = string.Empty;
        public string NamePrefix => _namePrefix;

        private readonly string _NameAppendix = null;
        private string NameAppendix
        {
            get { return (_NameAppendix == null ? string.Empty : System.Type.Delimiter + _NameAppendix); }
        }
        public string Name => NamePrefix + Object.GetType().Namespace + System.Type.Delimiter + Object.GetType().Name + System.Type.Delimiter + PropertyInfo.Name + NameAppendix;
        public string ShortName
        {
            get
            {
                int index = Name.LastIndexOf('.');
                if (index > 0 && index + 1 < Name.Length)
                    return Name.Substring(index + 1);
                else
                    return Name;
            }
        }

        public object Value
        {
            get { return PropertyInfo.GetValue(Object, null); }
            set { PropertyInfo.SetValue(Object, value, null); }
        }

        public Type Type
        {
            get { return PropertyInfo.PropertyType; }
        }

        #endregion
        private Preference(object rawObj, PropertyInfo property,
                          PreferenceCharacteristicsAttribute entry, PreferenceTypeAttribute type, PreferenceRelationAttribute relation)
        {
            _assembly = property.Module.Assembly;
            _preferenceElement = entry;
            _preferenceKind = type;
            _propertyInfo = property;
            _object = rawObj;           
        }

        internal static bool TryInvestigate(PropertyInfo propertyInfo, object rawobj, out Preference itemToAttatch)
        {
            PreferenceCharacteristicsAttribute characteristics = null;
            PreferenceTypeAttribute type = null;
            PreferenceRelationAttribute relation = null;
            itemToAttatch = null;
            
            var customAttributes = Attribute.GetCustomAttributes(propertyInfo).ToList();
            foreach (Attribute customAttribute in customAttributes)
            {
                DetermineAttributeType(ref characteristics, ref type, ref relation, customAttribute);
            }

            //If the property has no characteristics it is not to be added.
            if (characteristics == null)
                return false;   
            //Try to get the Preference from the PropertyType
            if (type == null)   
                type = PreferenceTypeAttribute.TryGetPreferenceType(propertyInfo.PropertyType);
            //
            if (type == null) 
                throw new Exception("Es wurde kein SettingsType-Attribut angegeben");

            if (!type.SupportedType(propertyInfo.PropertyType))
                throw new Exception("Das verwendete SettingsType-Attribut (" + type.GetType().Name + ") ist nicht mit dem Typ der Eigenschaft (" + propertyInfo.PropertyType + ") kompatibel");

            itemToAttatch = new Preference(rawobj, propertyInfo, characteristics, type, relation);
            return true;
        }

        private static void DetermineAttributeType(ref PreferenceCharacteristicsAttribute characteristics, 
                                                   ref PreferenceTypeAttribute type,
                                                   ref PreferenceRelationAttribute relation, 
                                                   Attribute customAttribute)
        {
            if (customAttribute is IPreferenceCharacteristics)
            {
                if (@characteristics == null)
                    @characteristics = (PreferenceCharacteristicsAttribute)customAttribute;
                else
                    throw new Exception("Unerlaubter Mehrfach-Eintrag des SettingsEntry-Attributes");
            }
            else if (customAttribute is PreferenceTypeAttribute)
            {
                if (@type == null)
                    @type = (PreferenceTypeAttribute)customAttribute;
                else
                    throw new Exception("Unerlaubter Mehrfach-Eintrag des SettingsType-Attributes");
            }
            else if (customAttribute == null)
            {
                if (@relation == null)
                    @relation = (PreferenceRelationAttribute)customAttribute;
                else
                    throw new Exception("Unerlaubter Mehrfach-Eintrag des SettingsType-Attributes");
            }
        }
    }
}
