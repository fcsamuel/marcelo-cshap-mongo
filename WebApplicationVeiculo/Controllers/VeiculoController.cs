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
    public class VeiculoController : Controller
    {
        private readonly MongoDBContext _mongoDBContext = new MongoDBContext();

        // GET: Veiculo
        public ActionResult Index() => View(_mongoDBContext.Veiculos.Find(v => true).ToList()); // Index é a lista

        // GET: Veiculo/Details/5
        public ActionResult Details(string id)
        {
            var veiculoDetails = _mongoDBContext.Veiculos.Find(v => v.Id == ObjectId.Parse(id)).FirstOrDefault();
            return View(veiculoDetails);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veiculo veiculo)
        {
           if (ModelState.IsValid)
            {
                _mongoDBContext.Veiculos.InsertOne(veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(string id)
        {
            var veiculoEdit = _mongoDBContext.Veiculos.Find(v => v.Id == ObjectId.Parse(id)).FirstOrDefault();
            return View(veiculoEdit);
        }

        // POST: Veiculo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculo.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", veiculo.Id);
                _mongoDBContext.Veiculos.ReplaceOne(filter, veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(string id)
        {
            var veiculoDelete = _mongoDBContext.Veiculos.Find(v => v.Id == ObjectId.Parse(id)).FirstOrDefault();
            return View(veiculoDelete);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVeiculo(string id)
        {
            _mongoDBContext.Veiculos.DeleteOne(v => v.Id == ObjectId.Parse(id));
            return RedirectToAction(nameof(Index));
        }

        private ActionResult GetVeiculoView(string id) => View(_mongoDBContext.Veiculos.Find(v => v.Id == ObjectId.Parse(id)).FirstOrDefault());

    }
}