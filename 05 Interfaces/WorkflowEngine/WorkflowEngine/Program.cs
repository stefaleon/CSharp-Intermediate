namespace WorkflowEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var workflow = new Workflow();
            workflow.RegisterActivity(new Activity1());
            workflow.RegisterActivity(new Activity2());
            workflow.RegisterActivity(new Activity3());
            workflow.Execute();
        }
    }
}
