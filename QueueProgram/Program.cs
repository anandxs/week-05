namespace QueueProgram
{
	class Node<T>
	{
		public T Value { get; set; }
		public Node<T>? Next { get; set; }

		public Node(T value)
        {
			Value = value;
			Next = null;
        }
    }

	class LinkedListQueue<T>
	{
		private Node<T>? front;
		private Node<T>? end;
		private int count;

		public int Count { get { return count; } }

		public LinkedListQueue()
        {
			front = end = null;
			count = 0;
        }

		public void Enqueue(T data)
		{
			Node<T> newNode = new Node<T>(data);

			if (end == null)
				front = end = newNode;
			else
			{
				end.Next = newNode;
				end = newNode;
			}

			count++;
		}

		public T Dequeue()
		{
			if (front == null)
				throw new InvalidOperationException();

			T pop = front.Value;

			if (front.Next == null)
				front = end = null;
			else
			{
				Node<T> temp = front;
				front = front.Next;
				temp.Next = null;
			}

			count--;

			return pop;
		}

		public T Peek()
		{
			if (front == null)
				throw new InvalidOperationException("Empty queue");

			return front.Value;
		}

		public bool Contain(T data)
		{
			var curr = front;

			while(curr != null)
			{
				if (curr.Value.Equals(data))
					return true;

				curr = curr.Next;
			}

			return false;
		}

		public void Clear()
		{
			while (front != null)
			{
				Dequeue();
			}
		}

		public void Print()
		{
			if (count == 0)
				throw new InvalidOperationException();

            Node<T> curr = front;

			while (curr != null)
			{
                Console.Write(curr.Value + " ");
				curr = curr.Next;
            }
		}
    }

	class ArrayQueue<T>
	{
		private int front;
		private int rear;
		private int count;
		private T[] arr;
		private int capacity;

		public int Count { get { return count; } }

        public ArrayQueue()
        {
			front = rear = -1;
			count = 0;
			capacity = 4;
			arr = new T[capacity];
        }

		public void Enqueue(T data)
		{
			if (rear == capacity - 1)
				throw new InvalidOperationException("Queue full");

			if (rear == -1)
			{
				front = 0;
			}

			rear++;
			arr[rear] = data;
			count++;
		}

		public void Print()
		{
			for (int i = front; i <= rear; i++)
			{
				Console.Write(arr[i] + " ");
            }
		}
    }

	internal class Program
	{
		static void Main(string[] args)
		{
			var q = new ArrayQueue<int>();
			q.Enqueue(1);
			q.Enqueue(2);
			q.Enqueue(3);
			q.Enqueue(4);
			q.Print();
			q.Enqueue(1);
		}
	}
}