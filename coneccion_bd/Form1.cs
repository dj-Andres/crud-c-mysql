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
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using System.IO;

namespace coneccion_bd
{
    public partial class Form1 : Form
    {
        OdbcConnection cnn;
        private Boolean editar = false;
        //public delegate void enviar(string nombre_curso);
        //public event enviar enviado;
        public Form1()
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

            OdbcDataAdapter da = new OdbcDataAdapter("select alumno.id_alumno,alumno.cedula,alumno.apellido,alumno.nombre,alumno.estado,alumno.fecha,curso.id_curso,curso.paralelo,curso.jornada from alumno join curso on curso.id_curso=alumno.id_curso where alumno.estado=1 order by id_alumno asc", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();
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
        
            //cadena("insert into alumno(id_curso,cedula, apellido, nombre, fecha, estado)values('"+ txtidcurso.Text+"','" + txtcedula.Text + "','" + txtapellido.Text.ToUpper() + "','" + txtnombre.Text.ToUpper() + "', '" + dateTimePicker1.Text + "' ,'1')");
            //MessageBox.Show("Datos ingresados");
            //limpiar();

            cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=p;port=3306");
            cnn.Open();
            string query;
            query = "select * from alumno where estado=1 and cedula='" + txtcedula.Text + "'";
            OdbcCommand cmd = new OdbcCommand(query, cnn);
            cmd.ExecuteScalar();
            //cnn.Close();
            int n;
            n=Convert.ToInt16(cmd.ExecuteScalar());
            cnn.Close();
            if (n > 0)
            {
                MessageBox.Show("El alumno ya esta ingresado");
            }
            else
            {
                cadena("insert into alumno(id_curso,cedula, apellido, nombre, fecha, estado)values('" + txtidcurso.Text + "','" + txtcedula.Text + "','" + txtapellido.Text.ToUpper() + "','" + txtnombre.Text.ToUpper() + "', '" + dateTimePicker1.Text + "' ,'1')");
                MessageBox.Show("Datos ingresados");
                limpiar();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcedula.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtapellido.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtnombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            txtidcurso.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            txtdetalle.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString() + " " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();

            

            //enviado(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            //this.Close();
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar_tabla();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            cadena("delete from alumno where cedula= '" + txtcedula.Text + "'");
            MessageBox.Show("Datos eliminados");
            limpiar();

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            cadena("update alumno set  cedula = '" + txtcedula.Text + "', apellido='" + txtapellido.Text.ToUpper() + "', nombre= '" + txtnombre.Text.ToUpper() +"',fecha='"+ dateTimePicker1.Text+"'  where id_alumno='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'");
            //cadena("update curso set  paralelo='" + txtdetalle.Text + "',jornada='" + txtdetalle.Text + "' where id_curso='" + txtidcurso.Text + "'");
            MessageBox.Show("Datos actualizados");
            limpiar();
        }

        private void btnlogico_Click(object sender, EventArgs e)
        {
            cadena("update alumno set estado='0' where cedula='"+dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()+"'");
            MessageBox.Show("Datos Eliminados");
            cargar_tabla();
            limpiar();
        }
        private void limpiar()
        {
            txtcedula.Text = "";
            txtapellido.Text = "";
            txtnombre.Text = "";
            dateTimePicker1.Text = "";
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conexion();
            OdbcDataAdapter da = new OdbcDataAdapter("select cedula, apellido, nombre, estado, fecha from alumno where estado=1", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            ds.DefaultView.RowFilter = "cedula like '" + textBox1.Text + "%' or nombre like '" + textBox1.Text + "%'";
            dataGridView1.DataSource = ds;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;


                txtcedula.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();
                txtapellido.Text  = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha"].Value.ToString();
                
            }
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

        private void validar()
        {
            conexion();
            string sql;
            sql = "select * from alumno where estado=1 and cedula='" + txtcedula.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cmd.ExecuteScalar();
            int n;
            n=Convert.ToInt16(cmd.ExecuteScalar());
            
            if (n > 0)
            {
             MessageBox.Show("El alumno ya esta ingresado");
            }
            cnn.Close();
        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if( rdcedula.Checked==true)
            {
                buscame(" select alumno.id_alumno,alumno.cedula,alumno.apellido,alumno.nombre,alumno.estado,alumno.fecha,curso.id_curso,curso.paralelo,curso.jornada from alumno join curso on curso.id_curso=alumno.id_curso where cedula like'" + txtbuscar.Text + "%'");
            }
            
            if(rdcurso.Checked==true)
            {
                buscame("select alumno.id_alumno,alumno.cedula,alumno.apellido,alumno.nombre,alumno.estado,alumno.fecha,curso.id_curso,curso.paralelo,curso.jornada from alumno join curso on curso.id_curso=alumno.id_curso where apellido like'" + txtbuscar.Text + "%'");
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            conexion();

            OdbcDataAdapter da = new OdbcDataAdapter("select cedula, apellido, nombre, estado, fecha from alumno where cedula='"+txtcedula.Text+"' ", cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            cnn.Close();

            txtcedula.Text = Convert.ToString(ds.Rows[0][0]);
            txtapellido.Text = Convert.ToString(ds.Rows[0][1]);
            txtnombre.Text = Convert.ToString(ds.Rows[0][2]);
            dateTimePicker1.Text = Convert.ToString(ds.Rows[0][4]);
            
        }
        private void visualizar(string nombre_curso,string detalle)
        {
           
            txtidcurso.Text = nombre_curso;
            txtdetalle.Text = detalle;

        }
        private void btnver_Click(object sender, EventArgs e)
        {
            //Parallel llamar as otros formularios
           Form2 bc = new Form2();
           bc.Show();
           bc.enviado += new Form2.enviar(visualizar);
        }

        private void btnreporte_Click(object sender, EventArgs e)
        {
            Form3 reporte = new Form3();
            reporte.Show();
        }

        private void btnreporteCURSO_Click(object sender, EventArgs e)
        {
            Form4 reporte = new Form4();
            reporte.Show();
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        

        


        }
    }

