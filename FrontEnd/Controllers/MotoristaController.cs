using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            IEnumerable<MotoristaViewModel> motoristas = null;

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

                    motoristas = readTask.Result;
                }
                else
                {
                    motoristas = Enumerable.Empty<MotoristaViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(motoristas);
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motorista
        [HttpPost]
        public ActionResult Create(MotoristaViewModel motorista)
        {
            if (motorista == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64686/api/");

                var postTast = client.PostAsJsonAsync<MotoristaViewModel>("motorista", motorista);
                postTast.Wait();
                var result = postTast.Result;

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(motorista);
        }

        [HttpGet]
        public ActionResult Edit(int? codigo)
        {
            if (codigo == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MotoristaViewModel motorista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64686/api/");

                var responseTask = client.GetAsync("motorista/" + codigo.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MotoristaViewModel>();
                    readTask.Wait();

                    motorista = readTask.Result;
                }
            }
            return View(motorista);
        }

        // PUT: Motorista
        [HttpPost]
        public ActionResult Edit(MotoristaViewModel motorista)
        {
            if (motorista == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64686/api/");

                var putTask = client.PutAsJsonAsync<MotoristaViewModel>("motorista", motorista);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            return View(motorista);
        }

        // DELTE: Motorista
        [HttpGet]
        public ActionResult Delete(int? codigo)
        {
            if (codigo == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MotoristaViewModel motorista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64686/api/motorista");

                var deleteTask = client.DeleteAsync("?codigo=" + codigo.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            return View(motorista);
        }

        // GET: Motorista
        [HttpGet]
        public ActionResult Details(int? codigo)
        {
            if (codigo == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            MotoristaViewModel motorista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64686/api/");

                var responseTask = client.GetAsync("motorista/" + codigo.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MotoristaViewModel>();
                    readTask.Wait();

                    motorista = readTask.Result;
                }
            }
            return View(motorista);
        }
    }
}