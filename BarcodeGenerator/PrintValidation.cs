using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeGenerator
{
    public partial class PrintValidation : Form
    {
        public PrintValidation()
        {
            InitializeComponent();
        }
       

        private void ValidationButton_Click(object sender, EventArgs e)
        {
            string varification = this.textBox1.Text;
            if(varification == "12345")
            {
                this.Hide();
                PrintReport frm = new PrintReport();
                frm.MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width, frm.MinimumSize.Height);
                frm.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
