using System;
using System.Threading.Tasks;
using TheBoyKnowsClass.Common.UI.Enumerations;

namespace TheBoyKnowsClass.Common.UI.Interfaces
{
    public interface IMessageHandler
    {
        Task<MessageHandlerResponse?> GetResponseAsync(string title, string message, MessageBoxButtons messageBoxButtons);
        Task<MessageHandlerResponse?> GetResponseAsync(string title, string message, long interval, long timeout, MessageBoxButtons messageBoxButtons, EventHandler eventHandler);
        void HideMessageBox();
    }
}