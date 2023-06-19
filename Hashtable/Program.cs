using System.ComponentModel.DataAnnotations;

namespace Hashtable
{
	class Node<T>
	{
		public string Key { get; set; }
		public T Value { get; set; }
		public Node<T> Next { get; set; }

        public Node(string key, T value)
        {
			Key = key;
			Value = value;
		}
    }

	class HashTable<T>
	{
		private Node<T>[] buckets;
		private int count;

		public int Count { get { return count; } }

        public HashTable(int size = 5)
        {
			buckets = new Node<T>[size];
			count = 0;
        }

		private int HashCode(string key)
		{
			int num = 0;

			for (int i = 0; i < key.Length; i++)
			{
				num += (int)key[i]; 
			}

			return (num * 13) % buckets.Length;
		}

		public void Put(string key, T value)
		{
			var node = new Node<T>(key, value);
			int position = HashCode(key);

			if (buckets[position] == null)
			{
				buckets[position] = node;
			}
			else
			{
				var temp = buckets[position];

				while (true)
				{
					if (temp.Key == key)
					{
						temp.Value = value;
						break;
					}
					else if (temp.Next == null)
					{
						temp.Next = node;
						break;
					}
					else
					{
						temp = temp.Next;
					}
				}
			}

			count++;
		}

		public T Get(string key)
		{
			int position = HashCode(key);
			Node<T> bucket = buckets[position];

			if (bucket == null)
				throw new ArgumentException("Key does not exist");
			else
			{
				var temp = bucket;

				while (temp != null)
				{
					if (key == temp.Key)
						return temp.Value;
					else
						temp = temp.Next;
				}

				throw new ArgumentException("Key does not exist");
			}
		}

		public void Remove(string key)
		{
			int position = HashCode(key);
			var bucket = buckets[position];

			if (bucket == null)
				throw new ArgumentException("Key does not exist");
			else
			{
				if (bucket.Key == key)
				{
					buckets[position] = buckets[position].Next;
				}
				else
				{
					Node<T>? prev = null;

					while(bucket != null)
					{
						if (bucket.Key == key)
						{
							prev.Next = bucket.Next;
							bucket.Next = null;
						}

						prev = bucket;
						bucket = bucket.Next;
					}
				}
			}

			count--;
		}

		public bool ContainsKey(string key)
		{
			int position = HashCode(key);
			var bucket = buckets[position];

			if (bucket == null)
				return false;
			else
			{
				while(bucket != null)
				{
					if (bucket.Key == key)
						return true;
					bucket = bucket.Next;
				}
				return false;
			}
		}

		public void Print()
		{
            Console.WriteLine($"{"Key", -10}{"Value", -6}");

			foreach (var bucket in buckets)
			{
				if (bucket == null)
					continue;

				var curr = bucket;
                while (curr != null)
				{
					Console.WriteLine($"{curr.Key, -10}{curr.Value, -6}");
					curr = curr.Next;
				}
			}
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			var t = new HashTable<int>();
			t.Put("HI", 1);
			t.Put("HI", 123423);
			t.Put("HIasdfsa", 1);
			t.Put("HIsdfsdf", 1);
			t.Print();
		}
	}
}