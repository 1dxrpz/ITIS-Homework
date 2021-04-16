using System;
using System.Collections.Generic;

namespace CollectionsTask
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList<Book> test = new LinkedList<Book>();
			test.AddLast(new Book(
				new Author("а"),
				new Title("лох, полный лох!"),
				new DateTime(), Genres.Horror));
			test.AddLast(new Book(
				new Author("в"),
				new Title("лох, полный лох: возвращение"),
				new DateTime(), Genres.Comedy));
			
			Bookshelf bookshelf = new Bookshelf(test);

			bookshelf.AddBook<Title>(new Book(
				new Author("д"),
				new Title("лох, полный лох: возвращение"),
				DateTime.Now, Genres.Horror));
			bookshelf.AddBook<Title>(new Book(
				new Author("б"),
				new Title("лох, полный лох:"),
				DateTime.Now, Genres.Drama));
			bookshelf.AddBook<Title>(new Book(
				new Author("г"),
				new Title("лох, полный лох: возвращение"),
				DateTime.Now, Genres.Thriller));
			


			foreach (var t in bookshelf)
			{
				Console.WriteLine(t.ToString());
			}
			
		}
	}
}
