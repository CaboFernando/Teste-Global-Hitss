using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class MotoristaController : Controller
    {
        // GET: Motorista
        public ActionResult Index()
        {
            IEnumerable<MotoristaViewModel> clientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64686/api/");

                var responseTask = client.GetAsync("motorista");
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