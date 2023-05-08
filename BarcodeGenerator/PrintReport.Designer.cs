
namespace BarcodeGenerator
{
    partial class PrintReport
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
            this.header = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboExcelName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEan = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSheetName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIsSummary = new System.Windows.Forms.CheckBox();
            this.chkIsDetail = new System.Windows.Forms.CheckBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.importDataBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.body = new System.Windows.Forms.Panel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.reportgrd = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.header.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header.Controls.Add(this.panel2);
            this.header.Controls.Add(this.panel1);
            this.header.Controls.Add(this.btnShow);
            this.header.Controls.Add(this.importDataBtn);
            this.header.Controls.Add(this.printBtn);
            this.header.Controls.Add(this.label2);
            this.header.Controls.Add(this.label1);
            this.header.Controls.Add(this.dateTimePicker2);
            this.header.Controls.Add(this.dateTimePicker1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1765, 139);
            this.header.TabIndex = 0;
            this.header.Paint += new System.Windows.Forms.PaintEventHandler(this.header_Paint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboExcelName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtEan);
            this.panel2.Controls.Add(this.cboStatus);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboSheetName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(326, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 119);
            this.panel2.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "EAN";
            // 
            // cboExcelName
            // 
            this.cboExcelName.FormattingEnabled = true;
            this.cboExcelName.Location = new System.Drawing.Point(12, 26);
            this.cboExcelName.Name = "cboExcelName";
            this.cboExcelName.Size = new System.Drawing.Size(243, 24);
            this.cboExcelName.TabIndex = 27;
            this.cboExcelName.SelectedIndexChanged += new System.EventHandler(this.cboExcelName_SelectedIndexChanged);
            this.cboExcelName.SelectedValueChanged += new System.EventHandler(this.cboExcelName_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Excel Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtEan
            // 
            this.txtEan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEan.Location = new System.Drawing.Point(12, 81);
            this.txtEan.Name = "txtEan";
            this.txtEan.Size = new System.Drawing.Size(243, 22);
            this.txtEan.TabIndex = 30;
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(297, 79);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(243, 24);
            this.cboStatus.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(293, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Status";
            // 
            // cboSheetName
            // 
            this.cboSheetName.FormattingEnabled = true;
            this.cboSheetName.Location = new System.Drawing.Point(297, 26);
            this.cboSheetName.Name = "cboSheetName";
            this.cboSheetName.Size = new System.Drawing.Size(243, 24);
            this.cboSheetName.TabIndex = 26;
            this.cboSheetName.SelectedIndexChanged += new System.EventHandler(this.cboSheetName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(293, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Sheet Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkIsSummary);
            this.panel1.Controls.Add(this.chkIsDetail);
            this.panel1.Location = new System.Drawing.Point(31, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 77);
            this.panel1.TabIndex = 32;
            // 
            // chkIsSummary
            // 
            this.chkIsSummary.AutoSize = true;
            this.chkIsSummary.Location = new System.Drawing.Point(132, 30);
            this.chkIsSummary.Name = "chkIsSummary";
            this.chkIsSummary.Size = new System.Drawing.Size(89, 21);
            this.chkIsSummary.TabIndex = 31;
            this.chkIsSummary.Text = "Summary";
            this.chkIsSummary.UseVisualStyleBackColor = true;
            this.chkIsSummary.CheckedChanged += new System.EventHandler(this.chkIsSummary_CheckedChanged_1);
            // 
            // chkIsDetail
            // 
            this.chkIsDetail.AutoSize = true;
            this.chkIsDetail.Checked = true;
            this.chkIsDetail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsDetail.Location = new System.Drawing.Point(18, 29);
            this.chkIsDetail.Name = "chkIsDetail";
            this.chkIsDetail.Size = new System.Drawing.Size(82, 21);
            this.chkIsDetail.TabIndex = 30;
            this.chkIsDetail.Text = "Detailed";
            this.chkIsDetail.UseVisualStyleBackColor = true;
            this.chkIsDetail.CheckedChanged += new System.EventHandler(this.chkIsDetail_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Salmon;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnShow.FlatAppearance.BorderSize = 5;
            this.btnShow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(1314, 38);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(131, 53);
            this.btnShow.TabIndex = 25;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // importDataBtn
            // 
            this.importDataBtn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.importDataBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.importDataBtn.FlatAppearance.BorderSize = 5;
            this.importDataBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importDataBtn.Location = new System.Drawing.Point(1595, 38);
            this.importDataBtn.Margin = new System.Windows.Forms.Padding(0);
            this.importDataBtn.Name = "importDataBtn";
            this.importDataBtn.Size = new System.Drawing.Size(134, 53);
            this.importDataBtn.TabIndex = 5;
            this.importDataBtn.Text = "Cancel";
            this.importDataBtn.UseVisualStyleBackColor = false;
            this.importDataBtn.Click += new System.EventHandler(this.importDataBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.printBtn.Enabled = false;
            this.printBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.printBtn.FlatAppearance.BorderSize = 5;
            this.printBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(1456, 38);
            this.printBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(131, 53);
            this.printBtn.TabIndex = 6;
            this.printBtn.Text = "Export";
            this.printBtn.UseVisualStyleBackColor = false;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1103, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(914, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(1110, 61);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(166, 30);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(921, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(175, 30);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // body
            // 
            this.body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.body.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.body.Controls.Add(this.lblTotalCount);
            this.body.Controls.Add(this.reportgrd);
            this.body.Controls.Add(this.label6);
            this.body.Location = new System.Drawing.Point(0, 137);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(1765, 651);
            this.body.TabIndex = 1;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(1645, 622);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(30, 22);
            this.lblTotalCount.TabIndex = 31;
            this.lblTotalCount.Text = "00";
            // 
            // reportgrd
            // 
            this.reportgrd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportgrd.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportgrd.Location = new System.Drawing.Point(3, 3);
            this.reportgrd.Name = "reportgrd";
            this.reportgrd.RowHeadersWidth = 51;
            this.reportgrd.RowTemplate.Height = 24;
            this.reportgrd.Size = new System.Drawing.Size(1757, 616);
            this.reportgrd.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1552, 622);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Total Count :";
            // 
            // PrintReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1765, 788);
            this.Controls.Add(this.body);
            this.Controls.Add(this.header);
            this.Name = "PrintReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintReport";
            this.Load += new System.EventHandler(this.PrintReport_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.body.ResumeLayout(false);
            this.body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportgrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel body;
        private System.Windows.Forms.Button importDataBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.DataGridView reportgrd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cboSheetName;
        private System.Windows.Forms.ComboBox cboExcelName;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIsDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkIsSummary;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEan;
    }
}