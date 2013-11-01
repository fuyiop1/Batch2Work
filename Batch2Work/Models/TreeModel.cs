using System.Collections.Generic;

namespace Batch2Work.Models
{
    public class TreeModel
    {
        public TreeModel(TreeNode rootNode)
        {
            RootNode = rootNode;
        }

        public TreeNode RootNode{ get; set; }

        public IList<TreeNode> RootNodes
        {
            get
            {
                return new List<TreeNode> {RootNode};
            }
        }
    }

    public class TreeNode
    {
        private readonly IDictionary<int, TreeNode> _childNodes = new Dictionary<int, TreeNode>();

        public TreeNode(int id, string name, string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string ImageUrl { get; private set; }

        public IList<TreeNode> ChildNodes
        {
            get
            {
                return new List<TreeNode>(_childNodes.Values);
            }
        }

        public void AddChildNode(TreeNode treeNode)
        {
            _childNodes.Add(treeNode.Id, treeNode);
        }

    }
}