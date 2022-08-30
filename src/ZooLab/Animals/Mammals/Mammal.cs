namespace ZooLab.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal() { }

        protected Mammal(bool isSick)
        {
            IsSick = isSick;
        }

    }
}