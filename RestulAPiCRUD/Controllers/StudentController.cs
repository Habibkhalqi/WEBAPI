using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestulAPiCRUD.Models;
using System.Text;


namespace RestulAPiCRUD.Controllers
{
    public class StudentController : Controller
    {
        private string Url = "https://localhost:7246/api/StudentAPI/";

        HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult index()
        {
            List<Student> std = new List<Student>();
            HttpResponseMessage Response = client.GetAsync(Url).Result;
            if(Response.IsSuccessStatusCode)
            {
                var result = Response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if(data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            
            StringContent cont = new StringContent(data, Encoding.UTF8,"application/json");

            HttpResponseMessage response = client.PostAsync(Url, cont).Result;

            if(response.IsSuccessStatusCode)
            {
                TempData["Message"] = "StudentRecord Successfully...";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(Url + id).Result;
            if(response != null)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if(data != null)
                {
                    std = data;

                }

            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(Url + std.id, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["UpdateData"] = "Student Update...";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(Url + id).Result;
            if (response != null)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;

                }

            }
            return View(std);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(Url + id).Result;
            if (response != null)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;

                }

            }
            return View(std);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
           
            HttpResponseMessage response = client.DeleteAsync(Url + id).Result;
            if (response != null)
            {

                TempData["DeletedData"] = "Student Deleted...";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
