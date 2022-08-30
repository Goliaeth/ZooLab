using ZooLab.Animals.Reptiles;
using ZooLab.Enclosures;
using ZooLab.Exceptions;

public class TurtleTest
{

    EnclosureTestFixture enclosureTestFixture = new();

    [Fact]
    public void ShouldBeAbleToCreateTurtle()
    {
        Turtle turtle = new Turtle();
    }

    [Fact]
    public void ShouldBeAbleToCreateSickTurtle()
    {
        Turtle turtle = new Turtle(isSick: true);
    }

    [Fact]
    public void ShouldBeAbleToFeedTurtle()
    {
        Turtle turtle = new Turtle();
        turtle.Feed(turtle.FavouriteFood[0]);
    }

    [Fact]
    public void ShouldBeFriendlyWithTurtleType()
    {
        Turtle turtle = new Turtle();

        Assert.Contains(turtle.Type, turtle.FriendlyAnimals);
        Assert.True(turtle.IsFriendlyWithAnimal(turtle));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Elephant)]
    [InlineData(ZooLab.Animals.Animals.Bison)]
    [InlineData(ZooLab.Animals.Animals.Parrot)]
    public void ShouldTurtleBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Turtle turtle = new Turtle();

        Assert.Contains(animalType, turtle.FriendlyAnimals);
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Penguin)]
    [InlineData(ZooLab.Animals.Animals.Lion)]
    [InlineData(ZooLab.Animals.Animals.Snake)]
    public void ShouldTurtleNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Turtle turtle = new Turtle();

        Assert.DoesNotContain(animalType, turtle.FriendlyAnimals);
    }

    [Fact]
    public void ShouldTurtleFitEnclosure()
    {
        Turtle turtle = new Turtle();

        Enclosure enclosure = enclosureTestFixture.GetCustomEnclosure(squareFeet: 5);

        enclosure.AddAnimal(turtle);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(turtle));
    }
}