using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentApp.UI.ViewModels;

namespace StudentApp.UI.Controllers
{
    public class StudentController : Controller
    {
        
       
            private HttpClient _client;
            public StudentController()
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri("https://localhost:7197/api/");
            }
            public async Task<IActionResult> Index()
            {
                using (var response = await _client.GetAsync("https://localhost:7197/api/students/all"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        StudentViewModel vm = new StudentViewModel
                        {
                            Students = JsonConvert.DeserializeObject<List<StudentViewModelItem>>(content)
                        };

                        return View(vm);
                    }
                }

                return View("Error");
            }



        public async Task<IActionResult> Create()
        {
            ViewBag.Groups = await _getGroups();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = await _getGroups();
                return View();
            }



            StringContent requestContent = new StringContent(JsonConvert.SerializeObject(vm), System.Text.Encoding.UTF8, "application/json");

            
            using (var response = await _client.PostAsync("students", requestContent))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.Groups = await _getGroups();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorVM = JsonConvert.DeserializeObject<ErrorViewModel>(responseContent);
                    foreach (var item in errorVM.Errors)
                        ModelState.AddModelError(item.Key, item.ErrorMessage);

                    return View();
                }
            }

            return View("error");
        }

        public async Task<IActionResult> Edit(int id)
        {

            using (var response = await _client.GetAsync($"students/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var vm = JsonConvert.DeserializeObject<StudentEditViewModel>(content);
                    return View(vm);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentEditViewModel vm)
        {
            if (!ModelState.IsValid) return View();

            var requestContent = new StringContent(JsonConvert.SerializeObject(vm), System.Text.Encoding.UTF8, "application/json");
            using (var response = await _client.PutAsync($"students/{id}", requestContent
                ))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorVM = JsonConvert.DeserializeObject<ErrorViewModel>(responseContent);

                    foreach (var item in errorVM.Errors)
                        ModelState.AddModelError(item.Key, item.ErrorMessage);

                    return View();
                }
            }

            return View("error");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"students/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        StudentViewModel vm = new StudentViewModel
                        {
                            Students = JsonConvert.DeserializeObject<List<StudentViewModelItem>>(content)
                        };

                        return View(vm);
                    }
                }
            }
            return View("Error");
        }


        private async Task<List<GroupViewModelItem>> _getGroups()
        {
            List<GroupViewModelItem> data = new List<GroupViewModelItem>();
            using (var response = await _client.GetAsync("groups/all"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<GroupViewModelItem>>(content);
                }
            }

            return data;
        }

    }
}

