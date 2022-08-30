using ZooLab.Animals;
using ZooLab.Console;
using ZooLab.Exceptions;

namespace ZooLab.Employees;

public class ZooKeeper : IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IConsole Console { get; set; } = new DefaultConsole();

    public List<Animals.Animals> AnimalExperiences { get; private set; }

    public ZooKeeper(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = new List<Animals.Animals>();
    }

    public ZooKeeper(string firstName, string lastName, List<Animals.Animals> animalExperiences)
    {
        FirstName = firstName;
        LastName = lastName;
        AnimalExperiences = animalExperiences;
    }

    public void AddAnimalExperience(Animals.Animals animalType)
    {
        AnimalExperiences.Add(animalType);
    }

    public bool HasAnimalExperience(Animal animal)
    {
        return AnimalExperiences.Any(a => a == animal.Type);
    }

    public bool FeedAnimal(Animal animal)
    {
        if (animal.FavouriteFood.Count > 0 && animal.FeedTimes.Select(feedTime => feedTime.Time.Day == DateTime.Now.Day).Count() < animal.FeedSchedule.Count)
        {
            if (HasAnimalExperience(animal))
            {
                animal.Feed(animal.FavouriteFood[0]);
                animal.FeedTimes.Add(new FeedTime(DateTime.Now, this));

                Console.WriteLine(animal + " was fed by " + this);

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