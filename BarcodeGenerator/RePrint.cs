using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace BarcodeGenerator
{
    public partial class RePrint : Form
    {
        public RePrint()
        {
            InitializeComponent();
        }
        private DataTable filterTableData = new DataTable();
        private void RePrint_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                UpdatePrintTable(txtId.Text);
            }
        }
        private void UpdatePrintTable(string ean)
        {
            string sql = "";
            SqlCommand cmd = new SqlCommand();
            sql = "EXEC [dbo].[REPRINTUPDATE] @Id=@id";
            cmd.Parameters.AddWithValue("@Id", txtId.Text);
            
            cmd.CommandText = sql;
            filterTableData = DBOperations.ExecuteStoreProcedure(cmd);
            if (filterTableData.Rows.Count > 0)
            {
                foreach (DataRow row in filterTableData.Rows)
                {
                    printFunction(row);

                }
               
            }
        }
        private void printFunction(DataRow dr)
        {
            try
            {
                var text = this.lblEAN.Text; // **** Restof the validation will check inside the UpdatePrintTable
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
                 "^FO850,30 ^A0R,20,30 ^FB500,1,10,L ^FDКоличество; ^FS " +
                "^FO845,200 ^A0R,35,30  ^FB500,1,10,L^FD<Quantity> ^FS " +
                "^FO619,365 ^FWB ^BY5 ^BXB,5,200,40,40,5,+ ^FH ^FH ^FD<DataMatrix> ^FS" +
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
               if( RawPrinterHelper.SendRawDataToPrinter2("ZDesigner ZD621-300dpi ZPL", rawData))
                {
                    updatePrintStatusById();
                }
               
            }
            catch (Exception ex)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if (id.Length > 0)
            {
                DataTable dt = new DataTable();
                string sql = "select * from Data";
                sql += " where status=1 and ID=@id ";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dt = DBOperations.GetTable(cmd);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.lblColorCode.Text = dt.Rows[0]["CodeColors"].ToString();
                    this.lblEAN.Text = dt.Rows[0]["EAN"].ToString();
                    this.lblArticle.Text = dt.Rows[0]["Article"].ToString();
                    this.lblDataMatrix.Text= dt.Rows[0]["DataMatrix"].ToString();
                    btnPrint.Enabled = true;
                }

            }
        }
        private int updatePrintStatusById()
        {          
            
            int xyz = 0;
            string sql = "UPDATE [Data] SET " +
                "PRINTDATETIME=@nowDateTime,PalletNo=@PalletNo,BoxNo=@BoxNo where ID =@id ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", txtId.Text);    
            cmd.Parameters.AddWithValue("@nowDateTime", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@PalletNo", txtPallet.Text);
            cmd.Parameters.AddWithValue("@BoxNo", txtBox.Text);
            xyz = DBOperations.ExecuteNonQuery(cmd);
            if (xyz != 0)
            {

            }
            return xyz;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {






        }
    }
}
