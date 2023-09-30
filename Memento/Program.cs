using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "1234",
                Title = "Alice",
                Author = "Fadıl"
            };

            book.ShowBook();
            CareTaker history=new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "4567";
            book.Title = "Soa";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);

            book.ShowBook();
            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _Isbn;
        DateTime _lastEdited;

        public string Title
        {
            get { return _title; }
            set { _title = value; SetLastEdited(); }

        }
        public string Author
        {
            get { return _author; }
            set { _author = value; SetLastEdited(); }

        }
        public string Isbn
        {
            get { return _Isbn; }
            set { _Isbn = value; SetLastEdited(); }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_Isbn,_title,_author,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title=memento.Title;
            _author=memento.Author;
            _lastEdited=memento.LastEdited;
            _Isbn=memento.Isbn;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0} = Isbn, {1} = Title, {2} = Author, edited: {3}", Isbn,Title,Author,_lastEdited);
        }

    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }

}
