using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace BarcodeGenerator
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        bool IsTotalPrint = false;
        bool IsSinglePrint = true;
        private DataTable filterTableData = new DataTable();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void importDataBtn_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            PrintValidation validateFrm = new PrintValidation();
            validateFrm.ShowDialog();
        }
       
        private DataTable UpdatePrintTable(string ean)
        {
            try
            {
                //For updatating the Print-Table affter,with the use of storeProcedure [UPDATEDATAByID]
                int PrintLimit = 0;
                string sql = "";
                SqlCommand cmd = new SqlCommand();
                if (IsTotalPrint)
                {
                    sql = "EXEC [dbo].[UPDATE_All_DATABY_ID] @EAN=@EAN";
                    cmd.Parameters.AddWithValue("@EAN", ean);
                }
                else if (IsSinglePrint)
                {
                    sql = "EXEC [dbo].[UPDATEDATAByID] @EAN=@EAN,@MaxCount=@MaxCount";
                    cmd.Parameters.AddWithValue("@EAN", ean);
                    cmd.Parameters.AddWithValue("@MaxCount", 1);
                }
                else if(!IsTotalPrint && !IsSinglePrint && txtPrintLimit.Text.Length>0)
                {
                    PrintLimit = Convert.ToInt32(txtPrintLimit.Text);
                    sql = "EXEC [dbo].[UPDATEDATAByID] @EAN=@EAN,@MaxCount=@MaxCount";
                    cmd.Parameters.AddWithValue("@EAN", ean);
                    cmd.Parameters.AddWithValue("@MaxCount", PrintLimit);
                }
                cmd.CommandText = sql;
                filterTableData= DBOperations.ExecuteStoreProcedure(cmd);
              
            }
            catch(Exception exe)
            {
                
            }
            return filterTableData;
        }

        private void barcodeText_TextChanged(object sender, EventArgs e)
        {
            if (this.barcodeText.Text == ""|| this.txtPallet.Text == "" || this.txtBox.Text == "")
            {
               // clearLabels();
                return;
            }
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var text = this.barcodeText.Text;                  
                   if (checkBarcodeTextLength(text))
                    {
                        getTableCountWithEAN(text);
                        DataTable dt = new DataTable();
                        string sql = "select * from [data]";
                        sql += " where EAN=@EAN and STATUS=0";
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@EAN", text);
                        dt = DBOperations.GetTable(cmd);
                        filterTableData = dt;

                        if (filterTableData != null && filterTableData.Rows.Count > 0)
                        {
                            //** The printing function Only hapend, when the DataGridView length>0
                            
                            this.lblItemName.Text = dt.Rows[0]["ItemName"].ToString();
                            this.lblCompositionRawMaterialsTop.Text = dt.Rows[0]["CORMT"].ToString();
                            this.lblCountryOG.Text = dt.Rows[0]["CountryOfOrigin"].ToString();
                            this.lblCodeColors.Text = dt.Rows[0]["CodeColors"].ToString();
                            this.lblEANVAlue.Text = dt.Rows[0]["EAN"].ToString();
                            this.lblCompositionRawMaterialsLine.Text = dt.Rows[0]["CORML"].ToString();
                            this.lblManufacturer.Text = dt.Rows[0]["Manufacturer"].ToString();
                            this.lblTrademark.Text = dt.Rows[0]["Trademark"].ToString();
                            this.lblTotalCount.Text = dt.Rows.Count.ToString();

                            this.lbl2Age.Text = dt.Rows[0]["SizeAge"].ToString();
                            this.lbl2DateOM.Text = dt.Rows[0]["MFGDate"].ToString();
                            this.lbl2Gender.Text = dt.Rows[0]["MFCSM"].ToString();
                            this.lbl2ImporterName.Text = dt.Rows[0]["ExporterAddress"].ToString();
                            this.lbl2ManufactureName.Text = dt.Rows[0]["ManufacturerAddress"].ToString();
                            this.lbl2DataMatrix.Text = dt.Rows[0]["DataMatrix"].ToString();
                            this.lbl2RSize.Text = dt.Rows[0]["RussianSize"].ToString();
                            this.lbl2TNVEDcode.Text = dt.Rows[0]["TNVED_code"].ToString();
                            this.lbl2Quantity.Text = dt.Rows[0]["Quantity"].ToString();
                            this.lbl2uit.Text = dt.Rows[0]["UIT"].ToString();
                            this.lbl2Article.Text = dt.Rows[0]["Article"].ToString();
                            this.lblId.Text = dt.Rows[0]["ID"].ToString();

                            if (IsTotalPrint || IsSinglePrint)
                            {
                                startBarcodePrintingFunction();
                            //   barcodeText.Text = "";
                                
                            }
                            scope.Complete();
                            return;
                        }
                        else
                        {
                            //** The printing function Only hapend, when the DataGridView length>0
                            clearLabels();
                            
                        }

                    }
                    else if(barcodeText.Text.Length>14)
                    {
                        MessageBox.Show("Error, Please enter 12 digit value and select 12 digit check box   , if 13 digit value then select 13 digit check box ");
                        clearLabels();
                    }
                    else
                    {
                       // clearLabels();
                    }


                }
                catch (Exception ex)
                {
                    if (scope != null)
                    {
                        scope.Dispose();
                        MessageBox.Show("Error, " + ex.Message);
                    }

                }
                finally
                {
                    if (scope != null)
                    {
                        scope.Dispose();

                    }
                }


            }
        }
        private void takeDataCount()
        {
            DataTable dt = new DataTable();
            string sql = "select top 1 " +
                "(select COUNT(ID) from Data where STATUS=1)as Printed," +
                "(select COUNT(ID) from Data where STATUS=0)as NonPrinted " +
                "from [Data] ";   
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            dt = DBOperations.GetTable(cmd);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.lblTotalPrinted.Text = dt.Rows[0]["Printed"].ToString();
                this.lblTotalNonPrintCount.Text = dt.Rows[0]["NonPrinted"].ToString();
            }
        }
        private void startBarcodePrintingFunction()
        {
            var text = this.barcodeText.Text; // **** Restof the validation will check inside the UpdatePrintTable
            UpdatePrintTable(text);           //**** when we Update The Print Table,We got the Filterd Data in filterTableData
            if (filterTableData.Rows.Count > 0) //**** this loop only excecute when the filterTableData count>0
            {
                foreach (DataRow row in filterTableData.Rows)
                {
                    ZplPrint(row);
                  
                }
                getTableCountWithEAN(text);

                //ProcessStartInfo prg = new ProcessStartInfo();
                //string path = AppDomain.CurrentDomain.BaseDirectory;
                //prg.FileName = path + "test.bat";
                //prg.WindowStyle = ProcessWindowStyle.Hidden;
                //Process MyProcess = Process.Start(prg);
                //*********************

                //updatePrintStatusByEAN(text);



            }
        }
        private void ZplPrint(DataRow dr)
        {
            try
            {
                var text = this.barcodeText.Text; // **** Restof the validation will check inside the UpdatePrintTable
                int id = Convert.ToInt32(dr["id"]);
                string Quantity = (dr["Quantity"]).ToString();
                string DataMatrix = (dr["DataMatrix"]).ToString();
                string CodeColors = (dr["CodeColors"]).ToString();
                string MFCSM = (dr["MFCSM"]).ToString();
                string Brand = (dr["Trademark"]).ToString();
                string Article = (dr["Article"]).ToString();
                string RSize = (dr["RussianSize"]).ToString();
                string UIT = (dr["UIT"]).ToString();
                string ItemName = (dr["ItemName"]).ToString();
                string Manufacture = (dr["Manufacturer"]).ToString();
                string Manufacture1 = (dr["Manufacturer"]).ToString();
                string ManufacturerAddressstr = (dr["ManufacturerAddress"]).ToString();
                string mnfAddress = ManufacturerAddressstr.Replace("\"", "");
                string ManufacturerAddress = mnfAddress;
                string CORMT = (dr["CORMT"]).ToString();

                string CountryOfOrigin = (dr["CountryOfOrigin"]).ToString();
                string MFGDate = (dr["MFGDate"]).ToString();
                MFGDate = DateTime.Now.ToShortDateString();
                string ExporterAddressstr = (dr["ExporterAddress"]).ToString();
                string expAddress = ExporterAddressstr.Replace("\"", "");
                string ExporterAddress = expAddress;


                string zplCode = "^XA" +
                    "^CI28" +
                 "^FO850,30 ^AR,20,30 ^FB500,1,10,L ^FDКоличество; ^FS " +
                "^FO845,200 ^A0R,35,30  ^FB500,1,10,L^FD<Quantity> ^FS " +
                "^FO619,365 ^FWB ^BY5 ^BXB,5,200,40,40,5,_ ^FH ^FH ^FD<DataMatrix> ^FNC1 ^FS" +
                "^FO850,340 ^A0R,15,30 ^FB500,1,10,L ^FDКОД Цвета; ^FS" +
                "^FO850,490 ^A0R,20,30 ^FD<CodeColors> ^FS" +
                "^FO825, 30 ^A0R,20,30 ^FB500,1,10,L ^FDК( муж./жен./дет.( мал.,дев.):^FS" +
                "^FO780, 180 ^A0R,30,40 ^FB500,1,10,L ^FD<MFCSM> ^FS " +

                "^FO790, 30 ^A0R,20,30 ^FB500,1,10,L^FDТорговая марка; ^FS " +
                "^FO745, 100 ^A0R,30,40 ^FB500,1,10,L^FD<Brand> ^FS " +
                "^FO710, 30 ^A0R,20,30 ^FB500,1,10,L^FDАртикул: ^FS" +
                "^FO670, 100 ^A0R,30,40 ^FB500,1,10,L^FD<Article> ^FS" +


                "^FO630, 30 ^A0R, 20, 30 ^FB500,1,10,L^FDРоссийский размер: ^FS " +
                "^FO620, 285 ^A0R, 40,40 ^FB500,1,10,L^FD<RSize> ^FS" +
                "^FO520, 30 ^A0R, 15,25 ^FB530,4,8,R^FD<DataMatrix> ^FS" +
                "^FO505, 30 ^A0R, 20, 35 ^FDНаименование ^FS " +
                "^FO480, 30 ^A0R, 20, 35 ^FDноменклатуры; ^FS " +
                "^FO445, 60 ^A0R, 30, 35^FD<ItemName> ^FS" +
                "^FO420, 30 ^A0R, 20, 30^FDПроизводитель: - ^FS" +
                "^FO390, 140 ^A0R, 25, 30^FD<Manufacture> ^FS" +
                 "^FO410,450^GFA,1320,1320,12, ,:::G3gGFH0G3gGFG8G0G3gGFH0G3gGFG8G0:::::::G3HFM0HFGCL0G1HFG8G0G3GFGEM0HFGCL0G1HFG8G0:::::::G3HFM0HFGCL0G1HFG8G0G3GFGEM0HFGCL0G1HFG8G0,::::::::::G1g0G1H0G3gGFG8G0:G3gGFH0G3gGFG8G0:::::::P0HFGCL0G1HFG2G0:P0HFGCL0G1HFG8G0::::::::G3gGFG8G0:::::::::G3gGFH0,::::::::::G3gGFH0G3gGFG8G0G3gGFH0G3gGFG8G0:::::::G3HFV0G1HFG8G0G3GFGEV0G1HFG8G0::::::G3GFGEV0G1HFH0G3HFV0G1HFG8G0:,:::::^FS " +
                 "^FO365, 30 ^A0R, 20,25 ^FDИмпортер( имя и адрес ) - ^FS" +
                 "^FO320,50 ^A0R, 20, 25 ^FB500,2,0,C ^FD<ExporterAddress> ^FS" +
                "^FO295, 30 ^A0R, 20, 35 ^FDСостав сырья( верх ); - ^FS" +
                "^FO270, 50 ^A0R, 20, 25^FB550,1,0,C^FD<CORMT> ^FS" +
                "^FO245,30 ^A0R, 20, 25 ^FDСтрана происхождения: - ^FS" +
                "^FO240, 350 ^A0R, 25, 35 ^FD<CountryOfOrigin> ^FS" +
                "^FO210, 30 ^A0R, 20, 25 ^FDДата производства: - ^FS" +
                "^FO205, 330 ^A0R, 25, 35 ^FD<MFGDate> ^FS" +
                "^FO175, 30 ^A0R, 20, 25  ^FDПроизводитель( имя и адрес ): - ^FS" +
                "^FO115, 40 ^A0R, 20, 25 ^FB550,2,5,C ^FD<ManufacturerAddress> ^FS" +
                // "^FO45, 75 ^BY5 .4 ^BER, 40, Y, N ^FD<EAN> ^FS " +
                "^FO30, 115 ^BY4 ^BER,80 ^FD<EAN> ^FS" +

                    "^XZ";

                zplCode = zplCode.Replace("<Quantity>", Quantity);
                zplCode = zplCode.Replace("<DataMatrix>", DataMatrix);
                zplCode = zplCode.Replace("<CodeColors>", CodeColors);
                zplCode = zplCode.Replace("<MFCSM>", MFCSM);
                zplCode = zplCode.Replace("<Brand>", Brand);
                zplCode = zplCode.Replace("<Article>", Article);
                zplCode = zplCode.Replace("<RSize>", RSize);
                zplCode = zplCode.Replace("<UIT>", UIT);
                zplCode = zplCode.Replace("<ItemName>", ItemName);
                zplCode = zplCode.Replace("<Manufacture>", Manufacture);
                zplCode = zplCode.Replace("<Manufacture1>", Manufacture1);
                zplCode = zplCode.Replace("<ManufacturerAddress>", ManufacturerAddress);
                zplCode = zplCode.Replace("<CORMT>", CORMT);
                zplCode = zplCode.Replace("<CountryOfOrigin>", CountryOfOrigin);
                zplCode = zplCode.Replace("<MFGDate>", MFGDate);
                zplCode = zplCode.Replace("<ExporterAddress>", ExporterAddress);
                zplCode = zplCode.Replace("<EAN>", text);



                byte[] rawData = Encoding.UTF8.GetBytes(zplCode);

                PrintDialog printDialog = new PrintDialog();
                if (RawPrinterHelper.SendRawDataToPrinter2("ZDesigner ZD621-300dpi ZPL", rawData))
                {
                    int Id = Convert.ToInt32(dr["DataTableID"]);
                    updatePrintStatusById(Id);  //** After the Printing Update Main table will Update by ID                                           
                    barcodeText.Text = "";
                    takeDataCount();
                    barcodeText.Text = "";
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void getTableCountWithEAN(string EAN)
        {
            DataTable dt = new DataTable();
            string sql = "select COUNT(EAN) as NotPrinted," +
                "(select COUNT(EAN)from Data where EAN =@EAN and STATUS = 1) as Printed," +
                "(select COUNT(EAN)from Data where EAN = @EAN ) as Total " +
                "from Data where EAN =@EAN and STATUS = 0  ";    
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@EAN", EAN);
            dt = DBOperations.GetTable(cmd);
            lblPrintedCount.Text = dt.Rows[0]["Printed"].ToString();
            lblRemainingCount.Text = dt.Rows[0]["NotPrinted"].ToString();
            lblTotalPrintCount.Text = dt.Rows[0]["total"].ToString();
            return;
        }
        private bool checkBarcodeTextLength(string text)
        {
            if (chk12.Checked == true)
            {
                if (text.Length == 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(chk14.Checked == true)
            {
             if (text.Length >= 13)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private int updatePrintStatusByEAN(string EAN)
        {
            //for updating the status=1 in Dtata-Table
            string MachineName = Environment.MachineName;
            int xyz = 0;
            string sql = "UPDATE [Data] SET STATUS= 1,ModifiedDatetime=@ModifiedDatetime,ModifiedBy=@ModifiedBy  where EAN =@EAN and STATUS=0 ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@EAN", EAN);
            cmd.Parameters.AddWithValue("@ModifiedDatetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", MachineName);
            xyz = DBOperations.ExecuteNonQuery(cmd);
            if (xyz != 0)
            {
                //MessageBox.Show("succesfulyy printed No " + counter.ToString());
            }
            getTableCountWithEAN(EAN);
            return xyz;
        }
        private int updatePrintStatusById(int id)
        {
            //for updating the status=1 in Dtata-Table
            string MachineName = Environment.MachineName;
            int xyz = 0;
            string sql = "UPDATE [Data] SET STATUS= 1,ModifiedDatetime=@ModifiedDatetime,ModifiedBy=@ModifiedBy," +
                "PRINTDATETIME=@nowDateTime,PalletNo=@PalletNo,BoxNo=@BoxNo where ID =@id and STATUS=0 ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ModifiedDatetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", MachineName);
            cmd.Parameters.AddWithValue("@nowDateTime", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@PalletNo", txtPallet.Text);
            cmd.Parameters.AddWithValue("@BoxNo", txtBox.Text);
            xyz = DBOperations.ExecuteNonQuery(cmd);
            if (xyz != 0)
            {

            }
            return xyz;
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void barcodeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            //For fetching the filterd data from Data-Table
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                    if (!IsTotalPrint && txtPrintLimit.Text.Length>0)
                {
                    int printLimit = Convert.ToInt32(txtPrintLimit.Text);
                    int RemainingCount = Convert.ToInt32(lblRemainingCount.Text);
                    if (printLimit > RemainingCount)
                    {
                        MessageBox.Show("Error,  Print Limit must be less then Remaining Count");
                        txtPrintLimit.Text = null;
                        return;
                    }
                }
                startBarcodePrintingFunction();            
            }catch(Exception exe)
            {

            }

        }

        private void chk12_CheckedChanged(object sender, EventArgs e)
        {
            if(chk12.Checked == true)
            {
                chk14.Checked = false;
                chk12.Checked = true;
                barcodeText.Text = null;
            }

        }

        private void chk14_CheckedChanged(object sender, EventArgs e)
        {
            if (chk14.Checked == true)
            {
                chk12.Checked = false;
                chk14.Checked = true;
                barcodeText.Text = null;

            }

        }

        private void main_Load(object sender, EventArgs e)
        {
            barcodeText.Focus();
            chkSinglePrint.Checked = true;
            takeDataCount();
        }
        private void txtPrintLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void chkSpecificValue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecificValue.Checked == true)
            {
                chkTotalPrint.Checked = false;
                chkSinglePrint.Checked = false;
                txtPrintLimit.Visible = true;
                button1.Visible = true;
                IsTotalPrint = false;
                IsSinglePrint = false;
                barcodeText.Focus();
            }
            else if(chkSpecificValue.Checked ==false && chkSinglePrint.Checked == false)
            {
                chkTotalPrint.Checked = true;
                txtPrintLimit.Visible = false;
                button1.Visible = false;
                IsTotalPrint = true;
            }
        }

        private void chkTotalPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTotalPrint.Checked == true)
            {
                chkSpecificValue.Checked = false;   
                chkSinglePrint.Checked = false;
                txtPrintLimit.Visible = false;
                txtPrintLimit.Text = null;
                IsTotalPrint = true;
                IsSinglePrint = false;
                barcodeText.Focus();
                var text = this.barcodeText.Text;
                if (checkBarcodeTextLength(text))
                {
                    startBarcodePrintingFunction();
                }

            }
            else
            {
                IsTotalPrint = false;
            }
        }
         private void chkSinglePrint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinglePrint.Checked == true)
            {
                IsSinglePrint = true;
                chkSinglePrint.Checked = true;
                chkSpecificValue.Checked = false;
                chkTotalPrint.Checked = false;
                txtPrintLimit.Visible = false;
                txtPrintLimit.Text = null;
                button1.Visible = false;
                IsTotalPrint = false;
                barcodeText.Focus();
            }
            else if(chkSinglePrint.Checked == false && chkSpecificValue.Checked == false)
            {
                chkTotalPrint.Checked = true;
                IsTotalPrint = true;
            }
        }
        private void clearLabels()
        {
            this.lblItemName.Text = "";
            this.lblCompositionRawMaterialsTop.Text ="";
            this.lblCountryOG.Text ="";
            this.lblCodeColors.Text = "";
            this.lblEANVAlue.Text = "";
            this.lblCompositionRawMaterialsLine.Text= "";
            this.lblManufacturer.Text = "";
            this.lblTrademark.Text = "";
            this.lblTotalCount.Text = "";

            this.lbl2Age.Text = "";
            this.lbl2DateOM.Text = "";
            this.lbl2Gender.Text = "";
            this.lbl2ImporterName.Text = "";
            this.lbl2ManufactureName.Text= "";
            this.lbl2DataMatrix.Text = "";
            this.lbl2RSize.Text = "";
            this.lbl2TNVEDcode.Text = "";
            this.lbl2Quantity.Text = "";
            this.lbl2uit.Text = "";
            this.lbl2Article.Text = "";
            this.lblId.Text = "";
        }

        private void txtPrintLimit_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lblTotalPrintCount_Click(object sender, EventArgs e)
        {

        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            RePrint frm = new RePrint();
            frm.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
