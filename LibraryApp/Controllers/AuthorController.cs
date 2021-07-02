using AutoMapper;
using LibraryApp.Data;
using System.Linq;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class AuthorController
    {
        ApplicationDbContext db;
        public AuthorController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpPost]
        public HttpStatusCodeResult Add(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            db.SaveChanges();
            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }

        [HttpPost]
        public HttpStatusCodeResult Update(string name, Author update)
        {
            var current = db.Authors.Where(c => c.AuthorName == name).FirstOrDefault();
            var author = db.Authors.Find(current);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, Author>());
            var mapper = config.CreateMapper();
            author = mapper.Map<Author>(update);
            db.SaveChanges();

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }

        [HttpDelete]
        public HttpStatusCodeResult Delete(string name)
        {
            var current = db.Authors.Where(c => c.AuthorName == name).FirstOrDefault();
            db.Authors.Remove(current);
            db.SaveChanges();

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }

        [HttpGet]
        public HttpStatusCodeResult Get(string name)
        {
            var current = db.Authors.Where(c => c.AuthorName == name).FirstOrDefault();

            HttpStatusCodeResult result = new HttpStatusCodeResult(200);
            return result;
        }
    }
}
