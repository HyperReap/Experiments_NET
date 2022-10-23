using System.Windows.Forms;

namespace UnitTestsWorkshop.DragAndDrop
{
    internal class TreeViewDragDrop
    {
        private readonly TreeView treeView;
        private const DragDropEffects SUPPORTED_DROPS = DragDropEffects.All;
        private TreeNode draggedItem;

        internal TreeViewDragDrop(TreeView treeView)
        {
            this.treeView = treeView;
            this.treeView.DragOver += TreeView_DragOver;
            this.treeView.DragDrop += TreeView_DragDrop;
            this.treeView.ItemDrag += TreeViewOnItemDrag;
        }

        private void TreeViewOnItemDrag(object sender, ItemDragEventArgs e)
        {
            this.draggedItem = e.Item as TreeNode;
            if (SelectDropAction() == DragDropEffects.Move)
                this.treeView.DoDragDrop(e.Item, SUPPORTED_DROPS);
        }

        private void TreeView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = SelectDropAction();
        }

        private void TreeView_DragDrop(object sender, DragEventArgs e)
        {
            // todo provide action to take place for drop
        }

        private DragDropEffects SelectDropAction()
        {
            if (this.draggedItem != null && this.draggedItem.Text.StartsWith("Hello"))
                return DragDropEffects.Move;

            return DragDropEffects.None;
        }
    }
}