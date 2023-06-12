namespace StackProgram
{
	class Stack<T>
	{
		private int top;
		private T[] arr;
		private int capacity;
		private int count;

		public int Top { get { return top; } }
		public int Count { get { return count; } }

        public Stack()
        {
			capacity = 4;
			top = -1;
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

		public void Print()
		{
			int currIndex = top;

			while (currIndex > -1)
			{
				Console.Write(arr[currIndex--] + " ");
            }
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> s = new Stack<int>();
            Console.WriteLine(s.Contain(1));
			s.Push(1);
			s.Push(10);
			Console.WriteLine(s.Contain(2));
        }
	}
}