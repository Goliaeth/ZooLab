using ZooLab;
using ZooLab.Animals;
using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Animals.Reptiles;
using ZooLab.Console;
using ZooLab.Employees;
using ZooLab.Enclosures;

class Program
{
    static void Main(string[] args)
    {
        ZooCorp zooCorp = new ZooCorp();
        zooCorp.Run(new DefaultConsole());
    }
}

public class ZooCorp
{
    public void Run(IConsole console)
    {
        ZooApp zooApp = new ZooApp();
        zooApp.Console = console;

        Zoo zoo1 = new Zoo("New York");
        zoo1.Console = console;
        Zoo zoo2 = new Zoo("California");
        zoo2.Console = console;

        zooApp.AddZoo(zoo1);
        zooApp.AddZoo(zoo2);

        for (int i = 0; i < 5; i++)
        {
            var enclosure1 = new Enclosure("#" + (i + 1), zoo1, 2000);
            enclosure1.Console = console;
            var enclosure2 = new Enclosure("#" + (i + 8), zoo2, 2000);
            enclosure2.Console = console;

            zoo1.AddEnclosure(enclosure1);
            zoo2.AddEnclosure(enclosure2);
        }

        var animals1 = new List<Animal>()
            { new Parrot(isSick: true), new Bison(isSick: true), new Elephant(isSick: true), new Lion(isSick: true), new Turtle(isSick: true), new Snake(isSick: true), new Penguin(isSick: true) };
        var animals2 = new List<Animal>()
            { new Parrot(isSick: true), new Bison(isSick: true), new Elephant(isSick: true), new Lion(isSick: true), new Turtle(isSick: true), new Snake(isSick: true), new Penguin(isSick: true) };

        foreach (var animal in animals1)
        {
            zoo1.FindAvailableEnclosure(animal).AddAnimal(animal);
        }
        foreach (var animal in animals2)
        {
            zoo2.FindAvailableEnclosure(animal).AddAnimal(animal);
        }

        var animalExperiences = new List<Animals>();
        foreach (var animal in animals1)
        {
            animalExperiences.Add(animal.Type);
        }

        var employees1 = new List<IEmployee>()
        {
            new Veterinarian("Veterinarian", "#1", animalExperiences),
            new Veterinarian("Veterinarian", "#2", animalExperiences) ,
            new ZooKeeper("ZooKeeper", "#3", animalExperiences) ,
            new ZooKeeper("ZooKeeper", "#4", animalExperiences) ,
        };
        var employees2 = new List<IEmployee>()
        {
            new Veterinarian("Veterinarian", "#5", animalExperiences),
            new Veterinarian("Veterinarian", "#6", animalExperiences) ,
            new ZooKeeper("ZooKeeper", "#7", animalExperiences) ,
            new ZooKeeper("ZooKeeper", "#8", animalExperiences) ,
        };

        foreach (var employee in employees1)
        {
            employee.Console = console;
            zoo1.HireEmployee(employee);
        }
        foreach (var employee in employees2)
        {
            employee.Console = console;
            zoo2.HireEmployee(employee);
        }

        zoo1.FeedAnimals();
        zoo1.HealAnimals();

        zoo2.FeedAnimals();
        zoo2.HealAnimals();

    }
}