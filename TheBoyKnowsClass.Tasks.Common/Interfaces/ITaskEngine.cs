namespace TheBoyKnowsClass.Tasks.Common.Interfaces
{
    /// <summary>
    /// This is the interface to implement for Task Engines
    /// </summary>
    public interface ITaskEngine
    {
        /// <summary>
        /// Performs the Task using the Engine.
        /// </summary>
        /// <param name="item">the item can be anything to be used by the engine</param>
        void ProcessItem(object item);

        /// <summary>
        /// Checks if the task engine will process a specific input.
        /// </summary>
        /// <param name="item">Checks if the task engine will process a specific input item.</param>
        /// <returns>Can the task engine process the input</returns>
        bool CanProcessItem(object item);
    }
}
