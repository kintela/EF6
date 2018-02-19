using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NinjaDomain.Clases;
using NinjaDomain.DataModels;

namespace MVCAppRepository.Controllers
{
    public class NinjasController : Controller
    {
        private readonly DisconnectedRepository _repo = new DisconnectedRepository();

        // GET: Ninjas
        public ActionResult Index()
        {
            var ninjas = _repo.GetNinjasWithClan();
            return View(ninjas.ToList());
        }
      
    }
}
