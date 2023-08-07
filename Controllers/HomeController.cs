using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public object Photos { get; private set; }

        public HomeController(IEmployeeRepository employeeRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployee();
            return View(employees);
        }

        public ViewResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id.Value);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = model, 
                PageTitle = "Employee Details"
            };
           
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Department == Dept.None)
                {
                    ModelState.AddModelError("Department", "Invalid option selected!");
                    return View(model);
                }

                string uniqueFileName = ProcessUploadedFiles(model.Photos);

                Employee newEmployee = new Employee
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Address = model.Address,
                    BirthDate = model.BirthDate,
                    Email = model.Email,
                    Department = model.Department,
                    Salary = model.Salary,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }

            return View(model);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return View("Error");
            }

            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Address = employee.Address,
                BirthDate = employee.BirthDate,
                Email = employee.Email,
                Department = employee.Department,
                Salary = employee.Salary,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Department == Dept.None)
                {
                    ModelState.AddModelError("Department", "Invalid option selected!");
                    return View(model);
                }

                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.Address = model.Address;
                employee.BirthDate = model.BirthDate;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.Salary = model.Salary;

                if (model.Photos != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    string uniqueFileName = ProcessUploadedFiles(model.Photos);
                    employee.PhotoPath = uniqueFileName;
                }

                _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private string ProcessUploadedFiles(IFormFile photo)
        {
            string uniqueFileName = null;

            if (photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public ActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return View("EmployeeNotFound");
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var deletedEmployee = _employeeRepository.Delete(id);

            if (deletedEmployee == null)
            {
                return View("EmployeeNotFound");
            }

            return RedirectToAction("Index");
        }

    public ActionResult About()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}