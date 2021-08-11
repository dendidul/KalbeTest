using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using KalbeTest.Dao;
using KalbeTest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KalbeTest.Controllers
{
    public class PenjualanController : Controller
    {
        private readonly PenjualanDao PenjualanDao;
        private readonly CustomerDao CustomerDao;
        private readonly ProdukDao ProdukDao;

        public PenjualanController(IConfiguration config)
        {
            this.PenjualanDao = new PenjualanDao(config);
            this.CustomerDao = new CustomerDao(config);
            this.ProdukDao = new ProdukDao(config);
        }


        public List<OptionModel> CustomerList
        {
            get
            {

                List<OptionModel> listItems = new List<OptionModel>();

                var getdata = CustomerDao.GetAllData();

                foreach(var i in getdata)
                {
                    listItems.Add(new OptionModel { value = i.intCustomerId, text = i.txtCustomerName});
                }
              
              
                return listItems;
            }
        }

        public List<OptionModel> ProdukList
        {
            get
            {

                List<OptionModel> listItems = new List<OptionModel>();

                var getdata = ProdukDao.GetAllData();

                foreach (var i in getdata)
                {
                    listItems.Add(new OptionModel { value = i.intProductId, text = i.txtProductName });
                }


                return listItems;
            }
        }

        public static List<GenderModel> GenderList
        {
            get
            {
                List<GenderModel> listItems = new List<GenderModel>();
                listItems.Add(new GenderModel { value = true, text = "Laki - Laki" });
                listItems.Add(new GenderModel { value = false, text = "Perempuan" });
                return listItems;
            }
        }

        public IActionResult Index()
        {
            var model = PenjualanDao.GetAllData();
            return View(model);
        }


        public IActionResult Create()
        {
            ViewBag.ListCustomer = new SelectList(CustomerList, "value", "text", 0);
            ViewBag.ListProduk = new SelectList(ProdukList, "value", "text", 0);
            return View();
        }



        [HttpPost]
        public IActionResult Create(PenjualanModel model)
        {
            try
            {

                PenjualanDao.CreatePenjualan(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PenjualanModel model)
        {
            try
            {

                // TODO: Add update logic here
                PenjualanDao.UpdatePenjualan(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public IActionResult Edit(int Id)
        {
            ViewBag.ListCustomer = new SelectList(CustomerList, "value", "text", 0);
            ViewBag.ListProduk = new SelectList(ProdukList, "value", "text", 0);
            var model = PenjualanDao.GetDataById(Id);
            return View(model);
        }


        public IActionResult Delete(int Id)
        {
            ViewBag.ListCustomer = new SelectList(CustomerList, "value", "text", 0);
            ViewBag.ListProduk = new SelectList(ProdukList, "value", "text", 0);
            var model = PenjualanDao.GetDataById(Id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(PenjualanModel model)
        {


            PenjualanDao.DeletePenjualan(model.intSalesOrderID);


            return RedirectToAction("Index");
        }
    }
}