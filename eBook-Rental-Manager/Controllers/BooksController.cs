using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity; 
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eBook_Rental_Manager.Data;
using eBook_Rental_Manager.Models;
using eBook_Rental_Manager.DAL;

namespace eBook_Rental_Manager.Controllers
{
    public class BooksController : Controller
    {
        private eBook_Rental_ManagerContext db = new eBook_Rental_ManagerContext();
        //private BookshelfContext db = new BookshelfContext();

        
        
        // GET: Books
        public ActionResult BookShelf()
        {
            var books = db.Books.Include(b => b.Genre);

            return View(books.ToList());
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Genre);
            return View(books.ToList());
        }



        /*

        ///uploading images

        [HttpGet]
        public ActionResult UploadFiles()
        {
            return View();
        }
        public class FormDataTestVM
        {
            public HttpPostedFileBase formDataTestFile { get; set; }
        }

        [HttpPost]
        public ActionResult UploadFiles(FormDataTestVM formDataTestVM)
        {
            return View();
        }
        ///
        public string uploadImage(HttpPostedFileBase imgfile)
        {
            string path = "-1";

            return path;
        }
        
        // GET: Image
        public ActionResult AddImage()
        {
            Brand b1 = new Brand();
            return View(b1);
        }

        public ActionResult AddImage(Brand model)
        {
            var db = new DatabaseEntities();
            HttpPostFileBase file = Request.Files["imgfile"];

            if(file != null)
            {
                model.BrandImage = new byte[file.ContentLength];

                file.InputStream.Read(model.BrandImage, 0, file.ContentLength);
            }
            db.Brands.Add(model);
            db.SaveChanges();
            return View(model);
        }
        */

        // GET: Search results
        public ActionResult SearchForm(string searching)
        {
            var searchResult = db.Books.Where(x => x.Title.Contains(searching) || searching == null);
            var books = db.Books.Include(b => b.Genre);



            bool b1 = string.IsNullOrEmpty(searching);

            if (b1 != true)
            {
                return View(searchResult.ToList());
            } else
            {
                return View(books.ToList());
            }

            //return View(searchResult.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Title,Author,Excerpt,ReleaseDate,RentalPrice,GenreID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", book.GenreID);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", book.GenreID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Excerpt,ReleaseDate,RentalPrice,GenreID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", book.GenreID);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
