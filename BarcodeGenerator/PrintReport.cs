using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;

using ClosedXML.Excel;


namespace BarcodeGenerator
{
    public partial class PrintReport : Form
    {
        public PrintReport()
        {
            InitializeComponent();
        }

        private DataTable dt = new DataTable();
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
          
        }
        private void getDetailedReport()
        {
            //For fetching the filterd data from Data base
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    string excelName = cboExcelName.Text;
                    string sheetName = cboSheetName.Text;
                    string status = cboStatus.Text;
                    DateTime fromDate = dateTimePicker1.Value.Date;
                    DateTime toDate = dateTimePicker2.Value.Date;
                    if(fromDate == toDate)
                    {
                        toDate = toDate.AddDays(1);
                    }                 
                    SqlCommand cmd = new SqlCommand();

                    string sql = "select * from [Data] ";
                    sql += " WHERE CreatedDatetime >= @fromDate AND ModifiedDatetime <=@toDate ";
                    if (excelName.Length > 0)
                    {
                        sql += " and ExcelName=@ExcelName ";
                        cmd.Parameters.AddWithValue("@ExcelName", excelName);
                    }
                    if (txtEan.Text.Length > 11)
                    {
                        sql += " and EAN=@ean ";
                        cmd.Parameters.AddWithValue("@ean", txtEan.Text);
                    }
                    if (sheetName.Length > 0)
                    {
                        sql += " and SheetName=@SheetName ";
                        cmd.Parameters.AddWithValue("@SheetName", sheetName);
                    }
                    if (status.Length > 0)
                    {
                        if (status == "ALL")
                        {

                        }else if(status == "PRINTED")
                        {
                            sql += " and status=1";
                        }
                        else if(status == "NOT PRINTED")
                        {
                            sql += " and status=0";
                        }
                    }



                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    dt = DBOperations.GetTable(cmd);
                    if (dt.Rows.Count > 0) {
                    reportgrd.Visible = true;
                    reportgrd.DataSource = dt;
                        lblTotalCount.Text = dt.Rows.Count.ToString();
                    }
                    else { reportgrd.Visible = false; }


                }
                catch (Exception ex)
                {
                    if (scope != null)
                    {
                        scope.Dispose();
                        MessageBox.Show("Error, " + ex.Message);
                    }

                }

            }
        }
        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                if (dt.Rows.Count>0) {               
                XLWorkbook workbook = new XLWorkbook();
                    string fileName = "Report_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "");
                    string filePath = downloadFolderPath + "\\"+ fileName+".xlsx";
                // Add the DataTable to the workbook
                workbook.Worksheets.Add(dt, "Report");
                // Save the file
                workbook.SaveAs(filePath);
                    MessageBox.Show("Success, Export Completed" );
                }
            }
            catch (Exception ex)
            {
              
                    MessageBox.Show("Error, " + ex.Message);
            }
        }
        private void importDataBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (chkIsDetail.Checked == true)
            {
                getDetailedReport();
            }
            else if(chkIsSummary.Checked == true)
            {
                fetchSummaryDate();
            }
            if (dt.Rows.Count > 0)
            {
                printBtn.Enabled = true;
            }
        }
        private DataTable fetchSummaryDate()
        {
            string excelName = cboExcelName.Text;
            string sheetName = cboSheetName.Text;
            string status = cboStatus.Text;
            SqlCommand cmd = new SqlCommand();

            string sql = "with T1 as (SELECT EAN, COUNT(*) as Count,Article,ExcelName,SheetName FROM Data " +
 "GROUP BY EAN, Article, ExcelName, SheetName),T2 as (SELECT EAN, COUNT(*) Count,Article,ExcelName,SheetName,Status " +
 "FROM Data where STATUS = 1 GROUP BY EAN,Article,ExcelName,SheetName,Status), " +
"T3 as (SELECT EAN, COUNT(*) Count,Article,ExcelName,SheetName,Status FROM Data where STATUS = 0 GROUP BY EAN,Article,ExcelName,SheetName,Status) " +
"SELECT T1.EAN,T1.Article,T1.Count as TotalCount,ISNULL(T2.Count, 0) as PrintedCount,ISNULL(T3.Count, 0) as RemainingCount,T1.ExcelName,T1.SheetName FROM T1 " +
"left JOIN T2 ON T1.EAN = t2.EAN left JOIN T3 ON T1.EAN = t3.EAN WHERE 1=1";
           if (excelName.Length > 0)
            {
                sql += " and T1.ExcelName=@ExcelName ";
                cmd.Parameters.AddWithValue("@ExcelName", excelName);
            }
            if (sheetName.Length > 0)
            {
                sql += " and T1.SheetName=@SheetName ";
                cmd.Parameters.AddWithValue("@SheetName", sheetName);
            }
            if (txtEan.Text.Length > 11)
            {
                sql += " and T1.EAN=@ean ";
                cmd.Parameters.AddWithValue("@ean", txtEan.Text);
            }
            
            sql += "order by EAN ";
          
            cmd.CommandText = sql;
            dt = DBOperations.GetTable(cmd);
            if (dt.Rows.Count > 0)
            {
                reportgrd.Visible = true;
                reportgrd.DataSource = dt;
                lblTotalCount.Text = dt.Rows.Count.ToString();
            }
            else { reportgrd.Visible = false; }



            return dt;
        }
        private void fetchSheetNameList(string excelName)
        {
            try { 
            SqlCommand cmd = new SqlCommand();
            string sql = "select SheetName from Data where ExcelName=@ExcelName group by SheetName ";
            cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ExcelName", excelName);
                DataTable  dtNew = DBOperations.GetTable(cmd);
            var list = new List<string> { ""};
            foreach(DataRow rows in dtNew.Rows)
            {
                list.Add(rows["SheetName"].ToString());
            }         
            cboSheetName.DataSource = list;
            }
            catch (Exception exe) { }
            return;
        }
        private void fetchExcelNameList()
        { 
            try {
                SqlCommand cmd = new SqlCommand();
                string sql = "select ExcelName from Data group by ExcelName ";
            cmd.CommandText = sql;
            DataTable dtNew = DBOperations.GetTable(cmd);
            var list = new List<string> { "" };
            foreach (DataRow rows in dtNew.Rows)
            {
                list.Add(rows["ExcelName"].ToString());
            }
            cboExcelName.DataSource = list;
            }
            catch (Exception exe) { }
            return;
        }
        private void PrintReport_Load(object sender, EventArgs e)
        {
            //fetchSheetNameList();
            fetchExcelNameList();
            string[] items = { "ALL", "PRINTED", "NOT PRINTED" };
            cboStatus.Items.AddRange(items);
        }
        private void cboExcelName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboExcelName.Text.Length > 0) { fetchSheetNameList(cboExcelName.Text); }
        }
        private void chkIsSummary_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkIsSummary.Checked == true)
            {
                chkIsDetail.Checked = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                cboStatus.Visible = false;
                label5.Visible = false;
            }
        }

        private void chkIsDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsDetail.Checked == true) { 
            chkIsSummary.Checked = false;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            cboStatus.Visible = true;
            label5.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboExcelName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboSheetName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
