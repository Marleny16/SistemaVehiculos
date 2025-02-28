using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmVehiculos : Form
    {
        CD_Vehiculos cD_Vehiculos = new CD_Vehiculos();

        public FrmVehiculos()
        {
            InitializeComponent();
        }

        public void MtdMostrarVehiculos()
        {
            CD_Vehiculos cd_vehiculos = new CD_Vehiculos();
            DataTable dtMostrarVehiculos = cd_vehiculos.MtdMostrarVehiculos();
            dgvVehiculos.DataSource = dtMostrarVehiculos;
        }


        /*private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            MtdMostrarVehiculos();
        }¨*/

        

        private void gboxClientes_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Vehiculos.MtdAgregarVehiculos(txtMarca.Text, txtModelo.Text, txtAño.Text, txtPrecio.Text, cboxEstado.Text);
                MessageBox.Show("El vehiculo se agregó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                cD_Vehiculos.MtdEliminarVehiculos(int.Parse(txtVehiculoID.Text));
                MessageBox.Show("El vehiculo se eliminó con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*CD_Vehiculos cD_Vehiculos = new CD_Vehiculos();

            int VehiculoID = int.Parse(txtVehiculoID.Text);
            int vCantidadRegistros = cD_Vehiculos.MtdEliminarVehiculos(VehiculoID);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            MtdMostrarVehiculos();*/


        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVehiculoID.Text = dgvVehiculos.SelectedCells[0].Value.ToString();
            txtMarca.Text = dgvVehiculos.SelectedCells[1].Value.ToString();
            txtModelo.Text = dgvVehiculos.SelectedCells[2].Value.ToString();
            txtAño.Text = dgvVehiculos.SelectedCells[3].Value.ToString();
            txtPrecio.Text = dgvVehiculos.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvVehiculos.SelectedCells[5].Value.ToString();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                cD_Vehiculos.MtdActualizarVehiculos(int.Parse(txtVehiculoID.Text), txtMarca.Text, txtModelo.Text, txtAño.Text, txtPrecio.Text, cboxEstado.Text);
                MessageBox.Show("El vehiculo se actualizo con éxtio", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmVehiculos_Load_1(object sender, EventArgs e)
        {
            MtdMostrarVehiculos();
        }

        public void MtdLimpiarVehiculos()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtVehiculoID.Text = "";
            txtAño.Text = "";
            txtPrecio.Text = "";
            cboxEstado.Text = "";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarVehiculos();
        }
    }
}
