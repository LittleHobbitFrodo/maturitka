//oop brinrot

using System;

namespace Observer
{
	class Program
	{
		public interface IObserver
		{
			void Update(string data);	
		}

		public interface IObserverSubject
		{
			void Subs(IObserver o);
			void Unsubs(IObserver o);
			void PushUpdate();
		}

		public class Cumil : IObserver
		{
			private readonly string _jmeno;

			public Cumil(string jmeno)
			{
				_jmeno = jmeno;
			}

			public void Update(string data)
			{
				Console.WriteLine($"[{this._jmeno}] oooo co ti jebe, koukej co je videt z okna: {data}");
			}
		}

		public class Okno : IObserverSubject
		{
			private string vyhled;
			private List<IObserver> subscribers = new List<IObserver>();

			public Okno(string vyhled)
			{
				this.vyhled = vyhled;
			}

			public string Vyhled
			{
				get => vyhled;

				set
				{
					vyhled = value;
					this.PushUpdate();
				}
			}

			public void Subs(IObserver o)
			{
				if(!subscribers.Contains(o))
				{
					subscribers.Add(o);
				}
			}

			public void Unsubs(IObserver o)
			{
				if(subscribers.Contains(o))
				{
					subscribers.Remove(o);
				}
			}

			public void PushUpdate()
			{
				foreach(var subject in subscribers)
				{
					subject.Update(vyhled);
				}
			}
		}

		public static void Main(string[] args)
		{
			Cumil jeronym = new Cumil("jeronym");
			Cumil karel = new Cumil("kaja :) ");

			Okno okno = new Okno("zatim nic");

			okno.Subs(karel);
			okno.Subs(jeronym);

			okno.Vyhled = "krasna slecna";
			okno.Vyhled = "mobilní toaleta ToiToi láska!";
			okno.Unsubs(jeronym);
			okno.Vyhled = "pohledny mlady muz";

			okno.Unsubs(karel);
		}
	}
}
