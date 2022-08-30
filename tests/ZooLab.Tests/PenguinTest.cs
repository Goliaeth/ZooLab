
using ZooLab.Animals.Birds;
using ZooLab.Enclosures;
using ZooLab.Exceptions;

public class PenguinTest
{
    EnclosureTestFixture enclosureTestFixture = new();

    [Fact]
    public void ShouldBeAbleToCreatePenguin()
    {
        Penguin penguin = new Penguin();
    }

    [Fact]
    public void ShouldBeAbleToCreateSickPenguin()
    {
        Penguin penguin = new Penguin(isSick: true);
    }

    [Fact]
    public void ShouldBeAbleToFeedPenguin()
    {
        Penguin penguin = new Penguin();
        penguin.Feed(penguin.FavouriteFood[0]);
    }

    [Fact]
    public void ShouldPenguinBeFriendlyWithPenguinType()
    {
        Penguin penguin = new Penguin();

        Assert.Contains(penguin.Type, penguin.FriendlyAnimals);
        Assert.True(penguin.IsFriendlyWithAnimal(penguin));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Lion)]
    [InlineData(ZooLab.Animals.Animals.Parrot)]
    [InlineData(ZooLab.Animals.Animals.Snake)]
    [InlineData(ZooLab.Animals.Animals.Bison)]
    [InlineData(ZooLab.Animals.Animals.Elephant)]
    [InlineData(ZooLab.Animals.Animals.Turtle)]
    public void ShouldPenguinNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Penguin penguin = new Penguin();

        Assert.DoesNotContain(animalType, penguin.FriendlyAnimals);
    }

    [Fact]
    public void ShouldPenguinFitEnclosure()
    {
        Penguin penguin = new Penguin();

        Enclosure enclosure = enclosureTestFixture.GetCustomEnclosure(squareFeet: 10);

        enclosure.AddAnimal(penguin);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(penguin));
    }
}