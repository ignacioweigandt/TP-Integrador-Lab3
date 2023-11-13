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

namespace TP_Integrador_Lab3
{
    public partial class FrmVistaEmpleados : Form
    {
        public FrmVistaEmpleados()
        {
            InitializeComponent();
            
        }

        private void FrmVistaEmpleados_Load(object sender, EventArgs e)
        {
            clsEmpleo empleo = new clsEmpleo();

            empleo.CargarEmpleados(treeView1);
        }

    }
}
