namespace BubbleSortProgram
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 5, 4, 2, 1, 3 };
			BubbleSort(arr);

			foreach (int num in arr)
			{
                Console.Write(num + " ");
            }
		}

		private static void BubbleSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr.Length - i - 1; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}
		}
	}
}