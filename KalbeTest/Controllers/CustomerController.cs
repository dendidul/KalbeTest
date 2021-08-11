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
    public class CustomerController : Controller
    {


        private readonly CustomerDao CustomerDao;

        public CustomerController(IConfiguration config)
        {
            this.CustomerDao = new CustomerDao(config);
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

            var model = CustomerDao.GetAllData();
            return View(model);
        }


        public IActionResult Create()
        {
            ViewBag.ListGender = new SelectList(GenderList, "value", "text", 0);
            return View();
        }



        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            try
            {
               
                CustomerDao.CreateCustomer(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel model)
        {
            try
            {

                // TODO: Add update logic here
                CustomerDao.UpdateCustomer(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public IActionResult Edit(int Id)
        {
            ViewBag.ListGender = new SelectList(GenderList, "value", "text", 0);
            var model = CustomerDao.GetDataById(Id);
            return View(model);
        }


        public IActionResult Delete(int Id)
        {
            ViewBag.ListGender = new SelectList(GenderList, "value", "text", 0);
            var model = CustomerDao.GetDataById(Id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(CustomerModel model)
        {


            CustomerDao.DeleteCustomer(model.intCustomerId);


            return RedirectToAction("Index");
        }

    }
}