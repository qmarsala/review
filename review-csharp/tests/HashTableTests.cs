using NUnit.Framework;
using src;

namespace Tests
{
    public class HashTableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_ShouldIncrementCount()
        {
            var hashTable = new HashTable<string>();
            hashTable.Add("hello, world!");

            Assert.AreEqual(1, hashTable.Count);
        }


        [Test]
        public void Remove_ShouldDecrementCount()
        {
            var hashTable = new HashTable<string>();
            hashTable.Add("hello, world!");

            Assert.AreEqual(1, hashTable.Count);
        }

        [Test]
        public void Contains_ShouldReturnTrueAfterItemIsAddedAndReturnFalseAfterItemIsRemoved()
        {
            var hashTable = new HashTable<string>();
            var value = "hello, world!";
            
            hashTable.Add(value);
            Assert.IsTrue(hashTable.Contains(value));

            hashTable.Remove(value);
            Assert.IsFalse(hashTable.Contains(value));
        }

        [Test]
        public void Contains_ShouldReturnFalseWhenItemIsNotInList()
        {
            var hashTable = new HashTable<string>();
            var value = "hello, world!";

            Assert.IsFalse(hashTable.Contains(value));
        }


        [Test]
        public void Contains_ShouldReturnTrueWhenItemIsInList()
        {
            var hashTable = new HashTable<string>();
            var value = "hello, world!";
            hashTable.Add(value);

            Assert.IsTrue(hashTable.Contains(value));
        }
    }
}