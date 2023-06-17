namespace QuickSortProgram
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 5, 4, 3, 2, 1 };

			QuickSort(arr, 0, arr.Length - 1);

			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + " ");
            }
		}

		private static void QuickSort(int[] arr, int l, int h)
		{
			if (l < h)
			{
				int p = Partition(arr, l, h);

				QuickSort(arr, l, p - 1);
				QuickSort(arr, p + 1, h);
			}
		}

		private static int Partition(int[] arr, int l, int h)
		{
			int pivot = arr[h];
			int i = l - 1;

			for (int j = l; j < h; j++)
			{
				if (arr[j] < pivot)
				{
					i++;
					Swap(arr, i, j);
				}
			}

			Swap(arr, i + 1, h);
			return i + 1;
		}

		private static void Swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}
}