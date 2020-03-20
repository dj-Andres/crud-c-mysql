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
    public partial class Form7 : Form
    {
        OdbcConnection cnn;
        public delegate void enviar(string nombre_alumno, string detalle);
        public event enviar enviado;
        public Form7()
        {
            InitializeComponent();
        }
        private void conexion()
        {
            cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=persona;port=3306");
            cnn.Open(); //abrimos nuestra coneccion
        }
        private void cargar_tabla()
        {

            conexion();

            OdbcDataAdapter da = new OdbcDataAdapter("select id_alumno,cedula,apellido,nombre from alumno where estado=1 ", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            cargar_tabla();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enviado(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString() + " " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString() + " " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscame(" select id_alumno,cedula,apellido,nombre fecha from alumno where cedula like'" + textBox1.Text + "%' or apellido like '" + textBox1.Text + "%' or nombre like '" + textBox1.Text + "%'");
        }

        private void buscame(string sql)
        {
            conexion();

            OdbcDataAdapter da = new OdbcDataAdapter(sql, cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
    }
}
