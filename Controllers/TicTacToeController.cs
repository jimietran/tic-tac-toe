using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    /// <summary>
    /// Controller class
    /// </summary>
    public class TicTacToeController : Controller
    {
        private TicTacToeDBContext db = new TicTacToeDBContext();

        //
        // GET: /TicTacToe/

        public ActionResult Index()
        {
            return View(db.TicTacToe.ToList());
        }

        //
        // GET: /TicTacToe/Details/5

        public ActionResult Details(int id = 0)
        {
            TicTacToeModel tictactoemodel = db.TicTacToe.Find(id);
            if (tictactoemodel == null)
            {
                return HttpNotFound();
            }
            return View(tictactoemodel);
        }

        //
        // GET: /TicTacToe/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TicTacToe/Create

        [HttpPost]
        public ActionResult Create(TicTacToeModel tictactoemodel)
        {
            if (ModelState.IsValid)
            {
                db.TicTacToe.Add(tictactoemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tictactoemodel);
        }

        //
        // GET: /TicTacToe/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TicTacToeModel tictactoemodel = db.TicTacToe.Find(id);
            if (tictactoemodel == null)
            {
                return HttpNotFound();
            }
            return View(tictactoemodel);
        }

        //
        // POST: /TicTacToe/Edit/5

        [HttpPost]
        public ActionResult Edit(TicTacToeModel tictactoemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tictactoemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tictactoemodel);
        }

        //
        // GET: /TicTacToe/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TicTacToeModel tictactoemodel = db.TicTacToe.Find(id);
            if (tictactoemodel == null)
            {
                return HttpNotFound();
            }
            return View(tictactoemodel);
        }

        //
        // POST: /TicTacToe/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TicTacToeModel tictactoemodel = db.TicTacToe.Find(id);
            db.TicTacToe.Remove(tictactoemodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}