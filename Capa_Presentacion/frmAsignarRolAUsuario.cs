using Capa_Logica_Negocio;
using Entidades;
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
    public partial class frmAsignarRolAUsuario : Form
    {
        int numFila = 0;
        usuarios user;

        Cls_RolAsignado rolAsignado = new Cls_RolAsignado();

        public frmAsignarRolAUsuario()
        {
            InitializeComponent();
        }

        private void frmAsignarRolAUsuario_Load(object sender, EventArgs e)
        {
            llenarComboBox();
        }

        public void llenarComboBox()
        {
            cbxRoles.DataSource = new Cls_Rol().ListaRoles();
            cbxRoles.ValueMember = "ID_Rol";
            cbxRoles.DisplayMember = "Nombre";
        }

        private void EstadoIncial()
        {

            txtNomUsuario.Text = "";
            txtContra.Text = "";

            int numFila = dtgRoles.RowCount - 1;
            for (int i = 0; i < numFila; i++)
            {
                dtgRoles.Rows.RemoveAt(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                user = new Cls_Usuario().Consultar(txtNomUsuario.Text);
                txtNomUsuario.Text = user.nombreUsuario;
                txtContra.Text = user.contrasenna;

                if(rolAsignado.ExisteRoles(user.idUsuario))
                {
                    var lista = new Cls_RolAsignado().ListaRoles(user.idUsuario);

                    foreach (rolAsignadoAUsuario rolAsig in lista)
                    {
                        String nombreRol = new Cls_Rol().Consultar(Convert.ToInt32(rolAsig.idRol)).nombre;

                        dtgRoles.Rows.Add(rolAsig.idRol, nombreRol);
                    }

                }
               
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        
        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            numFila = dtgRoles.RowCount - 1;
            bool existe = false;
            for (int i = 0; i < numFila; i++)
            {
                if (Convert.ToInt32(dtgRoles.Rows[i].Cells[0].Value) == Convert.ToInt32(cbxRoles.SelectedValue))
                {
                    existe = true;
                }
                

            }
            if (existe)
            {
                MessageBox.Show("No puede ingresar la misma ventana", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dtgRoles.Rows.Add(cbxRoles.SelectedValue, cbxRoles.Text);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                numFila = dtgRoles.RowCount - 1;
                for (int i = 0; i < numFila; i++)
                {

                    rolAsignadoAUsuario rolAsignado = new rolAsignadoAUsuario
                    {
                        idUsuario = user.idUsuario,
                        idRol = Convert.ToInt32(dtgRoles.Rows[i].Cells[0].Value)

                    };

                    new Cls_RolAsignado().Agregar(rolAsignado);
                    MessageBox.Show("Roles asiganados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EstadoIncial();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            user = new Cls_Usuario().Consultar(txtNomUsuario.Text);
            txtNomUsuario.Text = user.nombreUsuario;
            txtContra.Text = user.contrasenna;

            if (rolAsignado.ExisteRoles(user.idUsuario))
            {
                var lista = new Cls_RolAsignado().ListaRoles(user.idUsuario);

                foreach (rolAsignadoAUsuario rolAsig in lista)
                {
                    String nombreRol = new Cls_Rol().Consultar(Convert.ToInt32(rolAsig.idRol)).nombre;

                    dtgRoles.Rows.Add(rolAsig.idRol, nombreRol);
                }

            }
        }

        private void dtgRoles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cbxRoles.SelectedValue = dtgRoles.Rows[e.RowIndex].Cells[0].Value;
            dtgRoles.Rows.RemoveAt(e.RowIndex);

        }
    }
}
