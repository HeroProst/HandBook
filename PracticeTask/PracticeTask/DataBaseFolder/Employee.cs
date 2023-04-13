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
	}
}
