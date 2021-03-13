using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace ListImplementation
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> b = new List<int>();
			FakeList<int> a = new FakeList<int>();

			for (int i = 0; i < 10; i++)
			{
				Random r = new Random();
				a.Add(r.Next(100));
			}

			Stopwatch stopwatch = Stopwatch.StartNew();
			
			stopwatch.Stop();

			Console.WriteLine($"elapsed: {stopwatch.ElapsedMilliseconds}ms");

			a.Sort();

			foreach (var item in a)
			{
				Console.WriteLine(item);
			}
		}
	}
}
