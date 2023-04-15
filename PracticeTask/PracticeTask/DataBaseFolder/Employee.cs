using System.Numerics;

namespace PracticeTask.DataBaseFolder
{
	public class Employee
	{
		public string Id { get; set; }
		public string Firstname { get; set; }
		public string Secondname { get; set; }
		public string Patronymic { get; set; }
		public string Phone { get; set; }
		public string id_Department { get; set; }
		public string id_Cabinet { get; set; }

		public virtual Department Department { get; set; }
		public virtual Cabines Cabinets { get; set; }

		public void SetEmployeeDepartmentName(IConfiguration server)
		{
			string sql = $"SELECT Name FROM Department WHERE Id = {id_Department}";

			DataBase db = new DataBase(sql, server);

			this.Department = new Department();

			if (!db.data.HasRows)
				return;
			Department.Id = id_Department;
			while(db.data.Read())
				Department.Name = db.data[0].ToString();
		}

		public void SetEmployeeCabinetsName(IConfiguration server)
		{
			string sql = $"SELECT Name FROM Cabinets WHERE Id = {id_Cabinet}";

			DataBase db = new DataBase(sql, server);

			this.Cabinets = new Cabines();

			if (!db.data.HasRows)
				return;
			Cabinets.Id = id_Cabinet;
            while (db.data.Read())
                Cabinets.Name = db.data[0].ToString();
			return;

		}

        public static List<string> GetAllEmployeeName(IConfiguration server)
        {
            List<string> allDepartments = new List<string>();
			string sql = $" SELECT td_employes.id,\r\n    td_employes.firstname,\r\n    td_employes.secondname,\r\n    td_employes.patronymic,\r\n    department.name AS departmentname,\r\n    cabinets.name AS cabinetname,\r\n    td_employes.phone\r\n   FROM td_employes\r\n     JOIN department ON td_employes.id_department = department.id\r\n     JOIN cabinets ON td_employes.id_cabinet = cabinets.id;";

			DataBase db = new DataBase(sql, server);

            if (db.data.HasRows)
            {
                while (db.data.Read())
                {
                    allDepartments.Add("id" + " " + db.data[0].ToString() + " " + db.data[1].ToString() + " " + db.data[2].ToString() + " " + db.data[3].ToString() + " Отдел: " + db.data[4].ToString() + " Кабинет: " + db.data[5].ToString() + " Телефон: " + db.data[6].ToString());
                }
            }
            return allDepartments;
        }
    }
}
