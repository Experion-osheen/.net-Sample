using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserManagement.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public static String RenderRazorString(string Label)
        {
            try
            {
                return ResourceFile.ResourceManager.GetString(Label);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}