using System;
using System.Diagnostics;
using System.Security;
using TheBoyKnowsClass.Common.Enumerations;

namespace TheBoyKnowsClass.Common.Operations.Log
{
    public class LogHelper
    {
        private readonly bool _eventLog;
        private readonly string _eventLogName;

        public LogHelper(string eventLogName, string eventLog)
        {
            try
            {
                if (!EventLog.SourceExists(eventLogName))
                {
                    EventLog.CreateEventSource(eventLogName, eventLog);
                }

                _eventLogName = eventLogName;
                _eventLog = true;
            }
            catch (SecurityException securityException)
            {
                _eventLog = false;
                WriteEntry(String.Format("Error Reading Event Log : {0}", securityException.Message), MessageType.Warning);
            }
        }

        public void WriteEntry(string message, MessageType messageType)
        {
            if(_eventLog)
            {
                EventLog.WriteEntry(_eventLogName, message, (EventLogEntryType)messageType);
            }
            else
            {
                string entry = String.Format("{0} : {1} : {2}", DateTime.Now, messageType.ToString(), message);

                Debug.WriteLine(entry);
                Console.WriteLine(entry);
            }
        }
    }
}
