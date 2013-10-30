using System.ServiceProcess;
using System.ComponentModel;

namespace TheBoyKnowsClass.SystemServices.Common.Enumerations
{
    /// <summary>
    /// The Status of a ServiceViewModel
    /// </summary>
    public enum SystemServiceStatus
    {
        [Description("Continuing...")]
        ContinuePending = ServiceControllerStatus.ContinuePending,
        [Description("Paused")]
        Paused = ServiceControllerStatus.Paused,
        [Description("Pausing...")]
        PausePending = ServiceControllerStatus.PausePending,
        [Description("Running")]
        Running = ServiceControllerStatus.Running,
        [Description("Starting...")]
        StartPending = ServiceControllerStatus.StartPending,
        [Description("Stopped")]
        Stopped = ServiceControllerStatus.Stopped,
        [Description("Stopping...")]
        StopPending = ServiceControllerStatus.StopPending,
        [Description("Not Installed")]
        NotInstalled = 0,
    }
}
