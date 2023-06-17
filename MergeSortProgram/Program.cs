﻿using System.Text.Json.Serialization;

namespace MergeSortProgram
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 5, 4, 3, 2, 1 };

			MergeSort(arr, 0, arr.Length - 1);

			foreach (int val in arr)
			{
                Console.Write(val + " ");
            }
		}

		private static void MergeSort(int[] arr, int l, int r)
		{
			if (l < r)
			{
				int m = l + (r - l) / 2;

				MergeSort(arr, l, m);
				MergeSort(arr, m + 1, r);

				Merge(arr, l, m, r);
			}
		}

		private static void Merge(int[] arr, int l, int m, int r)
		{
			int n1 = m - l + 1;
			int n2 = r - m;

			int[] left = new int[n1];
			int[] right = new int[n2];

			int i, j;
			for (i = 0; i < n1; i++)
				left[i] = arr[l + i];
			for (j = 0; j < n2; j++)
				right[j] = arr[m + 1 + j];

			i = j = 0;
			int k = l;

			while (i < n1 && j < n2)
			{
				if (left[i] <= right[j])
				{
					arr[k] = left[i];
					i++;
				}
				else
				{
					arr[k] = right[j];
					j++;
				}

				k++;
			}

			while (i < n1)
			{
				arr[k] = left[i];
				i++;
				k++;
			}

			while (j < n2)
			{
				arr[k] = right[j];
				j++;
				k++;
			}
		}
	}
}