using PreferenceInvestigator.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace PreferenceInvestigator.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PreferenceCharacteristicsAttribute : Attribute, IPreferenceCharacteristics
    {
        private string _title;
        private int _displayIndex;
        private bool _userCanChange;
        private string _category;
        private string _description;

        public List<string> CategoryTree => _category?.Split(Path.DirectorySeparatorChar).ToList();

        public PreferenceCharacteristicsAttribute(string title)
        {
            DisplayName = title;
            DisplayIndex = 0;
            UserCanChange = false;
            Category = String.Empty;
            Description = String.Empty;
        }

        public string DisplayName
        {
            get { return _title; }
            private set { _title = value; }
        }
        public int DisplayIndex
        {
            get { return _displayIndex; }
            set { _displayIndex = value; }
        }
        public bool UserCanChange
        {
            get { return _userCanChange; }
            set { _userCanChange = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
