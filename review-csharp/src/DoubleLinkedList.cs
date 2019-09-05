using System;

// Like a linked list, but remembers the previous node too.
// removal gets a little easier because each node remembers the previous and next node, no need to traverse to remove.

namespace src 
{
    public class DoubleLinkedList<T>
    {
        public DoubleNode<T> Head { get; private set; }

        public DoubleLinkedList()
        {
        }

        public void Append(T value)
        {
            var newNode = new DoubleNode<T>(value);
            if (Head is null) 
            {
                Head = newNode;
            }
            else
            {
                var last = Traverse((l, n) => false);
                last.Next = newNode;
                newNode.Previous = last;
            }
        }

        public void InsertAt(DoubleNode<T> node, T value)
        {
            var newNode = new DoubleNode<T>(value);
            newNode.Previous = node;
            newNode.Next = node.Next;
            if (node.Next != null) 
            {
                node.Next.Previous = newNode;
            }
            node.Next = newNode;
        }

        public void Remove(DoubleNode<T> node)
        {
            if (Head.Value.Equals(node.Value)) 
            {
                Head = Head.Next;
            }
            else
            {
                if (node.Previous != null)
                {
                    node.Previous.Next = node.Next;
                }
                if (node.Next != null)
                {
                    node.Next.Previous = node.Previous;
                }
            }
        }

        public DoubleNode<T> Traverse(Func<DoubleNode<T>, DoubleNode<T>, bool> findFn)
        {
            var current = Head;
            DoubleNode<T> previous = null;
            while (current != null) 
            {
                var result = findFn(previous, current);
                previous = current;
                current = current.Next;
                if (result) break;
            }
            return previous;
        }
    }

    public class DoubleNode<T>
    {
        public T Value { get; }
        public DoubleNode<T> Next { get; set; }
        public DoubleNode<T> Previous { get; set; }

        public DoubleNode(T value)
        {
            Value = value;
        }
    }
}