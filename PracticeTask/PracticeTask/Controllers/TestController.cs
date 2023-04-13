using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace PracticeTask.Controllers;

	public class TestController : Controller
	{
		// 
		// GET: /Test/

		public string Index()
		{
			return "dsfads";
		}

		// GET: /Test/Welcome/ 
		// Requires using System.Text.Encodings.Web;
		public string Welcome(string name, int ID = 1)
		{
			return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
		}
}

