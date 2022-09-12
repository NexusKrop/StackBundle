using System;
namespace StackBundle
{
    public interface ITask
    {
        string GetName();
        void Run();
    }
}
