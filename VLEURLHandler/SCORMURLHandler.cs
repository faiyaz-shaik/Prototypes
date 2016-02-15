using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace VLEHttpModule
{
    public class SCORMURLHandler : IHttpModule
    {
        public void Dispose()
        {
           
        }
         
        public void Init(HttpApplication context)
        {
            context.BeginRequest +=
            (new EventHandler(this.Application_BeginRequest));
            context.EndRequest +=
                (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source,
         EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;


            Uri currentUrl = context.Request.Url;

            if (currentUrl.AbsolutePath.ToLower().Contains("/scorm"))
            {
                context.Response.Redirect("");
            }


            //string filePath = context.Request.FilePath;




            //string fileExtension =
            //    VirtualPathUtility.GetExtension(filePath);
            //if (fileExtension.Equals(".aspx"))
            //{
            //    context.Response.Write("<h1><font color=red>" +
            //        "HelloWorldModule: Beginning of Request" +
            //        "</font></h1><hr>");
            //}
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            //HttpApplication application = (HttpApplication)source;
            //HttpContext context = application.Context;
            //string filePath = context.Request.FilePath;
            //string fileExtension =
            //    VirtualPathUtility.GetExtension(filePath);
            //if (fileExtension.Equals(".aspx"))
            //{
            //    context.Response.Write("<hr><h1><font color=red>" +
            //        "HelloWorldModule: End of Request</font></h1>");
            //}
        }
    }
}
