using ZooLab.Employees;

namespace ZooLab.Validators;

public abstract class HireValidator
{
    public abstract List<string> ValidateEmployee(IEmployee employee);
}