using ZooLab.Animals.Birds;
using ZooLab.Enclosures;
using ZooLab.Exceptions;

public class ParrotTest
{

    EnclosureTestFixture enclosureTestFixture = new();
    [Fact]
    public void ShouldBeAbleToCreateParrot()
    {
        Parrot parrot = new Parrot();
    }

    [Fact]
    public void ShouldBeAbleToCreateSickParrot()
    {
        Parrot parrot = new Parrot(isSick: true);
    }

    [Fact]
    public void ShouldBeAbleToFeedParrot()
    {
        Parrot parrot = new Parrot();
        parrot.Feed(parrot.FavouriteFood[0]);
    }

    [Fact]
    public void ShouldBeFriendlyWithParrotType()
    {
        Parrot parrot = new Parrot();

        Assert.Contains(parrot.Type, parrot.FriendlyAnimals);
        Assert.True(parrot.IsFriendlyWithAnimal(parrot));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Bison)]
    [InlineData(ZooLab.Animals.Animals.Elephant)]
    [InlineData(ZooLab.Animals.Animals.Turtle)]
    public void ShouldParrotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Parrot parrot = new Parrot();

        Assert.Contains(animalType, parrot.FriendlyAnimals);
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Lion)]
    [InlineData(ZooLab.Animals.Animals.Penguin)]
    [InlineData(ZooLab.Animals.Animals.Snake)]
    public void ShouldParrotNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Parrot parrot = new Parrot();

        Assert.DoesNotContain(animalType, parrot.FriendlyAnimals);
    }

    [Fact]
    public void ShouldParrotFitEnclosure()
    {
        Parrot parrot = new Parrot();

        Enclosure enclosure = enclosureTestFixture.GetCustomEnclosure(squareFeet: 5);

        enclosure.AddAnimal(parrot);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(parrot));
    }
}