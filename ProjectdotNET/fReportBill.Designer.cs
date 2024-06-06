namespace ProjectdotNET
{
    partial class fReportBill
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReportBill));
            this.reportBillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOFFEESTOREDataSet = new ProjectdotNET.COFFEESTOREDataSet();
            this.reportBillInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportBill = new Microsoft.Reporting.WinForms.ReportViewer();
            this.report_BillTableAdapter = new ProjectdotNET.COFFEESTOREDataSetTableAdapters.Report_BillTableAdapter();
            this.report_BillInfoTableAdapter = new ProjectdotNET.COFFEESTOREDataSetTableAdapters.Report_BillInfoTableAdapter();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportBillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBillInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportBillBindingSource
            // 
            this.reportBillBindingSource.DataMember = "Report_Bill";
            this.reportBillBindingSource.DataSource = this.cOFFEESTOREDataSet;
            // 
            // cOFFEESTOREDataSet
            // 
            this.cOFFEESTOREDataSet.DataSetName = "COFFEESTOREDataSet";
            this.cOFFEESTOREDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportBillInfoBindingSource
            // 
            this.reportBillInfoBindingSource.DataMember = "Report_BillInfo";
            this.reportBillInfoBindingSource.DataSource = this.cOFFEESTOREDataSet;
            // 
            // reportBill
            // 
            reportDataSource1.Name = "DataSetBill";
            reportDataSource1.Value = this.reportBillBindingSource;
            reportDataSource2.Name = "DataSetBillinfo";
            reportDataSource2.Value = this.reportBillInfoBindingSource;
            this.reportBill.LocalReport.DataSources.Add(reportDataSource1);
            this.reportBill.LocalReport.DataSources.Add(reportDataSource2);
            this.reportBill.LocalReport.ReportEmbeddedResource = "ProjectdotNET.ReportBillinfo.rdlc";
            this.reportBill.Location = new System.Drawing.Point(12, 12);
            this.reportBill.Name = "reportBill";
            this.reportBill.ServerReport.BearerToken = null;
            this.reportBill.Size = new System.Drawing.Size(525, 560);
            this.reportBill.TabIndex = 0;
            // 
            // report_BillTableAdapter
            // 
            this.report_BillTableAdapter.ClearBeforeFill = true;
            // 
            // report_BillInfoTableAdapter
            // 
            this.report_BillInfoTableAdapter.ClearBeforeFill = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(71, 578);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 42);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(362, 578);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(112, 42);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Hoàn tất";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // fReportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 632);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.reportBill);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fReportBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn";
            this.Load += new System.EventHandler(this.fReportBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportBillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBillInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportBill;
        private System.Windows.Forms.BindingSource reportBillBindingSource;
        private COFFEESTOREDataSet cOFFEESTOREDataSet;
        private System.Windows.Forms.BindingSource reportBillInfoBindingSource;
        private COFFEESTOREDataSetTableAdapters.Report_BillTableAdapter report_BillTableAdapter;
        private COFFEESTOREDataSetTableAdapters.Report_BillInfoTableAdapter report_BillInfoTableAdapter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnComplete;
    }
}