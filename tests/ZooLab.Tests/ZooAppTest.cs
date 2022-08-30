namespace ZooLab.Test
{
    public class ZooAppTest
    {
        [Fact]
        public void ShouldBeAbleToCreateZooApp()
        {
            ZooApp zooApp = new ZooApp();
        }

        [Fact]
        public void ShouldBeAbleToAddZooInZooApp()
        {
            ZooApp zooApp = new ZooApp();
            zooApp.AddZoo(new Zoo(location: "Location"));
        }

        [Fact]
        public void ShouldBeAbleToGetZoosInZooApp()
        {
            ZooApp zooApp = new ZooApp();
            zooApp.AddZoo(new Zoo(location: "Location"));
            Assert.NotEmpty(zooApp.GetZoos());
        }
    }
}