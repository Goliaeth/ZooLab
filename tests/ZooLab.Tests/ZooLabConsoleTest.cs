using ZooLab.Console;
using ZooLab.Tests;

namespace ZooLabConsole.Test
{
    public class ZooLabConsoleTest
    {

        [Fact]
        public void ShouldBeAbleToRunZooCorp()
        {
            ZooCorp zooCorp = new ZooCorp();
            zooCorp.Run(new DefaultConsole());
        }


        [Fact]
        public void ShouldBeAbleToRunZooCorpWithConsoleMock()
        {
            MockConsole consoleMock = new MockConsole();
            ZooCorp zooCorp = new ZooCorp();
            zooCorp.Run(consoleMock);

            List<string> expectedOutput = new List<string>()
            {
                "New zoo added in zoo app.",
                "New zoo added in zoo app.",
                "New Enclosure added: #1",
                "New Enclosure added: #8",
                "New Enclosure added: #2",
                "New Enclosure added: #9",
                "New Enclosure added: #3",
                "New Enclosure added: #10",
                "New Enclosure added: #4",
                "New Enclosure added: #11",
                "New Enclosure added: #5",
                "New Enclosure added: #12",
                "New animal Parrot 1 added to enclosure #1 in zoo New York",
                "New animal Bison 2 added to enclosure #2 in zoo New York",
                "New animal Elephant 3 added to enclosure #1 in zoo New York",
                "New animal Lion 4 added to enclosure #3 in zoo New York",
                "New animal Turtle 5 added to enclosure #1 in zoo New York",
                "New animal Snake 6 added to enclosure #4 in zoo New York",
                "New animal Penguin 7 added to enclosure #5 in zoo New York",
                "New animal Parrot 8 added to enclosure #8 in zoo California",
                "New animal Bison 9 added to enclosure #9 in zoo California",
                "New animal Elephant 10 added to enclosure #8 in zoo California",
                "New animal Lion 11 added to enclosure #10 in zoo California",
                "New animal Turtle 12 added to enclosure #8 in zoo California",
                "New animal Snake 13 added to enclosure #11 in zoo California",
                "New animal Penguin 14 added to enclosure #12 in zoo California",
                "New Employee added: Veterinarian #1 in zoo New York",
                "New Employee added: Veterinarian #2 in zoo New York",
                "New Employee added: ZooKeeper #3 in zoo New York",
                "New Employee added: ZooKeeper #4 in zoo New York",
                "New Employee added: Veterinarian #5 in zoo California",
                "New Employee added: Veterinarian #6 in zoo California",
                "New Employee added: ZooKeeper #7 in zoo California",
                "New Employee added: ZooKeeper #8 in zoo California",
                "Parrot #1 was fed by ZooKeeper #3",
                "Elephant #3 was fed by ZooKeeper #4",
                "Turtle #5 was fed by ZooKeeper #3",
                "Bison #2 was fed by ZooKeeper #4",
                "Lion #4 was fed by ZooKeeper #3",
                "Snake #6 was fed by ZooKeeper #4",
                "Penguin #7 was fed by ZooKeeper #3",
                "Parrot #1 was healed by Veterinarian #1",
                "Elephant #3 was healed by Veterinarian #2",
                "Turtle #5 was healed by Veterinarian #1",
                "Bison #2 was healed by Veterinarian #2",
                "Lion #4 was healed by Veterinarian #1",
                "Snake #6 was healed by Veterinarian #2",
                "Penguin #7 was healed by Veterinarian #1",
                "Parrot #8 was fed by ZooKeeper #7",
                "Elephant #10 was fed by ZooKeeper #8",
                "Turtle #12 was fed by ZooKeeper #7",
                "Bison #9 was fed by ZooKeeper #8",
                "Lion #11 was fed by ZooKeeper #7",
                "Snake #13 was fed by ZooKeeper #8",
                "Penguin #14 was fed by ZooKeeper #7",
                "Parrot #8 was healed by Veterinarian #5",
                "Elephant #10 was healed by Veterinarian #6",
                "Turtle #12 was healed by Veterinarian #5",
                "Bison #9 was healed by Veterinarian #6",
                "Lion #11 was healed by Veterinarian #5",
                "Snake #13 was healed by Veterinarian #6",
                "Penguin #14 was healed by Veterinarian #5"
            };
            Assert.Equal(expectedOutput.Count, consoleMock.Output.Count);
        }
    }
}