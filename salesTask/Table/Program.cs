using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Table
{
	class Program
	{
		static SalesInfo[] sales;
		static void Main(string[] args)
		{
			List<string> tables = File.ReadAllLines(@"..\..\..\csv\Sample.csv").ToList<string>();
			Console.SetWindowSize(240, 60);
			sales = new SalesInfo[tables.Count - 1];
			for (int i = 0; i < tables.Count - 1; i++)
				sales[i] = new SalesInfo(tables[i + 1]);
			
			sales = SalesInfo.SortByPriority(sales);
			Console.Write("Отсортировать по");

			Console.ReadLine();

			var test = SalesInfo.FindByDate(sales, "20.10.2010 0:00:00");
			for (int i = 0; i < test.Count; i++)
			{
				Console.WriteLine($"Customer: {test[i].CustomerName}\t\t\tProduct: {test[i].ProductName}");
			}
		}
	}
}
