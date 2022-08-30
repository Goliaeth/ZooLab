namespace ZooLab.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird() { }

        protected Bird(bool isSick)
        {
            IsSick = isSick;
        }

    }
}