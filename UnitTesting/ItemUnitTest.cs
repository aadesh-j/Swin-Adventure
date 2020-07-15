using Task5_1;
using NUnit.Framework;


namespace Iteration2
{
    public class ItemUnitTest
    {
        private Item item = null;


        [SetUp]
        public void Setup()
        {
            item = new Item(new string[] { "sword", "item" }, "bronze sword", "bronze sword description");
        }


        [Test]
        public void TestItemIsIdentifiable()
        {
            //true
            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsTrue(item.AreYou("item"));
            //false
            Assert.IsFalse(item.AreYou("notme"));
        }


        [Test]
        public void TestShortDescription()
        {
            string shortDescription = item.ShortDescription;
            Assert.AreEqual(shortDescription, "bronze sword (sword)");
            Assert.AreNotEqual(shortDescription, "bronze swords (sword)");

        }


        [Test]
        public void TestFullDescription()
        {
            string fullDescription = item.FullDescription;
            Assert.AreEqual(fullDescription, "bronze sword description");
            Assert.AreNotEqual(fullDescription, "bronze swords description");
        }

    }
}