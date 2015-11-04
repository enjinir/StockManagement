using DatabaseHelper;
using DatabaseHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Views
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }
        
        List<Product> products;
        List<User> users;

        private void HomeForm_Load(object sender, EventArgs e)
        {
           RefreshProducts();

            // Fill users combobox
            users = DBHelper.GetUsers();
            OwnerComboBox.Items.AddRange(users.ToArray());
        }

        private void ProductListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = (Product) ProductListBox.SelectedItem;

            ProductNameTextBox.Text = selectedProduct.Name;
            ProductNameLabel.Text = selectedProduct.Name;
            OwnerLabel.Text = selectedProduct.OwnerName;

            // Set default owner in combobox
            foreach (User u in OwnerComboBox.Items)
            {
                if (u.UserId == selectedProduct.OwnerId)
                {
                    OwnerComboBox.SelectedItem = u;
                    break;
                }
            }

            // Get count information
            StockInfo stockInfo = DBHelper.GetStockInfo(selectedProduct);

            if (stockInfo != null)
            {
                ProductCount.Value = stockInfo.Count;
            }
            else
            {
                ProductCount.Value = 0;
            }
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateStockButton_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)ProductListBox.SelectedItem;
            if (selectedProduct != null)
            {
                int count = (int)ProductCount.Value;
                DBHelper.UpdateStock(selectedProduct, count);
            }

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string name = ProductNameTextBox.Text;
            User owner = (User)OwnerComboBox.SelectedItem;
            Product product = new Product() 
            { 
                Name = name,
                OwnerId = owner.UserId

            };
            bool created = DBHelper.CreateProduct(product);
            if (created)
            {
                RefreshProducts();
            }
        }

        private void RefreshProducts()
        {
            Product previouslySelectedProduct = (Product)ProductListBox.SelectedItem;

            products = DBHelper.GetProducts();
            ProductListBox.Items.Clear();
            ProductListBox.Items.AddRange(products.ToArray());

            if (previouslySelectedProduct != null)
            {
                Product productToSelect = products.Where(p => p.ProductId == previouslySelectedProduct.ProductId).FirstOrDefault();
                if (productToSelect != null)
                {
                    ProductListBox.SelectedItem = productToSelect;
                } 
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)ProductListBox.SelectedItem;
            if (selectedProduct!=null)
            {
                selectedProduct.Name = ProductNameTextBox.Text;
                selectedProduct.OwnerId = ((User)OwnerComboBox.SelectedItem).UserId;
                bool updated = DBHelper.UpdateProduct(selectedProduct);

                if (updated)
                {
                    RefreshProducts();
                } 
            }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)ProductListBox.SelectedItem;
            if (selectedProduct != null)
            {
                bool deleted = DBHelper.DeleteProduct(selectedProduct);

                if (deleted)
                {
                    RefreshProducts();
                }
            }

        }
    }
}
