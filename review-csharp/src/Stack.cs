namespace src
{
    public class Stack<T> where T : class
    {
        public int Count { get; private set; }

        private LinkedList<T> Storage = new LinkedList<T>();

        public void Push(T value)
        {
            var newNode = new Node<T>(value, Storage.Head);
            Storage.Head = newNode;
            Count++;
        }

        public T Pop()
        {
            var value = Peek();
            if(value is null)
            {
                return default;
            }
            else
            {
                Storage.Remove(Storage.Head);
                Count--;
                return value;
            }
        }

        public T Peek()
        {
            return Storage.Head?.Value ?? default;
        }
    }
}