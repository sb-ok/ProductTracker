using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductTracker.ProductStructure;
using ProductTracker.Properties;
using ProductTracker.Forms;

namespace ProductTracker.Forms
{
    public partial class ProductList : Form
    {
        private ProductTrackerEntities db = new ProductTrackerEntities();

        private void ShowNoodFunction()
        {
            delProdButton.Visible = true;
            createButton.Visible = false;
            createLabel.Visible = false;
            createProductName.Visible = false;
        }

        private void ShowRootFunction()
        {
            delProdButton.Visible = false;
            createButton.Visible = true;
            createLabel.Visible = true;
            createProductName.Visible = true;
        }

        public ProductList()
        {
            InitializeComponent();
            TreeRefresh();
        }

        public void TreeRefresh()
        {
            treeOfProduct.Nodes.Add(Resources.Изделия);

            var query = from prod in db.product
                where prod.productType.typeName == Resources.productType_Изделие
                select prod.name;

            foreach (var prod in query)
            {
                treeOfProduct.Nodes[0].Nodes.Add(prod);


            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int typeId = 0;
            var query = from prodType in db.productType
                        where prodType.typeName == Resources.productType_Изделие
                        select prodType.typeID;

            foreach (var id in query)
            {
                typeId = id;
            }

            var product = new product()
            {
                name = createProductName.Text,
                typeID = typeId
            };

            db.product.Add(product);
            db.SaveChanges();
            treeOfProduct.Nodes[0].Nodes.Add(createProductName.Text);
            createProductName.Text = null;
        }

        private void treeOfProduct_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeOfProduct.SelectedNode.Parent != null)
            {
                ShowNoodFunction();
            }
            else
            {
                ShowRootFunction();
            }

        }

        private void delProdButton_Click(object sender, EventArgs e)
        {
            var delTarget = treeOfProduct.SelectedNode;

            using (var context = new ProductTrackerEntities())
            {
                try
                {
                    var delProd = context.product.First(product => product.name.Equals(delTarget.Text));
                    context.product.Remove(delProd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            treeOfProduct.Nodes.Remove(delTarget);
        }
    }
}
