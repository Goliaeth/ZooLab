using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals
{
    public abstract class Animal
    {
        private static int _currentId = 1;
        public int Id { get; }

        public bool IsSick { get; set; }

        public List<int> FeedSchedule { get; private set; } = new() { 10, 18 };

        public List<FeedTime> FeedTimes { get; } = new();

        public abstract List<Animals> FriendlyAnimals { get; }

        public abstract List<Food> FavouriteFood { get; }

        public abstract List<Medicine> NeededMedicine { get; set; }

        public abstract int RequiredSpaceSqFt { get; }

        public virtual bool IsFriendlyWithAnimal(Animal animal)
        {
            if (FriendlyAnimals.Contains(animal.Type))
            {
                return true;
            }
            return false;
        }

        public abstract Animals Type { get; }

        public void Feed(Food food) { }

        public void AddFeedSchedule(List<int> hours)
        {
            FeedSchedule = hours;
        }

        public void Heal(Medicine medicine)
        {
            IsSick = false;
            NeededMedicine.Clear();
        }

        protected Animal()
        {
            Id = _currentId;
            _currentId++;
        }

        public override string ToString()
        {
            return Type + " #" + Id;
        }
    }
}

