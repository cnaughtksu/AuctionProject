
namespace Bid501Server
{
    partial class AddProductView
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
            this.NewProd_ListBox = new System.Windows.Forms.ListBox();
            this.Add_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewProd_ListBox
            // 
            this.NewProd_ListBox.FormattingEnabled = true;
            this.NewProd_ListBox.ItemHeight = 16;
            this.NewProd_ListBox.Location = new System.Drawing.Point(16, 15);
            this.NewProd_ListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewProd_ListBox.Name = "NewProd_ListBox";
            this.NewProd_ListBox.Size = new System.Drawing.Size(333, 388);
            this.NewProd_ListBox.TabIndex = 1;
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(251, 412);
            this.Add_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(100, 28);
            this.Add_button.TabIndex = 2;
            this.Add_button.Text = "Add";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // AddProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 455);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.NewProd_ListBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddProductView";
            this.Text = "AddProductView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox NewProd_ListBox;
        private System.Windows.Forms.Button Add_button;
    }
}