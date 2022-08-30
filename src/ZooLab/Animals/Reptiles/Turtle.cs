using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Reptiles
{
    public class Turtle : Reptile
    {
        public override List<Animals> FriendlyAnimals =>
            new() { Animals.Turtle, Animals.Parrot, Animals.Elephant, Animals.Bison };
        public override List<Food> FavouriteFood => new() { new Vegetable() };
        public override List<Medicine> NeededMedicine { get; set; } = new List<Medicine>();
        public override int RequiredSpaceSqFt => 5;
        public override Animals Type => Animals.Turtle;

        public Turtle() { }
        public Turtle(bool isSick) : base(isSick)
        {
            IsSick = isSick;
            if (IsSick)
            {
                NeededMedicine.Add(new Antibiotics());
            }
        }
    }
}