namespace ProjectdotNET
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnBill_Info = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Controls.Add(this.btnProduct);
            this.flowLayoutPanel1.Controls.Add(this.btnCategory);
            this.flowLayoutPanel1.Controls.Add(this.btnBill);
            this.flowLayoutPanel1.Controls.Add(this.btnBill_Info);
            this.flowLayoutPanel1.Controls.Add(this.btnTable);
            this.flowLayoutPanel1.Controls.Add(this.btnEmployee);
            this.flowLayoutPanel1.Controls.Add(this.btnRevenue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(187, 755);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjectdotNET.Properties.Resources.coffee_shop_logo_branding_vector;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(0, 122);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(0);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(186, 70);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Sản Phẩm";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Location = new System.Drawing.Point(0, 192);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(0);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(186, 70);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "Loại sản phẩm";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnBill
            // 
            this.btnBill.Location = new System.Drawing.Point(0, 262);
            this.btnBill.Margin = new System.Windows.Forms.Padding(0);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(186, 70);
            this.btnBill.TabIndex = 3;
            this.btnBill.Text = "Hóa Đơn";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnBill_Info
            // 
            this.btnBill_Info.Location = new System.Drawing.Point(0, 332);
            this.btnBill_Info.Margin = new System.Windows.Forms.Padding(0);
            this.btnBill_Info.Name = "btnBill_Info";
            this.btnBill_Info.Size = new System.Drawing.Size(186, 70);
            this.btnBill_Info.TabIndex = 4;
            this.btnBill_Info.Text = "Chi Tiết Hóa Đơn";
            this.btnBill_Info.UseVisualStyleBackColor = true;
            this.btnBill_Info.Click += new System.EventHandler(this.btnBill_Info_Click);
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(0, 402);
            this.btnTable.Margin = new System.Windows.Forms.Padding(0);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(186, 70);
            this.btnTable.TabIndex = 5;
            this.btnTable.Text = "Bàn";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(0, 472);
            this.btnEmployee.Margin = new System.Windows.Forms.Padding(0);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(186, 70);
            this.btnEmployee.TabIndex = 6;
            this.btnEmployee.Text = "Nhân Viên";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnRevenue
            // 
            this.btnRevenue.Location = new System.Drawing.Point(0, 542);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(0);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(186, 70);
            this.btnRevenue.TabIndex = 7;
            this.btnRevenue.Text = "Thống kê";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // btnRevenue
            // 
            this.btnRevenue.Location = new System.Drawing.Point(0, 612);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(0);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(186, 70);
            this.btnRevenue.TabIndex = 7;
            this.btnRevenue.Text = "Thống kê";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoSize = true;
            this.pnlMain.Location = new System.Drawing.Point(189, 123);
            this.pnlMain.MaximumSize = new System.Drawing.Size(11111, 1111);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1211, 633);
            this.pnlMain.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 0);
            this.label1.MaximumSize = new System.Drawing.Size(11111, 1111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1211, 122);
            this.label1.TabIndex = 5;
            this.label1.Text = "Trang chủ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 755);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnBill_Info;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRevenue;
    }
}