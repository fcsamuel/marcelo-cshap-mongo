using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplicationVeiculo.Context;
using WebApplicationVeiculo.Models;

namespace WebApplicationVeiculo.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly MongoDBContext _mongoDBContext = new MongoDBContext();

        // GET: Categoria
        public ActionResult Index() => View(_mongoDBContext.Categorias.Find(v => true).ToList());

        // GET: Categoria/Create
        public ActionResult Create() => View();

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                // TODO: Add insert logic here
                _mongoDBContext.Categorias.InsertOne(categoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(string id)
        {
            var categoriaEdit = _mongoDBContext.Categorias.Find(v => v.Id == ObjectId.Parse(id)).FirstOrDefault();
            return View(categoriaEdit);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Categoria categoria)
        {
            try
            {
                // TODO: Add update logic here
                categoria.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", categoria.Id);
                _mongoDBContext.Categorias.ReplaceOne(filter, categoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(string id)
        {
            var categoriaDelete = _mongoDBContext.Categorias.Find(v => v.Id == ObjectId.Parse(id)).FirstOrDefault();
            return View(categoriaDelete);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoria(string id)
        {
            _mongoDBContext.Categorias.DeleteOne(v => v.Id == ObjectId.Parse(id));
            return RedirectToAction(nameof(Index));
        }
    }
}