namespace InsertionSortProgram
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 5, 4, 3, 2, 1 };

			InsertionSort(arr);

			foreach (int num in arr)
			{
                Console.Write(num + " ");
            }
		}

		private static void InsertionSort(int[] arr)
		{
			for (int i = 1; i < arr.Length; i++)
			{
				int current = arr[i];
				int j = i - 1;

				while (j >= 0 && arr[j] > current)
				{
					arr[j + 1] = arr[j];
					j--;
				}

				arr[j + 1] = current;
			}
		}
	}
}