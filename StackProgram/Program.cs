namespace StackProgram
{
	class Stack<T>
	{
		private int top;
		private T[] arr;
		private int capacity;

		public int Top { get { return top; } }

        public Stack()
        {
			capacity = 4;
			top = -1;
			arr = new T[capacity];
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

			return poppedValue;
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
		}
	}
}