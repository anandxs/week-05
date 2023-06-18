namespace Hashtable
{
	class Node<T>
	{
		public int Key { get; set; }
		public T Value { get; set; }
		public Node<T> Next { get; set; }

        public Node(int key, T value)
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

		private int HashCode(int key)
		{
			return key % buckets.Length;
		}

		public void Add(int key, T value)
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
					if (temp.Next == null)
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

		public T Get(int key)
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

		public void Remove(int key)
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
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			HashTable<string> t = new HashTable<string>();
			t.Add(1, "Anand");
			t.Add(6, "Anjali");
			t.Add(11, "as");
			t.Remove(1);
			t.Remove(11);
            Console.WriteLine(t.Get(6));
        }
	}
}