using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CleanArchitecture.DataAccess.Entities;
using CleanArchitecture.DataAccess.Interfaces;
using CleanArchitecture.DataAccess.Persistence;
using CleanArchitecture.MVC.ViewModels;
using PagedList;

namespace CleanArchitecture.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _unitOfWork.Employees.GetAll();
            return View(employees.ToList());
        }

        public ActionResult EmployeesWithPaging(int? page)
        {
            var employees = _unitOfWork.Employees.Get()
                .OrderBy(e => e.ID)
                .ToPagedList(page ?? 1, 3);

            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = _unitOfWork.Employees.GetById(id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var viewModel = new EmployeeFormViewModel
            {
                Departments = _unitOfWork.Departments.GetAll()
            };

            return View(viewModel);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employees.Create(employee);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeFormViewModel
            {
                Employee = new Employee(),
                Departments = _unitOfWork.Departments.GetAll()
            };
            return View(viewModel);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = _unitOfWork.Employees.GetById(id);

            if (employee == null)
            {
                return HttpNotFound();
            }


            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Departments = _unitOfWork.Departments.GetAll()
            };

            return View(viewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employees.Update(employee);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Departments = _unitOfWork.Departments.GetAll()
            };

            return View(viewModel);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = _unitOfWork.Employees.GetById(id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _unitOfWork.Employees.GetById(id);

            if(employee == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.Employees.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
