using System.Windows.Forms;

namespace UnitTestsWorkshop.DragAndDrop
{
    public partial class TreeViewForm : Form
    {
        private TreeViewDragDrop dragDrop;

        public TreeViewForm()
        {
            InitializeComponent();

            this.treeView.Nodes.AddRange(TreeViewSampleData.CreateSampleData());

            // typical usage of dragdrop event handlers
            //this.treeView.DragOver += TreeView_DragOver;
            //this.treeView.DragDrop += TreeView_DragDrop;
            //this.treeView.ItemDrag += TreeViewOnItemDrag;
            
            // example usage of the dragdrop controller
            this.dragDrop = new TreeViewDragDrop(this.treeView);
        }
    }
}
