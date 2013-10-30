using System.Diagnostics;

namespace TheBoyKnowsClass.Common.Desktop.Enumerations
{
    public enum MessageType
    {
        Information = (int)EventLogEntryType.Information,
        Warning = (int)EventLogEntryType.Warning,
        Error = (int)EventLogEntryType.Error
    }
}
