using System.Collections.Generic;
using System.Linq;
using Batch2Work.Helpers;

namespace Batch2Work.Models
{
    public class NavItem
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string PartialView { get; set; }
    }

    public class IndexModel
    {
        private NavItem _selectedNavItem;

        public const string ViewNameTree = "Tree";
        public const string ViewNameViewer = "Viewer";
        public const string ViewNameModal = "Modal";

        public IndexModel()
        {
            NavItems = new List<NavItem>
                           {
                               new NavItem() { Name = ViewNameTree, ActionName = "Tree", PartialView = "_TreeSplitView" },
                               new NavItem() { Name = ViewNameViewer, ActionName = "Viewer", PartialView = "_ViewerView" },
                               new NavItem() { Name = ViewNameModal, ActionName = "Modal", PartialView = "_ModalView" }
                           };
            SelectTreeView();
        }

        
        public bool ViewIsTree()
        {
            return _selectedNavItem.Name == ViewNameTree;
        }

        public bool ViewIsViewer()
        {
            return _selectedNavItem.Name == ViewNameViewer;
        }

        public bool ViewIsModal()
        {
            return _selectedNavItem.Name == ViewNameModal;
        }

        public void SelectTreeView()
        {
            ConfigureAllNavItems();
            var item = NavItems.First(x => x.Name == ViewNameTree);
            item.IsSelected = true;
            _selectedNavItem = item;
            ViewModel = null;
        }

        public void SelectViewerView()
        {
            ConfigureAllNavItems();
            var item = NavItems.First(x => x.Name == ViewNameViewer);
            item.IsSelected = true;
            _selectedNavItem = item;

            ViewModel = new ViewerModel(GetFileUrl("Content/sample.dwg"));
        }

        public void SelectModalView()
        {
            ConfigureAllNavItems();
            var item = NavItems.First(x => x.Name == ViewNameModal);
            item.IsSelected = true;
            _selectedNavItem = item;
            ViewModel = null;
        }

        public string PartialView
        {
            get { return _selectedNavItem.PartialView; }
        }

        public object ViewModel { get; set; }

        public List<NavItem> NavItems { get; set; }

        private void ConfigureAllNavItems()
        {
            foreach (var navItem in NavItems)
                navItem.IsSelected = false;
        }

        private string GetFileUrl(string relativePath)
        {
            string rootUrl = System.Web.HttpContext.Current.GetRootUrl().NormaliseUrl();
            string ret = rootUrl + relativePath;
            return ret.Replace(@"\", "/");
        }
    }
}