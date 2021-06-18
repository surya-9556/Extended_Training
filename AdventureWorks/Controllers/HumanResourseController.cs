using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.Models;

namespace AdventureWorks.Controllers
{
    public class HumanResourseController : Controller
    {
        // GET: HumanResourse
        public ActionResult Index()
        {
            using (AdventureEntities EA = new AdventureEntities())
            {
                var sol = new SelectList(EA.Departments.ToList(), "DepartmentID", "Name");
                TempData["HumanRes"] = sol;

                var sols = new SelectList(EA.Departments.ToList(), "DepartmentID", "GroupName");
                TempData["HumanRes1"] = sols;


                List<Employee> employees = EA.Employees.ToList();
                List<Department> departments = EA.Departments.ToList();
                List<Person> people = EA.People.ToList();
                List<EmployeeDepartmentHistory> histories = EA.EmployeeDepartmentHistories.ToList();

                var employeeRecord = from e in employees
                                     join p in histories on e.BusinessEntityID equals p.BusinessEntityID into table1
                                     from p in table1.ToList()
                                     join h in departments on p.DepartmentID equals h.DepartmentID into tabel2
                                     from h in tabel2.ToList()
                                     join l in people on e.BusinessEntityID equals l.BusinessEntityID into table3
                                     from l in table3.ToList()
                                     select new ViewModel
                                     {
                                         employee = e,
                                         histories = p,
                                         department = h,
                                         people = l,
                                     };

                ViewBag.slist = new SelectList(employeeRecord, "BusinessEntityID", "FirstName", "Gender", "BirthDate", "MaritalStatus", "HireDate");
                return View(employeeRecord);
            }
        }
    }
}