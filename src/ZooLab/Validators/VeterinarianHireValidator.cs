using ZooLab.Employees;
using ZooLab.Exceptions;

namespace ZooLab.Validators;

public class VeterinarianHireValidator : HireValidator, IHireValidator
{
    private Zoo Zoo;
    public VeterinarianHireValidator(Zoo zoo)
    {
        Zoo = zoo;
    }
    public override List<string> ValidateEmployee(IEmployee employee)
    {
        if (employee is Veterinarian veterinarian)
        {
            var errors = new List<string>();
            foreach (var enclosure in Zoo.Enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    if (!veterinarian.HasAnimalExperience(animal))
                    {
                        errors.Add("Veterinarian " + veterinarian.LastName + " has no experience with animal " + animal.Id);
                    }
                }
            }
            return errors;
        }
        throw new ArgumentException();

    }
}