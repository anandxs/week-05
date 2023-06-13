using System.Globalization;

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
		public T Value { get; set; }
		public Node<T> Next { get; set; }

		public Node(T value)
        {
			this.Value = value;
			this.Next = null;
        }
    }

	class LinkedListStack<T>
	{
		private Node<T>? top;
		private int count;

		public int Count { get { return count;  } }

        public LinkedListStack()
        {
			top = null;
			count = 0;
        }

		public void Push(T data)
		{
			Node<T> newNode = new Node<T>(data);

			if (top == null)
				top = newNode;
			else
			{
				newNode.Next = top;
				top = newNode;
			}

			count++;
		}

		public T Peek()
		{
			if (top == null)
				throw new InvalidOperationException();

			return top.Value;
		}

		public T Pop()
		{
			if (top == null)
				throw new InvalidOperationException();

			T pop = top.Value;

			Node<T> temp = top;
			top = top.Next;
			temp.Next = null;
			
			count--;

			return pop;
		}

		public bool Contain(T checkVal)
		{
			var curr = top;

			while (curr != null)
			{
				if (curr.Value.Equals(checkVal))
					return true;

				curr = curr.Next;
			}

			return false;
		}

		public void Clear()
		{
			while (top != null)
			{
				Pop();
			}
		}

		public void Print()
		{
			if (count == 0)
				throw new InvalidOperationException();

			Node<T> curr = top;

			while (curr != null)
			{
                Console.WriteLine(curr.Value);
				curr = curr.Next;
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