using System.Collections.Generic;
using TheBoyKnowsClass.Tasks.Common.Interfaces;

namespace TheBoyKnowsClass.Tasks.Common.Models
{
    public class TaskFactory
    {
        private readonly List<ITaskEngine> _taskEngines;

        public TaskFactory()
        {
            _taskEngines = new List<ITaskEngine>();
        }

        public void AddToTaskEngines(ITaskEngine taskEngine)
        {
            _taskEngines.Add(taskEngine);
        }

        public void RemoveFromTaskEngines(ITaskEngine taskEngine)
        {
            _taskEngines.Remove(taskEngine);
        }

        public void ProcessItem(object item)
        {
            foreach (ITaskEngine taskEngine in _taskEngines)
            {
                if (taskEngine.CanProcessItem(item))
                {
                    taskEngine.ProcessItem(item);
                }
            }
        }

        public List<ITaskEngine> TaskEngines
        {
            get { return _taskEngines; }
        }


    }
}
