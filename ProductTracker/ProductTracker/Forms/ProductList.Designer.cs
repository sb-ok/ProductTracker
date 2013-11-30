namespace ProductTracker.Forms
{
    partial class ProductList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.delProdButton = new System.Windows.Forms.ToolStripButton();
            this.treeOfProduct = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.productInformation = new System.Windows.Forms.GroupBox();
            this.createLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.createProductName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.productInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.treeOfProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 444);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 22);
            this.panel3.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delProdButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(281, 22);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // delProdButton
            // 
            this.delProdButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delProdButton.Image = global::ProductTracker.Properties.Resources.dellButton;
            this.delProdButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delProdButton.Name = "delProdButton";
            this.delProdButton.Size = new System.Drawing.Size(23, 19);
            this.delProdButton.Text = "toolStripButton2";
            this.delProdButton.Visible = false;
            this.delProdButton.Click += new System.EventHandler(this.delProdButton_Click);
            // 
            // treeOfProduct
            // 
            this.treeOfProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeOfProduct.Location = new System.Drawing.Point(0, 25);
            this.treeOfProduct.Name = "treeOfProduct";
            this.treeOfProduct.Size = new System.Drawing.Size(281, 419);
            this.treeOfProduct.TabIndex = 0;
            this.treeOfProduct.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOfProduct_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(281, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 444);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.productInformation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(284, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 444);
            this.panel2.TabIndex = 2;
            // 
            // productInformation
            // 
            this.productInformation.Controls.Add(this.createLabel);
            this.productInformation.Controls.Add(this.createButton);
            this.productInformation.Controls.Add(this.createProductName);
            this.productInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productInformation.Location = new System.Drawing.Point(0, 0);
            this.productInformation.Name = "productInformation";
            this.productInformation.Size = new System.Drawing.Size(257, 444);
            this.productInformation.TabIndex = 0;
            this.productInformation.TabStop = false;
            this.productInformation.Text = "Дейтсвия";
            // 
            // createLabel
            // 
            this.createLabel.AutoSize = true;
            this.createLabel.Location = new System.Drawing.Point(6, 20);
            this.createLabel.Name = "createLabel";
            this.createLabel.Size = new System.Drawing.Size(158, 13);
            this.createLabel.TabIndex = 2;
            this.createLabel.Text = "Введите имя нового изделия:";
            this.createLabel.Visible = false;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(151, 66);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(93, 23);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Создать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Visible = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // createProductName
            // 
            this.createProductName.Location = new System.Drawing.Point(6, 40);
            this.createProductName.Name = "createProductName";
            this.createProductName.Size = new System.Drawing.Size(238, 20);
            this.createProductName.TabIndex = 0;
            this.createProductName.Visible = false;
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 444);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал изделий";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.productInformation.ResumeLayout(false);
            this.productInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox productInformation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton delProdButton;
        public System.Windows.Forms.TreeView treeOfProduct;
        private System.Windows.Forms.Label createLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox createProductName;
    }
}