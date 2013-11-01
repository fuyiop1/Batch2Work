using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Batch2Work.Helpers;
using Batch2Work.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Batch2Work.Controllers
{

    public class HomeController : Controller
    {
        private const string INDEX_MODEL_KEY = "IndexModelKey";

        public ActionResult Index()
        {
            CheckInitialised();
            return View(IndexModel);
        }

        public ActionResult Tree()
        {
            var indexModel = IndexModel;
            indexModel.SelectTreeView();
            return View("Index", indexModel);
        }

        public ActionResult Viewer()
        {
            var indexModel = IndexModel;
            indexModel.SelectViewerView();
            return View("Index", indexModel);
        }

        public ActionResult Modal()
        {
            var indexModel = IndexModel;
            indexModel.SelectModalView();
            return View("Index", indexModel);
        }

        private IndexModel IndexModel
        {
            get
            {
                var item = System.Web.HttpContext.Current.Session[INDEX_MODEL_KEY];
                if (item != null)
                    return (IndexModel)item;

                var indexModel = new IndexModel();
                System.Web.HttpContext.Current.Session[INDEX_MODEL_KEY] = indexModel;
                return indexModel;

            }
        }

        private void CheckInitialised()
        {
            Uri linkUri = HttpContext.Request.Url;
            if (linkUri.Port != 80 && linkUri.Port != 443)
                System.Web.HttpContext.Current.StoreRootUrl(string.Format("{0}://{1}:{2}", linkUri.Scheme, linkUri.Host, linkUri.Port));
            else
                System.Web.HttpContext.Current.StoreRootUrl(string.Format("{0}://{1}", linkUri.Scheme, linkUri.Host));
        }
    }

}
