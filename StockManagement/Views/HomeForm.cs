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
            // Fill product list
            products = DBHelper.GetProducts();
            ProductListBox.Items.AddRange(products.ToArray());

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
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
