using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.Interfaces
{
    public interface IPreferenceElement
    {
        /// <summary>
        /// Displayname of the Property
        /// </summary>
        string DisplayName { get; }
        /// <summary>
        /// The hierarcical structure where the Property can be located
        /// e.g. Main/Subcategory
        /// </summary>
        string Category { get; set; }
        /// <summary>
        /// Splits all the Categories and lists them
        /// </summary>
        List<string> CategoryTree { get; }
        /// <summary>
        /// Is a description of the respective display name
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// If a category obtains multiple properties the display index sorts the properties according to its value
        /// </summary>
        int DisplayIndex { get; set; }
        /// <summary>
        /// Indicates whether the user directly can change the value
        /// </summary>
        bool UserCanChange { get; set; }
    }
}
