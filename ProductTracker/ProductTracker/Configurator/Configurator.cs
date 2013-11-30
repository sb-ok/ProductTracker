using System;
using System.Drawing;
using System.Windows.Forms;
using ProductTracker.Properties;


namespace ProductTracker.Forms
{
    public partial class Configurator : Form
    {
        private ProductTrackerEntities db = new ProductTrackerEntities();
        readonly DbCofigurator _dbConnection = new DbCofigurator();

        // отображает элементы работы с корневыми типами конфигуратора
        private void ShowNoodFunction()
        {
            removeButton.Visible = true;
            removeHelp.Visible = true;
            renameButton.Visible = true;
            renameHelp.Visible = true;
            renameTextBox.Visible = true;
            renameTextBox.Text = confTree.SelectedNode.Text;
            createNewObjButton.Visible = false;
            createNewObjText.Visible = false;
            createObjText.Visible = false;
            rootType.Visible = false;
        }

        // Отображает элементы работы с объектами
        private void HideNoodFunction()
        {
            removeButton.Visible = false;
            removeHelp.Visible = false;
            renameButton.Visible = false;
            renameHelp.Visible = false;
            renameTextBox.Visible = false;
            createNewObjButton.Location = new Point(203, 42);
            createNewObjText.Location = new Point(14, 15);
            createObjText.Location = new Point(14, 46);
            rootType.Location = new Point(14, 77);
            createNewObjButton.Visible = true;
            createNewObjText.Visible = true;
            createObjText.Visible = true;
            rootType.Visible = true;
        }

        // Метод выстраивает дерево
        private void BuildTree()
        {
            confTree.Nodes.Add(Resources.Configurator_Типы_объектов);
            confTree.Nodes.Add(Resources.Configurator_Атрибуты_объектов);
            foreach (string objType in _dbConnection.TypeList())
            {
                confTree.Nodes[0].Nodes.Add(objType);
            }
            foreach (string productAttribute in _dbConnection.ProductAttributeList())
            {
                confTree.Nodes[1].Nodes.Add(productAttribute);
            }
        }
        
        // Инициализация конструктора
        public Configurator()
        {
            InitializeComponent();
            BuildTree();
        }

        // Управление видимостью элементов работы с деревом конфигуратора
        private void confTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (confTree.SelectedNode.Parent != null)
            {
                ShowNoodFunction();
            }
            else
            {
                HideNoodFunction();
            }

        }

        // Кнопка переименования объектов конфигуратора в базе
        private void renameButton_Click(object sender, EventArgs e)
        {
            if (confTree.SelectedNode.Parent.Text == Resources.Configurator_Типы_объектов)
            {
                _dbConnection.RenameProductType(renameTextBox.Text, confTree.SelectedNode.Text);
                confTree.SelectedNode.Text = renameTextBox.Text;
            }
            else
            {
                if (confTree.SelectedNode.Parent.Text == Resources.Configurator_Атрибуты_объектов)
                {
                    _dbConnection.RenameProductAttribute(renameTextBox.Text, confTree.SelectedNode.Text);
                    confTree.SelectedNode.Text = renameTextBox.Text;
                }
            }
            
        }

        // Кнопка создания нового объекта конфигуратора
        private void createNewObjButton_Click(object sender, EventArgs e)
        {
            if (confTree.SelectedNode.Text == Resources.Configurator_Типы_объектов)
            {
                if (_dbConnection.ProductTypeThere(createObjText.Text))
                {
                    MessageBox.Show(Resources.Configurator_Указанный_тип_уже_существует, Resources.error_operation_msg);
                }
                else
                {
                    int isRooted = 0;
                    if (rootType.Checked)
                    {
                        isRooted = 1;
                    }
                      var productType = new productType()
                      {
                          typeName = createObjText.Text,
                          rootType = isRooted
                      };
                      db.productType.Add(productType);
                      db.SaveChanges();
                      confTree.Nodes[0].Nodes.Add(createObjText.Text);
                      createObjText.Text = null;
                      rootType.CheckState = CheckState.Unchecked;
                    
                }
            }
            else
            {
                if (confTree.SelectedNode.Text == Resources.Configurator_Атрибуты_объектов)
                {
                    if (_dbConnection.ProductAttributeThere(createObjText.Text))
                    {
                        MessageBox.Show(Resources.Configurator_Указанный_атрибут_уже_существует, Resources.error_operation_msg);
                    }
                    else
                    {
                        _dbConnection.CreateAttribute(createObjText.Text);
                        confTree.Nodes[1].Nodes.Add(createObjText.Text);
                        createObjText.Text = null;
                    }
                }
            }

        }

        // Кнопка удаления объекта конфигуратора из базы
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (confTree.SelectedNode.Parent.Text == Resources.Configurator_Типы_объектов)
            {
                _dbConnection.RemoveProductType(confTree.SelectedNode.Text);
                confTree.Nodes.Remove(confTree.SelectedNode);
                renameTextBox.Text = null;
                confTree.Select();
            }
            else
            {
                if (confTree.SelectedNode.Parent.Text == Resources.Configurator_Атрибуты_объектов)
                {
                    _dbConnection.RemoveProductAttribute(confTree.SelectedNode.Text);
                    confTree.Nodes.Remove(confTree.SelectedNode);
                    renameTextBox.Text = null;
                    confTree.Select();
                }
            }
        }
        
    }

}


/* Пример использования dataGridView
InitializeComponent();
            typeList.ReadOnly = true;
            typeList.ColumnCount = 1;
            typeList.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            typeList.RowHeadersVisible = false;

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            typeList.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            typeList.Columns[0].Name = "test";
            typeList.Rows.Add("Тип объекта");
 
 
 
 */
