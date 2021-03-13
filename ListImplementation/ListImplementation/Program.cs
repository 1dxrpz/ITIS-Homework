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
			FakeList<string> a = new FakeList<string>();

			a.Add("Hello world");
			a.Add("Hello");
			a.Add("Hello");
			a.Add("Hello");

			FakeList<string>.All_eq(a);

			foreach (var item in a)
			{
				Console.WriteLine(item);
			}
		}
	}
}
