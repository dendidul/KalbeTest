using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using KalbeTest.Dao;
using KalbeTest.Models;

namespace KalbeTest.Controllers
{
    public class ProdukController : Controller
    {

        private readonly ProdukDao ProdukDao;

        public ProdukController(IConfiguration config)
        {
            this.ProdukDao = new ProdukDao(config);
        }

        public IActionResult Index()
        {
            var model = ProdukDao.GetAllData();
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }


      
        [HttpPost]
        public IActionResult Create(ProdukModel model)
        {
            try
            {
                ProdukDao.CreateProduk(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdukModel model)
        {
            try
            {

                // TODO: Add update logic here
                ProdukDao.UpdateProduk(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public IActionResult Edit(int Id)
        {
            var model = ProdukDao.GetDataById(Id);
            return View(model);
        }


        public IActionResult Delete(int Id)
        {
            var model = ProdukDao.GetDataById(Id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(ProdukModel model)
        {


            ProdukDao.DeleteProduk(model.intProductId);


            return RedirectToAction("Index");
        }





    }
}