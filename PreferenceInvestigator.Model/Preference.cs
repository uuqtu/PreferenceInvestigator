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

        private readonly PreferenceElementAttribute _preferenceElement;
        public IPreferenceElement PreferenceElement => _preferenceElement;

        private readonly PreferenceKindAttribute _preferenceKind;
        public IPreferenceKindAttribut PreferenceKind => _preferenceKind;


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
        private Preference(Assembly assembly, PropertyInfo property, object obj,
                          PreferenceElementAttribute entry, PreferenceKindAttribute type)
        {
            _assembly = assembly;
            _preferenceElement = entry;
            _preferenceKind = type;
            _propertyInfo = property;
            _object = obj;           
        }

        internal static bool Investigate(PropertyInfo property, object obj, out Preference itemToAttatch)
        {
            itemToAttatch = null;
            if (property == null) throw new ArgumentNullException("property");
            if (obj == null) throw new ArgumentNullException("obj");

            if (!property.CanRead || !property.CanWrite)
                return false;

            PreferenceElementAttribute preferenceElement = null;
            PreferenceKindAttribute preferenceKind = null;

            var customAttributes = Attribute.GetCustomAttributes(property).ToList();
            foreach (Attribute customAttribute in customAttributes)
            {
                if (customAttribute is IPreferenceElement)
                {
                    if (preferenceElement == null)
                        preferenceElement = (PreferenceElementAttribute)customAttribute;
                    else
                        throw new Exception("Unerlaubter Mehrfach-Eintrag des SettingsEntry-Attributes");
                }
                else if (customAttribute is PreferenceKindAttribute)
                {
                    if (preferenceKind == null)
                        preferenceKind = (PreferenceKindAttribute)customAttribute;
                    else
                        throw new Exception("Unerlaubter Mehrfach-Eintrag des SettingsType-Attributes");
                }
            }

            if (preferenceKind == null)
                return false;   //Keine Exception schmeissen. Dies ist eine Property, die nicht aufgenommen werden soll

            if (preferenceKind == null)   //versuchen, Type aus property.Type zu generieren
                preferenceKind = PreferenceKindAttribute.GetStandardSettingsTypeAttribute(property.PropertyType);
            if (preferenceKind == null)   //wenn immernoch null --> Fehler
                throw new Exception("Es wurde kein SettingsType-Attribut angegeben");
            if (!preferenceKind.SupportedType(property.PropertyType))
                throw new Exception("Das verwendete SettingsType-Attribut (" + preferenceKind.GetType().Name + ") ist nicht mit dem Typ der Eigenschaft (" + property.PropertyType + ") kompatibel");

            itemToAttatch = new Preference(property.Module.Assembly, property, obj, preferenceElement, preferenceKind);
            return true;
        }
    }
}
