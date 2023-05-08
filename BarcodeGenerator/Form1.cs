
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

using System.Transactions;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
        InitializeComponent();

        }
       private string fileName = "";
        private string sheetName = "";
        private string SafeFileName = "";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            {
                string fileExt = Path.GetExtension(file.FileName); //get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0 || fileExt.CompareTo(".xlsm") == 0)
                {
                    try
                    {
                        this.fileName = file.FileName;
                        this.SafeFileName = file.SafeFileName;
                        ReadExcel(file.FileName);
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls , .xlsx or .xlsm file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error
                }
            }

        }

        private void ReadExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {

                // Get the workbook part
                WorkbookPart workbookPart = document.WorkbookPart;

                // Get the list of sheets in the workbook
                Sheets sheets = workbookPart.Workbook.Sheets;
                comboBox1.Items.Clear();
                // Loop through each sheet and print its name
                foreach (Sheet sheet in sheets)
                {
                    //Console.WriteLine(sheet.Name);
                    this.comboBox1.Items.Add(sheet.Name);
                }
            }
         
            return;
        }

        private string chackValidRow(string rowName)
        {

            return rowName;
        }

        public string CheckIsExist(DataGridView dgv,DataGridViewRow row,string columnname)
        {
            try
            {
                
                if (dgv.Columns.Contains(columnname))
                {
                    return row.Cells["Data Matrix"].Value.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch(Exception ex)
            {
                return "";
            }
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (CheckIsValidExcell(this.sheetName))
                    {
                        if (dataGridView1.Rows.Count ==0)
                        {
                            MessageBox.Show("Wrong File. Nothing to Save","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            //change the sql quer
                            if (!row.IsNewRow)
                            {
                                string MachineName = Environment.MachineName;
                                int i = 0;
                                string sql = "insert into [Data]([UIT],[Article],[CodeColors],[ItemName],[Manufacturer],[CountryOfOrigin],[Trademark]," +
                                    "[CORMT],[CORML],[SoleComposition],[MFCSM],[SizeAge],[RussianSize],[TNVED_code],[EAN],[Quantity],[GTIN]," +
                                    "[DataMatrix],[ManufacturerAddress],[ExporterAddress],[MFGDate],[TABLENAME],[PRINTDATETIME],[STATUS],[CreatedDatetime],[CreatedBy]," +
                                    "[ModifiedDatetime],[ModifiedBy],[ExcelName],[SheetName]) ";
                                sql += " values (@UIT ,@Article ,@CodeColors ,@ItemName,@Manufacturer,@CountryOfOrigin," +
                                    "@Trademark,@CORMT,@CORML,@SoleComposition,@MFCSM,@SizeAge,@RussianSize,@TNVED_code,@EAN,@Quantity,@GTIN," +
                                    "@DataMatrix,@ManufacturerAddress,@ExporterAddress,@MFGDate,@TABLENAME,@PRINTDATETIME,@STATUS,@CreatedDatetime," +
                                    "@CreatedBy,@ModifiedDatetime,@ModifiedBy,@ExcelName,@SheetName )";
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = sql;

                                cmd.Parameters.AddWithValue("@DataMatrix", row.Cells["Data Matrix"].Value.ToString());
                                cmd.Parameters.AddWithValue("@UIT", row.Cells["UIT"].Value.ToString());
                                cmd.Parameters.AddWithValue("@GTIN", row.Cells["GTIN"].Value.ToString());
                                cmd.Parameters.AddWithValue("@Trademark", row.Cells["Торговая марка"].Value.ToString());
                                cmd.Parameters.AddWithValue("@CORML", row.Cells["Состав сырья (подкладка)"].Value.ToString());
                                cmd.Parameters.AddWithValue("@CORMT", row.Cells["Состав сырья (верх)"].Value.ToString());
                                cmd.Parameters.AddWithValue("@Article", row.Cells["Артикул"].Value.ToString());
                                cmd.Parameters.AddWithValue("@CodeColors", row.Cells["КОД Цвета "].Value.ToString());
                                //cmd.Parameters.AddWithValue("@CodeColors", row.Cells["Артикул"].Value.ToString());

                                cmd.Parameters.AddWithValue("@Manufacturer", row.Cells["Производитель"].Value.ToString());
                                cmd.Parameters.AddWithValue("@ItemName", row.Cells["Наименование номенклатуры"].Value.ToString());
                                cmd.Parameters.AddWithValue("@CountryOfOrigin", row.Cells["Страна происхождения"].Value.ToString());
                                cmd.Parameters.AddWithValue("@SoleComposition", row.Cells["Состав подошвы"].Value.ToString());
                                cmd.Parameters.AddWithValue("@MFCSM", row.Cells["(муж#/жен#/дет# (мал#, дев#)"].Value.ToString());
                                cmd.Parameters.AddWithValue("@SizeAge", row.Cells["Размер/ Возраст"].Value.ToString());
                                cmd.Parameters.AddWithValue("@RussianSize", row.Cells["Российский размер"].Value.ToString());
                                cmd.Parameters.AddWithValue("@TNVED_code ", row.Cells["Код ТНВЭД"].Value.ToString());
                                cmd.Parameters.AddWithValue("@EAN", row.Cells["EAN"].Value.ToString());
                                cmd.Parameters.AddWithValue("@Quantity", row.Cells["Количество"].Value.ToString());
                                cmd.Parameters.AddWithValue("@ManufacturerAddress", row.Cells["Производитель (имя и адрес)"].Value.ToString());
                                cmd.Parameters.AddWithValue("@ExporterAddress", row.Cells["Импортер (имя и адрес)"].Value.ToString());
                                cmd.Parameters.AddWithValue("@MFGDate", row.Cells["Дата производства"].Value.ToString());

                                cmd.Parameters.AddWithValue("@TABLENAME", this.fileName);
                                cmd.Parameters.AddWithValue("@PRINTDATETIME", DateTime.Now);
                                cmd.Parameters.AddWithValue("@STATUS", 0);
                                cmd.Parameters.AddWithValue("@CreatedDatetime", DateTime.Now);
                                cmd.Parameters.AddWithValue("@CreatedBy", MachineName);
                                cmd.Parameters.AddWithValue("@ModifiedDatetime", DateTime.Now);
                                cmd.Parameters.AddWithValue("@ModifiedBy", MachineName);
                                cmd.Parameters.AddWithValue("@ExcelName", this.SafeFileName);
                                cmd.Parameters.AddWithValue("@SheetName", this.sheetName);




                                i = DBOperations.ExecuteNonQuery(cmd);
                                if (i < 0)
                                {
                                    scope.Dispose();
                                    MessageBox.Show("Not Saved", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Already Saved.", "Nothing to Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int count = dataGridView1.Rows.Count-1;
                    scope.Complete();
                    MessageBox.Show("Operation completed successfully. Total count: " + Convert.ToString(count), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                   
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    MessageBox.Show(ex.Message.ToString(), "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }

      
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
             this.sheetName = this.comboBox1.Text;
            DataTable dtExcel = setDataGridValue(sheetName); //read excel file
            dataGridView1.Visible = true;
            dataGridView1.DataSource = dtExcel;
            //  WorkSheet sheet = workbook.GetWorkSheet("Sheet1");
        }
        private DataTable setDataGridValue(string selectText)
        {
            var dataTable = new DataTable();
            try
            {
                var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.fileName + ";Extended Properties='Excel 8.0;HDR=YES'"; ;
                string sheetName1 = selectText + "$";
                using (var excelConnection = new OleDbConnection(connectionString))
                {
                    excelConnection.Open();
                    var dataAdapter = new OleDbDataAdapter("SELECT * FROM [" + sheetName1 + "]", excelConnection);
                    dataAdapter.Fill(dataTable);
                    excelConnection.Close();
                }
                Console.WriteLine("OpenExcelFile: File successfully opened:" + this.fileName);
                return dataTable;
            }catch(Exception exe)
            {
                return dataTable;
            }
        }
       


        private bool CheckIsValidExcell(string sheetName)
        {
            string sql = "select distinct SheetName from Data where SheetName=@sheetName";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@sheetName", sheetName);

            DataTable response = DBOperations.GetTable(cmd);
            if (response.Rows.Count > 0)
            {
                return false;
            }
            return true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
