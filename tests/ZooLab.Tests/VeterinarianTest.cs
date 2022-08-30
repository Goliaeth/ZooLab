using ZooLab.Animals.Birds;
using ZooLab.Animals.Mammals;
using ZooLab.Employees;
using ZooLab.Exceptions;
using ZooLab.Test;

public class VeterinarianTest
{
    private ZooTestFixture zooTestFixture = new ZooTestFixture();
    [Fact]
    public void ShouldBeAbleToCreateVeterinarian()
    {
        Veterinarian veterinarian = new Veterinarian("", "");
    }

    [Fact]
    public void ShouldVeterinarianBeAbleToHealAnimal()
    {
        Veterinarian veterinarian = zooTestFixture.GetVeterinarianWithExperience();
        Parrot parrot = new Parrot(isSick: true);

        veterinarian.HealAnimal(parrot);

        Assert.False(parrot.IsSick);
    }

    [Fact]
    public void ShouldVeterinarianNotBeAbleToHealAnimalWithoutExperience()
    {
        Veterinarian veterinarian = zooTestFixture.GetVeterinarian();
        Parrot parrot = new Parrot(isSick: true);

        Assert.Throws<NoNeededExperienceException>(() => veterinarian.HealAnimal(parrot));
    }

    [Fact]
    public void ShouldVeterinarianBeAbleToAddAnimalExperience()
    {
        Veterinarian veterinarian = zooTestFixture.GetVeterinarian();
        Lion lion = new Lion(isSick: true);

        Assert.Throws<NoNeededExperienceException>(() => veterinarian.HealAnimal(lion));

        veterinarian.AddAnimalExperience(lion.Type);

        Assert.True(veterinarian.HealAnimal(lion));
    }

    [Fact]
    public void ShouldVeterinarianNotHealHealthyAnimal()
    {
        Veterinarian veterinarian = zooTestFixture.GetVeterinarian();
        Lion lion = new Lion(isSick: false);

        Assert.False(veterinarian.HealAnimal(lion));
    }
}