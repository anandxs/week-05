namespace SelectionSortProgram
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 5, 4, 3, 2, 1 };

			SelectionSort(arr);

			foreach (int num in arr)
			{
                Console.Write(num + " ");
            }
		}

		private static void SelectionSort(int[] arr)
		{
			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (arr[i] > arr[j])
					{
						Swap(arr, i, j);
					}
				}
			}
		}

		private static void Swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}
}