using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UnitTestsWorkshop.DragAndDrop
{
    /// <summary>
    /// To populate the tree view with excersize data
    /// </summary>
    internal static class TreeViewSampleData
    {
        internal static TreeNode[] CreateSampleData()
        {
           var names = new List<string>()
            {
                "MMM",
                "HelloA",
                "HelloK",
                "HelloP"
            };

            return names.Select(name => new TreeNode(name)).ToArray();
        }
    }
}
