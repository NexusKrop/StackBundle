using System;
namespace StackBundle.Tasks
{
    public class TaskFailureException : Exception
    {
        public TaskFailureException(string message) : base(message)
        {
        }
    }
}
