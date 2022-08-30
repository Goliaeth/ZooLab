using ZooLab.Employees;

namespace ZooLab.Validators;

public class HireValidatorProvider
{
    private Zoo _zoo;
    public HireValidatorProvider(Zoo zoo)
    {
        _zoo = zoo;
    }
    public IHireValidator GetHireValidator(IEmployee employee)
    {
        switch (employee)
        {
            case ZooKeeper:
                return new ZooKeeperHireValidator(_zoo);
            case Veterinarian:
                return new VeterinarianHireValidator(_zoo);
            default:
                throw new ArgumentException("Undefined employee detected " + employee.GetType());
        }
    }
}