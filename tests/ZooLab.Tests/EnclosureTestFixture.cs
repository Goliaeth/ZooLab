using ZooLab.Enclosures;
using ZooLab.Test;

public class EnclosureTestFixture
{
    ZooTestFixture zooFixture = new ZooTestFixture();
    public Enclosure GetEnclosure()
    {
        return new Enclosure("New Enclosure", zooFixture.GetZoo(), 9999);
    }

    public Enclosure GetCustomEnclosure(int squareFeet)
    {
        return new Enclosure("New Enclosure", zooFixture.GetZoo(), squareFeet);
    }

    public Enclosure GetEnclosureWithAnimals()
    {
        return new Enclosure("New Enclosure", zooFixture.GetAnimalsList(), zooFixture.GetZoo(), 9999);
    }
}