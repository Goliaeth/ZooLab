using ZooLab.Employees;
using ZooLab.Exceptions;

namespace ZooLab.Validators;

public class ZooKeeperHireValidator : HireValidator, IHireValidator
{
    private Zoo Zoo;
    public ZooKeeperHireValidator(Zoo zoo)
    {
        Zoo = zoo;
    }
    public override List<string> ValidateEmployee(IEmployee employee)
    {
        if (employee is ZooKeeper zooKeeper)
        {
            var errors = new List<string>();
            foreach (var enclosure in Zoo.Enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    if (!zooKeeper.HasAnimalExperience(animal))
                    {
                        errors.Add("ZooKeeper " + zooKeeper.LastName + " has no experience with animal " + animal.Id);
                    }
                }
            }

            return errors;
        }
        throw new ArgumentException();

    }
}