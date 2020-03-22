using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coneccion_bd
{
    public partial class frmAdmin : Form
    {
        public frmAdmin(string nombre)
        {
            InitializeComponent();
            lblmensaje.Text = "Bienvenido "+ nombre;
        }
    }
}
