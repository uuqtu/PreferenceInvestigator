﻿using PreferenceInvestigator.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceInvestigator.Model.PreferenceClasses
{
    public class BooleanAttribute : PreferenceTypeAttribute
    {
        public override List<Type> SupportedTypes => new List<Type> { typeof(bool) };
    }
}
