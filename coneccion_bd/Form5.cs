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
    public partial class Form5 : Form
    {
        OdbcConnection cnn;
        public Form5()
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

            OdbcDataAdapter da = new OdbcDataAdapter("select n.id_nota AS codigo_nota,a.id_alumno as codigo_alumno,a.cedula,a.apellido,a.nombre,n.nota_1,n.nota_2,n.estado from  alumno a join nota n on a.id_alumno=n.id_alumno where n.estado=1 ", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            cargar_tabla();
        }

        private void visualizar(string nombre_alumno,string detalle)
        {

            txtidcurso.Text = nombre_alumno;
            txtdetalle.Text = detalle;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 bc = new Form7();
            bc.Show();
            //bc.enviado += new Form1.enviar(visualizar);
            bc.enviado += new Form7.enviar(visualizar);
        }

        private void cadena(string sql)
        {
            conexion();
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            cargar_tabla();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            int nota1, nota2; 
             double promedio;

            nota1 = Convert.ToInt16(txtNOTA1.Text);
            nota2 = Convert.ToInt16(txtNOTA2.Text);

            promedio = (nota1 + nota2) / 2;

            txtpromedio.Text = Convert.ToString(promedio);

            if (promedio <= 7)
            {
                MessageBox.Show("Promedio Regula" + promedio);
            }

            if (promedio >= 8)
            {
                MessageBox.Show("Promedio Muy Bueno" + promedio);
            }

            if (promedio >= 10)
            {
                MessageBox.Show("Promedio Excelente" + promedio);
            }
            
                       
            cadena("insert into nota(id_alumno,nota_1,nota_2,estado,Promedio)values('"+txtidcurso.Text+"','" +txtNOTA1.Text+ "','"+txtNOTA2.Text+"' ,'1','"+txtpromedio.Text+"')");
            MessageBox.Show("Datos ingresados");
        }

        private void btnBorradoLogico_Click(object sender, EventArgs e)
        {
            cadena("update nota set estado='0' where id_alumno='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString() + "'");
            MessageBox.Show("Datos Eliminados");
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Form6 reporte = new Form6();
            reporte.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double nota1, nota2,promedio ;

            nota1 = Convert.ToDouble(txtNOTA1.Text);
            nota2 = Convert.ToDouble(txtNOTA2.Text);

            promedio = (nota1 + nota2) / 2;

            txtpromedio.Text = Convert.ToString(promedio);

            if (promedio <= 7)
            {
                MessageBox.Show("Promedio Regula" + promedio);
            }

            if (promedio >= 8)
            {
                MessageBox.Show("Promedio Muy Bueno" + promedio);
            }

            if (promedio >= 10)
            {
                MessageBox.Show("Promedio Excelente" + promedio);
            }
        }
    }
}
