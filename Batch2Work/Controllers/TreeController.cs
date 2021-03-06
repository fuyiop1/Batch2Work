﻿using System.Globalization;
using System.Web.Mvc;
using Batch2Work.Helpers;
using Batch2Work.Models;

namespace Batch2Work.Controllers
{
    public class TreeController : Controller
    {
        private const string TREE_MODEL_KEY = "TreeModel";

        public virtual ActionResult GetTreeContents()
        {
            return View("Index", TreeModel);
        }

        public virtual ActionResult Details(int id)
        {
            return View("Details", new DetailsModel {Header = id.ToString(CultureInfo.InvariantCulture)});
        }

        private TreeModel TreeModel
        {
            get
            {
                var item = System.Web.HttpContext.Current.Session[TREE_MODEL_KEY];
                if (item != null)
                    return (TreeModel)item;

                var treeModel = SampleDataHelper.GenerateTreeModel();
                System.Web.HttpContext.Current.Session[TREE_MODEL_KEY] = treeModel;
                return treeModel;

            }
        }
    }
}
