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
    public partial class ModifyProduct : Form
    {
        public ModifyProduct(StoreDB2 db)
        {
            InitializeComponent();
            _db = db;
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void update_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            int productId = 0;
            try
            {
                quantity = int.Parse(addQuantity.Text);
                productId = int.Parse(productIdentifier.Text);
            } catch(FormatException except)
            {
                MessageBox.Show("Invalid arguments!");
                return;
            }
            if(quantity < 0)
            {   
                MessageBox.Show("Quantity cannot be negative.");
                return;
            }
            Task.Run(() =>
            {
                var product = _db.Products.Find(productId);
                string result = "";
                if (product != null)
                {
                    product.Quantity += quantity;
                    _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    result = "Product updated successfully.";

                }
                else
                {
                    result = "Product not found.";
                }
                this.Invoke((MethodInvoker)(() =>
                {
                    if(result != "")
                    MessageBox.Show(result);
                    update.Enabled = true;
                }));
            });
        }
    }
}
