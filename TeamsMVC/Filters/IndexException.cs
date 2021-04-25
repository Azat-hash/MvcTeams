using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamsMVC.Filters
{
    public class IndexException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is IndexOutOfRangeException)
            {
                filterContext.Result = new RedirectResult("IndexExceptions.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}