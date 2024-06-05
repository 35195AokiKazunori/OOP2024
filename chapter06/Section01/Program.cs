using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //Priceの降順出力
            var books = Books.GetBooks().OrderBy(x => x.Title).ToList();
            foreach (var book in books) {
                Console.WriteLine(book.Title + ":" + book.Price);
            }

            //ページ数が最も多いbookを出力
            //var page = Books.GetBooks().Max(x => x.Pages);
            //var bookTitle = Books.GetBooks()
            //                     .FirstOrDefault(b => b.Pages == page);
            //Console.WriteLine(bookTitle.Title);
        }
    }
}
