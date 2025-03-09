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

        public void MtdMostrarEmpleado()
        {
            CD_Empleados cd_empleado = new CD_Empleados();
            DataTable dtMostrarEstudiantes = cd_empleado.MtdMostrarEmpleados();
            dgvEmpleados.DataSource = dtMostrarEstudiantes;
        }




        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            MtdMostrarEmpleado();
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVehiculoId.Text = dgvEmpleados.SelectedCells[0].Value.ToString();
            txtMarca.Text = dgvEmpleados.SelectedCells[1].Value.ToString();
            txtApellido.Text = dgvEmpleados.SelectedCells[2].Value.ToString();
            txtFechaNacimiento.Text = dgvEmpleados.SelectedCells[3].Value.ToString();
            txtFechaContratacion.Text = dgvEmpleados.SelectedCells[4].Value.ToString();
            txtDepartamentoId.Text = dgvEmpleados.SelectedCells[5].Value.ToString();
            txtPuestoTrabajo.Text = dgvEmpleados.SelectedCells[6].Value.ToString();
            txtSalario.Text = dgvEmpleados.SelectedCells[7].Value.ToString();
            cboxEstado.Text = dgvEmpleados.SelectedCells[8].Value.ToString();
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
            txtFechaNacimiento.Clear();
            txtFechaContratacion.Clear();
            txtDepartamentoId.Clear();
            txtPuestoTrabajo.Clear();
            txtSalario.Clear();
            cboxEstado.Text="";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Empleados cd_empleado = new CD_Empleados();

            try
            {
                cd_empleado.MtdAgregarEmpleados(txtMarca.Text, txtApellido.Text, txtFechaNacimiento.Text, txtFechaContratacion.Text, txtDepartamentoId.Text, txtPuestoTrabajo.Text, txtSalario.Text, cboxEstado.Text);
                MessageBox.Show("El empleado se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MtdMostrarEmpleado();


            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
