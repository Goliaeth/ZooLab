using ZooLab.Console;

namespace ZooLab
{
    public class ZooApp
    {
        private List<Zoo> _zoos = new List<Zoo>();

        public IConsole Console { get; set; } = new DefaultConsole();

        public void AddZoo(Zoo zoo)
        {
            _zoos.Add(zoo);

            Console.WriteLine("New zoo added in zoo app.");
        }

        public List<Zoo> GetZoos()
        {
            return _zoos;
        }
    }
}