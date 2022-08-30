using ZooLab.Animals.Foods;
using ZooLab.Animals.Medicines;

namespace ZooLab.Animals.Reptiles
{
    public abstract class Reptile : Animal
    {
        protected Reptile() { }
        protected Reptile(bool isSick)
        {
            IsSick = isSick;
        }
    }
}