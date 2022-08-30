using ZooLab.Animals;
using ZooLab.Console;
using ZooLab.Exceptions;

namespace ZooLab.Employees;

public class Veterinarian : IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public IConsole Console { get; set; } = new DefaultConsole();

    public List<Animals.Animals> AnimalExperiences { get; private set; }

    public Veterinarian(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = new List<Animals.Animals>();
    }

    public Veterinarian(string firstName, string lastName, List<Animals.Animals> animalExperiences)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = animalExperiences;
    }

    public void AddAnimalExperience(Animals.Animals animalType)
    {
        AnimalExperiences.Add(animalType);

        Console.WriteLine("Veterinarian " + FirstName + " " + LastName + " gained new experience with " + animalType);
    }

    public bool HasAnimalExperience(Animal animal)
    {
        return AnimalExperiences.Any(a => a == animal.Type);
    }
    public bool HealAnimal(Animal animal)
    {
        if (animal.IsSick && animal.NeededMedicine.Count > 0)
        {
            if (HasAnimalExperience(animal))
            {
                animal.Heal(animal.NeededMedicine[0]);

                Console.WriteLine(animal + " was healed by " + this);
                return true;
            }
            else
            {
                throw new NoNeededExperienceException();
            }
        }
        return false;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}