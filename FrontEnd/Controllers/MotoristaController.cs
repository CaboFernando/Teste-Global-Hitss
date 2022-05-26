using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class MotoristaController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<MotoristaViewModel> clientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61353/api/");

                var responseTask = client.GetAsync("clientes");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MotoristaViewModel>>();
                    readTask.Wait();

                    clientes = readTask.Result;
                }
                else
                {
                    clientes = Enumerable.Empty<MotoristaViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(clientes);
            }
        }
    }
}
