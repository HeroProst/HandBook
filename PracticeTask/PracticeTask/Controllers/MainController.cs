using Microsoft.AspNetCore.Mvc;
using PracticeTask.DataBaseFolder;
using System.Numerics;

namespace PracticeTask.Controllers
{
	public class MainController : Controller
	{
		public IConfiguration server;
		public MainController(IConfiguration server) 
		{
			this.server = server;
		}

		public IActionResult Index()
		{

			List<Employee> employees = new List<Employee>();
			string sql = "SELECT Id, Firstname, Secondname, Patronymic, id_Department, id_Cabinet, Phone FROM td_Employes";

			DataBase db = new DataBase(sql, server);

			if(db.data.HasRows) 
			{
				while (db.data.Read())
				{
					Employee emp = new Employee()
                    {
                        Id = db.data[0].ToString(),
						Firstname = db.data[1].ToString(),
						Secondname = db.data[2].ToString(),
						Patronymic = db.data[3].ToString(),
						id_Department = db.data[4].ToString(),
						id_Cabinet = db.data[5].ToString(),
						Phone = db.data[6].ToString()
					};

					employees.Add(emp);

					emp.SetEmployeeDepartmentName(server);
					emp.SetEmployeeCabinetsName(server);
				}
			}

			List<string> departmentsName = new List<string>();

            departmentsName = Department.GetAllDepartmentsName(server);

			ViewData["DepartmetList"] = departmentsName;

			db.Close();

			return View(employees);
		}
	}
}
