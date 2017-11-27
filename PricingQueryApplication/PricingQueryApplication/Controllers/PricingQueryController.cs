using PricingQueryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PricingQueryApplication.Controllers
{
    public class PricingQueryController : Controller
    {
        // GET: PricingQuery
        public ActionResult Index()
        {
            PricingQueryModel pricingQuery = new PricingQueryModel();
            pricingQuery.getProducts();
            
            return View(pricingQuery);
            
        }

        [HttpPost]
        public ActionResult Index(PricingQueryModel pricingQuery)
        {
            
            
            String ok = pricingQuery.callProcedure();
            var body = "<p>Email From: {0} ({1})</p><p>Query On Products:</p><p>{2}</p>";
            String emailContent = string.Format(body, pricingQuery.Customer.LastName, pricingQuery.Customer.Email, pricingQuery.SelectedProd);
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("sender@gmail.com", "password"),
                EnableSsl = true
            };
            client.Send("sender@gmail.com", "receiver@gmail.com", "test", "testbody");


            if (ok == "Ok")
            {
                return Redirect(Url.Action("Success", "PricingQuery"));
            }
            else
            {
                return Redirect(Url.Action("Failure", "PricingQuery"));
            }
            

        }
        public ActionResult Success()
        {
            return View();

        }
        public ActionResult Failure()
        {
            return View();

        }

    }
}