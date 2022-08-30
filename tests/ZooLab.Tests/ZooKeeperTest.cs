using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Employees;
using ZooLab.Exceptions;
using ZooLab.Test;

public class ZooKeeperTest
{
    private ZooTestFixture zooTestFixture = new ZooTestFixture();

    [Fact]
    public void ShouldBeAbleToCreateZooKeeper()
    {
        ZooKeeper zooKeeper = new ZooKeeper("", "");
    }

    [Fact]
    public void ShouldZooKeeperBeAbleToFeedAnimal()
    {
        ZooKeeper zooKeeper = zooTestFixture.GetZooKeeperWithExperience();
        Parrot parrot = new Parrot();

        zooKeeper.FeedAnimal(parrot);

        Assert.Equal(zooKeeper, parrot.FeedTimes[0].FeedBy);
    }

    [Fact]
    public void ShouldZooKeeperNotBeAbleToFeedAnimalWithoutExperience()
    {
        ZooKeeper zooKeeper = zooTestFixture.GetZooKeeper();
        Parrot parrot = new Parrot();

        Assert.Throws<NoNeededExperienceException>(() => zooKeeper.FeedAnimal(parrot));
    }

    [Fact]
    public void ShouldZooKeeperBeAbleToAddAnimalExperience()
    {
        ZooKeeper zooKeeper = zooTestFixture.GetZooKeeper();
        Lion lion = new Lion();

        Assert.Throws<NoNeededExperienceException>(() => zooKeeper.FeedAnimal(lion));

        zooKeeper.AddAnimalExperience(lion.Type);

        Assert.True(zooKeeper.FeedAnimal(lion));
    }


}