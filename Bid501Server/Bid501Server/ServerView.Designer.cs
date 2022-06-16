
namespace Bid501Server
{
    partial class ServerView
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
            this.Product_listBox = new System.Windows.Forms.ListBox();
            this.Add_Button = new System.Windows.Forms.Button();
            this.Client_ListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Product_listBox
            // 
            this.Product_listBox.FormattingEnabled = true;
            this.Product_listBox.ItemHeight = 16;
            this.Product_listBox.Location = new System.Drawing.Point(16, 15);
            this.Product_listBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Product_listBox.Name = "Product_listBox";
            this.Product_listBox.Size = new System.Drawing.Size(259, 340);
            this.Product_listBox.TabIndex = 0;
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(231, 363);
            this.Add_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(100, 28);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "Add";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Client_ListBox
            // 
            this.Client_ListBox.FormattingEnabled = true;
            this.Client_ListBox.ItemHeight = 16;
            this.Client_ListBox.Location = new System.Drawing.Point(284, 15);
            this.Client_ListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Client_ListBox.Name = "Client_ListBox";
            this.Client_ListBox.Size = new System.Drawing.Size(259, 340);
            this.Client_ListBox.TabIndex = 2;
            // 
            // ServerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Client_ListBox);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.Product_listBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ServerView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Product_listBox;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.ListBox Client_ListBox;
    }
}

