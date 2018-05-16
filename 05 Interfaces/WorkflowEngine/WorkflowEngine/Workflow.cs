using System.Collections.Generic;

namespace WorkflowEngine
{
    public class Workflow
    {
        private readonly IList<IActivity>
            _activities = new List<IActivity>();
        


        public void Execute()
        
        {
            foreach (var activity in _activities)
            {
                activity.Execute();
            }
        }

        public void RegisterActivity(IActivity activity)         
        {
            _activities.Add(activity);
        }
    }
}
