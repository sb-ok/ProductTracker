using System;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using ProductTracker.ProductStructure;
using ProductTracker.Properties;

namespace ProductTracker.Forms
{
    public partial class AddObjInTree : Form
    {
        AdministrationWindows aw = new AdministrationWindows();
        TreeNode addTarget = new TreeNode();
        public TreeNode AddProduct = new TreeNode(); 

        // Инициализация формы
        public AddObjInTree(TreeNode target)
        {
            InitializeComponent();
            addTarget = target;

            // Добавдяет типы объектов дерева в выпадуху создания нового объекта
            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var query = from type in context.productType
                                where type.rootType == 0
                                select type.typeName;
                    foreach (var tname in query)
                    {
                        createTypeChose.Items.Add(tname);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            
        }

        // Создает дочерний объект к выбранному объекту дерева
        private void createButton_Click(object sender, EventArgs e)
        {
            if (createTypeChose.Text == String.Empty)
            {
                MessageBox.Show(Resources.AdministrationWindows_createNewButton_Click_Тип_элемента_не_выбран,
                    Resources.error_operation_msg);
                return;
            }

            if (createNameBox.Text == String.Empty)
            {
                MessageBox.Show(Resources.AdministrationWindows_createNewButton_Click_Не_указано_имя_объекта,
                    Resources.error_operation_msg);
                return;
            }

            var newProduct = new product();

            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var query = from type in context.productType
                                where type.typeName == createTypeChose.Text
                                select type.typeID;
                    
                    foreach (var type in query.Take(1))
                    {
                        newProduct.name = createNameBox.Text;
                        newProduct.typeID = type;
                        foreach (TreeNode node in addTarget.Nodes)
                        {
                            if (node.Text.Equals(createNameBox.Text) && node.Tag.Equals(newProduct.typeID))
                            {
                                MessageBox.Show(Resources.AdministrationWindows_createNewButton_Click_Такой_элемент_уже_создан_в_структуре_);
                                return;
                            }
                        }

                    }

                    context.product.Add(newProduct);
                    context.SaveChanges();

                    var queryProd = from pr in context.product
                                    where pr.name == addTarget.Text
                                    select pr;
                    var parent = new product();

                    foreach (var p in queryProd.Take(1))
                    {
                        parent = p;
                    }

                    var pt = new productTree
                    {
                        productID = newProduct.id,
                        parentID = parent.id,
                        product = newProduct
                    };

                    context.productTree.Add(pt);
                    context.SaveChanges();
                }
                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }
            }
            aw.ExpandTree();
            Close();
            AddProduct.Text = newProduct.name;
            AddProduct.Tag = newProduct.typeID;
        }

    }
}
