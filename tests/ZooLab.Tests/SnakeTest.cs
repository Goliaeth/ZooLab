using ZooLab.Animals.Reptiles;
using ZooLab.Enclosures;
using ZooLab.Exceptions;

public class SnakeTest
{

    EnclosureTestFixture enclosureTestFixture = new();

    [Fact]
    public void ShouldBeAbleToCreateSnake()
    {
        Snake snake = new Snake();
    }

    [Fact]
    public void ShouldBeAbleToCreateSickSnake()
    {
        Snake snake = new Snake(isSick: true);
    }

    [Fact]
    public void ShouldBeAbleToFeedSnake()
    {
        Snake snake = new Snake();
        snake.Feed(snake.FavouriteFood[0]);
    }

    [Fact]
    public void ShouldBeFriendlyWithSnakeType()
    {
        Snake snake = new Snake();

        Assert.Contains(snake.Type, snake.FriendlyAnimals);
        Assert.True(snake.IsFriendlyWithAnimal(snake));
    }

    [Theory]
    [InlineData(ZooLab.Animals.Animals.Penguin)]
    [InlineData(ZooLab.Animals.Animals.Elephant)]
    [InlineData(ZooLab.Animals.Animals.Lion)]
    [InlineData(ZooLab.Animals.Animals.Turtle)]
    [InlineData(ZooLab.Animals.Animals.Bison)]
    [InlineData(ZooLab.Animals.Animals.Parrot)]
    public void ShouldSnakeNotBeFriendlyWithOtherAnimals(ZooLab.Animals.Animals animalType)
    {
        Snake snake = new Snake();

        Assert.DoesNotContain(animalType, snake.FriendlyAnimals);
    }

    [Fact]
    public void ShouldSnakeFitEnclosure()
    {
        Snake snake = new Snake();

        Enclosure enclosure = enclosureTestFixture.GetCustomEnclosure(squareFeet: 2);

        enclosure.AddAnimal(snake);

        Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(snake));
    }
}