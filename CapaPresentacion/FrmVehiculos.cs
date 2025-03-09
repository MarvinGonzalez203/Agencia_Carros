using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVehiculos : Form
    {
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        public void MtdMostrar()
        {

            CD_Vehiculos mostrar = new CD_Vehiculos();
            DataTable dtMostrar = mostrar.MtMostrar();
            dgvEmpleados.DataSource = dtMostrar;
        }




        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            MtdMostrar();
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVehiculoId.Text = dgvEmpleados.SelectedCells[0].Value.ToString();
            txtMarca.Text = dgvEmpleados.SelectedCells[1].Value.ToString();
            txtApellido.Text = dgvEmpleados.SelectedCells[2].Value.ToString();
            txtFechaContratacion.Text = dgvEmpleados.SelectedCells[3].Value.ToString();
            txtSalario.Text = dgvEmpleados.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvEmpleados.SelectedCells[5].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtVehiculoId.Clear();
            txtMarca.Clear();
            txtApellido.Clear();
            txtFechaContratacion.Clear();
            txtSalario.Clear();
            cboxEstado.Text = "";
        }


      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos conn = new CD_Vehiculos();

            try
            {
                conn.MtInsertar(txtMarca.Text,txtApellido.Text, int.Parse(txtFechaContratacion.Text),decimal.Parse(txtSalario.Text),cboxEstado.Text);

                MessageBox.Show("El Vehiculo se agregó con éxito", "Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MtdMostrar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos conn = new CD_Vehiculos();

            try
            {
                conn.MtDelete(
                    int.Parse(txtVehiculoId.Text));

                MessageBox.Show("El Vehiculo se elimino con éxito", "Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MtdMostrar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos conn = new CD_Vehiculos();

            try
            {
                conn.MtUpdate(
                    int.Parse(txtVehiculoId.Text),txtMarca.Text, txtApellido.Text, int.Parse(txtFechaContratacion.Text),decimal.Parse(txtFechaContratacion.Text), cboxEstado.Text);

                MessageBox.Show("El Vehiculo se actualizo con éxito", "Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MtdMostrar();
        }
    }
}
