using ZooLab.Employees;

namespace ZooLab.Validators
{
    public interface IHireValidator
    {
        public List<string> ValidateEmployee(IEmployee employee);
    }
}
