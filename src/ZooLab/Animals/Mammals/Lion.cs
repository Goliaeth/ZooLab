using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Mammals
{
    public class Lion : Mammal
    {
        public override List<Animals> FriendlyAnimals => new() { Animals.Lion };
        public override List<Food> FavouriteFood => new() { new Meat() };
        public override List<Medicine> NeededMedicine { get; set; } = new List<Medicine>();
        public override int RequiredSpaceSqFt => 1000;
        public override Animals Type => Animals.Lion;
        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            if (FriendlyAnimals.Contains(animal.Type))
            {
                return true;
            }

            return false;
        }

        public Lion() { }
        public Lion(bool isSick) : base(isSick)
        {
            IsSick = isSick;
            if (IsSick)
            {
                NeededMedicine.Add(new Antibiotics());
            }
        }
    }
}