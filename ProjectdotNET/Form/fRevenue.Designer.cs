namespace ProjectdotNET
{
    partial class fRevenue
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
            this.btnSum = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStatistical = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTotalRevemue = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbTotalBill = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvBillinfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgcProduct = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistical)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillinfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcProduct)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(454, 12);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(136, 57);
            this.btnSum.TabIndex = 6;
            this.btnSum.Text = "Thống kê";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtEnd);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(676, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 57);
            this.panel3.TabIndex = 4;
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(96, 12);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(186, 27);
            this.dtEnd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kêt thúc:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtStart);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(66, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 57);
            this.panel2.TabIndex = 5;
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(96, 12);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(186, 27);
            this.dtStart.TabIndex = 1;
            this.dtStart.Value = new System.DateTime(2024, 5, 10, 8, 30, 42, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bắt đầu:";
            // 
            // dgvStatistical
            // 
            this.dgvStatistical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistical.Location = new System.Drawing.Point(6, 26);
            this.dgvStatistical.Name = "dgvStatistical";
            this.dgvStatistical.RowHeadersWidth = 51;
            this.dgvStatistical.RowTemplate.Height = 24;
            this.dgvStatistical.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatistical.Size = new System.Drawing.Size(600, 262);
            this.dgvStatistical.TabIndex = 0;
            this.dgvStatistical.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStatistical_CellEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tổng tiền";
            // 
            // tbTotalRevemue
            // 
            this.tbTotalRevemue.Location = new System.Drawing.Point(146, 63);
            this.tbTotalRevemue.Name = "tbTotalRevemue";
            this.tbTotalRevemue.Size = new System.Drawing.Size(177, 27);
            this.tbTotalRevemue.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbTotalRevemue);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.tbTotalBill);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(32, 116);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(335, 111);
            this.panel5.TabIndex = 1;
            // 
            // tbTotalBill
            // 
            this.tbTotalBill.Location = new System.Drawing.Point(146, 12);
            this.tbTotalBill.Name = "tbTotalBill";
            this.tbTotalBill.Size = new System.Drawing.Size(177, 27);
            this.tbTotalBill.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tổng đơn hàng";
            // 
            // dgvBillinfo
            // 
            this.dgvBillinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillinfo.Location = new System.Drawing.Point(6, 26);
            this.dgvBillinfo.Name = "dgvBillinfo";
            this.dgvBillinfo.RowHeadersWidth = 51;
            this.dgvBillinfo.RowTemplate.Height = 24;
            this.dgvBillinfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillinfo.Size = new System.Drawing.Size(600, 159);
            this.dgvBillinfo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStatistical);
            this.groupBox1.Location = new System.Drawing.Point(410, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 294);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đơn hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBillinfo);
            this.groupBox2.Location = new System.Drawing.Point(410, 390);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 193);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết đơn hàng";
            // 
            // dgcProduct
            // 
            this.dgcProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcProduct.Location = new System.Drawing.Point(6, 26);
            this.dgcProduct.Name = "dgcProduct";
            this.dgcProduct.RowHeadersWidth = 51;
            this.dgcProduct.RowTemplate.Height = 24;
            this.dgcProduct.Size = new System.Drawing.Size(353, 303);
            this.dgcProduct.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgcProduct);
            this.groupBox3.Location = new System.Drawing.Point(25, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 337);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết sản phẩm bán";
            // 
            // fRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 595);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnSum);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fRevenue";
            this.Text = "fRevenue";
            this.Load += new System.EventHandler(this.fRevenue_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistical)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillinfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcProduct)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStatistical;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTotalRevemue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbTotalBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvBillinfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgcProduct;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}