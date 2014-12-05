using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SharedClasses.Extensions
{
    public static class TreeNodeCollectionExtensions
    {
        public static IEnumerable<TreeNode> Where(this TreeNodeCollection collection, Func<TreeNode, bool> predicate)
        {
            return collection.Where(predicate);
        }
    }
}