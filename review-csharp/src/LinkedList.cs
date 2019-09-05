using System;

// Values stored in non contiguous memory
// - grow and change as needed
// Each value also has a pointer to the next value
// - if double linked, then it also has a pointer to the previous value
// Downsides
// - always have to traverse the list to get the data - O(n)

namespace src
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; } = null;

        public Node<T> Traverse(Func<Node<T>, Node<T>, bool> findFn)
        {
            var current = Head;
            Node<T> last = null;
            while (current != null)
            {
                var result = findFn(last, current);
                last = current;
                current = current.Next;
                if (result) break;
            }
            return last;
        }

        public void InsertAt(Node<T> node, T value)
        {
            var next = node.Next;
            var newNode = new Node<T>(value);
            newNode.Next = next;
            node.Next = newNode;
        }

        public void Append(T value)
        {
            var newNode = new Node<T>(value);
            if (Head is null)
            {
                Head = newNode;
            }
            else
            {
                var last = Traverse((l,n) => false);
                last.Next = newNode;
            }
        }

        public void Remove(Node<T> node)
        {
            if(Head.Value.Equals(node.Value))
            {
                Head = Head.Next;
            }
            else
            {
                Traverse((l, n) => {
                    if (n.Value.Equals(node.Value)) 
                    {
                        l.Next = n.Next;
                        return true;
                    }
                    return false;
                });
            }
        }
    }

    public class Node<T>
    {
        public T Value { get; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
