using ZooLab.Employees;

namespace ZooLab.Animals
{
    public class FeedTime
    {
        public DateTime Time { get; }

        public ZooKeeper FeedBy { get; }

        public FeedTime(DateTime feedTime, ZooKeeper zooKeeper)
        {
            Time = feedTime;
            FeedBy = zooKeeper;
        }
    }
}