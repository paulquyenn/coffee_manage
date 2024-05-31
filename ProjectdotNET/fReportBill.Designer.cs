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
            this.reportBillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOFFEESTOREDataBillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOFFEESTOREDataBill = new ProjectdotNET.COFFEESTOREDataBill();
            this.reportBillInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Report_BillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOFFEESTOREDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvBill = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cOFFEESTOREDataSet1 = new ProjectdotNET.COFFEESTOREDataSet1();
            this.cOFFEESTOREDataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.report_BillTableAdapter = new ProjectdotNET.COFFEESTOREDataBillTableAdapters.Report_BillTableAdapter();
            this.report_BillInfoTableAdapter = new ProjectdotNET.COFFEESTOREDataBillTableAdapters.Report_BillInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportBillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataBillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBillInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_BillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportBillBindingSource
            // 
            this.reportBillBindingSource.DataMember = "Report_Bill";
            this.reportBillBindingSource.DataSource = this.cOFFEESTOREDataBillBindingSource;
            // 
            // cOFFEESTOREDataBillBindingSource
            // 
            this.cOFFEESTOREDataBillBindingSource.DataSource = this.cOFFEESTOREDataBill;
            this.cOFFEESTOREDataBillBindingSource.Position = 0;
            // 
            // cOFFEESTOREDataBill
            // 
            this.cOFFEESTOREDataBill.DataSetName = "COFFEESTOREDataBill";
            this.cOFFEESTOREDataBill.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportBillInfoBindingSource
            // 
            this.reportBillInfoBindingSource.DataMember = "Report_BillInfo";
            this.reportBillInfoBindingSource.DataSource = this.cOFFEESTOREDataBillBindingSource;
            // 
            // rpvBill
            // 
            reportDataSource1.Name = "DataBill";
            reportDataSource1.Value = this.reportBillBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.reportBillInfoBindingSource;
            this.rpvBill.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBill.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvBill.LocalReport.ReportEmbeddedResource = "ProjectdotNET.ReportBill.rdlc";
            this.rpvBill.Location = new System.Drawing.Point(12, 12);
            this.rpvBill.Name = "rpvBill";
            this.rpvBill.ServerReport.BearerToken = null;
            this.rpvBill.Size = new System.Drawing.Size(543, 620);
            this.rpvBill.TabIndex = 0;
            // 
            // cOFFEESTOREDataSet1
            // 
            this.cOFFEESTOREDataSet1.DataSetName = "COFFEESTOREDataSet1";
            this.cOFFEESTOREDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cOFFEESTOREDataSet1BindingSource1
            // 
            this.cOFFEESTOREDataSet1BindingSource1.DataSource = this.cOFFEESTOREDataSet1;
            this.cOFFEESTOREDataSet1BindingSource1.Position = 0;
            // 
            // report_BillTableAdapter
            // 
            this.report_BillTableAdapter.ClearBeforeFill = true;
            // 
            // report_BillInfoTableAdapter
            // 
            this.report_BillInfoTableAdapter.ClearBeforeFill = true;
            // 
            // fReportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(567, 644);
            this.Controls.Add(this.rpvBill);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fReportBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fReportBill";
            this.Load += new System.EventHandler(this.fReportBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportBillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataBillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBillInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_BillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOFFEESTOREDataSet1BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBill;
        private System.Windows.Forms.BindingSource cOFFEESTOREDataSet1BindingSource;
        private System.Windows.Forms.BindingSource Report_BillBindingSource;
        private System.Windows.Forms.BindingSource cOFFEESTOREDataBillBindingSource;
        private COFFEESTOREDataBill cOFFEESTOREDataBill;
        private System.Windows.Forms.BindingSource cOFFEESTOREDataSet1BindingSource1;
        private COFFEESTOREDataSet1 cOFFEESTOREDataSet1;
        private System.Windows.Forms.BindingSource reportBillBindingSource;
        private System.Windows.Forms.BindingSource reportBillInfoBindingSource;
        private COFFEESTOREDataBillTableAdapters.Report_BillTableAdapter report_BillTableAdapter;
        private COFFEESTOREDataBillTableAdapters.Report_BillInfoTableAdapter report_BillInfoTableAdapter;
    }
}