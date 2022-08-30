using ZooLab.Animals.Mammals;
using ZooLab.Enclosures;
using ZooLab.Exceptions;

public class LionTest
{

    EnclosureTestFixture enclosureTestFixture = new();

    [Fact]
    public void ShouldBeAbleToCreateLion()
    {
        Lion lion = new Lion();
    }

    [Fact]
    public void ShouldBeAbleToCreateSickLion()
    {
        Lion lion = new Lion(isSick: true);
    }

    [Fact]
    public void ShouldBeAbleToFeedLion()
    {
        Lion lion = new Lion();
        lion.Feed(lion.FavouriteFood[0]);
    }

    [Fact]
    public void ShouldBeFriendlyWithLionType()
    {
        Lion lion = new Lion();

        Assert.Contains(lion.Type, lion.FriendlyAnimals);
        Assert.True(lion.IsFriendlyWithAnimal(lion));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Turtle)]
    [InlineData(ZooLab.Animals.Animals.Penguin)]
    [InlineData(ZooLab.Animals.Animals.Snake)]
    [InlineData(ZooLab.Animals.Animals.Bison)]
    [InlineData(ZooLab.Animals.Animals.Elephant)]
    [InlineData(ZooLab.Animals.Animals.Parrot)]
    public void ShouldLionNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Lion lion = new Lion();

        Assert.DoesNotContain(animalType, lion.FriendlyAnimals);
    }

    [Fact]
    public void ShouldLionFitEnclosure()
    {
        Lion lion = new Lion();

        Enclosure enclosure = enclosureTestFixture.GetCustomEnclosure(squareFeet: 1000);

        enclosure.AddAnimal(lion);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(lion));
    }
}