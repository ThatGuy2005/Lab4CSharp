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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _db = new StoreDB2();
            addProductForm = new AddProduct();
            addProductForm.Hide();
            modifyProductForm = new ModifyProduct(_db);
            modifyProductForm.Hide();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadProductsAsync();
        }
        private void LoadProductsAsync()
        {
            UseWaitCursor = true;   // UI thread

            Task.Run(() =>
            {
                string error = null;
                try
                {
                    _db.Database.Initialize(force: false);   // opens connection, builds model
                    _db.Products.Load();                     // loads rows into _db.Products.Local
                }
                catch (Exception ex)
                {
                    error = ex.GetBaseException().Message;
                }

                // Notify the GUI thread with the result
                this.Invoke((MethodInvoker)(() =>
                {
                    if (error != null)
                        MessageBox.Show(error, "Could not load products");
                    else
                        dataGridView1.DataSource = _db.Products.Local.ToBindingList();

                    UseWaitCursor = false;
                }));
            });
        }
        private void addProduct_Click(object sender, EventArgs e)
        {

        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddProduct())
                form.ShowDialog();
            LoadProductsAsync();
        }

        private  void Refreash_Click(object sender, EventArgs e)
        {
            LoadProductsAsync();
        }

        private void modifyProductQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new ModifyProduct(_db))
                form.ShowDialog();
            LoadProductsAsync();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // header row

            var value = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            if (value == null) return;    // empty "new row" at the bottom

            int productIdentifier = Convert.ToInt32(value);
            using (var form = new SellForm(_db, productIdentifier))
                form.ShowDialog();
            LoadProductsAsync();
        }

        private void sell_Click(object sender, EventArgs e)
        {
            
        }

        private void filterInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = filterInput.Text.Trim();
            string propertyName = selectedColumn >= 0
            ? dataGridView1.Columns[selectedColumn].DataPropertyName
            : null;

            
            Task.Run(() =>
            {
                List<Products> result = new List<Products>();
                using (var db = new StoreDB2())
                {
                    var prop = propertyName != null ? typeof(Products).GetProperty(propertyName) : null;
                    if (string.IsNullOrEmpty(text) || propertyName == null)
                    {
                        result = db.Products.ToList();

                    }
                    else
                    {

                        result = db.Products
                            .AsEnumerable()
                            .Where(p =>
                            {
                                object value = prop.GetValue(p);
                                return value != null &&
                                       value.ToString().IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
                            })
                            .ToList();
                    }
                }

                if (IsDisposed) return;

                this.Invoke((MethodInvoker)(() =>
                {
                    dataGridView1.DataSource = result;
                }));
            });

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedColumn = e.ColumnIndex;
        }
    }
}
