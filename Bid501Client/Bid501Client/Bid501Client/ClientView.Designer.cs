
namespace Bid501Client
{
    partial class ClientView
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
            this.Product = new System.Windows.Forms.Label();
            this.product_ListBox = new System.Windows.Forms.ListBox();
            this.bid_Button = new System.Windows.Forms.Button();
            this.bid_TextBox = new System.Windows.Forms.TextBox();
            this.Status_Color = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bid_Count = new System.Windows.Forms.Label();
            this.top_Bid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bid_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Product
            // 
            this.Product.AutoSize = true;
            this.Product.Location = new System.Drawing.Point(61, 46);
            this.Product.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(57, 17);
            this.Product.TabIndex = 0;
            this.Product.Text = "Product";
            // 
            // product_ListBox
            // 
            this.product_ListBox.FormattingEnabled = true;
            this.product_ListBox.ItemHeight = 16;
            this.product_ListBox.Location = new System.Drawing.Point(405, 82);
            this.product_ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.product_ListBox.Name = "product_ListBox";
            this.product_ListBox.Size = new System.Drawing.Size(183, 228);
            this.product_ListBox.TabIndex = 1;
            this.product_ListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bid_Button
            // 
            this.bid_Button.Location = new System.Drawing.Point(104, 283);
            this.bid_Button.Margin = new System.Windows.Forms.Padding(4);
            this.bid_Button.Name = "bid_Button";
            this.bid_Button.Size = new System.Drawing.Size(100, 28);
            this.bid_Button.TabIndex = 2;
            this.bid_Button.Text = "Place Bid";
            this.bid_Button.UseVisualStyleBackColor = true;
            this.bid_Button.Click += new System.EventHandler(this.bid_Button_Click);
            // 
            // bid_TextBox
            // 
            this.bid_TextBox.Location = new System.Drawing.Point(104, 166);
            this.bid_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.bid_TextBox.Name = "bid_TextBox";
            this.bid_TextBox.Size = new System.Drawing.Size(132, 22);
            this.bid_TextBox.TabIndex = 3;
            // 
            // Status_Color
            // 
            this.Status_Color.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Status_Color.Location = new System.Drawing.Point(149, 121);
            this.Status_Color.Margin = new System.Windows.Forms.Padding(4);
            this.Status_Color.Name = "Status_Color";
            this.Status_Color.Size = new System.Drawing.Size(49, 18);
            this.Status_Color.TabIndex = 4;
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Location = new System.Drawing.Point(61, 80);
            this.Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(44, 17);
            this.Timer.TabIndex = 5;
            this.Timer.Text = "Timer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status";
            // 
            // bid_Count
            // 
            this.bid_Count.AutoSize = true;
            this.bid_Count.Location = new System.Drawing.Point(252, 172);
            this.bid_Count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bid_Count.Name = "bid_Count";
            this.bid_Count.Size = new System.Drawing.Size(34, 17);
            this.bid_Count.TabIndex = 7;
            this.bid_Count.Text = "bids";
            // 
            // top_Bid
            // 
            this.top_Bid.AutoSize = true;
            this.top_Bid.Location = new System.Drawing.Point(61, 217);
            this.top_Bid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.top_Bid.Name = "top_Bid";
            this.top_Bid.Size = new System.Drawing.Size(53, 17);
            this.top_Bid.TabIndex = 8;
            this.top_Bid.Text = "TopBid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Products";
            // 
            // bid_Status
            // 
            this.bid_Status.AutoSize = true;
            this.bid_Status.Location = new System.Drawing.Point(252, 217);
            this.bid_Status.Name = "bid_Status";
            this.bid_Status.Size = new System.Drawing.Size(68, 17);
            this.bid_Status.TabIndex = 10;
            this.bid_Status.Text = "BidStatus";
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 377);
            this.Controls.Add(this.bid_Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.top_Bid);
            this.Controls.Add(this.bid_Count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.Status_Color);
            this.Controls.Add(this.bid_TextBox);
            this.Controls.Add(this.bid_Button);
            this.Controls.Add(this.product_ListBox);
            this.Controls.Add(this.Product);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientView";
            this.Text = "Bid501ClientView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Product;
        private System.Windows.Forms.ListBox product_ListBox;
        private System.Windows.Forms.Button bid_Button;
        private System.Windows.Forms.TextBox bid_TextBox;
        private System.Windows.Forms.Panel Status_Color;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label bid_Count;
        private System.Windows.Forms.Label top_Bid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label bid_Status;
    }
}

