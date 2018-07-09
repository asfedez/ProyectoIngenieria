using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void nuevoUsusarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmUsuarios = new frmUsuarios();
            frmUsuarios.ShowDialog();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoles frmRoles = new frmRoles();
            frmRoles.ShowDialog();
        }

        private void cobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturaCobro frmFacturaCobro = new frmFacturaCobro();
            frmFacturaCobro.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturaIngreso frmFacturaIngreso = new frmFacturaIngreso();
            frmFacturaIngreso.ShowDialog();
        }

        private void permisosDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rolesAUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignarRolAUsuario frmAsignarRolAUsuario = new frmAsignarRolAUsuario();
            frmAsignarRolAUsuario.ShowDialog();
        }
    }
}
