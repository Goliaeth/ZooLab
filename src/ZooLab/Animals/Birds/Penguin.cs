using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Birds
{
    public class Penguin : Bird
    {
        public override List<Animals> FriendlyAnimals => new() { Animals.Penguin };
        public override List<Food> FavouriteFood => new() { new Vegetable() };
        public override int RequiredSpaceSqFt => 10;
        public override Animals Type => Animals.Penguin;
        public override List<Medicine> NeededMedicine { get; set; } = new List<Medicine>();

        public Penguin() { }
        public Penguin(bool isSick) : base(isSick)
        {
            IsSick = isSick;
            if (isSick)
                NeededMedicine.Add(new AntiInflammatory());
        }
    }
}