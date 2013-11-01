using System.Web;

namespace Batch2Work.Helpers
{
    public static class HttpContextExt
    {
        
        public static void StoreRootUrl(this HttpContext httpContext, string rootUrl)
        {
            httpContext.Session["RootUrl"] = rootUrl;
        }

        public static string GetRootUrl(this HttpContext httpContext)
        {
            return httpContext.Session["RootUrl"].ToString();
        }
    }
}