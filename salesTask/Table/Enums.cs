using System;
using System.Collections.Generic;
using System.Text;

namespace Table
{
	public enum Priority
	{
		NotSpecified,
		Low,
		Medium,
		High,
		Critical
	}
	public enum DeliveryType
	{
		RegularAir,
		ExpressAir,
		DeliveryTruck
	}
	public enum Segment
	{
		SmallBusiness,
		Consumer,
		Corporate,
		HomeOffice,

	}
	public enum Category
	{
		OfficeSupplies,
		Technology,
		Furniture,
	}
	public enum Container
	{
		JumboDrum,
		JumboBox,
		SmallBox,
		MediumBox,
		LargeBox,
		SmallPack,
		WrapBag
	}
}
