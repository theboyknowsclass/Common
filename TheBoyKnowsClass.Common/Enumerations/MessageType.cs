using System.Diagnostics;

namespace TheBoyKnowsClass.Common.Enumerations
{
    public enum MessageType
    {
        Information = (int)EventLogEntryType.Information,
        Warning = (int)EventLogEntryType.Warning,
        Error = (int)EventLogEntryType.Error
    }
}
