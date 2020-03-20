using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace coneccion_bd
{
    public partial class Form4 : Form
    {
        OdbcConnection cnn;
        public Form4()
        {
            InitializeComponent();
        }
        private void conexion()
        {
            cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=persona;port=3306");
            cnn.Open(); //abrimos nuestra coneccion
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            conexion();

            OdbcDataAdapter da = new OdbcDataAdapter("select * from curso", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);

            CrystalReport2 mi_reporte = new CrystalReport2();

            mi_reporte.SetDataSource(ds);
            crystalReportViewer1.ReportSource = mi_reporte;
        }
    }
}
