using AutoMapper;
using LibraryApp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BooksController
    {
        ApplicationDbContext db;
        public BooksController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpPost]
        public HttpStatusCodeResult Add(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }

        [HttpPost]
        public HttpStatusCodeResult Update(string name, Book update)
        {
            var current = db.Books.Where(c => c.BookName == name).FirstOrDefault();
            var book = db.Books.Find(current);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, Book>());
            var mapper = config.CreateMapper();
            book = mapper.Map<Book>(update);
            db.SaveChanges();

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }

        [HttpDelete]
        public HttpStatusCodeResult Delete(string name)
        {
            var current = db.Books.Where(c => c.BookName == name).FirstOrDefault();
            db.Books.Remove(current);
            db.SaveChanges();

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }

        [HttpGet]
        public HttpStatusCodeResult GetByName(string name)
        {
            var current = db.Books.Where(c => c.BookName == name).FirstOrDefault();

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }

        [HttpGet]
        public HttpStatusCodeResult GetByAuthor(string author)
        {
            if(author != null) { }
            List<Book> selected = new List<Book>();
            foreach (Book b in db.Books)
            {
                if (b.Authors.Contains((Author)db.Authors.Where(a => a.AuthorName == author)))
                    selected.Add(b);
            }

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }
    }
}
