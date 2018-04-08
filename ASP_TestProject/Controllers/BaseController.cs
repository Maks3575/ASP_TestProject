using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_TestProject.Controllers
{
    public class BaseController : Controller
    {
        protected readonly TestASPEntities Db = new TestASPEntities();

        // GET: Base

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}