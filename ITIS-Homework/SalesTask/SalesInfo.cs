using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SalesTask
{
	class SalesInfo
	{
		public int RowID;
		public int OrderID;
		public DateTime OrderDate;
		public Priority OrderPriority;
		public int OrderQuantity;
		public int Sales;
		public double Discount;
		public DeliveryType Delivery;
		public double Profit;
		public double UnitPrice;
		public double ShippingCost;
		public string CustomerName;
		public string Province;
		public string Region;
		public Segment CustomerSegment;
		public Category ProductCategory;
		public string ProductSubCategory;
		public string ProductName;
		public Container ProductContainer;
		public double ProductBaseMargin;
		public DateTime ShipDate;

		public SalesInfo(string v)
		{
			string[] values = v.SplitTable(';');
			RowID = int.Parse(values[0]);
			OrderID = int.Parse(values[1]);
			OrderDate = DateTime.ParseExact(values[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
			OrderPriority = Enum.Parse<Priority>(String.Concat(values[3].Split(' ')));
			OrderQuantity = int.Parse(values[4]);
			Sales = int.Parse(String.Concat(values[5].Split(',')));
			Discount = double.Parse(values[6]);
			Delivery = Enum.Parse<DeliveryType>(String.Concat(values[7].Split(' ')));
			Profit = double.Parse(values[8]);
			UnitPrice = double.Parse(values[9]);
			ShippingCost = double.Parse(values[10]);
			CustomerName = values[11];
			Province = values[12];
			Region = values[13];
			CustomerSegment = Enum.Parse<Segment>(String.Concat(values[14].Split(' ')));
			ProductCategory = Enum.Parse<Category>(String.Concat(values[15].Split(' ')));
			ProductSubCategory = values[16];
			ProductName = values[17];
			ProductContainer = Enum.Parse<Container>(String.Concat(values[18].Split(' ')));
			ProductBaseMargin = values[19].Equals(String.Empty) ? 0 : double.Parse(values[19]);
			ShipDate = DateTime.ParseExact(values[20], "dd.MM.yyyy", CultureInfo.InvariantCulture);
		}
		public override string ToString()
		{
			return $"{RowID}\t{OrderID}\t{OrderDate}\t{OrderPriority}\t{OrderQuantity}\t" +
				$"{Sales}\t{Discount}\t{Delivery}\t{Profit}\t{UnitPrice}\t" +
				$"{ShippingCost}\t{CustomerName}\t{Province}\t{Region}\t{CustomerSegment}\t" +
				$"{ProductCategory}\t{ProductSubCategory}\t{ProductName}\t{ProductContainer}\t{ProductBaseMargin}\t" +
				$"{ShipDate}";
		}
		public static SalesInfo[] SortByPriority(SalesInfo[] array)
		{
			return array.OrderBy(v => v.OrderPriority).ToArray();
		}
		public static SalesInfo[] SortByOrderDate(SalesInfo[] array)
		{
			return array.OrderBy(v => v.ShipDate).ToArray();
		}
		public static SalesInfo[] SortByShipDate(SalesInfo[] array)
		{
			return array.OrderBy(v => v.ShipDate).ToArray();
		}
		public static List<SalesInfo> FindByDate(SalesInfo[] array, string date)
		{
			return array.ToList().FindAll(v => v.ShipDate.ToString() == date);
		}
	}

}