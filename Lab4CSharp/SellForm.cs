using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4CSharp
{
    public partial class SellForm : Form
    {
        public SellForm(StoreDB2 db, int productIdentifier)
        {
            InitializeComponent();
            _db = db;
            this.productIdentifier = productIdentifier;
            this.Load += SellForm_Load;
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
            sell.Enabled = false;
            bool error = false;

            Task.Run(() =>
            {
                string result = "";
                try
                {
                    _product = _db.Products.FirstOrDefault(p => p.ProductID == this.productIdentifier);

                    if (_product == null)
                    {
                        result = "Product not found.";
                    }
                }
                catch (Exception ex)
                {
                    result = "Could not load product: " + ex.Message;
                    error = true;
                }
                this.Invoke((MethodInvoker)(() =>
                {
                    if(result != "")
                        MessageBox.Show(result);
                    if(error)
                    {
                        this.Close();
                        return;
                    }
                    comboBox1.Items.Clear();
                    for (int i = 1; i <= _product.Quantity; i++)
                        comboBox1.Items.Add(i);

                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                        sell.Enabled = true;
                    }
                    
                }));
            });
        }

        private void sell_Click(object sender, EventArgs e)
        {
            if (_product == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a quantity.");
                return;
            }
            string result = "";
            sell.Enabled = false;
            _product.Quantity -= (int)comboBox1.SelectedItem;
            Task.Run(() => {
                if (_product.Quantity == 0)
                {
                    _db.Products.Remove(_product);
                } else
                {
                    _db.Entry(_product).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    _db.SaveChanges();
                    result = "Product(s) sold!";
                } catch (Exception ex){
                    _product.Quantity += (int)comboBox1.SelectedItem;
                    result = ex.Message;
                }
                this.Invoke((MethodInvoker)(() => {
                    if(result != "")
                        MessageBox.Show(result);
                    sell.Enabled = true;
                }));
            });
            
        }
    }
}
