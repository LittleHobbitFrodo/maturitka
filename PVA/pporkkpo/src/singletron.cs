using System;

namespace Singletron
{
	class Program
	{
		public class ToiToi
		{
			private static ToiToi _instance;
			private int _capacity;

			private ToiToi(int capacity)
			{
				_capacity = capacity;
			}

			public static ToiToi Instance
			{
				get
				{
					if(_instance == null)
					{
						_instance = new ToiToi(-1);
					}
					return _instance;
				}
			}

			public int Capacity
			{
				get
				{
					return _capacity;
				}

				set
				{
					if(_capacity == -1)
					{
						_capacity = Math.Abs(value);
					}
					else
					{
						Console.WriteLine("alrdy set!");
					}
				}
			}
		}
		
		static void Main(string[] args)
		{
			ToiToi test = ToiToi.Instance;
			test.Capacity = 2000;
			test.Capacity = 200;
			ToiToi dva = ToiToi.Instance;
			Console.WriteLine(dva.Capacity);
		}
	}
}
