using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;


namespace Iteration2
{
    public class InventoryUnitTest
    {
        private Inventory inventory = null;

        Item sword = new Item(new string[] { "sword" }, "bronze sword", "bronze sword description");
        Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel description");
        Item laptop = new Item(new string[] { "laptop" }, "small computer", "laptop description");

        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
            inventory.Put(sword);
            inventory.Put(shovel);
            inventory.Put(laptop);
        }


        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(inventory.HasItem("sword"));
            Assert.IsTrue(inventory.HasItem("shovel"));
            Assert.IsTrue(inventory.HasItem("laptop"));
        }

        [Test]
        public void TestNoFindItem()
        { 
            Assert.IsFalse(inventory.HasItem("book"));
            Assert.IsFalse(inventory.HasItem("pencil"));
            Assert.IsFalse(inventory.HasItem("pen"));
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.AreEqual(sword, inventory.Fetch("sword"));
            Assert.IsTrue(inventory.HasItem("sword"));
            Assert.AreEqual(shovel, inventory.Fetch("shovel"));
            Assert.IsTrue(inventory.HasItem("shovel"));
            Assert.AreEqual(laptop, inventory.Fetch("laptop"));
            Assert.IsTrue(inventory.HasItem("laptop"));
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.AreEqual(sword, inventory.Take("sword"));
            Assert.IsFalse(inventory.HasItem("sword"));
            Assert.AreEqual(shovel, inventory.Take("shovel"));
            Assert.IsFalse(inventory.HasItem("shovel"));
            Assert.AreEqual(laptop, inventory.Take("laptop"));
            Assert.IsFalse(inventory.HasItem("laptop"));
        }

        [Test]
        public void TestItemList()
        {
            string items = inventory.ItemList;
            Assert.AreEqual("\tbronze sword (sword)\n" +
                            "\tshovel (shovel)\n" +
                            "\tsmall computer (laptop)\n", items);
        }
    }
}