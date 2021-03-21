using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Table
{
	static class Utils
	{
		static public string[] SplitTable(this string value, char delimetr)
		{
			StringBuilder builder = new StringBuilder();
			List<string> result = new List<string>();
			for (int i = 0; i < value.Length; i++)
			{
				if (!value[i].Equals(delimetr))
				{
					builder.Append(value[i]);
				} else
				if (i != value.Length - 1 && value[i + 1] != ' ')
				{
					result.Add(builder.ToString());
					builder.Clear();
				}
			}
			result.Add(builder.ToString());
			return result.ToArray();
		}
	}
}
