using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProductTracker.Forms;
using ProductTracker.Properties;

namespace ProductTracker.ProductStructure
{
    public partial class AdministrationWindows : Form
    {

        internal User EnteredUser = new User();
        public TreeNode AddTarget = new TreeNode();
        protected TreeNode TargetNode;
        ImageList ImgList = new ImageList();

        private void createImageList()
        {
            ImgList.ImageSize = new Size(18, 18);
            ImgList.Images.Add(Resources.uzel);
            ImgList.Images.Add(Resources.sborka);
            ImgList.Images.Add(Resources.detail);
            ImgList.Images.Add(Resources.technology);
            ImgList.Images.Add(Resources._default);
        }
        
        
        // закоментил для отладочных запусков
        public AdministrationWindows(/*User user*/)
        {
            InitializeComponent();
            //_enteredUser = user;
            //userStatus.Text = Resources.AutorisationForm_Пользователь + user.Fio;

            createImageList();
            specTree.ImageList = ImgList;

            // Добавляет изделия в список продуктов
            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var querytypeId = from prodType in context.productType
                                      where prodType.typeName == Resources.productType_Изделие
                                      select prodType.typeID;

                    int typeId = 0;

                    foreach (var id in querytypeId.Take(1))
                    {
                        typeId = id;
                    }

                    var queryProdName = from prod in context.product
                                        where prod.typeID == typeId
                                        select prod.name;

                    foreach (var prod in queryProdName)
                    {
                        productSelector.Items.Add(prod);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            

            specTree.HideSelection = false;
            
        }

        void specTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            specTree.SelectedNode = e.Node;
         //   nodeContextMenu.Show(specTree, e.Location);
        }

        private void OpenConfigurator_Click(object sender, EventArgs e)
        {
            var conf = new Configurator();
            conf.ShowDialog();
        }

        private void productListMenu_Click(object sender, EventArgs e)
        {
            var productList = new ProductList();
            productList.ShowDialog();
        }

        // Метод - выстраивает дерево элементов выбранного изделия
        public void ExpandProductTree(int productId, string productName)
        {
            specTree.Nodes.Clear();
            var mainNode = new TreeNode(productName);
            mainNode = AddNodeChild(mainNode, productId);
            specTree.Nodes.Add(mainNode);
        }

        // Метод добавляет к родительскому элементу дочерние. Определеяет картинки объекта.
        public TreeNode AddNodeChild(TreeNode parentNode, int parentId)
        {
            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var childList = from child in context.productTree
                                    where child.parentID == parentId
                                    select child.product;

                    foreach (var child in childList)
                    {
                        var childNode = new TreeNode(child.name);
                        switch (child.typeID)
                        {
                            case 2:
                                childNode.ImageIndex = 0;
                                childNode.SelectedImageIndex = 0;
                                break;
                            case 5:
                                childNode.ImageIndex = 1;
                                childNode.SelectedImageIndex = 1;
                                break;
                            case 6:
                                childNode.ImageIndex = 2;
                                childNode.SelectedImageIndex = 2;
                                break;
                            case 7:
                                childNode.ImageIndex = 3;
                                childNode.SelectedImageIndex = 3;
                                break;
                            default:
                                childNode.ImageIndex = 4;
                                childNode.SelectedImageIndex = 4;
                                break;
                        }
                        childNode.Tag = child.typeID;
                        childNode = AddNodeChild(childNode, child.id);
                        parentNode.Nodes.Add(childNode);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return parentNode;
        }

        // Кнопка добавления нового элемента дерева
        private void addNodeButton_Click(object sender, EventArgs e)
        {
            if (specTree.SelectedNode == null) return;
            var addWin = new AddObjInTree(specTree.SelectedNode);
            addWin.ShowDialog();
            AddTarget.Nodes.Add(addWin.AddProduct);
        }

        // По кнопке поиск строим дерево на основе выбранного объекта
        private void searchButton_Click(object sender, EventArgs e)
        {
            ExpandTree();
        }

        // Метод построения дерева выбранного объекта в ComboBox
        public void ExpandTree()
        {
            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var idInTree = from prod in context.product
                                   where prod.name == productSelector.Text
                                   select prod.id;
                    foreach (var id in idInTree.Take(1))
                    {
                        ExpandProductTree(id, productSelector.Text);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            specTree.CollapseAll();
        }

        // Действия при выделении элемента дерева
        private void specTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AddTarget = specTree.SelectedNode;
        }

        // Кнопка удаления элемента дерева
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var delTarget = specTree.SelectedNode;

            if (delTarget == null) return;

            if (delTarget.Parent == null)
            {
                MessageBox.Show(Resources.AdministrationWindows_deleteButton_Click_Для_удаления_изделия_воспользуйтесь_меню_Журнал_изделий);
                return;
            }

            if (delTarget.Nodes.Count != 0)
            {
                var delForm = new DeleteFromTree();
                DialogResult dr = delForm.ShowDialog();
                if (dr == DialogResult.Cancel) return;
            }

            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var delProduct = context.product.First(product => product.name == delTarget.Text);
                    if (delProduct.typeID.Equals(delTarget.Tag))
                    {
                        var prodInTree = delProduct.productTree;

                        context.productTree.Remove(prodInTree);
                        context.SaveChanges();
                        context.product.Remove(delProduct);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            specTree.Nodes.Remove(delTarget);
        }

        // Переименование объекта
        private void editBtn_Click(object sender, EventArgs e)
        {
            TargetNode = specTree.SelectedNode;
            specTree.LabelEdit = true;
            specTree.SelectedNode.BeginEdit();
        }

        // Для обеспечения работоспособности переименования объекта
        private void specTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                e.Node.EndEdit(false);
            }

            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var renameProduct = context.product.First(product => product.name == TargetNode.Text);
                    if (renameProduct != null)
                    {
                        renameProduct.name = e.Label;
                       /* renameProduct.id = renameProduct.id;
                        renameProduct.productAttribute = renameProduct.productAttribute;
                        renameProduct.productTree = renameProduct.productTree;
                        renameProduct.productType = renameProduct.productType;
                        renameProduct.typeID = renameProduct.typeID;*/
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
    }
}



/* Удаление выделенных объектов дерева
private List<TreeNode> ckeckedNodes = new List<TreeNode>();
private void RemoveCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    ckeckedNodes.Add(node);
                }
                else
                {
                    RemoveCheckedNodes(node.Nodes);
                }
            }

            foreach (TreeNode ckeckedNode in ckeckedNodes)
            {
                nodes.Remove(ckeckedNode);
            }
        }

*/