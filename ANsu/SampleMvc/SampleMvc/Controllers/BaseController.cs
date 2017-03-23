using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvc.App_Resources;
using System.IO;

namespace SampleMvc.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base      

        public static string GetLocalisedString(string key)
        {
            return Resource1.ResourceManager.GetString(key);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            try
            {
                ViewData.Model = model;
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}