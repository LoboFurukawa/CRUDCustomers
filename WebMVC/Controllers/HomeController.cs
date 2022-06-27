using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        string baseUrl = @"https://localhost:44332/";
        public async Task<ActionResult> Index()
        {
            List<Customers> EmpInfo = new List<Customers>();
            List<UFs> uFs = new List<UFs>();
            List<DispatchAgency> dispatchAgencies = new List<DispatchAgency>();
            List<MaritalStatus> maritalStatuses = new List<MaritalStatus>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Customers/GetUFs");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    uFs = JsonConvert.DeserializeObject<List<UFs>>(EmpResponse);
                }

                ViewBag.UFsList = (from c in uFs
                                   select c.Description).Distinct();

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Res = await client.GetAsync("api/Customers/GetUFs");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    uFs = JsonConvert.DeserializeObject<List<UFs>>(EmpResponse);
                }

                ViewBag.UFsListAddress = (from c in uFs
                                          select c.Description).Distinct();

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Res = await client.GetAsync("api/Customers/GetDispatchAgency");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    dispatchAgencies = JsonConvert.DeserializeObject<List<DispatchAgency>>(EmpResponse);
                }

                ViewBag.lstDispatchAgency = (from c in dispatchAgencies
                                             select c.Description).Distinct();

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Res = await client.GetAsync("api/Customers/GetMaritalStatus");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    maritalStatuses = JsonConvert.DeserializeObject<List<MaritalStatus>>(EmpResponse);
                }

                ViewBag.lstMaritalStatus = (from c in maritalStatuses
                                            select c.Description).Distinct();



                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Res = await client.GetAsync("api/Customers/GetCustomers");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Customers>>(EmpResponse);
                }
                ViewBag.CustomerInfo = EmpInfo;
                return View(EmpInfo);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(Customers customers)
        {
            return Content($"Hello {customers.Name}");
        }
    }
}