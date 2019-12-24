using PreferenceInvestigator.Model.Attributes;
using PreferenceInvestigator.Model.Exceptions;
using PreferenceInvestigator.Model.Interfaces;
using PreferenceInvestigator.Model.PreferenceClasses;
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

        private readonly PreferenceCharacteristicsAttribute _preferenceCharasteristice;
        public IPreferenceCharacteristics PreferenceCharacteristics => _preferenceCharasteristice;

        private readonly PreferenceTypeAttribute _preferenceType;
        public IPreferenceType PreferenceType => _preferenceType;

        public readonly PreferenceRelationAttribute _relation;
        public IPreferenceRelation Relation => _relation;

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
            _preferenceCharasteristice = entry;
            _preferenceType = type;
            _propertyInfo = property;
            _object = rawObj;
        }

        internal static bool TryInvestigate(PropertyInfo propertyInfo, object rawobj, out Preference itemToAttatch)
        {
            PreferenceCharacteristicsAttribute characteristics = null;
            PreferenceTypeAttribute type = null;
            PreferenceRelationAttribute relation = null;
            itemToAttatch = null;
            //Get the custom prperties of the the property
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
                throw new PreferenceInvestigationException("There is no PreferenceTypeAttribute given for this Preference.", rawobj, propertyInfo);

            if (!PreferenceTypeAttribute.IsSupportedType(propertyInfo.PropertyType))
                throw new PreferenceInvestigationException("The used PreferenceTypeAttribute (" + type.GetType().Name + ") " +
                                                           "can not be used with with the type (" + propertyInfo.PropertyType + ").",
                                                           rawobj, propertyInfo);

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
                    throw new PreferenceAttributeParseException("Unerlaubter Mehrfach-Eintrag des SettingsEntry-Attributes", @characteristics);
            }
            else if (customAttribute is PreferenceTypeAttribute)
            {
                if (@type == null)
                    @type = (PreferenceTypeAttribute)customAttribute;
                else
                    throw new PreferenceAttributeParseException("Unerlaubter Mehrfach-Eintrag des SettingsType-Attributes", @type);
            }
            else if (customAttribute == null)
            {
                if (@relation == null)
                    @relation = (PreferenceRelationAttribute)customAttribute;
                else
                    throw new PreferenceAttributeParseException("Unerlaubter Mehrfach-Eintrag des SettingsType-Attributes", @relation);
            }
        }
    }
}
