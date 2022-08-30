using ZooLab.Animals;
using ZooLab.Console;
using ZooLab.Employees;
using ZooLab.Enclosures;
using ZooLab.Exceptions;
using ZooLab.Validators;

namespace ZooLab
{
    public class Zoo
    {
        private HireValidatorProvider _hireValidatorProvider;

        public IConsole Console { get; set; } = new DefaultConsole();

        public List<Enclosure> Enclosures { get; set; }
        public List<IEmployee> Employees { get; set; }
        public string Location { get; set; }

        public Zoo(string location)
        {
            Location = location;
            _hireValidatorProvider = new HireValidatorProvider(this);
            Enclosures = new List<Enclosure>();
            Employees = new List<IEmployee>();
        }

        public void AddEnclosure(Enclosure enclosure)
        {
            Enclosures.Add(enclosure);

            Console.WriteLine("New Enclosure added: " + enclosure.Name);
        }

        public void HireEmployee(IEmployee employee)
        {
            if (_hireValidatorProvider.GetHireValidator(employee).ValidateEmployee(employee).Count == 0)
            {
                Employees.Add(employee);

                Console.WriteLine("New Employee added: " + employee.FirstName + " " + employee.LastName + " in zoo " + Location);
            }
            else
            {
                throw new NoNeededExperienceException();
            }

        }

        public Enclosure FindAvailableEnclosure(Animal animalWithoutEnclosure)
        {
            foreach (var enclosure in Enclosures)
            {
                int availableSquare = enclosure.SquareFeet;
                foreach (var animal in enclosure.Animals)
                {
                    if (animalWithoutEnclosure.IsFriendlyWithAnimal(animal))
                        availableSquare -= animal.RequiredSpaceSqFt;
                    else
                        availableSquare = -1;
                }

                if (availableSquare >= animalWithoutEnclosure.RequiredSpaceSqFt)
                {

                    return enclosure;
                }

            }

            throw new NoAvailableEnclosureException();
        }

        public void FeedAnimals()
        {
            var zooKeepers = getAllZooKeepers();
            if (zooKeepers.Count > 0)
            {
                int currentZookeeperIndex = 0;
                foreach (var enclosure in Enclosures)
                {
                    foreach (var enclosureAnimal in enclosure.Animals)
                    {
                        zooKeepers[currentZookeeperIndex].FeedAnimal(enclosureAnimal);
                        currentZookeeperIndex++;
                        if (currentZookeeperIndex >= zooKeepers.Count)
                        {
                            currentZookeeperIndex = 0;
                        }
                    }
                }
            }
        }

        public void HealAnimals()
        {
            var veterianrians = getAllVeterinarians();
            if (veterianrians.Count > 0)
            {
                int currentVeterianrianIndex = 0;
                foreach (var enclosure in Enclosures)
                {
                    foreach (var enclosureAnimal in enclosure.Animals)
                    {
                        if (enclosureAnimal.IsSick && enclosureAnimal.NeededMedicine.Count > 0)
                        {
                            veterianrians[currentVeterianrianIndex].HealAnimal(enclosureAnimal);
                            currentVeterianrianIndex++;
                            if (currentVeterianrianIndex >= veterianrians.Count)
                            {
                                currentVeterianrianIndex = 0;
                            }
                        }
                    }
                }
            }
        }

        private List<ZooKeeper> getAllZooKeepers()
        {
            var listOfZooKeepers = new List<ZooKeeper>();
            foreach (var employee in Employees)
            {
                if (employee is ZooKeeper zooKeeper)
                {
                    listOfZooKeepers.Add(zooKeeper);
                }
            }
            return listOfZooKeepers;
        }

        private List<Veterinarian> getAllVeterinarians()
        {
            var listOfVeterinarians = new List<Veterinarian>();
            foreach (var employee in Employees)
            {
                if (employee is Veterinarian veterinarian)
                {
                    listOfVeterinarians.Add(veterinarian);
                }
            }
            return listOfVeterinarians;
        }
    }
}