using System;
using NUnit.Framework;
using src;

namespace Tests
{
    public class StackTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Push_ShouldIncrementCount()
        {
            var stack = new Stack<string>();
            stack.Push("hello");

            Assert.AreEqual(1, stack.Count);
        }
        
        [Test]
        public void Pop_ShouldDecrementCountAndReturnItem()
        {
            var stack = new Stack<string>();
            stack.Push("hello");
            
            var result = stack.Pop();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual("hello", result);
        }
        
        [Test]        
        public void Pop_ShouldReturnNullWhenStackIsEmpty()
        {
            var stack = new Stack<string>();

            var result = stack.Pop();

            Assert.AreEqual(null, result);
        }

        [Test]
        public void Peek_ShouldReturnItemAndNotDecrementCount()
        {
            var stack = new Stack<string>();
            stack.Push("hello");

            var result = stack.Peek();

            Assert.AreEqual("hello", result);
            Assert.AreEqual(1, stack.Count);
        }
    }
}