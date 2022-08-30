using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Birds
{
    public class Parrot : Bird
    {
        public override List<Animals> FriendlyAnimals => new() { Animals.Parrot, Animals.Bison, Animals.Elephant, Animals.Turtle };
        public override List<Food> FavouriteFood => new() { new Grass(), new Vegetable() };
        public override int RequiredSpaceSqFt => 5;
        public override Animals Type => Animals.Parrot;
        public override List<Medicine> NeededMedicine { get; set; } = new List<Medicine>();


        public Parrot()
        {
        }
        public Parrot(bool isSick) : base(isSick)
        {
            IsSick = isSick;
            if (IsSick)
                NeededMedicine.Add(new AntiDepression());
        }

    }
}