using ZooLab.Animals.Mammals;
using ZooLab.Enclosures;
using ZooLab.Exceptions;
using ZooLab.Test;

public class EnclosureTest
{
    EnclosureTestFixture enclosureFixture = new EnclosureTestFixture();

    [Fact]
    public void ShouldBeAbleToCreateEnclosure()
    {
        Enclosure enclosure = enclosureFixture.GetEnclosure();
    }

    [Fact]
    public void ShouldBeAbleToCreateEnclosureWithAnimals()
    {
        Enclosure enclosure = enclosureFixture.GetEnclosureWithAnimals();
        Assert.NotEmpty(enclosure.Animals);
    }

    [Fact]
    public void ShouldNotBeAbleToAddAnimalInEnclosureWithoutEnoughSpace()
    {
        Enclosure enclosure = enclosureFixture.GetCustomEnclosure(1000);
        enclosure.AddAnimal(new Elephant());
        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(new Elephant()));
    }

    [Fact]
    public void ShouldNotBeAbleToAddAnimalInEnclosureWithNotFriendlyAnimals()
    {
        Enclosure enclosure = enclosureFixture.GetEnclosure();
        enclosure.AddAnimal(new Elephant());
        Assert.Throws<NotFriendlyAnimalException>(() => enclosure.AddAnimal(new Lion()));
    }
}