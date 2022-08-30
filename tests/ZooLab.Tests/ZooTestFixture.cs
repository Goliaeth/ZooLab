using ZooLab;
using ZooLab.Animals;
using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Animals.Reptiles;
using ZooLab.Employees;
using ZooLab.Enclosures;

public class ZooTestFixture
{
    internal Zoo GetZoo()
    {
        return new Zoo("Location");
    }

    internal List<Animal> GetAnimalsList()
    {
        return new List<Animal> { new Bison(), new Elephant(), new Parrot(), new Turtle() };
    }

    internal List<ZooLab.Animals.Animals> GetAnimalsTypesList()
    {
        return new List<ZooLab.Animals.Animals> { ZooLab.Animals.Animals.Bison, ZooLab.Animals.Animals.Elephant, ZooLab.Animals.Animals.Parrot, ZooLab.Animals.Animals.Turtle };
    }

    internal Enclosure GetEnclosure(Zoo zoo)
    {
        return new Enclosure("New enclosure", zoo, 9999);
    }

    internal Enclosure GetEnclosureWithAnimals(Zoo zoo)
    {
        var animals = GetAnimalsList();
        return new Enclosure("New enclosure", animals, zoo, 10);
    }

    internal ZooKeeper GetZooKeeper()
    {
        return new ZooKeeper("FirstName", "LastName");
    }
    internal Veterinarian GetVeterinarian()
    {
        return new Veterinarian("FirstName", "LastName");
    }

    internal Veterinarian GetVeterinarianWithExperience()
    {
        return new Veterinarian("FirstName", "LastName", GetAnimalsTypesList());
    }

    internal ZooKeeper GetZooKeeperWithExperience()
    {
        return new ZooKeeper("FirstName", "LastName", GetAnimalsTypesList());
    }

    internal List<Animal> GetAllAnimalsFromZoo(Zoo zoo)
    {
        var list = new List<Animal>();
        foreach (var zooEnclosure in zoo.Enclosures)
        {
            foreach (var zooEnclosureAnimal in zooEnclosure.Animals)
            {
                list.Add(zooEnclosureAnimal);
            }
        }
        return list;
    }


}