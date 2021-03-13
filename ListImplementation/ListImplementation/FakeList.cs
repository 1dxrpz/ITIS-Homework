﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListImplementation
{
	class FakeList<T>
	{
		private int count = 0;
		private int buffer = 2;
		private int multiplicator = 2;
		private T[] array = new T[2];
		public void Add(T a)
		{
			if (count >= buffer)
			{
				buffer *= multiplicator;
				multiplicator *= 2;
				buffer *= 2;
				Array.Resize<T>(ref this.array, buffer);
			}
			array[count] = a;
			count++;
		}
		public void AddRange(ICollection<T> collection)
		{
			foreach(var item in collection)
			{
				Add(item);
			}
		}
		public int Count()
		{
			return count;
		}
		public T this[int i]
		{
			get
			{
				if (i >= this.count)
					throw new System.ArgumentOutOfRangeException();
				else
					return array[i];
			}
			set
			{
				if (i >= this.count)
					throw new System.ArgumentOutOfRangeException();
				else
					array[i] = value;
			}
		}
		public void Remove (T element)
		{
			int index = Array.FindIndex<T>(array, v => v.Equals(element));
			RemoveAt(index);
		}
		public void RemoveAt(int index)
		{
			for (int i = index; i < count - index; i++)
			{
				array[i] = array[i + 1];
			}
			array[count] = default(T);
			count--;
		}
		public IEnumerator GetEnumerator()
		{
			T[] temp = (T[])array.Clone();
			Array.Resize<T>(ref temp, count);
			return temp.GetEnumerator();
		}
		public int IndexOf(T item)
		{
			return Array.FindIndex<T>(array, v => v.Equals(item));
		}
		public void Insert(int index, T item)
		{
			this.Add(item);
			for (int i = count; i > count - index ; i--)
			{
				array[i] = array[i - 1];
			}
			array[index] = item;
		}
		public void Sort()
		{
			T[] temp = (T[])array.Clone();
			Array.Resize<T>(ref temp, count);
			array = temp;
			Array.Sort<T>(array);
		}
		public void ChangeMin()
		{
			T[] temp = (T[])array.Clone();
			Array.Resize<T>(ref temp, count);
			Array.Sort<T>(temp);
			int min = Array.FindIndex<T>(array, v => v.Equals(temp[0]));
			int max = Array.FindIndex<T>(array, v => v.Equals(temp[count - 1]));

			T temp_item = array[min];
			array[min] = array[max];
			array[max] = temp_item;
		}
		static public void All_eq(FakeList<string> list)
		{
			FakeList<string> temp = new FakeList<string>();
			for (int i = 0; i < list.count; i++)
				temp.Add(list[i]);
			temp.Sort();
			int length = temp[temp.count - 1].Length;
			for (int i = 0; i < list.count; i++)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(list[i]);
				for (int n = list[i].Length; n < length; n++)
					sb.Append("_");
				list[i] = sb.ToString();
			}	
		}
	}
}
