using System.Xml;

namespace QueueProgram
{
	class Node<T>
	{
		public T Value;
		public Node<T> Next;

        public Node(T value)
        {
			Value = value;
			Next = null;
        }
    }
	class Queue<T>
	{
		private Node<T> head;
		private Node<T> tail;
		private int count;

		public int Count { get { return count; } }

		public Queue()
        {
			head = tail = null;
			count = 0;
        }

		public void Enqueue(T data)
		{
			Node<T> newNode = new Node<T>(data);

			if (tail == null)
				head = tail = newNode;
			else
			{
				tail.Next = newNode;
				tail = newNode;
			}

			count++;
		}

		public T Dequeue()
		{
			if (head == null)
				throw new InvalidOperationException();

			T pop = head.Value;

			if (head.Next == null)
				head = tail = null;
			else
			{
				Node<T> temp = head;
				head = head.Next;
				temp.Next = null;
			}

			count--;

			return pop;
		}

		public bool Contain(T data)
		{
			var curr = head;

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
			while (head != null)
			{
				Dequeue();
			}
		}

		public void Print()
		{
			if (count == 0)
				throw new InvalidOperationException();

            Node<T> curr = head;

			while (curr != null)
			{
                Console.Write(curr.Value + " ");
				curr = curr.Next;
            }
		}
    }

	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<int> q = new Queue<int>();
        }
	}
}