using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionsTask
{
	public class Bookshelf
	{
		private LinkedList<Book> books = new LinkedList<Book>();
		public LinkedList<Book> Books
		{
			get { return books; }
		}

		public Bookshelf(LinkedList<Book> b)
		{
			books = b;
		}
		public IEnumerator GetEnumerator()
		{
			return books.GetEnumerator();
		}
		public void AddBook<T>(Book book)
		{
			if (typeof(T) == typeof(Author))
			{
				foreach (var t in books)
				{
					if (books.Find(t).Next != null)
					{
						if (String.Compare(book.Author.Name, t.Author.Name) >= 0 &&
							String.Compare(book.Author.Name, books.Find(t).Next.Value.Author.Name) < 0)
						{
							books.AddAfter(books.Find(t), book);
							break;
						}
					}
					else
					{
						books.AddLast(book);
						break;
					}
				}
			}
			if (typeof(T) == typeof(Title))
			{
				foreach (var t in books)
				{
					if (books.Find(t).Next != null)
					{
						if (String.Compare(book.Title.Name, t.Title.Name) >= 0 &&
							String.Compare(book.Title.Name, books.Find(t).Next.Value.Title.Name) < 0)
						{
							books.AddAfter(books.Find(t), book);
							break;
						}
					}
					else
					{
						books.AddLast(book);
						break;
					}
				}
			}
			if (typeof(T) == typeof(Genres))
			{
				foreach (var t in books)
				{
					if (books.Find(t).Next != null)
					{
						if (book.Genre >= t.Genre &&
							book.Genre < books.Find(t).Next.Value.Genre)
						{
							books.AddAfter(books.Find(t), book);
							break;
						}
					}
					else
					{
						books.AddLast(book);
						break;
					}
				}
			}
			if (typeof(T) == typeof(DateTime))
			{
				foreach (var t in books)
				{
					if (books.Find(t).Next != null)
					{
						if (book.Date >= t.Date &&
							book.Date < books.Find(t).Next.Value.Date)
						{
							books.AddAfter(books.Find(t), book);
							break;
						}
					}
					else
					{
						books.AddLast(book);
						break;
					}
				}
			}

		}
	}
	
	public enum Genres
	{
		Horror, Drama, Comedy, Thriller, Manga, Tales, Documentary, Fantasy, Poems
	}
	public class Book
	{
		public Author Author;
		public Title Title;
		public DateTime Date;
		public Genres Genre;

		public Book(Author author, Title title, DateTime date, Genres genre)
		{
			Author = author;
			Title = title;
			Date = date;
			Genre = genre;
		}
		public override string ToString()
		{
			return $"{Genre}\t{Author.Name}\t{Title.Name}\t{Date}";
		}
	}
	public class Author
	{
		public string Name;
		public Author(string name)
		{
			Name = name;
		}
	}
	public class Title
	{
		public string Name;
		public Title(string name)
		{
			Name = name;
		}
	}
}