using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsWorkshop.DragAndDrop;

namespace Tests.DragAndDrop
{
    [TestClass]
    public class TreeViewDragDropTests
    {
        private TestTreeView treeView;
        private TreeViewDragDrop dragDrop;
        private TreeNode mmNode;
        private TreeNode helloANode;

        [TestInitialize]
        public void TestSetup()
        {
            this.treeView = new TestTreeView();
            // configure the dragdrop field here
            this.treeView.Nodes.AddRange(TreeViewSampleData.CreateSampleData());
            this.mmNode = this.treeView.Nodes[0];
            this.helloANode = this.treeView.Nodes[1];
        }
        
        // Todo test the drag drop
        [TestMethod]
        public void DragNodeStartingWithHello_AllowsMoveDropEffect()
        {
            var dragArgs = new ItemDragEventArgs(MouseButtons.Left, this.helloANode);
            // simaulate drag item here
            DragEventArgs dragOverArgs = CreateDropArguments(this.mmNode);
            // simulate dragover here
            const string assertMessage = "Cant DragOver, if the dragged node doesnt start with 'Hello' prefix";
            Assert.AreEqual(DragDropEffects.Move, dragOverArgs.Effect, assertMessage);
        }

        private static DragEventArgs CreateDropArguments(TreeNode source)
        {
            var data = new DataObject(source);
            // location is not relevant
            return new DragEventArgs(data, 0, 0, 0, DragDropEffects.All, DragDropEffects.None);
        }
    }
}
