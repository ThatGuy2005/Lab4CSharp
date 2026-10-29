using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4CSharp
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            // Read and validate the controls on the GUI thread
            int qty;
            if (!int.TryParse(quantity.Text, out qty) || qty < 0)
            {
                MessageBox.Show("Invalid input format. Please check your entries.");
                return;
            }

            var product = new Products
            {
                ProductName = productName.Text,
                ProductDescription = productDescription.Text,
                StoreEntryDate = arrivalDate.Value,
                ExpirationDate = expirationDate.Value,
                Quantity = qty
            };

            add.Enabled = false;

            Task.Run(() =>
            {
                string result;
                try
                {
                    using (var db = new StoreDB2())   // lives exactly as long as the work
                    {
                        db.Products.Add(product);
                        db.SaveChanges();
                    }
                    result = "Product added successfully!";
                }
                catch (Exception ex)
                {
                    result = "An error occurred while adding the product: " + ex.GetBaseException().Message;
                }

                this.Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show(result);
                    add.Enabled = true;
                }));
            });
        }
    }
}
