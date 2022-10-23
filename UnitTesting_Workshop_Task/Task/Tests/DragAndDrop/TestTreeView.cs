using System.Windows.Forms;

namespace Tests.DragAndDrop
{
    /// <summary>
    /// Wrapped tree view to be able test UI from unit test.
    /// Trick is, that child class sees OnXXX methods, which can fire events.
    /// </summary>
    internal class TestTreeView : TreeView
    {
        internal void FireItemDrag(ItemDragEventArgs args)
        {
            base.OnItemDrag(args);
        }

        internal void FireOnDragOver(DragEventArgs args)
        {
            base.OnDragOver(args);
        }

        internal void FireOnDragDrop(DragEventArgs args)
        {
            base.OnDragDrop(args);
        }
    }
}