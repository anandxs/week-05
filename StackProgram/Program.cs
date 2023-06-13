namespace StackProgram
{
	class ArrayStack<T>
	{
		private int top;
		private T[] arr;
		private int capacity;
		private int count;

		public int Top { get { return top; } }
		public int Count { get { return count; } }

        public ArrayStack()
        {
			top = -1;
			capacity = 4;
			arr = new T[capacity];
			count = 0;
        }

        public void Push(T data)
		{
			if (top == capacity - 1)
			{
				capacity *= 2;
				T[] temp = new T[capacity];
				arr.CopyTo(temp, 0);
				arr = temp;
			}

			top++;
			arr[top] = data;
			count++;
		}

		public T Peek()
		{
			if (top == -1)
				throw new InvalidOperationException();

			return arr[top];
		}

		public T Pop()
		{
			if (top == -1)
				throw new InvalidOperationException();

			T poppedValue = arr[top];
			top--;
			count--;

			return poppedValue;
		}

		public bool Contain(T value)
		{
			for (int i = top; i > -1; i--)
			{
				if (arr[i].Equals(value))
					return true;
			}

			return false;
		}

		public void Clear()
		{
			top = -1;
			count = 0;
		}

		public void Print()
		{
			if (count == 0)
				throw new InvalidOperationException();

			int currIndex = top;

			while (currIndex > -1)
			{
				Console.Write(arr[currIndex--] + " ");
            }
		}
	}

	class Node<T>
	{
		public T Value;
		public Node<T> Next;

        public Node(T value)
        {
			this.Value = value;
			this.Next = null;
        }
    }

	class LinkedListStack<T>
	{
		private Node<T>? head;
		private Node<T>? tail;
		private int count;

		public int Count { get { return count;  } }

        public LinkedListStack()
        {
			head = tail = null;
			count = 0;
        }

		public void Push(T data)
		{
			Node<T> newNode = new Node<T>(data);

			if (head == null)
				head = tail = newNode;
			else
			{
				tail.Next = newNode;
				tail = newNode;
			}

			count++;
		}

		public T Peek()
		{
			if (head == null)
				throw new InvalidOperationException();

			return tail.Value;
		}

		public T Pop()
		{
			if (head == null)
				throw new InvalidOperationException();

			T popValue = tail.Value;

			Node<T> curr = head;

			while (curr.Next != tail)
			{
				curr = curr.Next;
			}

			curr.Next = null;
			tail = curr;
			count--;

			return popValue;
		}

		public void Print()
		{
			PrintHelper(head);
        }

		private void PrintHelper(Node<T>? node)
		{
			if (node == null)
				return;
			
			if (node.Next == null)
                Console.WriteLine(node.Value + " ");
			else
			{
				PrintHelper(node.Next);
                Console.WriteLine(node.Value + " ");
			}
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
        }
	}
}