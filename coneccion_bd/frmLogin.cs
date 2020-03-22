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
    public partial class frmLogin : Form
    {
        OdbcConnection cnn;
        private void conexion()
        {
            cnn = new OdbcConnection("Driver={MySQL ODBC 5.2w Driver};server=localhost;uid=root;password=1234;database=persona;port=3306");
            cnn.Open();
        }

        public void logear()
        {
            try
            {
                conexion();
                OdbcCommand cmd = new OdbcCommand("Select usuario,tipo from login where usuario='"+txtusuario.Text+"' and password='"+txtclave.Text+"'",cnn);
                //cmd.Parameters.AddWithValue("usuario",usuario);
                //cmd.Parameters.AddWithValue("clave", clave);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count ==1 )
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString()=="admin")
                    {
                        new frmAdmin(dt.Rows[0][0].ToString()).Show();
                    }
                    else if (dt.Rows[0][1].ToString() == "usuario")
                    {
                        new frmUsuario(dt.Rows[0][0].ToString()).Show();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no se encuentra registrado");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally{
                cnn.Close();
            }
        }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //logear(this.txtusuario.Text, this.txtclave.Text);
            logear();
        }
    }
}
