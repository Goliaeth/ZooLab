using ZooLab;
using ZooLab.Console;
using ZooLab.Employees;
using ZooLab.Test;
using ZooLab.Validators;

public class VeterinarianHireValidatorTest
{
    private ZooTestFixture zooTestFixture = new();

    [Fact]
    public void ShouldBeAbleToHireUsingVeterinarianHireValidator()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        zoo.HireEmployee(zooTestFixture.GetVeterinarian());
    }

    class UndefinedEmployee : IEmployee
    {
        public string FirstName { get; set; } = "FirstName";
        public string LastName { get; set; } = "LastName";
        public IConsole Console { get; set; } = new DefaultConsole();
    }

    [Fact]
    public void ShouldBeAbleToValidateVeterinarian()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        HireValidatorProvider hireValidatorProvider = new(zoo);
        UndefinedEmployee undefinedEmployee = new UndefinedEmployee();
        IHireValidator veterinarianHireValidator =
            hireValidatorProvider.GetHireValidator(zooTestFixture.GetVeterinarian());

        Assert.Empty(veterinarianHireValidator.ValidateEmployee(zooTestFixture.GetVeterinarian()));
    }

    [Fact]
    public void ShouldNotBeAbleToValidateUndefinedEmployeeUsingVeterinarianHireValidator()
    {
        Zoo zoo = zooTestFixture.GetZoo();
        HireValidatorProvider hireValidatorProvider = new(zoo);
        UndefinedEmployee undefinedEmployee = new UndefinedEmployee();
        IHireValidator veterinarianHireValidator =
            hireValidatorProvider.GetHireValidator(zooTestFixture.GetVeterinarian());

        Assert.Throws<ArgumentException>(() => veterinarianHireValidator.ValidateEmployee(undefinedEmployee));
    }
}