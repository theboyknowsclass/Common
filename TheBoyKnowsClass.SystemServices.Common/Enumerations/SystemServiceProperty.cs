using System;
using TheBoyKnowsClass.Common.Attributes;

namespace TheBoyKnowsClass.SystemServices.Common.Enumerations
{
    public enum SystemServiceProperty
    {
        [Type(typeof(string))]
        DisplayName = 0,

        [Type(typeof(string))]
        PathName = 1,

        [Type(typeof(UInt32))]
        ServiceType = 2,

        [Type(typeof(UInt32))]
        ErrorControl = 3,

        [Type(typeof(string))]
        StartMode = 4,

        [Type(typeof(bool))]
        DesktopInteract = 5,

        [Type(typeof(string))]
        StartName = 6,

        [Type(typeof(string))]
        StartPassword = 7,

        [Type(typeof(string))]
        LoadOrderGroup = 8,

        [Type(typeof(string))]
        LoadOrderGroupDependencies = 9,

        [Type(typeof(string))]
        ServiceDependencies = 10,      
    }
}
