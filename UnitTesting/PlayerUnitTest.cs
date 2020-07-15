using NUnit.Framework;
using Task5_1;


namespace Iteration2
{
    public class PlayerUnitTests
    {
        private Player player = null;
        Item sword = new Item(new string[] { "sword" }, "bronze sword", "bronze sword description");
        Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel description");
        Item laptop = new Item(new string[] { "laptop" }, "small computer", "laptop description");

        [SetUp]
        public void Setup()
        {
            player = new Player("Fred", "Mighty Programmer");
            player.AddIdentifier("me");
            player.AddIdentifier("inventory");

            player.Inventory.Put(sword);
            player.Inventory.Put(shovel);
            player.Inventory.Put(laptop);

        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {

            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));


            Assert.IsFalse(player.AreYou("notme"));
        }


        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.AreEqual(sword, player.Locate("sword"));
            Assert.AreEqual(shovel, player.Locate("shovel"));
            Assert.AreEqual(laptop, player.Locate("laptop"));

        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.AreEqual(player, player.Locate("me"));
            Assert.AreEqual(player, player.Locate("inventory"));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.IsNull(player.Locate("notme"));
            Assert.IsNotNull(player.Locate("sword"));
        }


        [Test]
        public void TestPlayerFullDescription()
        {
            string text = player.FullDescription;
            string expected = "You are Fred the Mighty Programmer\n";
            expected += "You are carrying:\n\tbronze sword (sword)\n\tshovel (shovel)\n\tsmall computer (laptop)\n";
            Assert.AreEqual(text, expected);
        }

    }
}