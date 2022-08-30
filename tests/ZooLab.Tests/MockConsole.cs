using ZooLab.Console;

namespace ZooLab.Tests
{
    public class MockConsole : IConsole
    {
        public List<string> Output { get; } = new List<string>();

        public void WriteLine(string message)
        {
            Output.Add(message);
        }
    }
}
