using ZooLab.Console;

namespace ZooLab.Employees;

public interface IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public IConsole Console { get; set; }
}