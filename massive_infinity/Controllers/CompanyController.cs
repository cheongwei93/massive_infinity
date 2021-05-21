using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using massive_infinity.Data.Entities;
using massive_infinity.Data;
using massive_infinity.Models;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace massive_infinity.Controllers
{
    
    public class CompanyController : Controller
    {
        private readonly massive_infinityContext _context;
        private ILogger<CompanyController> _logger;

        public CompanyController(massive_infinityContext context, ILogger<CompanyController> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            List<Company> list = _context.Company.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Add(CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                Company content = new Company();
                content.ID = Guid.NewGuid();
                content.Name = model.Name;
                content.Email = model.Email;
                content.Website_URL = model.Website_URL;
                if (model.LogoPath != null)
                {
                    content.Logo = ConvertToByteArray(model.LogoPath);
                }
                _context.Company.AddRange(content);
                _context.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            else {
                return RedirectToAction("Index", "Company");
            }
            
        }

        public IActionResult Details(string ID)
        {
            var result = _context.Company.Where(x => x.ID.Equals(Guid.Parse(ID))).FirstOrDefault();
            return View(result);
        }

        public IActionResult Employee(Guid ID)
        {
            List<Employee> list = _context.Employee.Where(x => x.Company.Equals(ID)).ToList();
            ViewData["ID"] = ID;
            return View(list);
        }

        public IActionResult NewEmployee(Guid ID)
        {
            ViewData["ID"] = ID;
            return View();
        }

        public IActionResult InsertNewEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                
                Employee content = new Employee();
                content.ID = Guid.NewGuid();
                content.First_Name = model.First_Name;
                content.Last_Name = model.Last_Name;
                content.Company = model.Company;
                content.Email = model.Email;
                content.Phone = model.Phone;
                _context.Employee.AddRange(content);
                _context.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            else {
                return RedirectToAction("Index", "Company");
            }
        }

        public IActionResult Delete(string ID)
        {
            if (ID != null)
            {

                Employee content = new Employee();
                content.ID = Guid.Parse(ID);
                _context.Employee.RemoveRange(content);
                _context.SaveChanges();
                return RedirectToAction("Index", "Company");

            }

            return RedirectToAction("Index", "Company");
        }

        public IActionResult DeleteCompany(string ID)
        {
            if (ID != null)
            {

                Company content = new Company();
                content.ID = Guid.Parse(ID);
                _context.Company.RemoveRange(content);
                _context.SaveChanges();
                return RedirectToAction("Index", "Company");

            }

            return RedirectToAction("Index", "Company");
        }

        public IActionResult EditCompany(string ID)
        {
            if (ID != null)
            {
                Guid guid = Guid.Parse(ID);
                var modify = _context.Company;
                ViewBag.ID = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().ID;
                ViewBag.Name = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().Name;
                ViewBag.Email = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().Email;
                ViewBag.Website_URL = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().Website_URL;
            }
            return View();
        }

        public IActionResult EditEmployee(string ID)
        {
            if (ID != null)
            {
                Guid guid = Guid.Parse(ID);
                var modify = _context.Employee;
                ViewBag.ID = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().ID;
                ViewBag.FirstName = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().First_Name;
                ViewBag.LastName = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().Last_Name;
                ViewBag.Company = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().Company;
                ViewBag.Email = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().Email;
                ViewBag.Phone = modify.Where(x => x.ID.Equals(guid)).FirstOrDefault().Phone;
            }
            return View();
        }

        public IActionResult UpdateCompany(CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                Company content = new Company();
                content.ID = model.ID;
                var context = _context.Company;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().Name = model.Name;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().Email = model.Email;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().Website_URL = model.Website_URL;

                _context.Company.UpdateRange(context);
                _context.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            return RedirectToAction("Index", "Company");
        }

        public IActionResult UpdateEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                Employee content = new Employee();
                content.ID = model.ID;
                var context = _context.Employee;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().First_Name = model.First_Name;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().Last_Name = model.Last_Name;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().Company = model.Company;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().Email = model.Email;
                context.Where(x => x.ID.Equals(content.ID)).FirstOrDefault().Phone = model.Phone;

                _context.Employee.UpdateRange(context);
                _context.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            return RedirectToAction("Index", "Company");
        }

        private string ConvertToByteArray(IFormFile file)
        {
            using (var toByte = new MemoryStream())
            {
                file.CopyTo(toByte);
                string base64 = Convert.ToBase64String(toByte.ToArray());
                return base64;
            }
        }



        
    }

}
