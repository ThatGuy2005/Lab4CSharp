namespace Lab4CSharp
{
    partial class ModifyProduct
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
            this.update = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.productIdentifier = new System.Windows.Forms.TextBox();
            this.addQuantity = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(374, 192);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(80, 39);
            this.update.TabIndex = 0;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(374, 251);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(80, 43);
            this.quit.TabIndex = 1;
            this.quit.Text = "Quit";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Add Quantity: ";
            // 
            // productIdentifier
            // 
            this.productIdentifier.Location = new System.Drawing.Point(178, 46);
            this.productIdentifier.Name = "productIdentifier";
            this.productIdentifier.Size = new System.Drawing.Size(145, 26);
            this.productIdentifier.TabIndex = 4;
            // 
            // addQuantity
            // 
            this.addQuantity.Location = new System.Drawing.Point(178, 113);
            this.addQuantity.Name = "addQuantity";
            this.addQuantity.Size = new System.Drawing.Size(145, 26);
            this.addQuantity.TabIndex = 5;
            // 
            // ModifyProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 334);
            this.Controls.Add(this.addQuantity);
            this.Controls.Add(this.productIdentifier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.update);
            this.Name = "ModifyProduct";
            this.Text = "ModifyProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox productIdentifier;
        private System.Windows.Forms.TextBox addQuantity;
        private StoreDB2 _db;
    }
}