using NUnit.Framework;
using src;

namespace Tests
{
    public class DoubleLinkedListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Append_ShouldSetHeadOnEmptyList()
        {
            var linkedListInt = new DoubleLinkedList<int>();
            linkedListInt.Append(1);

            Assert.AreEqual(1, linkedListInt.Head.Value);
        }

        [Test]
        public void Append_ShouldSetNextOnCurrentLastItemAndPreviousOnNewItem()
        {
            var linkedListInt = new DoubleLinkedList<int>();
            linkedListInt.Append(1);
            linkedListInt.Append(2);

            Assert.AreEqual(2, linkedListInt.Head.Next.Value);
            Assert.AreEqual(1, linkedListInt.Head.Next.Previous.Value);
        }

        [Test]
        public void InsertAt_ShouldPutANewNodeBetweenTwoExistingNodesAndSetPreviousOnNewAndNextNode()
        {
            var linkedListInt = new DoubleLinkedList<int>();
            linkedListInt.Append(1);
            linkedListInt.Append(3);

            linkedListInt.InsertAt(linkedListInt.Head, 2);

            Assert.AreEqual(2, linkedListInt.Head.Next.Value);
            Assert.AreEqual(1, linkedListInt.Head.Next.Previous.Value);
            Assert.AreEqual(2, linkedListInt.Head.Next.Next.Previous.Value);
        }

        [Test]
        public void Traverse_ShouldReturnMatchingNode()
        {
            var linkedListInt = new DoubleLinkedList<int>();
            linkedListInt.Append(1);
            linkedListInt.Append(2);
            linkedListInt.Append(3);

            var found = linkedListInt.Traverse((l, n) => n.Value == 2);

            Assert.AreEqual(2, found.Value);
        }

        [Test]
        public void Remove_ShouldDeleteANewNodeBetweenTwoExistingNodesAndSetTailPreviousToHead()
        {
            var linkedListInt = new DoubleLinkedList<int>();
            linkedListInt.Append(1);
            linkedListInt.Append(2);
            linkedListInt.Append(3);

            var node2 = linkedListInt.Traverse((l, n) =>  n.Value == 2);

            linkedListInt.Remove(node2);

            Assert.AreEqual(3, linkedListInt.Head.Next.Value);
            Assert.AreEqual(1, linkedListInt.Head.Next.Previous.Value);
        }
    }
}