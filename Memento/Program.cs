using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            CareTaker history = new CareTaker();
            Book book = new Book { Isbn = "12345", Title = "Sefiller", Author ="Victor Hugo" };
            
            history.Memento = book.CreateUndo();
            book.ShowBook();

            bekle();

            book.Isbn = "54321";
            kaydet();
            book.ShowBook();

            bekle();

            book.Title = "VICTOR HUGO";
            kaydet();
            book.ShowBook();

            bekle();

            book.Author = "Şşşşşşşşşş";
            //kaydet();//son diye kaydetmesin
            book.ShowBook();
            
            bekle();

            Console.WriteLine("\t\t<<<< Geri Alma Başlıyor >>>>");
            geriAl();

            Console.ReadLine();

            void kaydet()
            {
                history.Memento = book.CreateUndo();
            }

            void bekle(){
                Thread.Sleep(1000); 
            }

            void geriAl()
            {
                do
                {
                    islem();
                } while (history.getCount() >0);

                void islem()
                {
                    book.RestoreFromUndo(history.Memento);
                    book.ShowBook();
                    bekle();
                }
            }
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited; //sondeğiştirilme zamanı

        //public string GetTitle()
        //{
        //    return _title;
        //}

        //public void SetTitle(string value)
        //{
        //    _title = value;
        //}

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
            get { return _isbn; }
            set { _isbn = value; SetLastEdited(); }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.Now; //DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            if(memento != null)
            {
                _title = memento.Title;
                _author = memento.Author;
                _isbn = memento.Isbn;
                _lastEdited = memento.LastEdited;
            }
            
        }

        public void ShowBook()
        {
            Random random = new Random();
            Console.ForegroundColor = (ConsoleColor)random.Next((int)ConsoleColor.DarkBlue,(int)ConsoleColor.White);
            Console.WriteLine($"isbn: {_isbn},title: {_title}, author: {_author}, edited: {_lastEdited}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //benim geliştirme
        public Book()
        {
            SetLastEdited();
        }
    }

    class Memento // geçmişin kaydı
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

    class CareTaker //geçmişin kaytlarını tutucu
    {
        //public Memento Memento { get; set; }

        #region Benim yaptığım geliştirme
        private List<Memento> memento = new List<Memento>();

        public Memento Memento
        {
            get{
                Memento result = null;
                if (memento.Count > 0)
                {
                    result = memento[memento.Count-1];
                    memento.RemoveAt(memento.Count - 1);
                }
                return result;
            }

            set{ memento.Add(value); }
        }

        public int getCount()
        {
            return memento.Count();
        }
        #endregion
    }
}
